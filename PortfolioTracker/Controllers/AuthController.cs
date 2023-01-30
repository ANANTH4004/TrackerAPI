using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PortfolioTracker.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace PortfolioTracker.Controllers
{
    public class AuthController : Controller
    {
        private readonly TrackerContext _context;
        private readonly AppSettings _settings;
        public AuthController(IOptions<AppSettings> _settings,TrackerContext context )
        {
            this._settings = _settings.Value;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login model)
        {
            var user = _context.Users.Where(x => x.UserName == model.UserName).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            var match = CheckPassword(model.Password, user);
            if (!match)
            {
                return BadRequest("Password is not match");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserName) }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);
            return Ok(new { token = encryptedToken, userName = user.UserName});
        }

        private bool CheckPassword(string password, User user)
        {
            bool result ;
            using(HMACSHA512 ? hmac = new HMACSHA512(user.PasswordSalt))
            {
                var compute = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                result = compute.SequenceEqual(user.PasswordHash);
            }
            return result;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] Register model)
        {
            var user = new User { UserName = model.UserName };
            if(model.Password == model.ConfirmPassword)
            {
                using (HMACSHA512? hmac = new HMACSHA512())
                {
                    user.PasswordSalt = hmac.Key;
                    user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));
                    user.Email = model.Email;
                    user.MobileNo = model.MobileNo;
                    var port =  new Portfolio()
                    {
                        portfolioName = "My Portfolio", coins = null, portfpolioId = new Guid(), totalBalance = 0, User = user, UserName = user.UserName
                    };
                    user.Portfolios = new List<Portfolio> { port };
                    _context.Users.Add(user);
                    _context.Portfolios.Add(port);
                    _context.SaveChanges();
                }
            }
            else
            {
                return BadRequest("Password not Match");
            }
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string json = JsonConvert.SerializeObject(user, jsonSerializerSettings);


            return Ok(json);

        }
    }
}

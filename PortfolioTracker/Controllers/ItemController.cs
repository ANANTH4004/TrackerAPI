using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioTracker.Controllers
{
    [Authorize]
    [ApiController]
    public class ItemController : Controller
    {
        public List<string> color = new List<string>() { "red", "green", "bule" };
        [HttpGet("getcolor")]
        public List<string> GetColor()
        {
            try
            {
                return color;
            }
            catch (Exception ex)
            {
                throw;
            }
         
        }
    }
}

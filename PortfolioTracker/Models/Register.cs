using System.ComponentModel.DataAnnotations;

namespace PortfolioTracker.Models
{
    public class Register
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
       
    }
}

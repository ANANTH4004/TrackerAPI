using System.ComponentModel.DataAnnotations;

namespace PortfolioTracker.Models
{
    public class User

    { 
        [Key]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
    }
}

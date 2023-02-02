using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioTracker.Models
{
    public class Portfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid portfpolioId { get; set; }
        public string portfolioName { get; set; }
        public decimal totalBalance { get; set; }

        public virtual ICollection<Coin>? coins { get; set; }

        [ForeignKey("User")]
        public string UserName { get; set; }
        public virtual User? User { get; set; }


    }
}

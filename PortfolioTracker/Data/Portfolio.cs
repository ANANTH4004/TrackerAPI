using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioTracker.Data
{
    public class Portfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string PortfolioName { get; set; }
        public decimal TotalBalance { get; set; }

        public virtual ICollection<Coin> Coins { get; set; }
        
    }
}

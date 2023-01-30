using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioTracker.Models
{
    public class Coin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CoinId { get; set; }
        public string CoinName { get; set; }
        public decimal TotalCoins { get; set; }
        public decimal TotalBuyingPrice { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
        [ForeignKey("Portfolio")]
        public Guid? PortfolioId { get; set; }
       
        public virtual Portfolio? Portfolio { get; set; }
    }
}

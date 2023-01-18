using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioTracker.Models
{
    public class Coin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string CoinName { get; set; }
        public decimal TotalCoins { get; set; }
        public decimal TotalBuyingPrice { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public Guid PortfolioId { get; set; }
        [ForeignKey("PortfolioId")]
        public Portfolio Portfolio { get; set; }
    }
}

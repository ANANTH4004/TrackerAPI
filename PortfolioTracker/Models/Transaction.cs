using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioTracker.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string TransactionType { get; set; }
        public decimal PricePerCoin { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal Fees { get; set; }
        public Guid CoinId { get; set; }
        [ForeignKey("CoinId")]
        public Coin Coin { get; set; }
    }
}

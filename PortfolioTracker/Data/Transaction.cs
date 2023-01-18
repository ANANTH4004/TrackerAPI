using System.ComponentModel.DataAnnotations;

namespace PortfolioTracker.Data
{
    public class Transaction
    {
        [Key]
        public string TransactionType { get; set; }
        public decimal PricePerCoin { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal Fees { get; set; }
    }
}

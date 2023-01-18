namespace PortfolioTracker.Data
{
    public class Coin
    {
        public string CoinName { get; set; }
        public decimal TotalCoins { get; set; }
        public decimal TotalBuyingPrice { get; set; }

       public virtual ICollection<Transaction> Transactions { get; set; }
    }
}

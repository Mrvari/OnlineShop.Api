namespace OnlineShop.Api.DTO
{
    public class StockDTO
    {
        public int StockID { get; set; }
        public int Quantity { get; set; }
        public int InTransitQuantity { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}

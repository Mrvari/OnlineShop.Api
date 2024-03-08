namespace OnlineShop.Api.DTO
{
    public class SaveReturnDTO
    {
        public int ReturnID { get; set; }
        public String ReturnReason { get; set; }
        public DateTime ReturnDate { get; set; }
        public int QuantityReturned { get; set; }
        public int RefaundAmount { get; set; }
    }
}

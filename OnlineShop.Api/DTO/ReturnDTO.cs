namespace OnlineShop.Api.DTO
{
    public class ReturnDTO
    {
        public int ReturnID { get; set; }
        public String ReturnReason { get; set; }
        public DateTime ReturnDate { get; set; }
        public int QuantityReturned { get; set; }
        public string Condution { get; set; }
        public int RefaundAmount { get; set; }
        public int ReturnStatus { get; set; }
    }
}

namespace OnlineShop.Api.DTO
{
    public class ReturnedProductDTO
    {
        //public int ReturnID { get; set; }
        public string ReturnReason { get; set; } 
        public string ReturnDate { get; set; }
        public int QuantityReturned { get; set; }
        public string Condution { get; set; }
        public int RefaundAmount { get; set; }
        public int ReturnStatus { get; set; }
    }
}

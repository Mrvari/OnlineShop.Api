namespace OnlineShop.Api.DTO
{
    public class SaveReturnedProductDTO
    {
        //public int ReturnID { get; set; }
        public string ReturnReason { get; set; }
        public string ReturnDate { get; set; }
        public int QuantityReturned { get; set; }
        public int RefaundAmount { get; set; }
    }
}

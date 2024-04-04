namespace OnlineShop.Api.DTO
{
    public class OrderDTO
    {
       // public int OrderID { get; set; }
        public int TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }

        public string DeliveryAdress;
        public int TrackingNumber { get; set; }
    }
}

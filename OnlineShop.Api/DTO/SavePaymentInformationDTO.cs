namespace OnlineShop.Api.DTO
{
    public class SavePaymentInformationDTO
    {
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; } = "";
        public string PaymentStatus { get; set; } = "";
        public int PaymentAmount { get; set; }
    }
}

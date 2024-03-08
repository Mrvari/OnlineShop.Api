namespace OnlineShop.Api.DTO
{
    public class SaveCreditCardDTO
    {
        public int CardID { get; set; }
        public string CardHolderName { get; set; }

        public string CardNumber;
        public DateTime ExpiryDate { get; set; }

        public int CVV;
    }
}

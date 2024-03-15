namespace OnlineShop.Api.DTO
{
    public class SaveCustomerDTO
    {
        public int CustomerID { get; set; } //PK
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string email { get; set; } = "";

        public int Password { get; set; }
    }
}

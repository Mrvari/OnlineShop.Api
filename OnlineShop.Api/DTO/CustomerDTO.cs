namespace OnlineShop.Api.DTO
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; } //PK
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string email { get; set; } = "";

        private string Password;
    }
}

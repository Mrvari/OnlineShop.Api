namespace OnlineShop.Api.DTO
{
    public class SaveCustomerDTO
    {
        //public int CustomerID { get; set; } //PK
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";

        public string Password { get; set; }
    }
}

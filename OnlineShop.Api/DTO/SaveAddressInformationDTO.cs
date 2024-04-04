namespace OnlineShop.Api.DTO
{
    public class SaveAddressInformationDTO
    {
        //public int AddressID { get; set; }
        public string County { get; set; } = "";
        public string street { get; set; } = "";
        public int zipcode { get; set; }
    }
}

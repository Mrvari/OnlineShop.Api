namespace OnlineShop.Api.DTO
{
    //istemci tarafından sunucuya bir ürünün oluşturulması veya güncellenmesi için gönderilen verileri taşır
    public class SaveProductDTO
    {
        //public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } = "";
        public string Images { get; set; } = "";
        public string Brand { get; set; } = "";
        public string TechnicalSpecifications { get; set; }
        public string Reviews { get; set; } = "";
        public decimal? ReviewScores { get; set; }
    }
}

using System.Drawing;

namespace OnlineShop.Api.DTO
{
    //DTOları veri transferi için kullanıyoruz
    //gereksiz alanları boşu boşuna client tarafına göndermememizi sağlar
    //Ayrıca ilerleyen zamanlarda modelimize yeni bir alan (field) eklediğimizi düşünelim
    //bize client olan bütün uygulamalarda değişiklik yapılması gerekecektir.İşte bunlardan dolayı DTO nesnelerine ihtiyaç duyulur.
    //Katmanlar Arası Bağımlılığın Azaltılması ise diğer bir önemli etkendir.

    //istemci tarafına sunulan veya API yanıtlarında kullanılan bir DTO'dur
    public class ProductDTO
    {
        //public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } = "";
        public string Images { get; set; } = "";
        public string Brand { get; set; } = "";
        public string TechnicalSpecifications { get; set; } = "";
        public string Reviews { get; set; } = "";
        public decimal? ReviewScores { get; set; } 
    }
}

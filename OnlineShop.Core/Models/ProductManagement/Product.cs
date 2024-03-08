using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.PromotionManagement;
using OnlineShop.Core.Models.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.ProductManagement
{
    public class Product
    {
        public int ProductID { get; set; }
        public int StockID { get; set; } //FK
        public int ShoppingCartID { get; set; } //FK
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } = "";
        public string Images { get; set; } = "";
        public string Brand { get; set; } = "";
        public string TechnicalSpecifications { get; set; } // required özelliğin class oluşturulması sırasında null olmaması gerektiğini ifade eder
        public string Reviews { get; set; }
        public decimal ReviewScores { get; set; }

        public Stock Stock { get; set; } // between product and stock

        public ShoppingCart? ShoppingCart { get; set; }

        public List<Promotion> Promotions { get; set; }
    }
}

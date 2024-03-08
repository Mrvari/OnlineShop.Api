using OnlineShop.Core.Models.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.PromotionManagement
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Cuponcode { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime ExpireDate { get; set; }

        public List<Product> Products { get; set; }
    }
}

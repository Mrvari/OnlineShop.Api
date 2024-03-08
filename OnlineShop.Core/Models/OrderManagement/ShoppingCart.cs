using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.OrderManagement
{
    public class ShoppingCart
    {
        public int CartID { get; set; }
        public int CustomerID { get; set; }
        public int ProducrID { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public int Cuponcode { get; set; }
        public int TotalAmount { get; set; }
        public int ItemCount { get; set; }
        public int DiscountAmount { get; set; }

        public Order Order { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Product?> Products { get; set; }

    }
}

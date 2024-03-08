using OnlineShop.Core.Models.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.StockManagement
{
    public class Stock
    {
        public int StockID { get; set; }
        public int ProductID { get; set; } //Fk
        public int Quantity { get; set; }
        public int InTransitQuantity { get; set; }
        public DateTime LastUpdate { get; set; }

        public Product Product { get; set; }
    }
}

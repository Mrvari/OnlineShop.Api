using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int InTransitQuantity { get; set; }
        public string LastUpdate { get; set; }

        public int StockProductId { get; set; }
        public Product Product { get; set; }
    }
}

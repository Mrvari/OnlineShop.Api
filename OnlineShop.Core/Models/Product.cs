using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class Product
    {
        public Product() 
        {
           Stocks = new Collection<Stock>();
        }    
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } = "";
        public string Images { get; set; } = "";
        public string Brand { get; set; } = "";
        public string TechnicalSpecifications { get; set; } 
        public string Reviews { get; set; }
        public decimal ReviewScores { get; set; }

        public int CartId { get; set; } //FK
        public ShoppingCart ShoppingCart { get; set; }

        public ICollection<Stock> Stocks { get; set; }

    }
}

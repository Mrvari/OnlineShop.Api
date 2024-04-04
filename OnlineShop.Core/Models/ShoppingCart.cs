using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class ShoppingCart
    {
        public ShoppingCart() 
        {
            Products = new Collection<Product>();
            Orders = new Collection<Order>();
        }
        public int Id { get; set; }
        public string Status { get; set; }

        public int ShoppingCartCustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }



    }
}

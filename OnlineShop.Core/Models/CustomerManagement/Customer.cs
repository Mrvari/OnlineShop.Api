using OnlineShop.Core.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.CustomerManagement
{
    public class Customer
    {
        public int CustomerID { get; set; } //PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // email özelliğini büyük harfle başlatmak iyi bir pratiktir

        public string Password { get; set; } // Password alanını public yapın

        public int Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<AddressInformation> AddressInformations { get; }
        public ICollection<CreditCard> CreditCards { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public OrderHistory OrderHistory { get; set; }
    }
}

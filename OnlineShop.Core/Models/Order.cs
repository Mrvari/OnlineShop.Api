using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class Order
    {
        public Order() 
        {
            ReturnedProducts = new Collection<ReturnedProduct>();
            PaymentInformations = new Collection<PaymentInformation>();
        }
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public int TrackingNumber { get; set; }
        public int CartId { get; set; } 
        public ShoppingCart ShoppingCart { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<PaymentInformation> PaymentInformations { get; set; }

        public ICollection<ReturnedProduct> ReturnedProducts { get; set; }
    }
}

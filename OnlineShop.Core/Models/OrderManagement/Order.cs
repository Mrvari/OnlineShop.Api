using OnlineShop.Core.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.OrderManagement
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ShoppingCartID { get; set; } //FK
        public int TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }

        private string DeliveryAdress;
        public int TrackingNumber { get; set; }
        public string deliveryAdress
        {
            get { return DeliveryAdress; }
            set { DeliveryAdress = value; }
        }

        //Navigation 
        public Customer Customer { get; set; }// optional

        public ShoppingCart ShoppingCart { get; set; }

        public PaymentInformation PaymentInformation { get; set; }
        
        public Return? Return { get; set; }
    }
}

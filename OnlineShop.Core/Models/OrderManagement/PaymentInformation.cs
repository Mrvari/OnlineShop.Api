using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.OrderManagement
{
    public class PaymentInformation
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public int PaymentAmount { get; set; }
        public int CardID { get; set; }

        public Order Order { get; set; }
    }
}

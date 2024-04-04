using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class PaymentInformation
    {
        public int Id { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public int PaymentInformationOrderId { get; set; }
        public Order Order { get; set; }
    }
}

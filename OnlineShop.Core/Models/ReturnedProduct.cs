using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class ReturnedProduct
    {
        public int Id { get; set; }
        public string ReturnReason { get; set; }
        public string ReturnDate { get; set; }
        public string Contiditon { get; set; }
        public int ReturnStatus { get; set; }

        public int ReturnedOrderId { get; set; }
        public Order Order { get; set; }

    }
}

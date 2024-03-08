using OnlineShop.Core.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.OrderManagement
{
    public class OrderHistory
    {
        public int HistoryID { get; set; }
        public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer? Customer { get; set; }
    }
}

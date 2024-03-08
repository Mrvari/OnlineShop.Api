using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.OrderManagement
{
    public class Return
    {
        public int ReturnID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; } //FK
        public int CustomerID { get; set; }
        public String ReturnReason { get; set; }
        public DateTime ReturnDate { get; set; }
        public int QuantityReturned { get; set; }
        public string Condution { get; set; }
        public int RefaundAmount { get; set; }
        public int ReturnStatus { get; set; }

        public Order Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.CustomerManagement
{
    public class AddressInformation
    {
        public int AddressID { get; set; } //PK
        public int? CustomerID { get; set; } //FK (?) => müşteri adres kaydı olmadan da olabilir
        public int OrderID { get; set; } //Fk
        public string County { get; set; }
        public string street { get; set; }
        public int zipcode { get; set; }

        public Customer? Customer { get; set; }
    }
}

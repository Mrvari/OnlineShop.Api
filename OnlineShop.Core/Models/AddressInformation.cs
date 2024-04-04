using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class AddressInformation
    {
        public int Id { get; set; } //PK
        public string County { get; set; }
        public string street { get; set; }
        public int zipcode { get; set; }
        public int CustomerId { get; set; } //FK 
        public Customer Customer { get; set; }
    }
}

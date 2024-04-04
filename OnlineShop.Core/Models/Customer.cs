using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class Customer
    {
        public Customer()
        {
            AddressInformations = new Collection<AddressInformation>();
            CreditCards = new Collection<CreditCard>();
            ShoppingCarts = new Collection<ShoppingCart>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //PK


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } 
        public int Phone { get; set; }

        public ICollection<AddressInformation> AddressInformations { get; set; }
        public ICollection<CreditCard> CreditCards { get; set;}
        public ICollection<ShoppingCart> ShoppingCarts { get; set;}
 


    }
}

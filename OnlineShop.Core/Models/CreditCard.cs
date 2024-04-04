using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CardHolderName { get; set; }

        private string CardNumber;
        private string ExpiryDate { get; set; }

        private int CVV;

        public string cardNumber
        {
            get { return CardNumber; }
            set { CardNumber = value; }
        }

        public string expiryDate
        {
            get { return ExpiryDate; }
            set { ExpiryDate = value; }
        }

        public int cvv
        {
            get { return CVV; }
            set { CVV = value; }
        }

        public int CustomerId { get; set; }
       
        public Customer Customer { get; set; }
        
    }
}

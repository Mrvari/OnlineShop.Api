using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models.CustomerManagement
{
    public class CreditCard
    {
        public int CardID { get; set; }
        public int CustomerID { get; set; }
        public string CardHolderName { get; set; }

        private string CardNumber;
        private DateTime ExpiryDate { get; set; }

        private int CVV;

        public string cardNumber
        {
            get { return CardNumber; }
            set { CardNumber = value; }
        }

        public DateTime expiryDate
        {
            get { return ExpiryDate; }
            set { ExpiryDate = value; }
        }

        public int cvv
        {
            get { return CVV; }
            set { CVV = value; }
        }

        public Customer? Customer { get; set; }
    }
}

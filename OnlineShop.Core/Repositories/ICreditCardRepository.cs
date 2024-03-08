using OnlineShop.Core.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface ICreditCardRepository : IRepository<CreditCard>
    {
        Task<IEnumerable<CreditCard>> GetAllWithCreditCardAsync();
        Task<CreditCard> GetWithCreditCardByIdAsync(int CardID);
        Task<IEnumerable<CreditCard>> GetAllWithCreditCardByCustomerIdAsync(int CustomerID);
    }
}

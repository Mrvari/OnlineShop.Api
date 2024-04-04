using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface ICreditCardRepository : IRepository<CreditCard>
    {
        Task<IEnumerable<CreditCard>> GetAllWithCustomerAsync();
        Task<CreditCard> GetWithCreditCardByIdAsync(int id);
        Task<IEnumerable<CreditCard>> GetAllWithCustomerByCustomerIdAsync(int customerId);
    }
}

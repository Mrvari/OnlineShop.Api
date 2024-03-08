using OnlineShop.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public class CreditCardRepository : Repository<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(OnlineShopDbContext context)
            : base(context) { }

        public async Task<IEnumerable<CreditCard>> GetAllWithCreditCardAsync()
        {
            return await OnlineShopDbContext.CreditCards
                .Include(c => c.Customer)
                .ToListAsync();
        }

        public async Task<CreditCard?> GetWithCreditCardByIdAsync(int cardID)
        {
            return await OnlineShopDbContext.CreditCards
                .Include(c => c.Customer)
                .SingleOrDefaultAsync(c => c.CardID == cardID);
        }

        public async Task<IEnumerable<CreditCard>> GetAllWithCreditCardByCustomerIdAsync(int customerID)
        {
            return await OnlineShopDbContext.CreditCards
                .Include(c => c.Customer)
                .Where(c => c.CustomerID == customerID)
                .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }

    }
}

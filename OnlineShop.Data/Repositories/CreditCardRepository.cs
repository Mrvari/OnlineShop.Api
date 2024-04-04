using OnlineShop.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.Repositories
{
    public class CreditCardRepository : Repository<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(OnlineShopDbContext context)
            : base(context) { }

        public async Task<IEnumerable<CreditCard>> GetAllWithCustomerAsync()
        {
            return await OnlineShopDbContext.CreditCards
                .Include(cd => cd.Customer)
                .ToListAsync();
        }

        public async Task<CreditCard?> GetWithCreditCardByIdAsync(int id)
        {
            return await OnlineShopDbContext.CreditCards
                .Include(cd => cd.Customer)
                .SingleOrDefaultAsync(cd => cd.Id == id);
        }

        public async Task<IEnumerable<CreditCard>> GetAllWithCustomerByCustomerIdAsync(int customerId)
        {
            return await OnlineShopDbContext.CreditCards
                .Include(cd => cd.Customer)
                .Where(cd => cd.CustomerId == customerId)
                .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }

    }
}

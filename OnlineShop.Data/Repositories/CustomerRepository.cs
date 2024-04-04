using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using OnlineShop.Core.Repositories;

namespace OnlineShop.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineShopDbContext context)
            : base(context) 
        { }
        
        public async Task<IEnumerable<Customer>> GetAllWithCreditCardAsync()
        {
            return await OnlineShopDbContext.Customers
                .Include(c => c.CreditCards)
                .ToListAsync();
        }

        public Task<Customer> GetWithCreditCardsByIdAsync(int id)
        {
            return OnlineShopDbContext.Customers
                .Include(c => c.CreditCards)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using OnlineShop.Core.Repositories;

namespace OnlineShop.Data.Repositories
{
    public class ReturnedProductRepository : Repository<ReturnedProduct>, IReturnedProductRepository 
    {
        public ReturnedProductRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<ReturnedProduct>> GetAllWithCustomerAsync()
        {
            return await OnlineShopDbContext.ReturnedProducts
                //.Include(r => r.Customer)
                .ToListAsync();
        }

        public async Task<ReturnedProduct> GetWithCustomerByIdAsync(int id)
        {
            return await OnlineShopDbContext.ReturnedProducts
                //.Include(r => r.Customer)
                .SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<ReturnedProduct>> GetAllWithCustomerByCustomerIdAsync(int customerId)
        {
            return await OnlineShopDbContext.ReturnedProducts
                //.Include(r => r.Customer)
                //.Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

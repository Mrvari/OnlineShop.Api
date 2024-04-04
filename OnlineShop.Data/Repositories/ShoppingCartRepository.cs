using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using OnlineShop.Core.Repositories;

namespace OnlineShop.Data.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<ShoppingCart>> GetAllWithCustomerAsync()
        {
            return await OnlineShopDbContext.ShoppingCarts
                .Include(sc => sc.Customer)
                .ToListAsync();

        }

        public async Task<ShoppingCart> GetWithCustomerByIdAsync(int id)
        {
            return await OnlineShopDbContext.ShoppingCarts
                .Include(sc => sc.Customer)
                .SingleOrDefaultAsync(sc => sc.Id == id);
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllWithCustomerByCustomerIdAsync(int shoppingCartCustomerId)
        {
            return await OnlineShopDbContext.ShoppingCarts
                .Include(sc => sc.Customer)
                .Where(sc => sc.ShoppingCartCustomerId == shoppingCartCustomerId)
                .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

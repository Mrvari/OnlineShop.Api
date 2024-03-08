using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<ShoppingCart>> GetAllWithShoppingCartAsync()
        {
            return await OnlineShopDbContext.ShoppingCarts
                .Include(c => c.Customer)
                .ToListAsync();

        }

        public async Task<ShoppingCart> GetWithShoppingCartByIdAsync(int CartID)
        {
            return await OnlineShopDbContext.ShoppingCarts
                .Include(c => c.Customer)
                .SingleOrDefaultAsync(c => c.CartID == CartID);
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllWithShoppingCartByCustomerIDAsync(int CustomerID)
        {
            return await OnlineShopDbContext.ShoppingCarts
                .Include(c => c.Customer)
                .Where(c => c.CustomerID == CustomerID)
                 .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

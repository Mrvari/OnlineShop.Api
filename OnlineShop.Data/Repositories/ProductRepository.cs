using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.ProductManagement;
using OnlineShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Product>> GetAllWithProductAsync()
        {
            return await OnlineShopDbContext.Products
                .Include( s => s.ShoppingCart)
                .ToListAsync();
        }

        public async Task<Product> GetWithProductByIdAsync(int ProductID)
        {
            return await OnlineShopDbContext.Products
                .Include ( s => s.ShoppingCart)
                .SingleOrDefaultAsync(p => p.ProductID == ProductID);
        }
        public async Task<IEnumerable<Product>> GetAllWithProductByPriceAsync(int Price)
        {
            return await OnlineShopDbContext.Products
            .Include(s => s.ShoppingCart)
                .Where(s => s.Price == Price)
                 .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

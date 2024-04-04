using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using OnlineShop.Core.Repositories;

namespace OnlineShop.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Product>> GetAllWithStocksAsync()
        {
            return await OnlineShopDbContext.Products
                .Include( pr => pr.Stocks)
                .ToListAsync();
        }

        public Task<Product> GetWithStockByIdAsync(int id)
        {
            return OnlineShopDbContext.Products
                .Include (pr => pr.Stocks)
                .SingleOrDefaultAsync(pr => pr.Id == id);
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

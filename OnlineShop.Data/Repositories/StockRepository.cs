using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.StockManagement;
using OnlineShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(OnlineShopDbContext context)
        : base(context)
        { }

        public async Task<IEnumerable<Stock>> GetAllWithShoppingCartAsync()
        {
            return await OnlineShopDbContext.Stocks
                .Include(p => p.Product)
                .ToListAsync();
        }

        public Task<Stock> GetWithStockByIdAsync(int StockID)
        {
            return OnlineShopDbContext.Stocks
                .Include (p => p.Product)
                .SingleOrDefaultAsync(s => s.StockID == StockID);
        }

        public async Task<IEnumerable<Stock>> GetAllWithStockByProductIDAsync(int ProductID)
        {
            return await OnlineShopDbContext.Stocks
                .Where(s => s.ProductID == ProductID)
                .Include(s => s.Product)
                .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

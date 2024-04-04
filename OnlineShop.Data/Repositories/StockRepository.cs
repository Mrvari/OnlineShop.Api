using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
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

        public async Task<IEnumerable<Stock>> GetAllWithProductAsync()
        {
            return await OnlineShopDbContext.Stocks
                .Include(s => s.Product)
                .ToListAsync();
        }

        public async Task<Stock> GetWithProductByIdAsync(int id)
        {
            return await OnlineShopDbContext.Stocks
                .Include (s => s.Product)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Stock>> GetAllWithProductByStockIdAsync(int stockProductId)
        {
            return await OnlineShopDbContext.Stocks
                .Include(s => s.Product)
                .Where(s => s.StockProductId == stockProductId)                
                .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

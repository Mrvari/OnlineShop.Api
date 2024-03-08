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
    public class OrderHistoryRepository : Repository<OrderHistory>, IOrderHistoryRepository
    {
        public OrderHistoryRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<OrderHistory>> GetAllWithOrderHistoryAsync()
        {
            return await OnlineShopDbContext.OrderHistories
                .ToListAsync();
        }

        public async Task<OrderHistory> GetWithOrderHistoryByIdAsync(int HistoryID)
        {
            return await OnlineShopDbContext.OrderHistories
                .Include(c => c.Customer)
                .SingleOrDefaultAsync(o => o.HistoryID == HistoryID);
        }

        public async Task<IEnumerable<OrderHistory>> GetAllWithOrderHistoryByCustomerIDAsync(int CustomerID)
        {
            return await OnlineShopDbContext.OrderHistories
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

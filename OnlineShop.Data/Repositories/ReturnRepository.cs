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
    public class ReturnRepository : Repository<Return>, IReturnRepository 
    {
        public ReturnRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Return>> GetAllWithReturnAsync()
        {
            return await OnlineShopDbContext.Returns
                .Include(o => o.Order)
                .ToListAsync();
        }

        public async Task<Return> GetWithReturnByIdAsync(int ReturnID)
        {
            return await OnlineShopDbContext.Returns
                .Include(o => o.Order)
                .SingleOrDefaultAsync(r => r.ReturnID == ReturnID);
        }

        public async Task<IEnumerable<Return>> GetAllWithReturnByOrderIDAsync(int OrderID)
        {
            return await OnlineShopDbContext.Returns
                .Include(o => o.Order)
                .Where(o => o.OrderID == OrderID)
                 .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

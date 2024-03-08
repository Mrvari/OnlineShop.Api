using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.ProductManagement;
using OnlineShop.Core.Models.PromotionManagement;
using OnlineShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public class PromotionRepository : Repository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Promotion>> GetAllWithPromotionAsync()
        {
            return await OnlineShopDbContext.Promotions
                .Include(p => p.Products)
                .ToListAsync();
        }

        public async Task<Promotion> GetWithPromotionByIdAsync(int PromotionID)
        {
            return await OnlineShopDbContext.Promotions
                .Include(p => p.Products)
                .SingleOrDefaultAsync(p => p.PromotionID == PromotionID);
        }

        public async Task<IEnumerable<Promotion>> GetAllWithPromotionByDiscountAmountAsync(int DiscountAmount)
        {
            return await OnlineShopDbContext.Promotions
                .Where(p => p.DiscountAmount == DiscountAmount)
                .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

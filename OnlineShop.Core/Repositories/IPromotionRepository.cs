using OnlineShop.Core.Models.ProductManagement;
using OnlineShop.Core.Models.PromotionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IPromotionRepository : IRepository<Promotion>
    {
        Task<IEnumerable<Promotion>> GetAllWithPromotionAsync();
        Task<Promotion> GetWithPromotionByIdAsync(int PromotionID);
        Task<IEnumerable<Promotion>> GetAllWithPromotionByDiscountAmountAsync(int DiscountAmount);
    }
}

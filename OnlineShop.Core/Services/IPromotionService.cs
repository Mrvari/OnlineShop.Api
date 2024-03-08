using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.PromotionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> GetAllPromotion();
        Task<Promotion> GetPromotionById(int id);
        Task<Promotion> CreatePromotion(Promotion newPromotion);
        Task UpdatePromotion(Promotion PromotionToBeUpdated, Promotion promotion);
        Task DeletePromotion(Promotion promotion);
    }
}

using OnlineShop.Core;
using OnlineShop.Core.Models.PromotionManagement;
using OnlineShop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PromotionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Promotion> CreatePromotion(Promotion newPromotion)
        {
            await _unitOfWork.Promotions
                .AddAsync(newPromotion);
            return newPromotion;
        }

        public async Task DeletePromotion(Promotion promotion)
        {
            _unitOfWork.Promotions.Remove(promotion);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Promotion>> GetAllPromotion()
        {
            return await _unitOfWork.Promotions .GetAllAsync();
        }

        public async Task<Promotion> GetPromotionById(int id)
        {
            return await _unitOfWork.Promotions.GetWithPromotionByIdAsync(id);
        }

        public async Task UpdatePromotion(Promotion PromotionToBeUpdated, Promotion promotion)
        {
            PromotionToBeUpdated.PromotionID = promotion.PromotionID;
            await _unitOfWork.CommitAsync();
        }
    }
}

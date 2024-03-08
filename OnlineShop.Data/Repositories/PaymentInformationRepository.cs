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
    public class PaymentInformationRepository : Repository<PaymentInformation> , IPaymentInformationRepository
    {
        public PaymentInformationRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<PaymentInformation>> GetAllWithPaymentInformationAsync()
        {
            return await OnlineShopDbContext.PaymentInformations
                .Include(o => o.Order)
                .ToListAsync();
        }

        public async Task<PaymentInformation> GetWithPaymentInformationByIdAsync(int PaymentID)
        {
            return await OnlineShopDbContext.PaymentInformations
                .Include(o => o.Order)
                .SingleOrDefaultAsync(p => p.PaymentID == PaymentID);
        }

        public async Task<IEnumerable<PaymentInformation>> GetAllWithPaymentInformationByCardIDAsync(int CardID)
        {
            return await OnlineShopDbContext.PaymentInformations
                .Include(o => o.Order)
                .Where(c => c.CardID == CardID)
                .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext 
            {
                get { return Context as OnlineShopDbContext; }
            }
    }
}

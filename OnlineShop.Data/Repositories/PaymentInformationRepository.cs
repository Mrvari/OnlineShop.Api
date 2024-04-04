using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using OnlineShop.Core.Repositories;

namespace OnlineShop.Data.Repositories
{
    public class PaymentInformationRepository : Repository<PaymentInformation> , IPaymentInformationRepository
    {
        public PaymentInformationRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<PaymentInformation>> GetAllWithOrderAsync()
        {
            return await OnlineShopDbContext.PaymentInformations
                .Include(o => o.Order)
                .ToListAsync();
        }

        public async Task<PaymentInformation> GetWithOrderByIdAsync(int id)
        {
            return await OnlineShopDbContext.PaymentInformations
                .Include(o => o.Order)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        private OnlineShopDbContext OnlineShopDbContext 
            {
                get { return Context as OnlineShopDbContext; }
            }
    }
}

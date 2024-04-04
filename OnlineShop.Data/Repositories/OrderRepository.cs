using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using OnlineShop.Core.Repositories;

namespace OnlineShop.Data.Repositories
{
    public class OrderRepository :Repository<Order>, IOrderRepository
    {
        public OrderRepository(OnlineShopDbContext context)
        : base(context)
        { }

        public async Task<IEnumerable<Order>> GetAllWithPaymentInformationAsync()
        {
            return await OnlineShopDbContext.Orders
                .Include(o => o.PaymentInformations)
                .ToListAsync();
        }

        public Task<Order> GetWithPaymentInformationsByIdAsync(int id)
        {
            return OnlineShopDbContext.Orders
                .Include(o => o.PaymentInformations)
                .SingleOrDefaultAsync(o => o.Id == id);
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }

    }

}

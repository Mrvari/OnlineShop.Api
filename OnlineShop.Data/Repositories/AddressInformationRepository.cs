using OnlineShop.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.Repositories
{
    public class AddressInformationRepository : Repository<AddressInformation>, IAddressInformationRepository
    {
        public AddressInformationRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<AddressInformation>> GetAllWithCustomerAsync()
        {
            return await OnlineShopDbContext.AddressInformations
                .Include(a => a.Customer)
                .ToListAsync();
        }

        public async Task<AddressInformation?> GetWithCustomerByIdAsync(int id)
        {
            return await OnlineShopDbContext.AddressInformations
                .Include(a => a.Customer)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AddressInformation>> GetAllWithCustomerByAddressInformationIdAsync(int customerId)
        {
            return await OnlineShopDbContext.AddressInformations
                .Include(a => a.Customer)
                .Where(a => a.CustomerId == customerId)
                .ToListAsync();
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
    
}

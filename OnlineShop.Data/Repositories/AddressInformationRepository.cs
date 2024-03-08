using OnlineShop.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Core.Models.CustomerManagement;

namespace OnlineShop.Data.Repositories
{
    public class AddressInformationRepository : Repository<AddressInformation>, IAddressInformationRepository
    {
        public AddressInformationRepository(OnlineShopDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<AddressInformation>> GetAllWithAddressAsync()
        {
            // Tüm adresleri ve ilişkili müşteri bilgilerini içeren bir liste döndürür
            return await OnlineShopDbContext.AddressInformations
                .Include(a => a.Customer)
                .ToListAsync();
        }

        public Task<AddressInformation?> GetWithAddressIDAsync(int id)
        {
            // Belirli bir müşteri kimliği (ID) ile ilişkili adresi ve ilişkili müşteri bilgisini döndürür
            return OnlineShopDbContext.AddressInformations
                .Include(a => a.Customer)
                .SingleOrDefaultAsync(a => a.CustomerID == id);
        }

        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
    
}

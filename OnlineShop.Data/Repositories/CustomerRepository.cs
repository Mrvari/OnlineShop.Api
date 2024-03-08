using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineShopDbContext context)
            : base(context) 
        { }
        
        public async Task<IEnumerable<Customer>> GetAllWithCustomerAsync()
        {
            // Tüm müşterileri içeren bir liste döndürür
            return await OnlineShopDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetWithCustomerByIdAsync(int CustomerID)
        {
            // ID'si verilen müşteriyi döndürür
            return await OnlineShopDbContext.Customers
            .SingleOrDefaultAsync(c => c.CustomerID == CustomerID);
        }

        public async Task<IEnumerable<Customer>> GetAllWithCustomerByFirstNameAsync(string FirstName)
        {
            // İlk ismi verilen müşterileri döndürür
            return await OnlineShopDbContext.Customers
                .Where(c => c.FirstName == FirstName)
                .ToListAsync();
        }
        private OnlineShopDbContext OnlineShopDbContext
        {
            get { return Context as OnlineShopDbContext; }
        }
    }
}

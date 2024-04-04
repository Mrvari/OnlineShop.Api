using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IReturnedProductRepository : IRepository<ReturnedProduct>
    {
        Task<IEnumerable<ReturnedProduct>> GetAllWithCustomerAsync();
        Task<ReturnedProduct> GetWithCustomerByIdAsync(int id);
        Task<IEnumerable<ReturnedProduct>> GetAllWithCustomerByCustomerIdAsync(int orderId);
    }
    
}

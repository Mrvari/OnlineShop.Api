using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task<IEnumerable<ShoppingCart>> GetAllWithCustomerAsync();
        Task<ShoppingCart> GetWithCustomerByIdAsync(int id);
        Task<IEnumerable<ShoppingCart>> GetAllWithCustomerByCustomerIdAsync(int customerId);
    }
}

using OnlineShop.Core.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task<IEnumerable<ShoppingCart>> GetAllWithShoppingCartAsync();
        Task<ShoppingCart> GetWithShoppingCartByIdAsync(int CartID);
        Task<IEnumerable<ShoppingCart>> GetAllWithShoppingCartByCustomerIDAsync(int CustomerID);
    }
}

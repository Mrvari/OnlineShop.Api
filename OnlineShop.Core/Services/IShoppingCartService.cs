using OnlineShop.Core.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface IShoppingCartService
    {
        Task<IEnumerable<ShoppingCart>> GetAllShoppingCart();
        Task<ShoppingCart> GetShoppingCartById(int id);
        Task<ShoppingCart> CreateShoppingCart(ShoppingCart newShoppingCart);
        Task UpdateShoppingCart(ShoppingCart ShoppingCartToBeUpdated, ShoppingCart newShoppingCart);
        Task DeleteShoppingCart(ShoppingCart shoppingCart);
    }
}

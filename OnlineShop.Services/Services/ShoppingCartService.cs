using OnlineShop.Core;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShoppingCart> CreateShoppingCart(ShoppingCart newShoppingCart)
        {
            await _unitOfWork.ShoppingCarts
                .AddAsync(newShoppingCart);
            return new ShoppingCart();
        }

        public async Task DeleteShoppingCart(ShoppingCart shoppingCart)
        {
            _unitOfWork.ShoppingCarts.Remove(shoppingCart);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCart()
        {
            return await _unitOfWork.ShoppingCarts.GetAllAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartById(int id)
        {
            return await _unitOfWork.ShoppingCarts.GetWithShoppingCartByIdAsync(id);
        }

        public async Task UpdateShoppingCart(ShoppingCart ShoppingCartToBeUpdated, ShoppingCart shoppingCart)
        {
            ShoppingCartToBeUpdated.CartID = shoppingCart.CartID;
            await _unitOfWork.CommitAsync();
        }
    }
}

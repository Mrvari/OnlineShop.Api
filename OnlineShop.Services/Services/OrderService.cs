using OnlineShop.Core;
using OnlineShop.Core.Models;
using OnlineShop.Core.Services;

namespace OnlineShop.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrder(Order newOrder)
        {
            await _unitOfWork.Orders
                .AddAsync(newOrder);
            return newOrder;
        }

        public async Task DeleteOrder(Order order)
        {
            _unitOfWork.Orders.Remove(order);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _unitOfWork.Orders.GetWithPaymentInformationsByIdAsync(id);
        }

        public async Task UpdateOrder(Order OrderToBeUpdated, Order order)
        {
            OrderToBeUpdated.Id = order.Id;
            await _unitOfWork.CommitAsync();
        }
    }
}

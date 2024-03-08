using OnlineShop.Core;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderHistoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<OrderHistory>> GetAllOrderHistory()
        {
            return await _unitOfWork.OrderHistories.GetAllAsync();
        }

        public async Task<OrderHistory> GetOrderHistoryById(int id)
        {
            return await _unitOfWork.OrderHistories.GetWithOrderHistoryByIdAsync(id);
        }

        public async Task<OrderHistory> CreateOrderHistory(OrderHistory newOrderHistory)
        {
            await _unitOfWork.OrderHistories
                .AddAsync(newOrderHistory);

            return newOrderHistory;
        }

        public async Task UpdateOrderHistory(OrderHistory OrderHistoryToBeUpdated, OrderHistory orderHistory)
        {
            OrderHistoryToBeUpdated.OrderID = orderHistory.OrderID;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteOrderHistory(OrderHistory OrderHistory)
        {
            _unitOfWork.OrderHistories.Remove(OrderHistory);

            await _unitOfWork.CommitAsync();
        }
    }
}

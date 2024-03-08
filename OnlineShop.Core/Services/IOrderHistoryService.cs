using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface IOrderHistoryService
    {
        Task<IEnumerable<OrderHistory>> GetAllOrderHistory();
        Task<OrderHistory> GetOrderHistoryById(int id);
        Task UpdateOrderHistory(OrderHistory OrderHistoryToBeUpdated, OrderHistory orderHistory);
    }
}

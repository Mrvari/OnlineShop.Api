using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrder();
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(Order newOrder);
        Task UpdateOrder(Order OrderToBeUpdated, Order order);
        Task DeleteOrder(Order order);
    }
}

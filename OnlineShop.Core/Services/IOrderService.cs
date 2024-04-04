using OnlineShop.Core.Models;
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
        Task UpdateOrder(Order orderToBeUpdated, Order order);
        Task DeleteOrder(Order order);
    }
}

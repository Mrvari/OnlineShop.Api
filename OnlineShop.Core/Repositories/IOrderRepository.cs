using OnlineShop.Core.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllWithOrderAsync();
        Task<Order> GetWithOrderByIdAsync(int OrderID);
        Task<IEnumerable<Order>> GetAllWithOrderByCustomerIDAsync(int CustomerID);
    }
}

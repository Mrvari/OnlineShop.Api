using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IOrderHistoryRepository : IRepository<OrderHistory>
    {
        Task<IEnumerable<OrderHistory>> GetAllWithOrderHistoryAsync();
        Task<OrderHistory> GetWithOrderHistoryByIdAsync(int HistoryID);
        Task<IEnumerable<OrderHistory>> GetAllWithOrderHistoryByCustomerIDAsync(int CustomerID);
    }
}

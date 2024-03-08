using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IReturnRepository : IRepository<Return>
    {
        Task<IEnumerable<Return>> GetAllWithReturnAsync();
        Task<Return> GetWithReturnByIdAsync(int ReturnID);
        Task<IEnumerable<Return>> GetAllWithReturnByOrderIDAsync(int OrderID);
    }
    
}

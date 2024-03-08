using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithProductAsync();
        Task<Product> GetWithProductByIdAsync(int ProductID);
        Task<IEnumerable<Product>> GetAllWithProductByPriceAsync(int Price);
    }
}

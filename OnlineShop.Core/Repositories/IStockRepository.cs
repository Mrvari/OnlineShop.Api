using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IStockRepository : IRepository<Stock>
    {
        Task<IEnumerable<Stock>> GetAllWithProductAsync();
        Task<Stock> GetWithProductByIdAsync(int id);
        Task<IEnumerable<Stock>> GetAllWithProductByStockIdAsync(int productId);
    }
}

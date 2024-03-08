using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IStockRepository : IRepository<Stock>
    {
        Task<IEnumerable<Stock>> GetAllWithShoppingCartAsync();
        Task<Stock> GetWithStockByIdAsync(int StockID);
        Task<IEnumerable<Stock>> GetAllWithStockByProductIDAsync(int ProductID);
    }
}

using OnlineShop.Core.Models;
using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> GetAllStock();
        Task<Stock> GetStockById(int id);
        Task<Stock> CreateStock(Stock newStock);
        Task UpdateStock(Stock StockToBeUpdated, Stock stock);
        Task DeleteStock(Stock stock);
    }
}

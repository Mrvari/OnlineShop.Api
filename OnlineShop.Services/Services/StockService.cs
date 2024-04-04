using OnlineShop.Core;
using OnlineShop.Core.Models;
using OnlineShop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Stock> CreateStock(Stock newStock)
        {
            await _unitOfWork.Stocks
                .AddAsync(newStock);
            return newStock;
        }

        public async Task DeleteStock(Stock stock)
        {
            _unitOfWork.Stocks.Remove(stock);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Stock>> GetAllStock()
        {
            return await _unitOfWork.Stocks.GetAllAsync();
        }

        public async Task<Stock> GetStockById(int id)
        {
            return await _unitOfWork.Stocks.GetWithProductByIdAsync(id);
        }

        public async Task UpdateStock(Stock StockToBeUpdated, Stock stock)
        {
            StockToBeUpdated.Id = stock.Id;
            await _unitOfWork.CommitAsync();
        }
    }
}

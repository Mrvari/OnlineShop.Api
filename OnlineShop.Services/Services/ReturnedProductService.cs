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
    public class ReturnedProductService : IReturnedProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReturnedProductService (IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ReturnedProduct> CreateReturnedProduct(ReturnedProduct newReturnedProduct)
        {
            await _unitOfWork.ReturnedProducts
                .AddAsync(newReturnedProduct);
            return newReturnedProduct;
        }

        public async Task DeleteReturnedProduct(ReturnedProduct returnedProduct)
        {
            _unitOfWork.ReturnedProducts.Remove(returnedProduct);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ReturnedProduct>> GetAllReturnedProduct()
        {
            return await _unitOfWork.ReturnedProducts.GetAllAsync();
        }

        public async Task<ReturnedProduct> GetReturnedProductById(int id)
        {
            return await _unitOfWork.ReturnedProducts.GetWithCustomerByIdAsync(id);
        }

        public async Task UpdateReturnedProduct(ReturnedProduct returnedProductToBeUpdated, ReturnedProduct returnedProduct)
        {
            returnedProductToBeUpdated.Id = returnedProduct.Id;
            await _unitOfWork.CommitAsync();
        }
    }
}

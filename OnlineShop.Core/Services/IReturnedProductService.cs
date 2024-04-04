using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface IReturnedProductService
    {
        Task<IEnumerable<ReturnedProduct>> GetAllReturnedProduct();
        Task<ReturnedProduct> GetReturnedProductById(int id);
        Task<ReturnedProduct> CreateReturnedProduct(ReturnedProduct newReturnedProduct);
        Task UpdateReturnedProduct(ReturnedProduct returnedProductToBeUpdated, ReturnedProduct returnedProduct);
        Task DeleteReturnedProduct(ReturnedProduct returnedProduct);
    }
}

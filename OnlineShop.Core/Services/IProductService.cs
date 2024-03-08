using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product newProduct);
        Task UpdateProduct(Product ProductToBeUpdated, Product product);
        Task DeleteProduct(Product product);
    }
}

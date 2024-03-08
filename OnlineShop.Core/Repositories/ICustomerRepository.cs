using OnlineShop.Core.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllWithCustomerAsync();
        Task<Customer> GetWithCustomerByIdAsync(int CustomerID);
        Task<IEnumerable<Customer>> GetAllWithCustomerByFirstNameAsync(string FirstName);
    }
}

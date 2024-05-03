using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> GetCustomerByEmailAndPassword(string email, string password);
        Task<Customer> GetCustomerByEmail(string email);
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task UpdateCustomer(Customer customerToBeUpdated, Customer customer);
        Task DeleteCustomer(Customer customer);
    }
}

using OnlineShop.Core;
using OnlineShop.Core.Models;
using OnlineShop.Core.Models;
using OnlineShop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            await _unitOfWork.Customers.AddAsync(newCustomer);
            await _unitOfWork.CommitAsync();
            return newCustomer;
        }

        public async Task DeleteCustomer(Customer Customer)
        {
            _unitOfWork.Customers.Remove(Customer);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _unitOfWork.Customers
                .GetAllAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _unitOfWork.Customers
                .GetWithCreditCardsByIdAsync(id);
        }

        public async Task UpdateCustomer(Customer CustomerToBeUpdated, Customer customer)
        {
            CustomerToBeUpdated.Id = customer.Id;
            await _unitOfWork.CommitAsync();
        }
    }
}

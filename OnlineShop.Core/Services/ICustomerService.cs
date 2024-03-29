﻿using OnlineShop.Core.Models.CustomerManagement;
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
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task UpdateCustomer(Customer CustomerToBeUpdated, Customer customer);
        Task DeleteCustomer(Customer Customer);
    }
}

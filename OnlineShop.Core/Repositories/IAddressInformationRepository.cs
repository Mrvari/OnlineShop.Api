using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IAddressInformationRepository : IRepository<AddressInformation>
    {
        Task<IEnumerable<AddressInformation>> GetAllWithCustomerAsync();
        Task<AddressInformation> GetWithCustomerByIdAsync(int id);
        Task<IEnumerable<AddressInformation>> GetAllWithCustomerByAddressInformationIdAsync(int customerId);

    }
}

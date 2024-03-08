using OnlineShop.Core.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IAddressInformationRepository : IRepository<AddressInformation>
    {
        Task<IEnumerable<AddressInformation>> GetAllWithAddressAsync();
        Task<AddressInformation> GetWithAddressIDAsync(int AddressID);
    }
}

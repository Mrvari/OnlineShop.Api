using OnlineShop.Core.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Services, genellikle iş mantığını yürüten ve farklı parçalar arasında iletişim sağlayan birimlerdir. 
 * Genellikle kullanıcı arayüzü veya diğer dış sistemlerle iletişim halinde olur ve veri işleme,
 * doğrulama, veritabanı işlemleri gibi işleri gerçekleştirir.
 */

namespace OnlineShop.Core.Services
{
    public interface IAddressInformationService
    {
        Task<IEnumerable<AddressInformation>> GetAllAddressInformation();
        Task<AddressInformation> GetAddressInformationById(int id);
        Task<AddressInformation> CreateAddress(AddressInformation newAddress);
        Task UpdateAddress(AddressInformation AddressToBeUpdated, AddressInformation Address);
        Task DeleteAddress(AddressInformation Address);
    }
}

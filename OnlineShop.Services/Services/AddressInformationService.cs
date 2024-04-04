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
    public class AddressInformationService : IAddressInformationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressInformationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<AddressInformation> CreateAddress(AddressInformation newAddress)
        {
            await _unitOfWork.AddressInformations
                .AddAsync(newAddress);

            //await _unitOfWork.CommitAsync();

            return newAddress;
        }

        public async Task DeleteAddress(AddressInformation Address)
        {
            _unitOfWork.AddressInformations.Remove(Address);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<AddressInformation>> GetAllAddressInformation()
        {
            return await _unitOfWork.AddressInformations.GetAllAsync();
        }

        public async Task<AddressInformation> GetAddressInformationById(int id)
        {
            return await _unitOfWork.AddressInformations.GetWithCustomerByIdAsync(id);
        }       

        public async Task UpdateAddress(AddressInformation addressInformationToBeUpdated, AddressInformation address)
        {
            addressInformationToBeUpdated.street = address.street;

            await _unitOfWork.CommitAsync();
        }

        

        
    }
}

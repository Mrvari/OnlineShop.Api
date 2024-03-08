using OnlineShop.Core;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
{
    public class ReturnService : IReturnService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReturnService (IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Return> CreateReturn(Return newReturn)
        {
            await _unitOfWork.Returns
                .AddAsync(newReturn);
            return newReturn;
        }

        public async Task DeleteReturn(Return @return)
        {
            _unitOfWork.Returns.Remove(@return);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Return>> GetAllReturn()
        {
            return await _unitOfWork.Returns.GetAllAsync();
        }

        public async Task<Return> GetReturnById(int id)
        {
            return await _unitOfWork.Returns.GetWithReturnByIdAsync(id);
        }

        public async Task UpdateReturn(Return ReturnToBeUpdated, Return Return)
        {
            ReturnToBeUpdated.ReturnID = Return.ReturnID;
            await _unitOfWork.CommitAsync();
        }
    }
}

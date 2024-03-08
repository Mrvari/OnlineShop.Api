using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.PromotionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface IReturnService
    {
        Task<IEnumerable<Return>> GetAllReturn();
        Task<Return> GetReturnById(int id);
        Task<Return> CreateReturn(Return newReturn);
        Task UpdateReturn(Return ReturnToBeUpdated, Return Return);
        Task DeleteReturn(Return @return);
    }
}

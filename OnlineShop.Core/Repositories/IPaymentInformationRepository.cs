using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IPaymentInformationRepository : IRepository<PaymentInformation>
    {
        Task<IEnumerable<PaymentInformation>> GetAllWithOrderAsync();
        Task<PaymentInformation> GetWithOrderByIdAsync(int id);
    }
}

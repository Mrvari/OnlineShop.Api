using OnlineShop.Core.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Repositories
{
    public interface IPaymentInformationRepository : IRepository<PaymentInformation>
    {
        Task<IEnumerable<PaymentInformation>> GetAllWithPaymentInformationAsync();
        Task<PaymentInformation> GetWithPaymentInformationByIdAsync(int PaymentID);
        Task<IEnumerable<PaymentInformation>> GetAllWithPaymentInformationByCardIDAsync(int CardID);
    }
}

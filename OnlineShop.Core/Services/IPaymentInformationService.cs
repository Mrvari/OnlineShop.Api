using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface IPaymentInformationService
    {
        Task<IEnumerable<PaymentInformation>> GetAllPaymentInformation();
        Task<PaymentInformation> GetPaymentInformationById(int id);
        Task<PaymentInformation> CreatePaymentInformation(PaymentInformation newPaymentInformation);
        Task UpdatePaymentInformation(PaymentInformation paymentToBeUpdated, PaymentInformation paymentInformation);
        Task DeletePaymentInformation(PaymentInformation paymentInformation);
    }
}

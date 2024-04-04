using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Services
{
    public interface ICreditCardService
    {
        Task<IEnumerable<CreditCard>> GetAllCreditCard();
        Task<CreditCard> GetCreditCardById(int id);
        Task<CreditCard> CreateCreditCard(CreditCard newcreditCard);
        Task UpdateCreditCard(CreditCard creditCardToBeUpdated, CreditCard creditCard);
        Task DeleteCreditCard(CreditCard creditCard);
    }
}

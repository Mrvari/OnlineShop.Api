using OnlineShop.Core;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Repositories;
using OnlineShop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreditCardService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<CreditCard> CreateCreditCard(CreditCard newcreditCard)
        {
            await _unitOfWork.CreditCards
                .AddAsync(newcreditCard);
            return newcreditCard;
        }

        public async Task DeleteCreditCard(CreditCard creditCard)
        {
            _unitOfWork.CreditCards.Remove(creditCard);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CreditCard>> GetAllCreditCard()
        {
            return await _unitOfWork.CreditCards .GetAllAsync();
        }

        public async Task<CreditCard> GetCreditCardById(int id)
        {
            return await _unitOfWork.CreditCards.GetWithCreditCardByIdAsync(id);
        }

        public async Task UpdateCreditCard(CreditCard creditCardToBeUpdated, CreditCard creditCard)
        {
            creditCardToBeUpdated.CardID = creditCard.CardID;
            await _unitOfWork.CommitAsync();
        }
    }
}

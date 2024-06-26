﻿using OnlineShop.Core;
using OnlineShop.Core.Models;
using OnlineShop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
{
    public class PaymentInformationService : IPaymentInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentInformationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<PaymentInformation> CreatePaymentInformation(PaymentInformation newPaymentInformation)
        {
            await _unitOfWork.PaymentInformations
                .AddAsync(newPaymentInformation);
            return newPaymentInformation;
        }

        public async Task DeletePaymentInformation(PaymentInformation paymentInformation)
        {
            _unitOfWork.PaymentInformations.Remove(paymentInformation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<PaymentInformation>> GetAllPaymentInformation()
        {
            return await _unitOfWork.PaymentInformations.GetAllWithOrderAsync();
        }

        public async Task<PaymentInformation> GetPaymentInformationById(int id)
        {
            return await _unitOfWork.PaymentInformations.GetWithOrderByIdAsync(id);
        }

        public async Task UpdatePaymentInformation(PaymentInformation PaymentToBeUpdated, PaymentInformation paymentInformation)
        {
            PaymentToBeUpdated.Id = paymentInformation.Id;
            await _unitOfWork.CommitAsync();
        }
    }
}

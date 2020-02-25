using BLShop.WEB.Infrastructure;
using BLShop.WEB.Interfaces;
using BLShop.WEB.ModelsDTO.ForEmployee;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLShop.WEB.Services
{
    public class PaymentAccountService : IPaymentAccountService
    {
        private readonly IRepository<PaymentAccount> paymentAccounts;

        public PaymentAccountService(IRepository<PaymentAccount> paymentAccounts)
        {
            this.paymentAccounts = paymentAccounts;
        }

        public void AddPaymentAccount(PaymentAccountDTO paymentAccountDTO)
        {
            paymentAccounts.Create(paymentAccountDTO.ToPaymentAccount());
        }

        public void DeletePaymentAccount(int id)
        {
            paymentAccounts.Delete(id);
        }

        public PaymentAccountDTO GetPaymentAccount(int id)
        {
            var paymentAccount = paymentAccounts.Get(id);
            if (paymentAccount == null)
            {
                throw new NullReferenceException();
            }

            return paymentAccount.ToPaymentAccountDTO();
        }

        public IEnumerable<PaymentAccountDTO> GetPaymentAccounts()
        {
            return paymentAccounts.GetAll().ToListPaymentAccountDTO();
        }

        public void UpdatePaymentAccount(PaymentAccountDTO paymentAccountDTO)
        {
            var paymentAccount = paymentAccountDTO.ToPaymentAccount();

            paymentAccounts.Update(paymentAccount);
        }
    }
}

using BLShop.WEB.ModelsDTO.ForEmployee;
using System;
using System.Collections.Generic;

namespace BLShop.WEB.Interfaces
{
    public interface IPaymentAccountService : IDisposable
    {
        void AddPaymentAccount(PaymentAccountDTO paymentAccountDTO);
        IEnumerable<PaymentAccountDTO> GetPaymentAccounts();
        PaymentAccountDTO GetPaymentAccount(int id);
        void DeletePaymentAccount(int id);
        void UpdatePaymentAccount(PaymentAccountDTO paymentAccountDTO);
    }
}

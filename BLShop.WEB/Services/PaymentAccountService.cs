using BLShop.WEB.Infrastructure;
using BLShop.WEB.Interfaces;
using BLShop.WEB.ModelsDTO.ForEmployee;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BLShop.WEB.Services
{
    public class PaymentAccountService : IPaymentAccountService
    {
        private readonly IRepository<PaymentAccount> paymentAccounts;
        private readonly IRepository<Employee> employees;

        private bool disposed = false;

        public PaymentAccountService(
            IRepository<PaymentAccount> paymentAccounts,
            IRepository<Employee> employees)
        {
            this.paymentAccounts = paymentAccounts;
            this.employees = employees;
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
            var employee = employees.Get(paymentAccount.EmployeeId);

            return new PaymentAccountDTO
                {
                    Id = paymentAccount.Id,
                    Payday = paymentAccount.Payday,
                    Salary = paymentAccount.Salary,
                    Name = employee.Name,
                    SurName = employee.SurName,
                    Patronymic = employee.Patronymic,
                    PositionId = employee.PositionId,
                    EmployeeId = paymentAccount.EmployeeId
                };
            
        }

        public IEnumerable<PaymentAccountDTO> GetPaymentAccounts()
        {
            var listPaymentAccounts = new List<PaymentAccountDTO>();

            foreach(var paymentAccount in paymentAccounts.GetAll())
            {
                var employee = employees.Get(paymentAccount.EmployeeId);
                listPaymentAccounts.Add(new PaymentAccountDTO
                {
                    Id = paymentAccount.Id,
                    Payday = paymentAccount.Payday,
                    Salary = paymentAccount.Salary,
                    Name = employee.Name,
                    SurName = employee.SurName,
                    Patronymic = employee.Patronymic,
                    PositionId = employee.PositionId,
                    EmployeeId = paymentAccount.EmployeeId
                });
            }

            return listPaymentAccounts;
        }

        public void UpdatePaymentAccount(PaymentAccountDTO paymentAccountDTO)
        {
            var paymentAccount = paymentAccountDTO.ToPaymentAccount();

            paymentAccounts.Update(paymentAccount);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                paymentAccounts.Dispose();
            }

            disposed = true;
        }
    }
}

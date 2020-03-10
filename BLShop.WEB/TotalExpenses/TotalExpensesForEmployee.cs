using BLShop.WEB.Interfaces;
using System;
using System.Linq;

namespace BLShop.WEB.TotalExpenses
{
    public class TotalExpensesForEmployee
    {
        private readonly IPaymentAccountService paymentAccountService;

        public TotalExpensesForEmployee(IPaymentAccountService paymentAccountService)
        {
            this.paymentAccountService = paymentAccountService;
        }

        public decimal GetTotalExpensesForEmployee (DateTime startDate, DateTime finishDate)
        {
            if(startDate > finishDate)
            {
                return 0.0M;
            }

            return paymentAccountService.GetPaymentAccounts().
                Where(month => month.Payday.Month >= startDate.Month &&
                      month.Payday.Month <= finishDate.Month).                
                Sum(salary => salary.Salary);
        }
    }
}

using DAShop.WEB.Models.ForEmployee;
using System;
using System.Linq;

namespace BLShop.WEB.Infrastructure
{
    public class SalaryWithTax
    {
        private readonly Employee employee;
        private readonly DateTime payday;

        public SalaryWithTax(Employee employee, DateTime payday, decimal tax)
        {
            this.employee = employee;
            this.payday = payday;
            Tax = tax;
        }

        public decimal Tax { get; }

        public decimal GetSalaryWithTax()
        {
            var bonusOrFineOfEmployee = employee.BonusOrFines.
                Where(month => month.Date.Month == payday.Month).
                Sum(money=>money.AmountOfBonusOrFine);

            var sickLeaveOfEmployee = employee.SickLeaves.
                Where(month => month.StartOfTheSickLeave.Month == payday.Month).
                Sum(money => money.MonetaryCompensation);

            return (employee.Position.MinSalary * 1.37M + bonusOrFineOfEmployee + sickLeaveOfEmployee) * (1 - Tax/100) ;
        }
    }
}

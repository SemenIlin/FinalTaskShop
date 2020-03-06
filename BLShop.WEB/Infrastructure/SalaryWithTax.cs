using BLShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using System;
using System.Linq;

namespace BLShop.WEB.Infrastructure
{
    public class SalaryWithTax
    {
        private readonly IEmployeeService employeeService;       

        public SalaryWithTax(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        
        public decimal GetSalaryWithTax(int id, DateTime payday, decimal tax)
        {
            var bonusOrFineOfEmployee = employeeService.GetBonusOrFines().
                Where(month => month.Date.Month == payday.Month && month.EmployeeId == id).
                Sum(money=>money.AmountOfBonusOrFine);

            var sickLeaveOfEmployee = employeeService.GetSickLeaves().
                Where(month => month.StartOfTheSickLeave.Month == payday.Month && month.EmployeeId == id).
                Sum(money => money.MonetaryCompensation);

            var minSalary = employeeService.GetEmployee(id).MinSalary;

            return (minSalary * 1.37M + bonusOrFineOfEmployee + sickLeaveOfEmployee) * (1 - tax/100) ;
        }
    }
}

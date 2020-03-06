using FinalTaskShop.Infrastructure;
using System.Linq;
using BLShop.WEB.ModelsDTO.ForEmployee;
using BLShop.WEB.Interfaces;
using FinalTaskShop.ViewModels.ForEmployee;
using Microsoft.AspNetCore.Mvc;
using BLShop.WEB.Infrastructure;

namespace FinalTaskShop.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IPaymentAccountService paymentAccountService;
        
        public SalaryController(IEmployeeService employeeService, 
                                IPaymentAccountService paymentAccountService)
        {
            this.employeeService = employeeService;
            this.paymentAccountService = paymentAccountService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult  CalculateSalary()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateSalary(PaymentAccountViewModel paymentAccountViewModel)
        {   
            if (ModelState.IsValid)
            {
                var employeeAccounts = employeeService.GetEmployees().ToList();
                foreach (var employeeAccount in employeeAccounts)
                {
                    var employee = employeeAccount.ToEmployee();
                    paymentAccountService.AddPaymentAccount(
                        new PaymentAccountDTO
                        { 
                            Id = paymentAccountViewModel.Id,
                            Name = employee.Name,
                            SurName = employee.SurName,
                            Patronymic = employee.Patronymic,
                            EmployeeId = employee.Id,
                            PositionId = employee.PositionId,
                            Payday = paymentAccountViewModel.Payday,
                            Salary = new SalaryWithTax(employeeService).GetSalaryWithTax(employee.Id, paymentAccountViewModel.Payday, 13M)
                        });                    
                }
                
                return RedirectToAction("Index");
            }

            return View(paymentAccountViewModel);
        }

        [HttpGet]
        public ActionResult ListPaymentAccounts()
        {
            var listpaymentAccounts = paymentAccountService.GetPaymentAccounts().ToListPaymentAccountViewModel();
            return View(listpaymentAccounts);
        }

        [HttpGet]
        public ActionResult DeletePaymentAccount(int? id)
        {
            try
            {
                var paymentAccountViewModel = paymentAccountService.GetPaymentAccount(id.Value).ToPaymentAccountViewModel();

                return View(paymentAccountViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("DeletePaymentAccount")]
        public ActionResult DeletePaymentAccountConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentAccount = paymentAccountService.GetPaymentAccount(id.Value);
            if (paymentAccount == null)
            {
                return NotFound();
            }

            paymentAccountService.DeletePaymentAccount(id.Value);

            return RedirectToAction("ListPaymentAccounts");
        }       
    }
}

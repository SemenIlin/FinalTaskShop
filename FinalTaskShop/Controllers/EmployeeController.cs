using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLShop.WEB.Interfaces;
using FinalTaskShop.Infrastructure;
using FinalTaskShop.ViewModels.ForEmployee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalTaskShop.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        //private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListEmployees()
        {
            var listEmployees = employeeService.GetEmployees().ToListEmployeeViewModels();

            return View(listEmployees);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            GetSelectListOfPositions();
            GetSelectListOfDepartaments();
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            var employeeDTO = employeeViewModel.ToEmployeeDTO();
            employeeService.AddEmployee(employeeDTO);

            return RedirectToAction("CreateEmployee");
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            try
            {
                var employeeViewModel= employeeService.GetEmployee(id.Value).ToEmployeeViewModel();

                return View(employeeViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public IActionResult DeleteEmployeeConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeService.GetEmployee(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            employeeService.DeleteEmployee(id.Value);

            return RedirectToAction("ListEmployees");
        }

        [HttpGet]
        public IActionResult EditEmployee(int? id)
        {
            try
            {
                GetSelectListOfPositions();
                GetSelectListOfDepartaments();

                var employeeViewModel = employeeService.GetEmployee(id.Value).ToEmployeeViewModel();
                
                return View(employeeViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditEmployee(EmployeeViewModel employeeViewModel)
        {
            var employeeDTO = employeeViewModel.ToEmployeeDTO();
            employeeService.UpdateEmployee(employeeDTO);

            return RedirectToAction("ListEmployees");
        }

        [HttpGet]
        public ActionResult DetailsEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employeDTO = employeeService.GetEmployee(id.Value).ToEmployeeViewModel();

            if (employeDTO == null)
            {
                return NotFound();
            }

            return View(employeDTO);
        }
        
        [HttpGet]
        public IActionResult ListPositions()
        {
            var listPositions = employeeService.GetPositions().ToListPositionViewModel();                

            return View(listPositions);
        }

        [HttpGet]
        public IActionResult CreatePosition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePosition(PositionViewModel positionViewModel)
        {
            var positionDTO = positionViewModel.ToPositionDTO();
            employeeService.CreatePosition(positionDTO);

            return RedirectToAction("CreatePosition");
        }

        [HttpGet]
        public IActionResult DeletePosition(int? id)
        {
            try
            {
                var positionDTO = employeeService.GetPosition(id.Value).ToPositionViewModel();

                return View(positionDTO);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("DeletePosition")]
        public IActionResult DeletePositionConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = employeeService.GetEmployee(id.Value);
            if (position == null)
            {
                return NotFound();
            }

            employeeService.DeletePosition(id.Value);

            return RedirectToAction("ListPositions");
        }

        [HttpGet]
        public IActionResult EditPosition(int? id)
        {
            try
            {
                var positionViewModel = employeeService.GetPosition(id.Value).ToPositionViewModel();               

                return View(positionViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditPosition(PositionViewModel positionViewModel)
        {
            var positionDTO = positionViewModel.ToPositionDTO();
            employeeService.UpdatePosition(positionDTO);

            return RedirectToAction("ListPositions");
        }

        [HttpGet]
        public IActionResult ListBonusOrFines()
        {
            var listBonusOrFines = employeeService.GetBonusOrFines().ToListBonusOrFineViewModel();

            return View(listBonusOrFines);
        }

        [HttpGet]
        public IActionResult CreateBonusOrFine()
        {
            GetSelectListOfEmployees();
            return View();
        }

        [HttpPost]
        public IActionResult CreateBonusOrFine(BonusOrFineViewModel bonusOrFineViewModel)
        {
            var bonusOrFineDTO = bonusOrFineViewModel.ToBonusOrFineDTO();
            employeeService.AddBonusOrFine(bonusOrFineDTO);

            return RedirectToAction("CreateBonusOrFine");
        }

        [HttpGet]
        public IActionResult DeleteBonusOrFine(int? id)
        {
            try
            {
                var bonusOrFineViewModel = employeeService.GetBonusOrFine(id.Value).ToBonusOrFineViewModel();

                return View(bonusOrFineViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("DeleteBonusOrFine")]
        public IActionResult DeleteBonusOrFineConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonusOrFine = employeeService.GetBonusOrFine(id.Value);
            if (bonusOrFine == null)
            {
                return NotFound();
            }

            employeeService.DeleteBonusOrFine(id.Value);

            return RedirectToAction("ListBonusOrFines");
        }

        [HttpGet]
        public IActionResult EditBonusOrFine(int? id)
        {
            try
            {
                GetSelectListOfEmployees();

                var bonusOrFineViewModel = employeeService.GetBonusOrFine(id.Value).ToBonusOrFineViewModel();

                return View(bonusOrFineViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditBonusOrFine(BonusOrFineViewModel bonusOrFineViewModel)
        {
            var bonusOrFineDTO = bonusOrFineViewModel.ToBonusOrFineDTO();
            employeeService.UpdateBonusOrFine(bonusOrFineDTO);

            return RedirectToAction("ListBonusOrFines");
        }

        [HttpGet]
        public ActionResult DetailsBonusOrFine(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bonusOrFineDTO = employeeService.GetBonusOrFine(id.Value).ToBonusOrFineViewModel();

            if (bonusOrFineDTO == null)
            {
                return NotFound();
            }

            return View(bonusOrFineDTO);
        }

        [HttpGet]
        public IActionResult ListSickLeaves()
        {
            var listSickLeaves = employeeService.GetSickLeaves().ToListSickLeaveViewModel();

            return View(listSickLeaves);
        }

        [HttpGet]
        public IActionResult CreateSickLeave()
        {
            GetSelectListOfEmployees();
            return View();
        }

        [HttpPost]
        public IActionResult CreateSickLeave(SickLeaveViewModel sickLeaveViewModel)
        {
            var sickLeaveDTO = sickLeaveViewModel.ToSickLeaveDTO();
            employeeService.AddSickLeave(sickLeaveDTO);

            return RedirectToAction("CreateSickLeave");
        }

        [HttpGet]
        public IActionResult DeleteSickLeave(int? id)
        {
            try
            {
                var sickLeaveViewModel = employeeService.GetSickLeave(id.Value).ToSickLeaveViewModel();

                return View(sickLeaveViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("DeleteSickLeave")]
        public IActionResult DeleteSickLeaveConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sickLeave = employeeService.GetSickLeave(id.Value);
            if (sickLeave == null)
            {
                return NotFound();
            }

            employeeService.DeleteSickLeave(id.Value);

            return RedirectToAction("ListSickLeaves");
        }

        [HttpGet]
        public IActionResult EditSickLeave(int? id)
        {
            try
            {
                GetSelectListOfEmployees();

                var sickLeaveViewModel = employeeService.GetSickLeave(id.Value).ToSickLeaveViewModel();

                return View(sickLeaveViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditSickLeave(SickLeaveViewModel sickLeaveViewModel)
        {
            var sickLeaveDTO = sickLeaveViewModel.ToSickLeaveDTO();
            employeeService.UpdateSickLeave(sickLeaveDTO);

            return RedirectToAction("ListSickLeaves");
        }

        [HttpGet]
        public ActionResult DetailsSickLeave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sickLeaveDTO = employeeService.GetSickLeave(id.Value).ToSickLeaveViewModel();

            if (sickLeaveDTO == null)
            {
                return NotFound();
            }

            return View(sickLeaveDTO);
        }

        [NonAction]
        public SelectList GetSelectListOfPositions()
        {
            var positions = employeeService.GetPositions().ToListPositionViewModel();
            ViewBag.Positions = new SelectList(positions, "Id", "Title");

            return ViewBag.Positions;
        }

        [NonAction]
        public SelectList GetSelectListOfEmployees()
        {
            var employees = employeeService.GetEmployees().ToListEmployeeViewModels();
            ViewBag.Employees = new SelectList(employees, "Id", "Title");

            return ViewBag.Employees;
        }


        [NonAction]
        public SelectList GetSelectListOfDepartaments()
        {
            var departaments = employeeService.GetDepartaments().ToListDepartamentViewModel();
            ViewBag.Departaments = new SelectList(departaments, "Id", "Title");

            return ViewBag.Departaments;
        }
        

    }
}

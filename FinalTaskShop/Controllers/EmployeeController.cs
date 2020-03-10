using BLShop.WEB.Interfaces;
using FinalTaskShop.Infrastructure;
using FinalTaskShop.ViewModels.ForEmployee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalTaskShop.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListEmployees()
        {
            var listEmployees = employeeService.GetEmployees().ToListEmployeeViewModels();

            return View(listEmployees);
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            GetSelectListOfPositions();
            GetSelectListOfDepartaments();
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var employeeDTO = employeeViewModel.ToEmployeeDTO();
                employeeService.AddEmployee(employeeDTO);

                return RedirectToAction("CreateEmployee");
            }

            GetSelectListOfPositions();
            GetSelectListOfDepartaments();

            return View(employeeViewModel);
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int? id)
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
        public ActionResult DeleteEmployeeConfirmed(int? id)
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
        public ActionResult EditEmployee(int? id)
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
        public ActionResult EditEmployee(EmployeeViewModel employeeViewModel)
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

            ViewBag.Position = employeeService.GetPosition(employeDTO.PositionId).Title;

            return View(employeDTO);
        }
        
        [HttpGet]
        public ActionResult ListPositions()
        {
            var listPositions = employeeService.GetPositions().ToListPositionViewModel();                

            return View(listPositions);
        }

        [HttpGet]
        public ActionResult CreatePosition()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePosition(PositionViewModel positionViewModel)
        {
            if (ModelState.IsValid)
            {
                var positionDTO = positionViewModel.ToPositionDTO();
                employeeService.CreatePosition(positionDTO);

                return RedirectToAction("CreatePosition");
            }

            return View(positionViewModel);
        }

        [HttpGet]
        public ActionResult DeletePosition(int? id)
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
        public ActionResult DeletePositionConfirmed(int? id)
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
        public ActionResult EditPosition(int? id)
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
        public ActionResult EditPosition(PositionViewModel positionViewModel)
        {
            var positionDTO = positionViewModel.ToPositionDTO();
            employeeService.UpdatePosition(positionDTO);

            return RedirectToAction("ListPositions");
        }

        [HttpGet]
        public ActionResult ListBonusOrFines()
        {
            var listBonusOrFines = employeeService.GetBonusOrFines().ToListBonusOrFineViewModel();

            return View(listBonusOrFines);
        }

        [HttpGet]
        public ActionResult CreateBonusOrFine()
        {
            GetSelectListOfEmployees();
            return View();
        }

        [HttpPost]
        public ActionResult CreateBonusOrFine(BonusOrFineViewModel bonusOrFineViewModel)
        {
            if (ModelState.IsValid)
            {
                var bonusOrFineDTO = bonusOrFineViewModel.ToBonusOrFineDTO();
                employeeService.AddBonusOrFine(bonusOrFineDTO);

                return RedirectToAction("CreateBonusOrFine");
            }

            GetSelectListOfEmployees();
            return View(bonusOrFineViewModel);
        }

        [HttpGet]
        public ActionResult DeleteBonusOrFine(int? id)
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
        public ActionResult DeleteBonusOrFineConfirmed(int? id)
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
        public ActionResult EditBonusOrFine(int? id)
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
        public ActionResult EditBonusOrFine(BonusOrFineViewModel bonusOrFineViewModel)
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

            GetEmployeeViewModel(bonusOrFineDTO.EmployeeId);

            return View(bonusOrFineDTO);
        }

        [HttpGet]
        public ActionResult ListSickLeaves()
        {
            var listSickLeaves = employeeService.GetSickLeaves().ToListSickLeaveViewModel();

            return View(listSickLeaves);
        }

        [HttpGet]
        public ActionResult CreateSickLeave()
        {
            GetSelectListOfEmployees();
            return View();
        }

        [HttpPost]
        public ActionResult CreateSickLeave(SickLeaveViewModel sickLeaveViewModel)
        {
            if (ModelState.IsValid)
            {
                var sickLeaveDTO = sickLeaveViewModel.ToSickLeaveDTO();
                employeeService.AddSickLeave(sickLeaveDTO);

                return RedirectToAction("CreateSickLeave");
            }

            GetSelectListOfEmployees();
            return View(sickLeaveViewModel);
        }

        [HttpGet]
        public ActionResult DeleteSickLeave(int? id)
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
        public ActionResult DeleteSickLeaveConfirmed(int? id)
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
        public ActionResult EditSickLeave(int? id)
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
        public ActionResult EditSickLeave(SickLeaveViewModel sickLeaveViewModel)
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

            GetEmployeeViewModel(sickLeaveDTO.EmployeeId);

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
            ViewBag.Employees = new SelectList(employees, "Id", "NSP");

            return ViewBag.Employees;
        }


        [NonAction]
        public SelectList GetSelectListOfDepartaments()
        {
            var departaments = employeeService.GetDepartaments().ToListDepartamentViewModel();
            ViewBag.Departaments = new SelectList(departaments, "Id", "Title");

            return ViewBag.Departaments;
        }

        [NonAction]
        public EmployeeViewModel GetEmployeeViewModel(int id)
        {
            ViewBag.Employee = employeeService.GetEmployee(id).ToEmployeeViewModel();
            return ViewBag.Employee;
        }
        

    }
}

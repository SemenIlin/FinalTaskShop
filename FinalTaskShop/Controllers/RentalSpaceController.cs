using BLShop.WEB.Interfaces;
using FinalTaskShop.Infrastructure;
using FinalTaskShop.ViewModels.ForRentalSpaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalTaskShop.Controllers
{
    public class RentalSpaceController : Controller
    {
        private readonly IRentalSpaceService rentalSpaceService;

        public RentalSpaceController(IRentalSpaceService rentalSpaceService)
        {
            this.rentalSpaceService = rentalSpaceService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateRentalSpace()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRentalSpace(RentalSpaceViewModel rentalSpaceViewModel)
        {
            if (ModelState.IsValid)
            {
                var rentalSpaceDTO = rentalSpaceViewModel.ToRentalSpaceDTO();
                rentalSpaceService.AddRentalSpace(rentalSpaceDTO);

                return RedirectToAction("CreateRentalSpace");
            }

            return View(rentalSpaceViewModel);
        }
        
        [HttpGet]
        public ActionResult ListRentalSpaces()
        {
            var listRentalSpacesViewModel = rentalSpaceService.GetRentalSpaces().ToListRentalSpaceViewModel();
            return View(listRentalSpacesViewModel);
        }

        [HttpGet]
        public ActionResult DeleteRentalSpace(int? id)
        {
            try
            {
                var rentalSpaceViewModel = rentalSpaceService.GetRentalSpace(id.Value).ToRentalSpaceViewModel();

                return View(rentalSpaceViewModel);
            }
            catch
            {
                return NotFound();
            }
        }
        
        [HttpPost, ActionName("DeleteRentalSpace")]
        public ActionResult DeleteRentalSpaceConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalSpace = rentalSpaceService.GetRentalSpace(id.Value);
            if (rentalSpace == null)
            {
                return NotFound();
            }

            rentalSpaceService.DeleteRentalSpace(id.Value);

            return RedirectToAction("ListRentalSpaces");
        }

        [HttpGet]
        public ActionResult EditRentalSpace(int? id)
        {
            try
            {
                var rentalSpaceViewModel = rentalSpaceService.GetRentalSpace(id.Value).ToRentalSpaceViewModel();
                
                return View(rentalSpaceViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult EditRentalSpace(RentalSpaceViewModel rentalSpaceViewModel)
        {
            var rentalSpaceDTO = rentalSpaceViewModel.ToRentalSpaceDTO();
            rentalSpaceService.UpdateRentalSpace(rentalSpaceDTO);

            return RedirectToAction("ListRentalSpaces");
        }
    }
}

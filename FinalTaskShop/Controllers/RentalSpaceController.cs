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
            var rentalSpaceDTO = rentalSpaceViewModel.ToRentalSpaceDTO();
            rentalSpaceService.AddRentalSpace(rentalSpaceDTO);

            return RedirectToAction("CreateRentalSpace");
        }
        
        [HttpGet]
        public ActionResult ListRentalSpaces()
        {
            var listRentalSpaces = rentalSpaceService.GetRentalSpaces().ToListRentalSpaceViewModel();
            return View(listRentalSpaces);
        }

        [HttpGet]
        public ActionResult DeleteRentalSpace(int? id)
        {
            try
            {
                var rentalSpace = rentalSpaceService.GetRentalSpace(id.Value);

                return View(rentalSpace.ToRentalSpaceViewModel());
            }
            catch
            {
                return RedirectToAction("NotFound");
            }
        }
        
        [HttpPost, ActionName("DeleteRentalSpace")]
        public ActionResult DeleteRentalSpaceConfirmed(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound");
            }

            var rentalSpace = rentalSpaceService.GetRentalSpace(id.Value);
            if (rentalSpace == null)
            {
                return RedirectToAction("NotFound");
            }

            rentalSpaceService.DeleteRentalSpace(id.Value);

            return RedirectToAction("ListRentalSpaces");
        }

        [HttpGet]
        public ActionResult EditRentalSpace(int? id)
        {
            try
            {
                var rentalSpace = rentalSpaceService.GetRentalSpace(id.Value);
                var rentalSpaceViewModel = rentalSpace.ToRentalSpaceViewModel();

                return View(rentalSpaceViewModel);
            }
            catch
            {
                return RedirectToAction("NotFound");
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

using BLShop.WEB.Interfaces;
using FinalTaskShop.ViewModels.ForGood;
using Microsoft.AspNetCore.Mvc;
using FinalTaskShop.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalTaskShop.Controllers
{
    public class GoodController : Controller
    {
        private readonly IGoodService goodService;

        public GoodController(IGoodService goodService)
        {
            this.goodService = goodService;
        }

        [HttpGet]
        public ActionResult Transportation()
        {
            return View();        
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListGoods()
        {
            var listGoodsViewModel = goodService.GetGoods().ToListGoodViewModel();
         
            return View(listGoodsViewModel);
        }

        [HttpGet]
        public ActionResult GoodCreate()
        {
            GetSelectListOfCompanies();
            return View();
        }

        [HttpPost]
        public ActionResult GoodCreate(GoodViewModel goodViewModel)
        {
            if (ModelState.IsValid)
            {
                var goodDTO = goodViewModel.ToGoodDTO();
                goodService.AddGood(goodDTO);

                return RedirectToAction("GoodCreate");
            }

            GetSelectListOfCompanies();

            return View(goodViewModel);
        }

        [HttpGet]
        public ActionResult DeleteGood(int? id)
        {
            try
            {
                var goodViewModel = goodService.GetGood(id.Value).ToGoodViewModel();

                return View(goodViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("DeleteGood")]
        public ActionResult DeleteGoodConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = goodService.GetGood(id.Value);
            if (good == null)
            {
                return NotFound();
            }

            goodService.DeleteGood(id.Value);

            return RedirectToAction("ListGoods");
        }

        [HttpGet]
        public ActionResult EditGood(int? id)
        {
            try
            {
                GetSelectListOfCompanies();

                var goodViewModel = goodService.GetGood(id.Value).ToGoodViewModel();

                return View(goodViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult EditGood(GoodViewModel goodViewModel)
        {
            var goodDTO = goodViewModel.ToGoodDTO();
            goodService.UpdateGood(goodDTO);

            return RedirectToAction("ListGoods");
        }

        [HttpGet]
        public ActionResult CreateTransportation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTransportation(TransportationViewModel transportationViewModel)
        {
            if (ModelState.IsValid)
            {
                var transportationDTO = transportationViewModel.ToTransportationDTO();
                goodService.AddTransportation(transportationDTO);

                return RedirectToAction("CreateTransportation");
            }

            return View(transportationViewModel);
        }

        [HttpGet]
        public ActionResult ListTransportations()
        {
            var listTranportationsViewModel = goodService.GetTransportations().ToListTransposrtationViewModel();
            return View(listTranportationsViewModel);
        }

        [HttpGet]
        public ActionResult DeleteTransportation(int? id)
        {
            try
            {
                var transportationViewModel = goodService.GetTransportation(id.Value).ToTransportationViewModel();
                return View(transportationViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("DeleteTransportation")]
        public ActionResult DeleteTransportationConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = goodService.GetTransportation(id.Value);
            if (transportation == null)
            {
                return NotFound();
            }

            goodService.DeleteTransportation(id.Value);

            return RedirectToAction("ListTransportations");
        }

        [HttpGet]
        public ActionResult DetailsTransportation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var transportationViewModel = goodService.GetTransportation(id.Value).ToTransportationViewModel();

            if (transportationViewModel == null)
            {
                return NotFound();
            }

            return View(transportationViewModel);            
        }

        [HttpGet]
        public ActionResult EditTransportation(int? id)
        {
            try
            {
                var transportationViewModel = goodService.GetTransportation(id.Value).ToTransportationViewModel();
                
                return View(transportationViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult EditTransportation(TransportationViewModel transportationViewModel)
        {
            var transportationDTO = transportationViewModel.ToTransportationDTO();
            goodService.UpdateTransportation(transportationDTO);

            return RedirectToAction("ListTransportations");
        }

        [HttpGet]
        public ActionResult CreateRepair()
        {
            GetSelectListOfCompanies();

            return View();
        }

        [HttpPost]
        public ActionResult CreateRepair(RepairViewModel repairViewModel)
        {
            if (ModelState.IsValid)
            {
                var repairDTO = repairViewModel.ToRepairDTO();
                goodService.CreateRepair(repairDTO);

                return RedirectToAction("CreateRepair");
            }

            GetSelectListOfCompanies();

            return View(repairViewModel);
        }

        [HttpGet]
        public ActionResult ListRepairs()
        {
            var listRepairsViewModel = goodService.GetRepairs().ToListRepairViewModel();
            return View(listRepairsViewModel);
        }

        [HttpGet]
        public ActionResult DeleteRepair(int? id)
        {
            try
            {
                var repairViewModel = goodService.GetRepair(id.Value).ToRepairViewModel();

                return View(repairViewModel);
            }
            catch
            {
                return NotFound();
            }     
        }

        [HttpPost, ActionName("DeleteRepair")]
        public ActionResult DeleteRepairConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = goodService.GetRepair(id.Value);
            if (repair == null)
            {
                return NotFound();
            }

            goodService.DeleteRepair(id.Value);

            return RedirectToAction("ListRepairs");
        }

        [HttpGet]
        public ActionResult EditRepair(int? id)
        {
            try
            {
                var repairViewModel = goodService.GetRepair(id.Value).ToRepairViewModel();
                
                GetSelectListOfCompanies();

                return View(repairViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult EditRepair(RepairViewModel repairViewModel)
        {
            var repairDTO = repairViewModel.ToRepairDTO();
            goodService.UpdateRepair(repairDTO);

            return RedirectToAction("ListRepairs");
        }

        [NonAction]
        public SelectList GetSelectListOfCompanies()
        {
            var transportationCompanies = goodService.GetTransportations().ToListTransposrtationViewModel();
            ViewBag.Companies = new SelectList(transportationCompanies, "Id", "TitleTransport");

            return ViewBag.Companies;
        }
    }
}
using BLShop.WEB.Interfaces;
using FinalTaskShop.ViewModels.ForGood;
using Microsoft.AspNetCore.Mvc;
using FinalTaskShop.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalTaskShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGoodService goodService;

        public HomeController(IGoodService goodService)
        {
            this.goodService = goodService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListGoods()
        {
            var listGoods = goodService.GetGoods().ToListGoodViewModel();
         
            return View(listGoods);
        }

        [HttpGet]
        public ActionResult GoodCreate()
        {
            var transportationCompanies = goodService.GetTransportations().ToListTransposrtationViewModel();
            ViewBag.Companies = new SelectList(transportationCompanies, "Id", "TitleTransport");
            return View();
        }

        [HttpPost]
        public ActionResult GoodCreate(GoodViewModel goodViewModel)
        {
            var goodDTO = goodViewModel.ToGoodDTO();
            goodService.AddGood(goodDTO);

            return RedirectToAction("GoodCreate");
        }

        [HttpGet]
        public ActionResult DeleteGood(int? id)
        {
            try
            {
                var good = goodService.GetGood(id.Value);
                //ViewBag.Company = goodService.GetTransportation(good.TransportationId).ToTransportationViewModel().TitleTransport;
                
                return View(good.ToGoodViewModel());
            }
            catch
            {
                return RedirectToAction("NotFound");
            }
        }

        [HttpPost, ActionName("DeleteGood")]
        public ActionResult DeleteGoodConfirmed(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound");
            }

            var good = goodService.GetGood(id.Value);
            if (good == null)
            {
                return RedirectToAction("NotFound");
            }

            goodService.DeleteGood(id.Value);

            return RedirectToAction("ListGoods");
        }

        [HttpGet]
        public ActionResult EditGood(int? id)
        {
            try
            {
                var transportationCompanies = goodService.GetTransportations().ToListTransposrtationViewModel();
                ViewBag.Companies = new SelectList(transportationCompanies, "Id", "TitleTransport");

                var good = goodService.GetGood(id.Value);
                var goodViewModel = good.ToGoodViewModel();


                return View(goodViewModel);
            }
            catch
            {
                return RedirectToAction("NotFound");
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
            var transportationDTO = transportationViewModel.ToTransportationDTO();
            goodService.AddTransportation(transportationDTO);

            return RedirectToAction("CreateTransportation");
        }

        [HttpGet]
        public ActionResult ListTransportations()
        {
            var listTranportations = goodService.GetTransportations().ToListTransposrtationViewModel();
            return View(listTranportations);
        }

        [HttpGet]
        public ActionResult DeleteTransportation(int? id)
        {
            try
            {
                var transportation = goodService.GetTransportation(id.Value);
                return View(transportation.ToTransportationViewModel());
            }
            catch
            {
                return RedirectToAction("NotFound");
            }
        }

        [HttpPost, ActionName("DeleteTransportation")]
        public ActionResult DeleteTransportationConfirmed(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound");
            }

            var transportation = goodService.GetTransportation(id.Value);
            if (transportation == null)
            {
                return RedirectToAction("NotFound");
            }

            goodService.DeleteTransportation(id.Value);

            return RedirectToAction("ListTransportations");
        }

        [HttpGet]
        public ActionResult DetailsTransportation(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound");
            }
            var transportation = goodService.GetTransportation(id.Value);

            if (transportation == null)
            {
                return RedirectToAction("NotFound");
            }

            return View(transportation);            
        }

        [HttpGet]
        public ActionResult EditTransportation(int? id)
        {
            try
            {
                var transportation = goodService.GetTransportation(id.Value);
                var transportationViewModel = transportation.ToTransportationViewModel();

                return View(transportationViewModel);
            }
            catch
            {
                return RedirectToAction("NotFound");
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
            var transportationCompanies = goodService.GetTransportations().ToListTransposrtationViewModel();
            ViewBag.Companies = new SelectList(transportationCompanies, "Id", "TitleTransport");

            return View();
        }

        [HttpPost]
        public ActionResult CreateRepair(RepairViewModel repairViewModel)
        {
            var repairDTO = repairViewModel.ToRepairDTO();
            goodService.CreateRepair(repairDTO);

            return RedirectToAction("CreateRepair");
        }

        [HttpGet]
        public ActionResult ListRepairs()
        {
            var listRepairs = goodService.GetRepairs().ToListRepairViewModel();
            return View(listRepairs);
        }

        [HttpGet]
        public ActionResult DeleteRepair(int? id)
        {
            try
            {
                var repair = goodService.GetRepair(id.Value);

                return View(repair.ToRepairViewModel());
            }
            catch
            {
                return RedirectToAction("NotFound");
            }     
        }

        [HttpPost, ActionName("DeleteRepair")]
        public ActionResult DeleteRepairConfirmed(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound");
            }

            var repair = goodService.GetRepair(id.Value);
            if (repair == null)
            {
                return RedirectToAction("NotFound");
            }

            goodService.DeleteRepair(id.Value);

            return RedirectToAction("ListRepairs");
        }

        [HttpGet]
        public ActionResult EditRepair(int? id)
        {
            try
            {
                var repair = goodService.GetRepair(id.Value);
                var repairViewModel = repair.ToRepairViewModel();

                var transportationCompanies = goodService.GetTransportations().ToListTransposrtationViewModel();
                ViewBag.Companies = new SelectList(transportationCompanies, "Id", "TitleTransport");

                return View(repairViewModel);
            }
            catch
            {
                return RedirectToAction("NotFound");
            }
        }

        [HttpPost]
        public ActionResult EditRepair(RepairViewModel repairViewModel)
        {
            var repairDTO = repairViewModel.ToRepairDTO();
            goodService.UpdateRepair(repairDTO);

            return RedirectToAction("ListRepairs");
        }
    }
}
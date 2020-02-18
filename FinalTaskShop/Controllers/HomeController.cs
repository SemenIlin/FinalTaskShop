using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLShop.WEB.Interfaces;
using BLShop.WEB.ModelsDTO.ForGood;
using DAShop.WEB.Interfaces;
using FinalTaskShop.ViewModels.ForGood;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalTaskShop.Infrastructure;

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
            if (id == null)
            {
                return RedirectToAction("NotFound");
            }

            var good = goodService.GetGood(id.Value);
            if (good == null)
            {
                return RedirectToAction("NotFound");
            }

            return View(good.ToGoodViewModel());
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

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditGood(int? id)
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

            var goodViewModel = good.ToGoodViewModel();         

            return View(goodViewModel);
        }

        [HttpPost]
        public ActionResult EditGood(GoodViewModel goodViewModel)
        {
            var goodDTO = goodViewModel.ToGoodDTO();
            goodService.UpdateGood(goodDTO);

            return RedirectToAction("Index");
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
            if (id == null)
            {
                return RedirectToAction("NotFound");
            }

            var transportation = goodService.GetTransportation(id.Value);
            if (transportation == null)
            {
                return RedirectToAction("NotFound");
            }

            return View(transportation.ToTransportationViewModel());
        }

        [HttpPost, ActionName("DeleteTransportation")]//создать каскадное удаление?
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

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTransportation(int? id)
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

            var transportationViewModel = transportation.ToTransportationViewModel();

            return View(transportationViewModel);
        }

        [HttpPost]
        public ActionResult EditTransportation(TransportationViewModel transportationViewModel)
        {
            var transportationDTO = transportationViewModel.ToTransportationDTO();
            goodService.UpdateTransportation(transportationDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateRepair()
        {
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
            if (id == null)
            {
                return RedirectToAction("NotFound");
            }

            var repair = goodService.GetRepair(id.Value);
            if (repair == null)
            {
                return RedirectToAction("NotFound");
            }

            return View(repair.ToRepairViewModel());
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

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditRepair(int? id)
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

            var repairViewModel = repair.ToRepairViewModel();

            return View(repairViewModel);
        }

        [HttpPost]
        public ActionResult EditRepair(RepairViewModel repairViewModel)
        {
            var repairDTO = repairViewModel.ToRepairDTO();
            goodService.UpdateRepair(repairDTO);

            return RedirectToAction("Index");
        }

























        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
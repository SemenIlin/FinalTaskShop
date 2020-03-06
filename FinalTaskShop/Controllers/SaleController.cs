using BLShop.WEB.Interfaces;
using FinalTaskShop.Infrastructure;
using FinalTaskShop.ViewModels.ForGood;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalTaskShop.Controllers
{
    public class SaleController : Controller
    {
        private readonly IReportOfSaleService reportOfSaleService;
        private readonly IGoodService goodService;

        public SaleController(
            IReportOfSaleService reportOfSaleService,
            IGoodService goodService)
        {
            this.reportOfSaleService = reportOfSaleService;
            this.goodService = goodService;
        }
       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateReportOfSale()
        {
            GetSelectListOfGoods();
            return View();
        }

        [HttpPost]
        public ActionResult CreateReportOfSale(ReportOfSaleViewModel reportOfSaleViewModel)
        {
            if (ModelState.IsValid)
            {
                var reportOfSaleDTO = reportOfSaleViewModel.ToReportOfSaleDTO();
                reportOfSaleService.AddReportOfSale(reportOfSaleDTO);

                return RedirectToAction("CreateReportOfSale");
            }

            GetSelectListOfGoods();
            return View(reportOfSaleViewModel);
        }

        [HttpGet]
        public ActionResult ListReportOfSales()
        {
            var listReportOfSaleViewModel = reportOfSaleService.GetReportOfSales().ToListReportOfSaleViewModel(goodService);
            return View(listReportOfSaleViewModel);
        }

        [HttpGet]
        public ActionResult DeleteReportOfSale(int? id)
        {
            try
            {
                var reportOfSaleViewModel = reportOfSaleService.GetReportOfSale(id.Value).ToReportOfSaleViewModel(goodService);
               
                return View(reportOfSaleViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("DeleteReportOfSale")]
        public ActionResult DeleteReportOfSaleConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportOfSale = reportOfSaleService.GetReportOfSale(id.Value);
            if (reportOfSale == null)
            {
                return NotFound();
            }

            reportOfSaleService.DeleteReportOfSale(id.Value);

            return RedirectToAction("ListReportOfSales");
        }

        [HttpGet]
        public ActionResult EditReportOfSale(int? id)
        {
            try
            {
                var reportOfSaleViewModel = reportOfSaleService.GetReportOfSale(id.Value).ToReportOfSaleViewModel(goodService);

                GetSelectListOfGoods();
                return View(reportOfSaleViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult EditReportOfSale(ReportOfSaleViewModel reportOfSaleViewModel)
        {
            var reportOfSaleDTO = reportOfSaleViewModel.ToReportOfSaleDTO();
            reportOfSaleService.UpdateReportOfSale(reportOfSaleDTO);

            return RedirectToAction("ListReportOfSales");
        }

        [NonAction]
        public SelectList GetSelectListOfGoods()
        {
            var goods = goodService.GetTransportations().ToListTransposrtationViewModel();
            ViewBag.Goods = new SelectList(goods, "Id", "Title");

            return ViewBag.Goods;
        }
    }
}

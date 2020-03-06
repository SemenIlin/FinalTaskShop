using BLShop.WEB.Infrastructure;
using BLShop.WEB.Interfaces;
using BLShop.WEB.ModelsDTO.ForGood;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForGood;
using System.Collections.Generic;

namespace BLShop.WEB.Services
{
    public class ReportOfSaleService : IReportOfSaleService
    {
        private readonly IRepository<ReportOfSale> reportOfSaleRepository;

        public ReportOfSaleService(IRepository<ReportOfSale> reportOfSaleRepository)
        {
            this.reportOfSaleRepository = reportOfSaleRepository;
        }

        public void AddReportOfSale(ReportOfSaleDTO reportOfSaleDTO)
        {
            reportOfSaleRepository.Create(reportOfSaleDTO.ToReportOfSale());
        }

        public void DeleteReportOfSale(int id)
        {
            reportOfSaleRepository.Delete(id);
        }

        public ReportOfSaleDTO GetReportOfSale(int id)
        {
            return reportOfSaleRepository.Get(id).ToReportOfSaleDTO();
        }

        public IEnumerable<ReportOfSaleDTO> GetReportOfSales()
        {
            return reportOfSaleRepository.GetAll().ToListReportOfSaleDTO();
        }

        public void UpdateReportOfSale(ReportOfSaleDTO reportOfSaleDTO)
        {
            reportOfSaleRepository.Update(reportOfSaleDTO.ToReportOfSale());
        }
    }
}

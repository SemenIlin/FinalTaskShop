using BLShop.WEB.ModelsDTO.ForGood;
using System.Collections.Generic;
namespace BLShop.WEB.Interfaces
{
    public interface IReportOfSaleService
    {
        void AddReportOfSale(ReportOfSaleDTO reportOfSaleDTO);
        IEnumerable<ReportOfSaleDTO> GetReportOfSales();
        ReportOfSaleDTO GetReportOfSale(int id);
        void DeleteReportOfSale(int id);
        void UpdateReportOfSale(ReportOfSaleDTO reportOfSaleDTO);
    }
}

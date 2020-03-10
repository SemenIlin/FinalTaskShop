using System.Collections.Generic;

namespace DAShop.WEB.Models.ForGood
{
    public class Good
    {
        public Good()
        {
            ReportOfSales = new List<ReportOfSale>();
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Qyantity { get; set; }

        public Transportation Transportation { get; set; }
        public int TransportationId { get; set; }

        public ICollection<ReportOfSale> ReportOfSales { get; set; }
    }
}

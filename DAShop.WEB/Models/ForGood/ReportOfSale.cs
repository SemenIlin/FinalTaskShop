namespace DAShop.WEB.Models.ForGood
{
    public class ReportOfSale
    {
        public int Id { get; set; }

        public int QuantityOfSales { get; set; }

        public Good Good { get; set; }
        public int GoodId { get; set; }
    }
}

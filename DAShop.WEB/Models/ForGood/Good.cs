namespace DAShop.WEB.Models.ForGood
{
    public class Good
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Qyantiy { get; set; }

        public Transportation Transportation { get; set; }
        public int TransportationId { get; set; }
    }
}

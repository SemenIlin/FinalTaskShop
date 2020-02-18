namespace FinalTaskShop.ViewModels.ForGood
{
    public class GoodViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Qyantity { get; set; }
        public int TransportationId { get; set; }
    }
}

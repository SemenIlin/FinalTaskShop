using DAShop.WEB.Models.ForGood;

namespace BLShop.WEB.ModelsDTO.ForGood
{
    public class GoodDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Qyantity { get; set; }

        public Transportation Transportation { get; set; }
        public int TransportationId { get; set; }
    }
}

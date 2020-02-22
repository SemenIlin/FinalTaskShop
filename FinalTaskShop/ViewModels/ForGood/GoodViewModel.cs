using DAShop.WEB.Models.ForGood;
using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForGood
{
    public class GoodViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public decimal SalePrice { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int Qyantity { get; set; }

        public Transportation TransportationDTO { get; set; }
        public int TransportationId { get; set; }
    }
}

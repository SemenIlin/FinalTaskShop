using DAShop.WEB.Models.ForGood;
using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForGood
{
    public class GoodViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Поле должно быть заполнено")]
        [Display(Name = "Title")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Purchase price")]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 9999999999.99)]
        public decimal PurchasePrice { get; set; }

        [Required]
        [Display(Name = "Sale price")]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 9999999999.99)]
        public decimal SalePrice { get; set; }

        [Required]
        [Display(Name = "Qyantity")]
        [Range(0, 999999999)]
        public int Qyantity { get; set; }

        public Transportation TransportationDTO { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int TransportationId { get; set; }
    }
}

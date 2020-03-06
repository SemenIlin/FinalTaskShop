
using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForRentalSpaces
{
    public class RentalSpaceViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "Название не может быть больше 100 символов")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Renta")]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 9999999999.99)]
        public decimal Rental { get; set; }

        [Display(Name = "Month")]
        public System.DateTime Month { get; set; }
    }
}

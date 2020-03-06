using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForEmployee
{
    public class BonusOrFineViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Title bonus/fine")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 100 символов")]
        public string Title { get; set; }

        
        [Display(Name = "Amount of bonus/fine")]
        [Required(ErrorMessage = "Введите компенсацию")]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(-999999999.99, 9999999999.99)]
        public decimal AmountOfBonusOrFine { get; set; }
                
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int EmployeeId { get; set; }
    }
}

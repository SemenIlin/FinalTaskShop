using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForEmployee
{
    public class PositionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Введите компенсацию")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 100 символов")]
        public string Title { get; set; }

        [Display(Name = "Min salary")]
        [Required(ErrorMessage = "Введите минимальную зарплату")]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 9999999999.99)]
        public decimal MinSalary { get; set; }
    }
}

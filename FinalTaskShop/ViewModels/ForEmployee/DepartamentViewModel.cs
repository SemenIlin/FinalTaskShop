using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForEmployee
{
    public class DepartamentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Name of departament")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Title { get; set; }
    }
}

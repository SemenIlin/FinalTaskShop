using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForEmployee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Name")]        
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 20 символов")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Surname")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 40 символов")]
        public string SurName { get; set; }
                
        [Display(Name = "Patronymic")]        
        [StringLength(30, ErrorMessage = "Длина строки должна быть до 30 символов")]
        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int PositionId { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int DepartamentId { get; set; }

        public string NSP { get; set; }
    }
}

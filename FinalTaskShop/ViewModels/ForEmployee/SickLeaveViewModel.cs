using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForEmployee
{
    public class SickLeaveViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Start of sick leave")]
        public DateTime StartOfTheSickLeave { get; set; }

        [Display(Name = "Finish of sick leave")]
        public DateTime FinishOfTheSickLeave { get; set; }

        [Required]
        [Display(Name = "Monetary compensation")]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 9999999999.99)]
        public decimal MonetaryCompensation { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int EmployeeId { get; set; }
    }
}

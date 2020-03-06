using DAShop.WEB.Models.ForGood;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForGood
{
    public class RepairViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Поле должно быть заполнено")]
        [Display(Name = "Title")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Title { get; set; }

        [Display(Name = "Date of repair")]
        public DateTime DateOfRepair { get; set; }

        [Required]
        [Display(Name = "Cost of repair")]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public decimal CostOfRepair { get; set; }

        public Transportation TransportationDTO { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int TransportationId { get; set; }
    }
}

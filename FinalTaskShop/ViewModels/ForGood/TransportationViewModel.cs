using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForGood
{
    public class TransportationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Name of the transport company")]
        [StringLength(100, ErrorMessage = "Название не может быть больше 100 символов")]
        public string TitleTransport { get; set; }

        [Display(Name = "Date of send")]
        public DateTime DateOfSend { get; set; }

        [Display(Name = "Date of arrival")]
        public DateTime DateOfArrival { get; set; }

        [Required]
        [Display(Name = "Price")]
        [RegularExpression(@"^\d+.\d{0,2}$")]
        [Range(0, 9999999999.99)]
        public decimal CostOfDelivery { get; set; }
    }
}

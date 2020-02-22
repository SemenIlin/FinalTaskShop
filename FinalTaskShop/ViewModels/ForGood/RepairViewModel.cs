using DAShop.WEB.Models.ForGood;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForGood
{
    public class RepairViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public DateTime DateOfRepair { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public decimal CostOfRepair { get; set; }

        public Transportation TransportationDTO { get; set; }
        public int TransportationId { get; set; }
    }
}

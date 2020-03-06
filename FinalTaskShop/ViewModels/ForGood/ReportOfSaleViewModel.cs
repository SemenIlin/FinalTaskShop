using System.ComponentModel.DataAnnotations;

namespace FinalTaskShop.ViewModels.ForGood
{
    public class ReportOfSaleViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "QyantityOfSales")]
        [Range(0, 999999999)]
        public int QuantityOfSales { get; set; }

        [Required]
        public int GoodId { get; set; }

        public string TitleOfGood { get; set; }
    }
}

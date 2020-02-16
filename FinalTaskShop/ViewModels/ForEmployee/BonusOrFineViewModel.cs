using System;

namespace FinalTaskShop.ViewModels.ForEmployee
{
    public class BonusOrFineViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal AmountOfBonusOrFine { get; set; }
        public DateTime Date { get; set; }
    }
}

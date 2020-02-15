using System;

namespace DAShop.WEB.Models.ForEmployee
{
    public class BonusOrFine
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal AmountOfBonusOrFine { get; set; }
        public DateTime Date { get; set; }

        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }
    }
}

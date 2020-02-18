using System;

namespace DAShop.WEB.Models.ForEmployee
{
    public class SickLeave
    {
        public int Id { get; set; }

        public DateTime StartOfTheSickLeave { get; set; }
        public DateTime FinishOfTheSickLeave { get; set; }

        public decimal MonetaryCompensation { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}

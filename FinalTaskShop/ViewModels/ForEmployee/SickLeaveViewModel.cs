using System;

namespace FinalTaskShop.ViewModels.ForEmployee
{
    public class SickLeaveViewModel
    {
        public int Id { get; set; }

        public DateTime StartOfTheSickLeave { get; set; }
        public DateTime FinishOfTheSickLeave { get; set; }

        public decimal MonetaryCompensation { get; set; }

        public int EmployeeId { get; set; }
    }
}

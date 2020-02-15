using System;

namespace BLShop.WEB.ModelsDTO.ForEmployee
{
    public class SickLeaveDTO
    {
        public int Id { get; set; }

        public DateTime StartOfTheSickLeave { get; set; }
        public DateTime FinishOfTheSickLeave { get; set; }

        public decimal MonetaryCompensation { get; set; }
        public int EmployeeId { get; set; }
    }
}

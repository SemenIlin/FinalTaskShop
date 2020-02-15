using System;

namespace BLShop.WEB.ModelsDTO.ForEmployee
{
    public class BonusOrFineDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal AmountOfBonusOrFine { get; set; }
        public DateTime Date { get; set; }

        public int EmployeeId { get; set; }
    }
}

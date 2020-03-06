using System;

namespace BLShop.WEB.ModelsDTO.ForEmployee
{
    public class PaymentAccountDTO
    {
        public int Id { get; set; }

        public DateTime Payday { get; set; }
        public decimal Salary { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public int PositionId { get; set; }

        public int EmployeeId { get; set; }
    }
}

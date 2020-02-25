using DAShop.WEB.Models.ForEmployee;
using System;

namespace BLShop.WEB.ModelsDTO.ForEmployee
{
    public class PaymentAccountDTO
    {
        public int Id { get; set; }

        public DateTime Payday { get; set; }
        public decimal Salary { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}

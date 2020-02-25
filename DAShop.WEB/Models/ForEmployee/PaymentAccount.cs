using System;

namespace DAShop.WEB.Models.ForEmployee
{
    public class PaymentAccount
    {
        public int Id { get; set; }

        public DateTime Payday { get; set; }
        public decimal Salary { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}

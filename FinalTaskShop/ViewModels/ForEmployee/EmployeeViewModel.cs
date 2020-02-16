using System;

namespace FinalTaskShop.ViewModels.ForEmployee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }
    }
}

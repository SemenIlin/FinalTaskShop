using System;
using System.Collections.Generic;

namespace DAShop.WEB.Models.ForEmployee
{
    public class Employee
    {
        public Employee()
        {
            BonusOrFines = new List<BonusOrFine>();
            SickLeaves = new List<SickLeave>();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<BonusOrFine> BonusOrFines { get; set; }       
        public ICollection<SickLeave> SickLeaves { get; set; }

        public Position Position { get; set; }
        public int PositionId { get; set; }
    }
}

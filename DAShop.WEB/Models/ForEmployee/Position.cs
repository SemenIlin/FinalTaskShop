using System.Collections.Generic;

namespace DAShop.WEB.Models.ForEmployee
{
    public class Position
    {
        public Position()
        {
            Employees = new List<Employee>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal MinSalary { get; set; }

        public ICollection<Employee> Employees  { get; set; }
    }
}

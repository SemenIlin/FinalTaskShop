using System;

namespace BLShop.WEB.ModelsDTO.ForEmployee
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public int PositionId { get; set; }
    }
}

using BLShop.WEB.Models.ForEmployee;
using BLShop.WEB.ModelsDTO.ForEmployee;
using System.Collections.Generic;

namespace BLShop.WEB.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeDTO employee);
        IEnumerable<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(int? id);

        void AddBonusOrFine(BonusOrFineDTO bonusOrFine);
        void AddSickLeave(SickLeaveDTO sickLeave);
        void CreatePosition(PositionDTO position);

        void Dispose();
    }
}

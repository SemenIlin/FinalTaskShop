using BLShop.WEB.Models.ForEmployee;
using BLShop.WEB.ModelsDTO.ForEmployee;
using System.Collections.Generic;

namespace BLShop.WEB.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeDTO employee);
        IEnumerable<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(int id);
        void DeleteEmployee(int id);
        void UpdateEmployee(EmployeeDTO employee);

        void AddBonusOrFine(BonusOrFineDTO bonusOrFine);
        IEnumerable<BonusOrFineDTO> GetBonusOrFines();
        BonusOrFineDTO GetBonusOrFine(int id);
        void DeleteBonusOrFine(int id);
        void UpdateBonusOrFine(BonusOrFineDTO bonusOrFine);

        void AddSickLeave(SickLeaveDTO sickLeave);
        IEnumerable<SickLeaveDTO> GetSickLeaves();
        SickLeaveDTO GetSickLeave(int id);
        void DeleteSickLeave(int id);
        void UpdateSickLeave(SickLeaveDTO sickLeave);

        void CreatePosition(PositionDTO position);
        IEnumerable<PositionDTO> GetPositions();
        PositionDTO GetPosition(int id);
        void DeletePosition(int id);
        void UpdatePosition(PositionDTO position);

        void CreateDepartament(DepartamentDTO departament);
        IEnumerable<DepartamentDTO> GetDepartaments();
        DepartamentDTO GetDepartament(int id);
        void DeleteDepartament(int id);
        void UpdateDepartament(DepartamentDTO departament);

        void Dispose();//?
    }
}

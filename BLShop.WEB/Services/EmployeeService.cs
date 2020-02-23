using BLShop.WEB.Infrastructure;
using BLShop.WEB.Interfaces;
using BLShop.WEB.Models.ForEmployee;
using BLShop.WEB.ModelsDTO.ForEmployee;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using System;
using System.Collections.Generic;

namespace BLShop.WEB.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> employees;
        private readonly IRepository<BonusOrFine> bonusOfFines;
        private readonly IRepository<Position> positions;
        private readonly IRepository<SickLeave> sickLeaves;

        public EmployeeService(
            IRepository<Employee> employees,
            IRepository<BonusOrFine> bonusOfFines,
            IRepository<Position> positions,
            IRepository<SickLeave> sickLeaves
            )
        {
            this.employees = employees;
            this.bonusOfFines = bonusOfFines;
            this.positions = positions;
            this.sickLeaves = sickLeaves;
        }

        public void AddBonusOrFine(BonusOrFineDTO bonusOrFine)
        {
            var bonus = bonusOrFine.ToBonusOrFine();
            bonusOfFines.Create(bonus);
            
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = employeeDTO.ToEmployee();

            employees.Create(employee);
        }

        public void AddSickLeave(SickLeaveDTO sickLeaveDTO)
        {
            var sickLeave = sickLeaveDTO.ToSickLeave();

            sickLeaves.Create(sickLeave);
        }

        public void CreatePosition(PositionDTO positionDTO)
        {
            var position = positionDTO.ToPosition();

            positions.Create(position);
        }

        public EmployeeDTO GetEmployee(int id)
        {
            var employee = employees.Get(id);
            if(employee == null)
            {
                throw new NullReferenceException();
            }

            return employee.ToEmployeeDTO();            
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            return employees.GetAll().ToListEmployeeDTO();
        }

        public void Dispose()
        {
            //Database.Dispose();
        }

        public void DeleteEmployee(int id)
        {
            employees.Delete(id);
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = employeeDTO.ToEmployee();
            employees.Update(employee);
        }

        public IEnumerable<BonusOrFineDTO> GetBonusOrFines()
        {
            return bonusOfFines.GetAll().ToListBonusOrFineDTO();
        }

        public BonusOrFineDTO GetBonusOrFine(int id)
        {
            var bonusOfFine = bonusOfFines.Get(id).ToBonusOrFineDTO();
            return bonusOfFine;
        }

        public void DeleteBonusOrFine(int id)
        {
            bonusOfFines.Delete(id);
        }

        public void UpdateBonusOrFine(BonusOrFineDTO bonusOrFineDTO)
        {
            var bonusOrFine = bonusOrFineDTO.ToBonusOrFine();
            bonusOfFines.Update(bonusOrFine);
        }

        public IEnumerable<SickLeaveDTO> GetSickLeaves()
        {
            return sickLeaves.GetAll().ToListSickLeaveDTO();
        }

        public SickLeaveDTO GetSickLeave(int id)
        {
            return sickLeaves.Get(id).ToSickLeaveDTO();
        }

        public void DeleteSickLeave(int id)
        {
            sickLeaves.Delete(id);
        }

        public void UpdateSickLeave(SickLeaveDTO sickLeaveDTO)
        {
            var sickLeave = sickLeaveDTO.ToSickLeave();
            sickLeaves.Update(sickLeave);
        }

        public IEnumerable<PositionDTO> GetPositions()
        {
            return positions.GetAll().ToListPositionDTO();
        }

        public PositionDTO GetPosition(int id)
        {
            return positions.Get(id).ToPositionDTO();
        }

        public void DeletePosition(int id)
        {
            positions.Delete(id);
        }

        public void UpdatePosition(PositionDTO positionDTO)
        {
            var position = positionDTO.ToPosition();
            positions.Update(position);
        }
    }
}

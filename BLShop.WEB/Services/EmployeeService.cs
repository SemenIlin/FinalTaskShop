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
        private IRepository<Employee> Employees { get; set; }
        private IRepository<BonusOrFine> BonusOfFines { get; set; }
        private IRepository<Position> Positions { get; set; }
        private IRepository<SickLeave> SickLeaves { get; set; }

        public EmployeeService(
            IRepository<Employee> employees,
            IRepository<BonusOrFine> bonusOfFines,
            IRepository<Position> positions,
            IRepository<SickLeave> sickLeaves
            )
        {
            Employees = employees;
            BonusOfFines = bonusOfFines;
            Positions = positions;
            SickLeaves = sickLeaves;
        }

        public void AddBonusOrFine(BonusOrFineDTO bonusOrFine)
        {
            var bonus = new BonusOrFine
            {
                Title = bonusOrFine.Title,
                AmountOfBonusOrFine = bonusOrFine.AmountOfBonusOrFine,
                Date = bonusOrFine.Date,
                EmployeeId = bonusOrFine.EmployeeId
            };

            BonusOfFines.Create(bonus);
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                Name = employeeDTO.Name,
                SurName = employeeDTO.SurName,
                Patronymic = employeeDTO.Patronymic,
                Birthday = employeeDTO.Birthday,

                PositionId = employeeDTO.PositionId
            };

            Employees.Create(employee);
        }

        public void AddSickLeave(SickLeaveDTO sickLeaveDTO)
        {
            var sickLeave = new SickLeave
            {
                StartOfTheSickLeave = sickLeaveDTO.StartOfTheSickLeave,
                FinishOfTheSickLeave = sickLeaveDTO.FinishOfTheSickLeave,

                MonetaryCompensation = sickLeaveDTO.MonetaryCompensation,
                EmployeeId = sickLeaveDTO.EmployeeId
            };

            SickLeaves.Create(sickLeave);
        }

        public void CreatePosition(PositionDTO positionDTO)
        {
            var position = new Position
            {
                Title = positionDTO.Title,
                MinSalary = positionDTO.MinSalary,
            };

            Positions.Create(position);
        }

        public EmployeeDTO GetEmployee(int? id)
        {
            if (id != null)
            {
                var employee = Employees.Get(id.Value);
                if(employee == null)
                {
                    throw new Exception("Сотрудник не найден.");
                }
                return new EmployeeDTO
                {
                    Name = employee.Name,
                    SurName = employee.SurName,
                    Patronymic = employee.Patronymic,
                    Birthday = employee.Birthday,
                    PositionId = employee.PositionId.Value
                };
            }
            else
            {
                throw new  NullReferenceException("Страница не найдена.");
            }
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //Database.Dispose();
        }
    }
}

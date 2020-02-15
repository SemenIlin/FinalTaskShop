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
        IEmployeeUnitOfWork Database { get; set; }

        public EmployeeService(IEmployeeUnitOfWork uow)
        {
            Database = uow;
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

            Database.BonusOfFines.Create(bonus);
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

            Database.Employees.Create(employee);
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

            Database.SickLeaves.Create(sickLeave);
        }

        public void CreatePosition(PositionDTO positionDTO)
        {
            var position = new Position
            {
                Title = positionDTO.Title,
                MinSalary = positionDTO.MinSalary,
            };

            Database.Positions.Create(position);
        }

        public EmployeeDTO GetEmployee(int? id)
        {
            if (id != null)
            {
                var employee = Database.Employees.Get(id.Value);
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
            Database.Dispose();
        }
    }
}

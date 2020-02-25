using BLShop.WEB.Models.ForEmployee;
using BLShop.WEB.Models.ForRentalSpaces;
using BLShop.WEB.ModelsDTO.ForEmployee;
using BLShop.WEB.ModelsDTO.ForGood;
using DAShop.WEB.Models.ForEmployee;
using DAShop.WEB.Models.ForGood;
using DAShop.WEB.Models.ForRentalSpaces;
using System.Collections.Generic;
using System.Linq;

namespace BLShop.WEB.Infrastructure
{
    public static class ModelsExtension
    {
        public static GoodDTO ToGoodDTO(this Good good)
        {
            return new GoodDTO
            {
                Id = good.Id,
                Title = good.Title,
                PurchasePrice = good.PurchasePrice,
                SalePrice = good.SalePrice,
                Qyantity = good.Qyantity,
                Transportation = good.Transportation,
                TransportationId = good.TransportationId
            };
        }

        public static IEnumerable<GoodDTO> ToListGoodDTO(this IEnumerable<Good> goods)
        {
            return goods.Select(good => good.ToGoodDTO());          
        }

        public static Good ToGood(this GoodDTO goodDTO)
        {
            return new Good
            {
                Id = goodDTO.Id,
                Title = goodDTO.Title,
                PurchasePrice = goodDTO.PurchasePrice,
                SalePrice = goodDTO.SalePrice,
                Qyantity = goodDTO.Qyantity,
                Transportation = goodDTO.Transportation,
                TransportationId = goodDTO.TransportationId
            };
        }

        public static TransportationDTO ToTransportationDTO(this Transportation transportation)
        {
            return new TransportationDTO 
            {
                Id = transportation.Id,
                TitleTransport = transportation.TitleTransport,
                DataOfSend = transportation.DataOfSend,
                DateOfArrival = transportation.DateOfArrival,
                CostOfDelivery = transportation.CostOfDelivery
            };
        }

        public static IEnumerable<TransportationDTO> ToListTransposrtationDTO(this IEnumerable<Transportation> transportations )
        {
            return transportations.Select(transportation=>transportation.ToTransportationDTO());
        }

        public static Transportation ToTransportation(this TransportationDTO transportationDTO)
        {
            return new Transportation
            {
                Id = transportationDTO.Id,
                TitleTransport = transportationDTO.TitleTransport,
                DataOfSend = transportationDTO.DataOfSend,
                DateOfArrival = transportationDTO.DateOfArrival,
                CostOfDelivery = transportationDTO.CostOfDelivery
            };
        }

        public static RepairDTO ToRepairDTO(this Repair repair)
        {
            return new RepairDTO
            {
                Id = repair.Id,
                Title = repair.Title,
                CostOfRepair = repair.CostOfRepair,
                DateOfRepair = repair.DateOfRepair,
                Transportation = repair.Transportation,
                TransportationId = repair.TransportationId
            };
        }

        public static IEnumerable<RepairDTO> ToListRepairDTO(this IEnumerable<Repair> repairs)
        {
            return repairs.Select(repair =>repair.ToRepairDTO());
        }

        public static Repair ToRepair(this RepairDTO repairDTO)
        {
            return new Repair
            {
                Id = repairDTO.Id,
                Title = repairDTO.Title,
                CostOfRepair = repairDTO.CostOfRepair,
                DateOfRepair = repairDTO.DateOfRepair,
                Transportation = repairDTO.Transportation,
                TransportationId = repairDTO.TransportationId
            };
        }

        public static RentalSpaceDTO ToRentalSpaceDTO(this RentalSpace rentalSpace)
        {
            return new RentalSpaceDTO
            {
                Id = rentalSpace.Id,
                Title = rentalSpace.Title,
                Month = rentalSpace.Month,
                Rental = rentalSpace.Rental
            };
        }

        public static IEnumerable<RentalSpaceDTO> ToListRentalSpaceDTO(this IEnumerable<RentalSpace> rentalSpaces)
        {
            return rentalSpaces.Select(rentalSpace => rentalSpace.ToRentalSpaceDTO());
        }

        public static RentalSpace ToRentalSpace(this RentalSpaceDTO rentalSpaceDTO)
        {
            return new RentalSpace
            {
                Id = rentalSpaceDTO.Id,
                Title = rentalSpaceDTO.Title,
                Month = rentalSpaceDTO.Month,
                Rental = rentalSpaceDTO.Rental
            };
        }

        public static BonusOrFineDTO ToBonusOrFineDTO(this BonusOrFine bonusOrFine)
        {
            return new BonusOrFineDTO
            {
                Id = bonusOrFine.Id,
                Title = bonusOrFine.Title,
                AmountOfBonusOrFine = bonusOrFine.AmountOfBonusOrFine,
                Date = bonusOrFine.Date,
                EmployeeId = bonusOrFine.EmployeeId
            };
        }

        public static IEnumerable<BonusOrFineDTO> ToListBonusOrFineDTO(this IEnumerable<BonusOrFine> bonusOrFines)
        {
            return bonusOrFines.Select(bonusOrFine=>bonusOrFine.ToBonusOrFineDTO());
        }

        public static BonusOrFine ToBonusOrFine(this BonusOrFineDTO bonusOrFineDTO)
        {
            return new BonusOrFine
            {
                Id = bonusOrFineDTO.Id,
                Title = bonusOrFineDTO.Title,
                Date = bonusOrFineDTO.Date,
                AmountOfBonusOrFine = bonusOrFineDTO.AmountOfBonusOrFine,
                EmployeeId = bonusOrFineDTO.EmployeeId
            };
        }

        public static EmployeeDTO ToEmployeeDTO(this Employee employee)
        {
            return new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                Birthday = employee.Birthday,
                PositionId = employee.PositionId,
                DepartamentId = employee.DepartamentId
            };
        }

        public static IEnumerable<EmployeeDTO> ToListEmployeeDTO(this IEnumerable<Employee> employees)
        {
            return employees.Select(employee => employee.ToEmployeeDTO());
        }

        public static Employee ToEmployee(this EmployeeDTO employeeDTO)
        {
            return new Employee
            {
                Id = employeeDTO.Id,
                Name = employeeDTO.Name,
                SurName = employeeDTO.SurName,
                Patronymic = employeeDTO.Patronymic,
                Birthday = employeeDTO.Birthday,
                PositionId = employeeDTO.PositionId,
                DepartamentId = employeeDTO.DepartamentId
                
            };
        }

        public static PositionDTO ToPositionDTO(this Position position)
        {
            return new PositionDTO
            {
                Id = position.Id,
                MinSalary = position.MinSalary,
                Title = position.Title                
            };
        }

        public static IEnumerable<PositionDTO> ToListPositionDTO(this IEnumerable<Position> positions)
        {
            return positions.Select(position => position.ToPositionDTO());
        }

        public static Position ToPosition(this PositionDTO positionDTO)
        {
            return new Position
            {
                Id = positionDTO.Id,
                Title = positionDTO.Title,
                MinSalary = positionDTO.MinSalary
            };
        }


        public static SickLeaveDTO ToSickLeaveDTO(this SickLeave sickLeave)
        {
            return new SickLeaveDTO
            {
                Id = sickLeave.Id,
                StartOfTheSickLeave = sickLeave.StartOfTheSickLeave,
                FinishOfTheSickLeave = sickLeave.FinishOfTheSickLeave,
                MonetaryCompensation = sickLeave.MonetaryCompensation,
                EmployeeId = sickLeave.EmployeeId
            };
        }

        public static IEnumerable<SickLeaveDTO> ToListSickLeaveDTO(this IEnumerable<SickLeave> sickLeaves)
        {
            return sickLeaves.Select(sickLeave=>sickLeave.ToSickLeaveDTO());
        }

        public static SickLeave ToSickLeave(this SickLeaveDTO sickLeaveDTO)
        {
            return new SickLeave
            {
                Id = sickLeaveDTO.Id,
                StartOfTheSickLeave = sickLeaveDTO.StartOfTheSickLeave,
                FinishOfTheSickLeave = sickLeaveDTO.FinishOfTheSickLeave,
                MonetaryCompensation = sickLeaveDTO.MonetaryCompensation,
                EmployeeId = sickLeaveDTO.EmployeeId
            };
        }

        public static PaymentAccountDTO ToPaymentAccountDTO(this PaymentAccount paymentAccount)
        {
            return new PaymentAccountDTO
            {
                Id = paymentAccount.Id,
                Payday = paymentAccount.Payday,
                Salary = paymentAccount.Salary,
                Employee = paymentAccount.Employee,
                EmployeeId = paymentAccount.EmployeeId
            };
        }

        public static IEnumerable<PaymentAccountDTO> ToListPaymentAccountDTO(this IEnumerable<PaymentAccount> paymentAccounts)
        {
            return paymentAccounts.Select(paymentAccount => paymentAccount.ToPaymentAccountDTO());
        }

        public static PaymentAccount ToPaymentAccount(this PaymentAccountDTO paymentAccountDTO)
        {
            return new PaymentAccount
            {
                Id = paymentAccountDTO.Id,
                Payday = paymentAccountDTO.Payday,
                Salary = paymentAccountDTO.Salary,
                Employee = paymentAccountDTO.Employee,
                EmployeeId = paymentAccountDTO.EmployeeId
            };
        }

        public static DepartamentDTO ToDepartamentDTO(this Departament departament)
        {
            return new DepartamentDTO
            {
                Id = departament.Id,
                Title = departament.Title                
            };
        }

        public static IEnumerable<DepartamentDTO> ToListDepartamentDTO(this IEnumerable<Departament> departaments)
        {
            return departaments.Select(departament => departament.ToDepartamentDTO());
        }

        public static Departament ToDepartament(this DepartamentDTO departamentDTO)
        {
            return new Departament
            {
                Id = departamentDTO.Id,
                Title = departamentDTO.Title,
            };
        }
    }
}
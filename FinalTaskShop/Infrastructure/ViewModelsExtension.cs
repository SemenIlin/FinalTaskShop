﻿using BLShop.WEB.ModelsDTO.ForGood;
using FinalTaskShop.ViewModels.ForGood;
using System.Collections.Generic;
using FinalTaskShop.ViewModels.ForRentalSpaces;
using BLShop.WEB.Models.ForRentalSpaces;
using BLShop.WEB.ModelsDTO.ForEmployee;
using FinalTaskShop.ViewModels.ForEmployee;
using BLShop.WEB.Models.ForEmployee;
using System.Linq;

namespace FinalTaskShop.Infrastructure
{
    public static class ViewModelsExtension
    {
        public static GoodDTO ToGoodDTO(this GoodViewModel goodModelView)
        {
            return new GoodDTO
            {
                Id = goodModelView.Id,
                Title = goodModelView.Title,
                PurchasePrice = goodModelView.PurchasePrice,
                SalePrice = goodModelView.SalePrice,
                Qyantity = goodModelView.Qyantity,
                Transportation = goodModelView.TransportationDTO,
                TransportationId = goodModelView.TransportationId
            };
        }

        public static IEnumerable<GoodViewModel> ToListGoodViewModel(this IEnumerable<GoodDTO> goodDTOs)
        {
            return goodDTOs.Select(goodDTO=>goodDTO.ToGoodViewModel());          
        }

        public static GoodViewModel ToGoodViewModel(this GoodDTO goodDTO)
        {
            return new GoodViewModel
            {
                Id = goodDTO.Id,
                Title = goodDTO.Title,
                PurchasePrice = goodDTO.PurchasePrice,
                SalePrice = goodDTO.SalePrice,
                Qyantity = goodDTO.Qyantity,
                TransportationDTO = goodDTO.Transportation,
                TransportationId = goodDTO.TransportationId
            };
        }

        public static TransportationDTO ToTransportationDTO(this TransportationViewModel transportationViewModel)
        {
            return new TransportationDTO 
            {
                Id = transportationViewModel.Id,
                TitleTransport = transportationViewModel.TitleTransport,
                DataOfSend = transportationViewModel.DataOfSend,
                DateOfArrival = transportationViewModel.DateOfArrival,
                CostOfDelivery = transportationViewModel.CostOfDelivery
            };
        }

        public static IEnumerable<TransportationViewModel> ToListTransposrtationViewModel(this IEnumerable<TransportationDTO> transportationDTOs )
        {
            return transportationDTOs.Select(transportationDTO=>transportationDTO.ToTransportationViewModel());
        }

        public static TransportationViewModel ToTransportationViewModel(this TransportationDTO transportationDTO)
        {
            return new TransportationViewModel
            {
                Id = transportationDTO.Id,
                TitleTransport = transportationDTO.TitleTransport,
                DataOfSend = transportationDTO.DataOfSend,
                DateOfArrival = transportationDTO.DateOfArrival,
                CostOfDelivery = transportationDTO.CostOfDelivery
            };
        }

        public static RepairDTO ToRepairDTO(this RepairViewModel repairViewModel)
        {
            return new RepairDTO
            {
                Id = repairViewModel.Id,
                Title = repairViewModel.Title,
                CostOfRepair = repairViewModel.CostOfRepair,
                DateOfRepair = repairViewModel.DateOfRepair,
                Transportation = repairViewModel.TransportationDTO,
                TransportationId = repairViewModel.TransportationId
            };
        }

        public static IEnumerable<RepairViewModel> ToListRepairViewModel(this IEnumerable<RepairDTO> repairDTOs)
        {
            return repairDTOs.Select(repairDTO => repairDTO.ToRepairViewModel());
        }

        public static RepairViewModel ToRepairViewModel(this RepairDTO repairDTO)
        {
            return new RepairViewModel
            {
                Id = repairDTO.Id,
                Title = repairDTO.Title,
                CostOfRepair = repairDTO.CostOfRepair,
                DateOfRepair = repairDTO.DateOfRepair,
                TransportationDTO = repairDTO.Transportation,
                TransportationId = repairDTO.TransportationId
            };
        }

        public static RentalSpaceDTO ToRentalSpaceDTO(this RentalSpaceViewModel rentalSpaceViewModel)
        {
            return new RentalSpaceDTO
            {
                Id = rentalSpaceViewModel.Id,
                Title = rentalSpaceViewModel.Title,
                Month = rentalSpaceViewModel.Month,
                Rental = rentalSpaceViewModel.Rental
            };
        }

        public static IEnumerable<RentalSpaceViewModel> ToListRentalSpaceViewModel(this IEnumerable<RentalSpaceDTO> rentalSpaceDTOs)
        {
            return rentalSpaceDTOs.Select(rentalSpace=>rentalSpace.ToRentalSpaceViewModel());
        }

        public static RentalSpaceViewModel ToRentalSpaceViewModel(this RentalSpaceDTO rentalSpaceDTO)
        {
            return new RentalSpaceViewModel
            {
                Id = rentalSpaceDTO.Id,
                Title = rentalSpaceDTO.Title,
                Month = rentalSpaceDTO.Month,
                Rental = rentalSpaceDTO.Rental                
            };
        }

        public static BonusOrFineDTO ToBonusOrFineDTO(this BonusOrFineViewModel bonusOrFineViewModel)
        {
            return new BonusOrFineDTO
            {
                Id = bonusOrFineViewModel.Id,
                Title = bonusOrFineViewModel.Title,
                AmountOfBonusOrFine = bonusOrFineViewModel.AmountOfBonusOrFine,
                Date = bonusOrFineViewModel.Date,
                EmployeeId = bonusOrFineViewModel.EmployeeId
            };
        }

        public static IEnumerable<BonusOrFineViewModel> ToListBonusOrFineViewModel(this IEnumerable<BonusOrFineDTO> bonusOrFineDTOs)
        {
            return bonusOrFineDTOs.Select(bonusOrFineDTO=>bonusOrFineDTO.ToBonusOrFineViewModel());
        }

        public static BonusOrFineViewModel ToBonusOrFineViewModel(this BonusOrFineDTO bonusOrFineDTO)
        {
            return new BonusOrFineViewModel
            {
                Id = bonusOrFineDTO.Id,
                Title = bonusOrFineDTO.Title,
                Date = bonusOrFineDTO.Date,
                AmountOfBonusOrFine = bonusOrFineDTO.AmountOfBonusOrFine,
                EmployeeId = bonusOrFineDTO.EmployeeId
            };
        }

        public static EmployeeDTO ToEmployeeDTO(this EmployeeViewModel employeeViewModel)
        {
            return new EmployeeDTO
            {
                Id = employeeViewModel.Id,
                Name = employeeViewModel.Name,
                SurName = employeeViewModel.SurName,
                Patronymic = employeeViewModel.Patronymic,
                Birthday = employeeViewModel.Birthday,
                PositionId = employeeViewModel.PositionId
            };
        }

        public static IEnumerable<EmployeeViewModel> ToListEmployeeViewModels(this IEnumerable<EmployeeDTO> employeeDTOs)
        {
            return employeeDTOs.Select(employeeDTO=>employeeDTO.ToEmployeeViewModel());
        }

        public static EmployeeViewModel ToEmployeeViewModel(this EmployeeDTO employeeDTO)
        {
            return new EmployeeViewModel
            {
                Id = employeeDTO.Id,
                Name = employeeDTO.Name,
                SurName = employeeDTO.SurName,
                Patronymic = employeeDTO.Patronymic,
                Birthday = employeeDTO.Birthday,
                PositionId = employeeDTO.PositionId
            };
        }

        public static PositionDTO ToPositionDTO(this PositionViewModel positionViewModel)
        {
            return new PositionDTO
            {
                Id = positionViewModel.Id,
                MinSalary = positionViewModel.MinSalary,
                Title = positionViewModel.Title
            };
        }

        public static IEnumerable<PositionViewModel> ToListPositionViewModel(this IEnumerable<PositionDTO> positionDTOs)
        {
            return positionDTOs.Select(positionDTO=>positionDTO.ToPositionViewModel());
        }

        public static PositionViewModel ToPositionViewModel(this PositionDTO positionDTO)
        {
            return new PositionViewModel
            {
                Id = positionDTO.Id,
                Title = positionDTO.Title,
                MinSalary = positionDTO.MinSalary
            };
        }

        public static SickLeaveDTO ToSickLeaveDTO(this SickLeaveViewModel sickLeaveViewModel)
        {
            return new SickLeaveDTO
            {
                Id = sickLeaveViewModel.Id,
                StartOfTheSickLeave = sickLeaveViewModel.StartOfTheSickLeave,
                FinishOfTheSickLeave = sickLeaveViewModel.FinishOfTheSickLeave,
                MonetaryCompensation = sickLeaveViewModel.MonetaryCompensation,
                EmployeeId = sickLeaveViewModel.EmployeeId
            };
        }

        public static IEnumerable<SickLeaveViewModel> ToListSickLeaveViewModel(this IEnumerable<SickLeaveDTO> sickLeaveDTOs)
        {
            return sickLeaveDTOs.Select(sickLeave => sickLeave.ToSickLeaveViewModel());           
        }

        public static SickLeaveViewModel ToSickLeaveViewModel(this SickLeaveDTO sickLeaveDTO)
        {
            return new SickLeaveViewModel
            {
                Id = sickLeaveDTO.Id,
                StartOfTheSickLeave = sickLeaveDTO.StartOfTheSickLeave,
                FinishOfTheSickLeave = sickLeaveDTO.FinishOfTheSickLeave,
                MonetaryCompensation = sickLeaveDTO.MonetaryCompensation,
                EmployeeId = sickLeaveDTO.EmployeeId
            };
        }
    }
}

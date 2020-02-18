using BLShop.WEB.ModelsDTO.ForGood;
using FinalTaskShop.ViewModels.ForGood;
using System.Collections.Generic;

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
                TransportationId = goodModelView.TransportationId
            };
        }

        public static IEnumerable<GoodViewModel> ToListGoodViewModel(this IEnumerable<GoodDTO> goodDTOs)
        {
            List<GoodViewModel>  goodViewModels = new List<GoodViewModel>(4);  

            foreach (var goodDTO in goodDTOs)
            {
                goodViewModels.Add(goodDTO.ToGoodViewModel());
            }

            return goodViewModels;          
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
                DateOfArrival = transportationViewModel.DateOfArrival
            };
        }

        public static IEnumerable<TransportationViewModel> ToListTransposrtationViewModel(this IEnumerable<TransportationDTO> transportationDTOs )
        {
            List<TransportationViewModel> transportationViewModels = new List<TransportationViewModel>(4);

            foreach (var transportationDTO in transportationDTOs)
            {
                transportationViewModels.Add(transportationDTO.ToTransportationViewModel());
            }

            return transportationViewModels;
        }

        public static TransportationViewModel ToTransportationViewModel(this TransportationDTO transportationDTO)
        {
            return new TransportationViewModel
            {
                Id = transportationDTO.Id,
                TitleTransport = transportationDTO.TitleTransport,
                DataOfSend = transportationDTO.DataOfSend,
                DateOfArrival = transportationDTO.DateOfArrival
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
                TransportationId = repairViewModel.TransportationId
            };
        }

        public static IEnumerable<RepairViewModel> ToListRepairViewModel(this IEnumerable<RepairDTO> repairDTOs)
        {
            List<RepairViewModel> repairViewModels = new List<RepairViewModel>(4);

            foreach (var repairDTO in repairDTOs)
            {
                repairViewModels.Add(repairDTO.ToRepairViewModel());
            }

            return repairViewModels;
        }

        public static RepairViewModel ToRepairViewModel(this RepairDTO repairDTO)
        {
            return new RepairViewModel
            {
                Id = repairDTO.Id,
                Title = repairDTO.Title,
                CostOfRepair = repairDTO.CostOfRepair,
                DateOfRepair = repairDTO.DateOfRepair,
                TransportationId = repairDTO.TransportationId
            };
        }


    }
}

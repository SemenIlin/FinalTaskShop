using BLShop.WEB.ModelsDTO.ForGood;
using DAShop.WEB.Models.ForGood;
using System.Collections.Generic;

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
                TransportationId = good.TransportationId
            };
        }

        public static IEnumerable<GoodDTO> ToListGoodDTO(this IEnumerable<Good> goods)
        {
            List<GoodDTO> goodDTOs = new List<GoodDTO>(4);  

            foreach (var good in goods)
            {
                goodDTOs.Add(good.ToGoodDTO());
            }

            return goodDTOs;          
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
                DateOfArrival = transportation.DateOfArrival
            };
        }

        public static IEnumerable<TransportationDTO> ToListTransposrtationDTO(this IEnumerable<Transportation> transportations )
        {
            List<TransportationDTO> transportationDTOs = new List<TransportationDTO>(4);

            foreach (var transportation in transportations)
            {
                transportationDTOs.Add(transportation.ToTransportationDTO());
            }

            return transportationDTOs;
        }

        public static Transportation ToTransportation(this TransportationDTO transportationDTO)
        {
            return new Transportation
            {
                Id = transportationDTO.Id,
                TitleTransport = transportationDTO.TitleTransport,
                DataOfSend = transportationDTO.DataOfSend,
                DateOfArrival = transportationDTO.DateOfArrival
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
                TransportationId = repair.TransportationId
            };
        }

        public static IEnumerable<RepairDTO> ToListRepairDTO(this IEnumerable<Repair> repairs)
        {
            List<RepairDTO> repairDTOs = new List<RepairDTO>(4);

            foreach (var repair in repairs)
            {
                repairDTOs.Add(repair.ToRepairDTO());
            }

            return repairDTOs;
        }

        public static Repair ToRepair(this RepairDTO repairDTO)
        {
            return new Repair
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

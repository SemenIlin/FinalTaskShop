using BLShop.WEB.Interfaces;
using BLShop.WEB.ModelsDTO.ForGood;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForGood;
using System;
using System.Collections.Generic;

namespace BLShop.WEB.Services
{
    class GoodService : IGoodService
    {
        IGoodUnitOfWork Database { get; set; }

        public GoodService(IGoodUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddGood(GoodDTO goodDTO)
        {
            var good = new Good
            { 
                Title = goodDTO.Title,
                PurchasePrice = goodDTO.PurchasePrice,
                SalePrice = goodDTO.SalePrice,
                Qyantiy = goodDTO.Qyantiy,
                TransportationId = goodDTO.TransportationId
            };

            Database.Goods.Create(good);
        }

        public void AddTransportation(TransportationDTO transportationDTO)
        {
            var transportation = new Transportation
            {
                DataOfSend = transportationDTO.DataOfSend,
                DateOfArrival = transportationDTO.DateOfArrival,
                CostOfDelivery = transportationDTO.CostOfDelivery,
            };

            Database.Transportations.Create(transportation);
        }

        public void CreateRepair(RepairDTO repairDTO)
        {
            var repair = new Repair
            {
                Title = repairDTO.Title,
                CostOfRepair = repairDTO.CostOfRepair,
                DateOfRepair = repairDTO.DateOfRepair,
                TransportationId = repairDTO.TransportationId
            };

            Database.Repairs.Create(repair);
        }

        public GoodDTO GetGood(int? id)
        {
            if (id != null)
            {
                var good = Database.Goods.Get(id.Value);
                if (good == null)
                {
                    throw new Exception("Товар не найден.");
                }
                return new GoodDTO
                {
                    Title = good.Title,
                    PurchasePrice = good.PurchasePrice,
                    SalePrice = good.SalePrice,
                    Qyantiy = good.Qyantiy,
                    TransportationId = good.TransportationId
                };
            }
            else
            {
                throw new NullReferenceException("Страница не найдена.");
            }
        }

        public IEnumerable<GoodDTO> GetGoods()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

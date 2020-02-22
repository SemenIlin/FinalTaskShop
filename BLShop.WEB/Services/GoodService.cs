using BLShop.WEB.Infrastructure;
using BLShop.WEB.Interfaces;
using BLShop.WEB.ModelsDTO.ForGood;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForGood;
using System;
using System.Collections.Generic;

namespace BLShop.WEB.Services
{
    public class GoodService : IGoodService
    {
        private readonly IRepository<Good> goods;
        private readonly IRepository<Transportation> transportations;
        private readonly IRepository<Repair> repairs;

        public GoodService(
            IRepository<Good> goods,
            IRepository<Transportation> transportations,
            IRepository<Repair> repairs)            
        {
            this.goods = goods;
            this.transportations = transportations;
            this.repairs = repairs;
        }

        public void AddGood(GoodDTO goodDTO)
        {
            var good = goodDTO.ToGood();

            goods.Create(good);
        }

        public void AddTransportation(TransportationDTO transportationDTO)
        {
            var transportation = transportationDTO.ToTransportation();

            transportations.Create(transportation);
        }

        public void CreateRepair(RepairDTO repairDTO)
        {
            var repair = repairDTO.ToRepair();

            repairs.Create(repair);
        }

        public GoodDTO GetGood(int id)
        {
            var good = goods.Get(id);
            if (good == null)
            {
                throw new NullReferenceException();
            }

            return good.ToGoodDTO();           
        }

        public IEnumerable<GoodDTO> GetGoods()
        {
            return goods.GetAll().ToListGoodDTO();
        }

        public void Dispose()
        {
            //Dispose();
        }

        public void DeleteGood(int id)
        {
            goods.Delete(id);            
        }

        public void UpdateGood(GoodDTO goodDTO)
        {
            var good = goodDTO.ToGood();

            goods.Update(good);
        }

        public IEnumerable<TransportationDTO> GetTransportations()
        {
            return transportations.GetAll().ToListTransposrtationDTO();
        }

        public TransportationDTO GetTransportation(int id)
        {
            var transportation = transportations.Get(id);
            if(transportation == null)
            {
                throw new NullReferenceException();
            }

            return transportation.ToTransportationDTO();
        }

        public void DeleteTransportation(int id)
        {
            transportations.Delete(id);
        }

        public void UpdateTransportation(TransportationDTO transportationDTO)
        {
            var transportation = transportationDTO.ToTransportation();
            transportations.Update(transportation);
        }

        public IEnumerable<RepairDTO> GetRepairs()
        {
            return repairs.GetAll().ToListRepairDTO();
        }

        public RepairDTO GetRepair(int id)
        {
            var repair = repairs.Get(id);
            if(repair == null)
            {
                throw new NullReferenceException();
            }

            return repair.ToRepairDTO();
        }

        public void DeleteRepair(int id)
        {
            repairs.Delete(id);
        }

        public void UpdateRepair(RepairDTO repairDTO)
        {
            var repair = repairDTO.ToRepair();
            repairs.Update(repair);
        }
    }
}

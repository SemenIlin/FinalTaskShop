using BLShop.WEB.ModelsDTO.ForGood;
using System;
using System.Collections.Generic;

namespace BLShop.WEB.Interfaces
{
    public interface IGoodService : IDisposable
    {
        void AddGood(GoodDTO goodDTO);
        IEnumerable<GoodDTO> GetGoods();
        GoodDTO GetGood(int id);
        void DeleteGood(int id);
        void UpdateGood(GoodDTO goodDTO);

        void AddTransportation(TransportationDTO transportationDTO);
        IEnumerable<TransportationDTO> GetTransportations();
        TransportationDTO GetTransportation(int id);
        void DeleteTransportation(int id);
        void UpdateTransportation(TransportationDTO transportationDTO);

        void CreateRepair(RepairDTO repairDTO);
        IEnumerable<RepairDTO> GetRepairs();
        RepairDTO GetRepair(int id);
        void DeleteRepair(int id);
        void UpdateRepair(RepairDTO repairDTO);
    }
}

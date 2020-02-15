using BLShop.WEB.ModelsDTO.ForGood;
using System.Collections.Generic;

namespace BLShop.WEB.Interfaces
{
    public interface IGoodService
    {
        void AddGood(GoodDTO goodDTO);
        IEnumerable<GoodDTO> GetGoods();
        GoodDTO GetGood(int? id);

        void AddTransportation(TransportationDTO transportationDTO);
        void CreateRepair(RepairDTO repairDTO);

        void Dispose();
    }
}

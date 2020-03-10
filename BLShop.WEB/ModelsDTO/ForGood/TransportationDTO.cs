using System;

namespace BLShop.WEB.ModelsDTO.ForGood
{
    public class TransportationDTO
    {
        public int Id { get; set; }
        public string TitleTransport { get; set; }

        public DateTime DateOfSend { get; set; }
        public DateTime DateOfArrival { get; set; }

        public decimal CostOfDelivery { get; set; }
    }
}

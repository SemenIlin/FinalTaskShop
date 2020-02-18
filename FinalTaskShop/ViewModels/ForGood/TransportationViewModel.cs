using System;

namespace FinalTaskShop.ViewModels.ForGood
{
    public class TransportationViewModel
    {
        public int Id { get; set; }
        public string TitleTransport { get; set; }

        public DateTime DataOfSend { get; set; }
        public DateTime DateOfArrival { get; set; }

        public decimal CostOfDelivery { get; set; }
    }
}

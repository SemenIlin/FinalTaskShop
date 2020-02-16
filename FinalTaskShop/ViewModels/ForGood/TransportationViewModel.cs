using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTaskShop.ViewModels.ForGood
{
    public class TransportationViewModel
    {
        public int Id { get; set; }

        public DateTime DataOfSend { get; set; }
        public DateTime DateOfArrival { get; set; }

        public decimal CostOfDelivery { get; set; }
    }
}

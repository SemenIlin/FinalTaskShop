using System;

namespace FinalTaskShop.ViewModels.ForGood
{
    public class RepairViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime DateOfRepair { get; set; }
        public decimal CostOfRepair { get; set; }

        public int TransportationId { get; set; }
    }
}

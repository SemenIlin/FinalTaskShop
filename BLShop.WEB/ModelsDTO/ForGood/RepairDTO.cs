using System;

namespace BLShop.WEB.ModelsDTO.ForGood
{
    public class RepairDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime DateOfRepair { get; set; }
        public decimal CostOfRepair { get; set; }

        public int TransportationId { get; set; }
    }
}

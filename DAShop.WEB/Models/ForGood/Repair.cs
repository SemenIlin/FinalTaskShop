using System;

namespace DAShop.WEB.Models.ForGood
{
    public class Repair
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime DateOfRepair { get; set; }
        public decimal CostOfRepair { get; set; }

        public Transportation Transportation { get; set; }
        public int? TransportationId { get; set; }
    }
}

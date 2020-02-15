using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLShop.WEB.ModelsDTO.ForGood
{
    public class TransportationDTO
    {
        [Key]
        [ForeignKey("Good")]
        public int Id { get; set; }

        public DateTime DataOfSend { get; set; }
        public DateTime DateOfArrival { get; set; }

        public decimal CostOfDelivery { get; set; }

        public int GoodId { get; set; }
    }
}

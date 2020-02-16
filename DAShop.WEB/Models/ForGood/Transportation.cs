using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAShop.WEB.Models.ForGood
{
    public class Transportation
    {
        public Transportation()
        {
            Repairs = new List<Repair>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime DataOfSend { get; set; }
        public DateTime DateOfArrival { get; set; }

        public decimal CostOfDelivery { get; set; }

        public ICollection<Repair> Repairs { get; set; }
        public ICollection<Good> Goods { get; set; }

    }
}

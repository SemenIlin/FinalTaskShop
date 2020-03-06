using System;
using System.Collections.Generic;

namespace DAShop.WEB.Models.ForGood
{
    public class Transportation
    {
        public Transportation()
        {
            Repairs = new List<Repair>();
            Goods = new List<Good>();
        }

        public int Id { get; set; }
        public string TitleTransport { get; set; }

        public DateTime DateOfSend { get; set; }
        public DateTime DateOfArrival { get; set; }

        public decimal CostOfDelivery { get; set; }

        public ICollection<Repair> Repairs { get; set; }
        public ICollection<Good> Goods { get; set; }

    }
}

using BLShop.WEB.Interfaces;
using System;
using System.Linq;

namespace BLShop.WEB.TotalRevenue
{
    public class TotalRevenueFromGood
    {
        private readonly IGoodService goodService;

        public TotalRevenueFromGood(IGoodService goodService)
        {
            this.goodService = goodService;
        }

        public decimal GetTotalRevenueFromGood(DateTime startDate, DateTime finishDate)
        {
            if(startDate > finishDate)
            {
                return 0.0M;
            }

            return goodService.GetGoods().
                Where(date => date.Transportation.DateOfArrival >= startDate &&
                      date.Transportation.DateOfArrival <= finishDate).
                      Sum(good => good.SalePrice * good.Qyantity);
        }
    }
}

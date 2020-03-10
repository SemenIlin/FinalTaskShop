using BLShop.WEB.Interfaces;
using System;
using System.Linq;

namespace BLShop.WEB.TotalExpenses
{
    public class TotalExpensesForTransportation
    {
        private readonly IGoodService goodService;

        public TotalExpensesForTransportation(IGoodService goodService)
        {
            this.goodService = goodService;              
        }

        public decimal GetTotalExpensesForTransportation(DateTime startDate, DateTime finishDate)
        { 
            if(startDate > finishDate)
            {
                return 0.0M;
            }

            return goodService.GetTransportations().
                Where(date => date.DateOfSend >= startDate && 
                      date.DateOfSend <= finishDate).
                Sum(cost => cost.CostOfDelivery);
        }
    }
}

using BLShop.WEB.Interfaces;
using System;
using System.Linq;

namespace BLShop.WEB.TotalExpenses
{
    public class TotalExpensesForGood
    {
        private readonly IGoodService  goodService;

        public TotalExpensesForGood(IGoodService  goodService)
        {
            this.goodService = goodService;
        }

        public decimal GetTotalExpensesForGood(DateTime startDate, DateTime finishDate)
        { 
            if(startDate > finishDate)
            {
                return 0.0M;
            }

            return goodService.GetGoods().
                Where(date => date.Transportation.DateOfSend.Month >= startDate.Month &&
                      date.Transportation.DateOfSend.Month <= finishDate.Month).                
                Sum(expense => expense.PurchasePrice * expense.Qyantity);
        }
    }
}

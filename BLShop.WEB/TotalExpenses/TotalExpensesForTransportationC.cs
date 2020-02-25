using DAShop.WEB.EFCore;
using System;
using System.Linq;

namespace BLShop.WEB.TotalExpenses
{
    public class TotalExpensesForTransportationC
    {
        public TotalExpensesForTransportationC(ShopContext context, DateTime startDate, DateTime finishDate)
        {
            TotalExpensesForTransportation = context.Transportations.
                Where(date => date.DataOfSend >= startDate).
                Where(date => date.DataOfSend <= finishDate).
                Sum(cost => cost.CostOfDelivery);
                
        }

        public decimal TotalExpensesForTransportation { get; }
    }
}

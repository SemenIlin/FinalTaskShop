using DAShop.WEB.EFCore;
using System;
using System.Linq;

namespace BLShop.WEB.TotalExpenses
{
    public class TotalExpensesForRentalSpaceC
    {
        public TotalExpensesForRentalSpaceC(ShopContext context, DateTime startDate, DateTime finishDate)
        {
            TotalExpensesForRentalSpace = context.RentalSpaces.
                Where(date => date.Month >= startDate).
                Where(date => date.Month <= finishDate).
                Sum(cost => cost.Rental);
        }

        public decimal TotalExpensesForRentalSpace { get; }
    }
}

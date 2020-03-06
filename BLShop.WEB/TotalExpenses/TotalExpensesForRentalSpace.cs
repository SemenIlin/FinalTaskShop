using BLShop.WEB.Interfaces;
using System;
using System.Linq;

namespace BLShop.WEB.TotalExpenses
{
    public class TotalExpensesForRentalSpace
    {
        private readonly IRentalSpaceService rentalSpaceService;

        public TotalExpensesForRentalSpace(IRentalSpaceService rentalSpaceService)
        {
            this.rentalSpaceService = rentalSpaceService;
        }

        public decimal GetTotalExpensesForRentalSpace(DateTime startDate, DateTime finishDate)
        {
            if(startDate > finishDate)
            {
                return 0.0M;
            }

            return rentalSpaceService.GetRentalSpaces().
                Where(date => date.Month >= startDate && date.Month <= finishDate).
                Sum(cost => cost.Rental);
        }
    }
}


using System;

namespace FinalTaskShop.ViewModels.ForRentalSpaces
{
    public class RentalSpaceViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public decimal Rental { get; set; }

        public System.DateTime Month { get; set; }
    }
}

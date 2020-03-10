using BLShop.WEB.Models.ForRentalSpaces;
using System;
using System.Collections.Generic;

namespace BLShop.WEB.Interfaces
{
    public interface IRentalSpaceService: IDisposable
    {
        void AddRentalSpace(RentalSpaceDTO rentalSpaceDTO);
        IEnumerable<RentalSpaceDTO> GetRentalSpaces();
        RentalSpaceDTO GetRentalSpace(int id);
        void DeleteRentalSpace(int id);
        void UpdateRentalSpace(RentalSpaceDTO rentalSpaceDTO);
    }
}
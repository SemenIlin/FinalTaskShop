using BLShop.WEB.Infrastructure;
using BLShop.WEB.Interfaces;
using BLShop.WEB.Models.ForRentalSpaces;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForRentalSpaces;
using System;
using System.Collections.Generic;

namespace BLShop.WEB.Services
{
    public class RentalSpaceService : IRentalSpaceService
    {
        private readonly IRepository<RentalSpace> rentalSpaces;

        public RentalSpaceService(IRepository<RentalSpace> rentalSpaces)
        {
            this.rentalSpaces = rentalSpaces;
        }

        public void AddRentalSpace(RentalSpaceDTO rentalSpaceDTO)
        {
            rentalSpaces.Create(rentalSpaceDTO.ToRentalSpace());
        }

        public void DeleteRentalSpace(int id)
        {
            rentalSpaces.Delete(id);
        }

        public RentalSpaceDTO GetRentalSpace(int id)
        {
            var rentalSpace = rentalSpaces.Get(id);
            if (rentalSpace == null)
            {
                throw new NullReferenceException();
            }

            return rentalSpace.ToRentalSpaceDTO();
        }

        public IEnumerable<RentalSpaceDTO> GetRentalSpaces()
        {
            return rentalSpaces.GetAll().ToListRentalSpaceDTO();
        }

        public void UpdateRentalSpace(RentalSpaceDTO rentalSpaceDTO)
        {
            var rentalSpace = rentalSpaceDTO.ToRentalSpace();

            rentalSpaces.Update(rentalSpace);
        }
    }
}

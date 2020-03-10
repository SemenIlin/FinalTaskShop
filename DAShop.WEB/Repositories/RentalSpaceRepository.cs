using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForRentalSpaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAShop.WEB.Repositories
{
    public class RentalSpaceRepository : IRepository<RentalSpace>
    {
        private readonly ShopContext db;

        public RentalSpaceRepository(ShopContext context)
        {
            db = context;
        }

        public void Create(RentalSpace item)
        {
            db.RentalSpaces.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var rentalSpaces = db.RentalSpaces.Find(id);
            if(rentalSpaces != null)
            {
                db.RentalSpaces.Remove(rentalSpaces);
            }

            Save();
        }

        public IEnumerable<RentalSpace> Find(Func<RentalSpace, bool> predicate)
        {
            return db.RentalSpaces.Where(predicate).ToList();
        }

        public RentalSpace Get(int id)
        {
            return db.RentalSpaces.Find(id);
        }

        public IEnumerable<RentalSpace> GetAll()
        {
            return db.RentalSpaces;
        }

        public void Update(RentalSpace item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
           db.Dispose();
        }
    }
}

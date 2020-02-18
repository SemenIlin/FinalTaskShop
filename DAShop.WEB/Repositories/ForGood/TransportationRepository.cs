using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForGood;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAShop.WEB.Repositories.ForGood
{
    public class TransportationRepository : IRepository<Transportation>
    {
        private readonly ShopContext db;

        public TransportationRepository(ShopContext context)
        {
            db = context;
        }

        public void Create(Transportation item)
        {
            db.Transportations.Add(item);
        }

        public void Delete(int id)
        {
            var transportation = db.Transportations.Find(id);
            if(transportation != null)
            {
                db.Transportations.Remove(transportation);
            }           
        }

        public IEnumerable<Transportation> Find(Func<Transportation, bool> predicate)
        {
            return db.Transportations.Where(predicate).ToList();
        }

        public Transportation Get(int id)
        {
            return db.Transportations.Find(id);
        }

        public IEnumerable<Transportation> GetAll()
        {
            return db.Transportations;
        }

        public void Update(Transportation item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

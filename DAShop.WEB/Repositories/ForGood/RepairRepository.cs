using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForGood;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAShop.WEB.Repositories.ForGood
{
    public class RepairRepository : IRepository<Repair>
    {
        private readonly ShopContext db;

        public RepairRepository(ShopContext context)
        {
            db = context;
        }

        public void Create(Repair item)
        {
            db.Repairs.Add(item);
        }

        public void Delete(int id)
        {
            var repair = db.Repairs.Find(id);
            if(repair != null)
            {
                db.Repairs.Remove(repair);
            }
        }

        public IEnumerable<Repair> Find(Func<Repair, bool> predicate)
        {
            return db.Repairs.Include(r => r.Transportation).Where(predicate).ToList();
        }

        public Repair Get(int id)
        {
            return db.Repairs.Find(id);
        }

        public IEnumerable<Repair> GetAll()
        {
            return db.Repairs.Include(r => r.Transportation);
        }

        public void Update(Repair item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

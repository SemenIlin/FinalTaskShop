using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAShop.WEB.Repositories.ForEmployee
{
    public class BonusOrFineRepository : IRepository<BonusOrFine>
    {
        private readonly ShopContext db;

        public BonusOrFineRepository(ShopContext context)
        {
            db = context;
        }  

        public void Create(BonusOrFine item)
        {
            db.BonusOrFines.Add(item);
        }

        public void Delete(int id)
        {
            var bonusOrFine = db.BonusOrFines.Find(id);
            if(bonusOrFine != null)
            {
                db.BonusOrFines.Remove(bonusOrFine);
            }
        }

        public IEnumerable<BonusOrFine> Find(Func<BonusOrFine, bool> predicate)
        {
            return db.BonusOrFines.Include(e => e.Employee).Where(predicate).ToList();
        }

        public BonusOrFine Get(int id)
        {
            return db.BonusOrFines.Find(id);
        }

        public IEnumerable<BonusOrFine> GetAll()
        {
            return db.BonusOrFines.Include(e => e.Employee); ;
        }

        public void Update(BonusOrFine item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

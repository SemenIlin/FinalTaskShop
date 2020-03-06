using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAShop.WEB.Repositories.ForEmployee
{
    public class SickLeaveRepository : IRepository<SickLeave>
    {
        private readonly ShopContext db;

        public SickLeaveRepository(ShopContext context)
        {
            db = context;
        }
        public void Create(SickLeave item)
        {
            db.SickLeaves.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var sickLeave = db.SickLeaves.Find(id);
            db.SickLeaves.Remove(sickLeave);
            
            Save();
        }

        public IEnumerable<SickLeave> Find(Func<SickLeave, bool> predicate)
        {
            return db.SickLeaves.Include(e => e.Employee).Where(predicate).ToList();
        }

        public SickLeave Get(int id)
        {
            return db.SickLeaves.Find(id);
        }

        public IEnumerable<SickLeave> GetAll()
        {
            return db.SickLeaves.Include(e => e.Employee);
        }

        public void Update(SickLeave item)
        {
            db.Entry(item).State = EntityState.Modified;
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

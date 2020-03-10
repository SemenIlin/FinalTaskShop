using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForGood;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAShop.WEB.Repositories.ForGood
{
    public class GoodRepository : IRepository<Good>
    {
        private readonly ShopContext db;

        public GoodRepository(ShopContext context)
        {
            db = context;
        }

        public void Create(Good item)
        {
            db.Goods.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var good = db.Goods.Find(id);
            db.Goods.Remove(good);

            Save();
        }

        public IEnumerable<Good> Find(Func<Good, bool> predicate)
        {
            return db.Goods.Include(t=>t.Transportation).Where(predicate).ToList();
        }

        public Good Get(int id)
        {
            return db.Goods.Find(id);
        }

        public IEnumerable<Good> GetAll()
        {
            return db.Goods.Include(t => t.Transportation);
        }

        public void Update(Good item)
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

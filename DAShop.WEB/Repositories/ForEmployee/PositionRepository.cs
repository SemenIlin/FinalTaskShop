using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAShop.WEB.Repositories.ForEmployee
{
    public class PositionRepository : IRepository<Position>
    {
        private readonly ShopContext db;

        public PositionRepository(ShopContext context)
        {
            db = context;
        }

        public void Create(Position item)
        {
            db.Positions.Add(item);
        }

        public void Delete(int id)
        {
            var position = db.Positions.Find(id);
            if(position != null)
            {
                db.Positions.Remove(position);
            }
        }

        public IEnumerable<Position> Find(Func<Position, bool> predicate)
        {
            return db.Positions.Where(predicate).ToList();
        }

        public Position Get(int id)
        {
            return db.Positions.Find(id); 
        }

        public IEnumerable<Position> GetAll()
        {
            return db.Positions;
        }

        public void Update(Position item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

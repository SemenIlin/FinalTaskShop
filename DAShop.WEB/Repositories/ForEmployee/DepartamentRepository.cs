using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAShop.WEB.Repositories.ForEmployee
{
    public class DepartamentRepository : IRepository<Departament>
    {
        private readonly ShopContext shop;

        public DepartamentRepository(ShopContext shop)
        {
            this.shop = shop;
        }

        public void Create(Departament item)
        {
            shop.Departaments.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var departament = shop.Departaments.Find(id);
            shop.Departaments.Remove(departament);

            Save();
        }

        public IEnumerable<Departament> Find(Func<Departament, bool> predicate)
        {
            return shop.Departaments.Where(predicate).ToList();
        }

        public Departament Get(int id)
        {
            return shop.Departaments.Find(id);
        }

        public IEnumerable<Departament> GetAll()
        {
            return shop.Departaments;
        }

        public void Save()
        {
            shop.SaveChanges();
        }

        public void Update(Departament item)
        {
            shop.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}

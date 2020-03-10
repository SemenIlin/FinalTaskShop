using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAShop.WEB.Repositories.ForEmployee
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly ShopContext db;

        public EmployeeRepository(ShopContext context)
        {
            db = context;
        }

        public void Create(Employee item)
        {
            db.Employees.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);

            Save();
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            return db.Employees.Include(p=>p.Position).Where(predicate).ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.Include(p => p.Position);
        }

        public void Update(Employee item)
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

using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForGood;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAShop.WEB.Repositories.ForGood
{
    public class ReportOfSaleRepository : IRepository<ReportOfSale>
    {
        private readonly ShopContext shopContext;

        public ReportOfSaleRepository(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public void Create(ReportOfSale item)
        {
            shopContext.ReportsOfSales.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var report = shopContext.ReportsOfSales.Find(id);
            shopContext.ReportsOfSales.Remove(report);

            Save();
        }

        public void Dispose()
        {
            shopContext.Dispose();
        }

        public IEnumerable<ReportOfSale> Find(Func<ReportOfSale, bool> predicate)
        {
            return shopContext.ReportsOfSales.Include(t => t.Good).Where(predicate).ToList();
        }

        public ReportOfSale Get(int id)
        {
            return shopContext.ReportsOfSales.Find(id);
        }

        public IEnumerable<ReportOfSale> GetAll()
        {
            return shopContext.ReportsOfSales.Include(t => t.Good);
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }

        public void Update(ReportOfSale item)
        {
            shopContext.Entry(item).State = EntityState.Modified;
            Save();
        }
    }
}

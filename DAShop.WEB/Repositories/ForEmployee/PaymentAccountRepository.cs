using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAShop.WEB.Repositories.ForEmployee
{
    public class PaymentAccountRepository : IRepository<PaymentAccount>
    {
        private readonly ShopContext db;

        public PaymentAccountRepository(ShopContext context)
        {
            db = context;
        }

        public void Create(PaymentAccount item)
        {
            db.PaymentAccounts.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var paymentAccount = db.PaymentAccounts.Find(id);
            db.PaymentAccounts.Remove(paymentAccount);

            Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<PaymentAccount> Find(Func<PaymentAccount, bool> predicate)
        {
            return db.PaymentAccounts.Where(predicate).ToList();
        }

        public PaymentAccount Get(int id)
        {
            return db.PaymentAccounts.Find(id);
        }

        public IEnumerable<PaymentAccount> GetAll()
        {
            return db.PaymentAccounts;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(PaymentAccount item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }
    }
}

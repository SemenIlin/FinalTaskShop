using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForGood;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAShop.WEB.Repositories.ForGood
{
    public class GoodUOW : IGoodUnitOfWork
    {
        private readonly ShopContext db;

        private IRepository<Good> goods;
        private IRepository<Repair> repairs;
        private IRepository<Transportation> transportations;

        private bool disposed = false;

        public GoodUOW(ShopContext context)
        {
            db = context;
        }

        public IRepository<Good> Goods 
        {
            get
            {
                if(goods == null)
                {
                    goods = new GoodRepository(db);
                }

                return goods;
            }
        }

        public IRepository<Repair> Repairs
        {
            get
            {
                if(repairs == null)
                {
                    repairs = new RepairRepository(db);
                }

                return repairs;
            }
        }

        public IRepository<Transportation> Transportations
        {
            get 
            {
                if(transportations == null)
                {
                    transportations = new TransportationRepository(db);
                }

                return transportations;
            
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

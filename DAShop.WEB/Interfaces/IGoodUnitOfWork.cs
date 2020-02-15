using DAShop.WEB.Models.ForGood;
using System;

namespace DAShop.WEB.Interfaces
{
    public interface IGoodUnitOfWork : IDisposable
    {
        IRepository<Good> Goods { get; }
        IRepository<Repair> Repairs { get; }
        IRepository<Transportation> Transportations { get; }
    }
}

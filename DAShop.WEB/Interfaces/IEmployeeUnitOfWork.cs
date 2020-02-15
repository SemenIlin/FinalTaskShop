using DAShop.WEB.Models.ForEmployee;
using System;

namespace DAShop.WEB.Interfaces
{
    public interface IEmployeeUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<BonusOrFine> BonusOfFines { get; }
        IRepository<Position> Positions { get; }
        IRepository<SickLeave> SickLeaves { get; }
    }
}

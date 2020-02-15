using DAShop.WEB.EFCore;
using DAShop.WEB.Interfaces;
using DAShop.WEB.Models.ForEmployee;
using DAShop.WEB.Repositories.ForEmployee;
using System;

namespace DAShop.WEB.Repositories
{
    public class EmployeeUOW : IEmployeeUnitOfWork
    {
        private readonly ShopContext db;

        private IRepository<Employee> employees;
        private IRepository<BonusOrFine> bonusOfFines;
        private IRepository<Position> positions;
        private IRepository<SickLeave> sickLeaves;

        private bool disposed = false;

        public EmployeeUOW(ShopContext context)
        {
            db = context;
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employees == null)
                {
                    employees = new EmployeeRepository(db);
                }

                return employees;
            }
        }

        public IRepository<BonusOrFine> BonusOfFines
        {
            get 
            {
                if(bonusOfFines == null)
                {
                    bonusOfFines = new BonusOrFineRepository(db);
                }

                return bonusOfFines;
            }
        }

        public IRepository<Position> Positions
        {
            get
            {
                if(positions == null)
                {
                    positions = new PositionRepository(db);
                }

                return positions;
            }
        }

        public IRepository<SickLeave> SickLeaves
        {
            get
            {
                if(sickLeaves == null)
                {
                    sickLeaves = new SickLeaveRepository(db);
                }

                return sickLeaves;
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

using DAShop.WEB.Models.ForEmployee;
using DAShop.WEB.Models.ForGood;
using DAShop.WEB.Models.ForRentalSpaces;
using Microsoft.EntityFrameworkCore;

namespace DAShop.WEB.EFCore
{
    public class ShopContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BonusOrFine> BonusOrFines { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }

        public DbSet<Good> Goods { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        public DbSet<RentalSpace> RentalSpaces { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

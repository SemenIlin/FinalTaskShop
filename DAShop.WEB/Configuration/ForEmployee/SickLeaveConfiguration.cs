using DAShop.WEB.Models.ForEmployee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAShop.WEB.Configuration.ForEmployee
{
    public class SickLeaveConfiguration : IEntityTypeConfiguration<SickLeave>
    {
        public void Configure(EntityTypeBuilder<SickLeave> builder)
        {
            builder.ToTable("Sick Leave");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartOfTheSickLeave).IsRequired();
            builder.Property(x => x.FinishOfTheSickLeave).IsRequired();
            builder.Property(x => x.MonetaryCompensation).IsRequired();
            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.EmployeeId);
        }
    }
}

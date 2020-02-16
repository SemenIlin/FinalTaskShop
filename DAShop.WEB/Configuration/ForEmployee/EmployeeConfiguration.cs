using DAShop.WEB.Models.ForEmployee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAShop.WEB.Configuration.ForEmployee
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.SurName).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Patronymic).HasMaxLength(30);
            builder.Property(x => x.Birthday).IsRequired();

            builder.HasOne(x => x.Position).WithMany().HasForeignKey(x => x.PositionId);
        }
    }
}

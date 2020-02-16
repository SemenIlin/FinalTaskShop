using DAShop.WEB.Models.ForEmployee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAShop.WEB.Configuration.ForEmployee
{
    public class BonusOrFineConfiguration : IEntityTypeConfiguration<BonusOrFine>
    {
        public void Configure(EntityTypeBuilder<BonusOrFine> builder)
        {
            builder.ToTable("Bonus Or Fine");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.AmountOfBonusOrFine).HasDefaultValue(0);

            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.EmployeeId);




        }
    }
}

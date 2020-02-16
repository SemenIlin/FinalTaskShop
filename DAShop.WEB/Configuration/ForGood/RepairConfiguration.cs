using DAShop.WEB.Models.ForGood;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAShop.WEB.Configuration.ForGood
{
    public class RepairConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder.ToTable("Repairs");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DateOfRepair).IsRequired();
            builder.Property(x => x.CostOfRepair).HasDefaultValue(0);

            builder.HasOne(x => x.Transportation).WithMany().HasForeignKey(x => x.TransportationId);
        }
    }
}

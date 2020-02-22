using DAShop.WEB.Models.ForRentalSpaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAShop.WEB.Configuration.ForRentalSpace
{
    public class RentalSpacesConfiguration : IEntityTypeConfiguration<RentalSpace>
    {
        public void Configure(EntityTypeBuilder<RentalSpace> builder)
        {
            builder.ToTable("Rental Space");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Month).IsRequired();
            builder.Property(x => x.Rental).IsRequired();
        }
    }
}

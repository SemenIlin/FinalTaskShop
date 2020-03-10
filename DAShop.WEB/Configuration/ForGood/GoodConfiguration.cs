using DAShop.WEB.Models.ForGood;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAShop.WEB.Configuration.ForGood
{
    public class GoodConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.ToTable("Good");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PurchasePrice).IsRequired();
            builder.Property(x => x.SalePrice).IsRequired();
            builder.Property(x => x.Qyantity).IsRequired();

            builder.HasOne(x => x.Transportation).WithMany().HasForeignKey(x => x.TransportationId);
        }
    }
}

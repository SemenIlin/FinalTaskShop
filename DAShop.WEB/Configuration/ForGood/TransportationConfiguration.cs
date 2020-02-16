using DAShop.WEB.Models.ForGood;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAShop.WEB.Configuration.ForGood
{
    public class TransportationConfiguration : IEntityTypeConfiguration<Transportation>
    {
        public void Configure(EntityTypeBuilder<Transportation> builder)
        {
            builder.ToTable("Transportations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataOfSend).IsRequired();
            builder.Property(x => x.CostOfDelivery).IsRequired();
            builder.Property(x => x.CostOfDelivery).HasDefaultValue(0);

        }
    }
}

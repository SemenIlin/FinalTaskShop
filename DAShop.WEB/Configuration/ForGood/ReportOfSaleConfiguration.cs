using DAShop.WEB.Models.ForGood;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAShop.WEB.Configuration.ForGood
{
    public class ReportOfSaleConfiguration : IEntityTypeConfiguration<ReportOfSale>
    {
        public void Configure(EntityTypeBuilder<ReportOfSale> builder)
        {
            builder.ToTable("ReportsOfSales");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.QuantityOfSales).IsRequired();

            builder.HasOne(x => x.Good).WithMany().HasForeignKey(x => x.GoodId);
        }    
    }
}

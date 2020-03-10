using DAShop.WEB.Models.ForEmployee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAShop.WEB.Configuration.ForEmployee
{
    public class PaymentAccountConfiguration: IEntityTypeConfiguration<PaymentAccount>
    {
        public void Configure(EntityTypeBuilder<PaymentAccount> builder)
        {
            builder.ToTable("PaymentAccount");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Payday).IsRequired();
            builder.Property(x => x.Salary).IsRequired();
            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.EmployeeId);
        }    
    }
}

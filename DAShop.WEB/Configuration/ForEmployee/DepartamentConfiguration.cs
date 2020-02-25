using DAShop.WEB.Models.ForEmployee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAShop.WEB.Configuration.ForEmployee
{
    public class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            builder.ToTable("Departaments");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
        }
    }
}

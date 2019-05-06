using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Package.Core.Domain.Zone;
using Package.Core.Extentions;

namespace Package.EntityFrameworkCore.Mapping
{
    internal class CityMap : DbEntityConfiguration<City>
    {
        public override void Configure(EntityTypeBuilder<City> entity)
        {
            entity.ToTable("City");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).HasMaxLength(255).IsRequired();
            entity.Property(c => c.Code).HasMaxLength(255).IsRequired();
        }
    }
}

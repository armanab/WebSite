using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Package.Core.Domain.Content;
using Package.Core.Extentions;

namespace Package.EntityFrameworkCore.Mapping
{
    internal class ProductMap : DbEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Product");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Title).HasMaxLength(255).IsRequired();
           
        }
    }
}

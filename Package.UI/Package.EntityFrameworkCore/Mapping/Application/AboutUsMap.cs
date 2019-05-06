using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Package.Core.Domain.Application;
using Package.Core.Domain.Media;
using Package.Core.Extentions;


namespace Package.EntityFrameworkCore.Application
{
    internal class AboutUsMap : DbEntityConfiguration<AboutUs>
    {
        public override void Configure(EntityTypeBuilder<AboutUs> entity)
        {
            entity.ToTable("AboutUs");
            entity.HasKey(c => c.Id);
            
        }
    }
}

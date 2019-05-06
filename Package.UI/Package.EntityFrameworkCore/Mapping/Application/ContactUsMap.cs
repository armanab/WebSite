using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Package.Core.Domain.Application;
using Package.Core.Domain.Media;
using Package.Core.Extentions;


namespace Package.EntityFrameworkCore.Application
{
    internal class ContactUsMap : DbEntityConfiguration<ContactUs>
    {
        public override void Configure(EntityTypeBuilder<ContactUs> entity)
        {
            entity.ToTable("ContactUs");
            entity.HasKey(c => c.Id);
            
        }
    }
}

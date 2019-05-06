using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Package.Core.Domain.Application;
using Package.Core.Domain.Media;
using Package.Core.Extentions;


namespace Package.EntityFrameworkCore.Application
{
    internal class ApplicationSettingMap : DbEntityConfiguration<ApplicationSetting>
    {
        public override void Configure(EntityTypeBuilder<ApplicationSetting> entity)
        {
            entity.ToTable("ApplicationSetting");
            entity.HasKey(c => c.Id);
        }
    }
}

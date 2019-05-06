using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Package.Core.Domain.Media;
using Package.Core.Extentions;


namespace Package.EntityFrameworkCore.Mapping
{
    internal class MediaMap : DbEntityConfiguration<Picture>
    {
        public override void Configure(EntityTypeBuilder<Picture> entity)
        {
            entity.ToTable("Picture");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Height).HasMaxLength(255);
            entity.Property(c => c.Width).HasMaxLength(255);
        }
    }
}

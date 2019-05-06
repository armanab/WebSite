using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Package.Core.Domain;
using Package.Core.Extentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Package.EntityFrameworkCore.Mapping
{
    internal class TownMap : DbEntityConfiguration<Town>
    {
        public override void Configure(EntityTypeBuilder<Town> entity)
        {
            entity.ToTable("Town");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).HasMaxLength(255).IsRequired();
            //entity.HasKey(c => c.CityId).Metadata.Relational();
        }
    }
}

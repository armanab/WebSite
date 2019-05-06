using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Package.Core.Extentions
{
    internal static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(
          this ModelBuilder modelBuilder,
          DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : Entity.Entity
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
        }
    }

    internal abstract class DbEntityConfiguration<TEntity> where TEntity : Entity.Entity
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}

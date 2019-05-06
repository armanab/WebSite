using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Package.Core.Domain.Users;
using Package.Core.Extentions;
using Package.EntityFrameworkCore.Application;
using Package.EntityFrameworkCore.Mapping;
using System;

namespace Package.EntityFrameworkCore
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddConfiguration(new CityMap());
            builder.AddConfiguration(new CountryMap());
            builder.AddConfiguration(new TownMap());
            builder.AddConfiguration(new ProductMap());
            builder.AddConfiguration(new MediaMap());
            builder.AddConfiguration(new ApplicationSettingMap());
            builder.AddConfiguration(new AboutUsMap());
            builder.AddConfiguration(new ContactUsMap());

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }
    //public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    //{
    //    public ApplicationDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

    //        return new ApplicationDbContext(optionsBuilder.Options);
    //    }

    //}
}

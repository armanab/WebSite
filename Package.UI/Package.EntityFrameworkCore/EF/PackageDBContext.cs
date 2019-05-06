using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Package.Core.Domain;
using Package.Core.Domain.Users;
using System;

namespace Package.EntityFrameworkCore.EF
{
    public class PackageDbContext : IdentityDbContext<User>
    {
        public PackageDbContext(DbContextOptions<PackageDbContext> options) : base(options)
        { }
        public PackageDbContext()
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  
        }

        internal static void Seed(IApplicationBuilder app)
        {
        }

        public static async void Seed(IServiceProvider applicationServices)
        {
            var context = applicationServices.GetService(typeof(PackageDbContext)) as PackageDbContext;
            var userManager = applicationServices.GetService(typeof(UserManager<User>)) as UserManager<User>;
            User user = null;
            user = await userManager.FindByNameAsync("demo@demo.com");
            if (user == null)
            {
                user = new User { UserName = "demo@demo.com", Email = "demo@demo.com" };
                await userManager.CreateAsync(user, "demo123");
            }
        }
    }
}

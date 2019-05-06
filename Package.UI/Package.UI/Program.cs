
using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Package.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Package.Core.Domain.Users;
using Microsoft.Extensions.Logging;
using AspNetCoreExample;

namespace Package.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<Role>>();

                    var dbInitializerLogger = services.GetRequiredService<ILogger<DbInitializer>>();
                    DbInitializer.Initialize(context, userManager, roleManager, dbInitializerLogger).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }



            host.Run();
            
            //BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var host = new WebHostBuilder()
                    .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                 .ConfigureServices(services => services.AddAutofac())
                .Build();


            return host;
        }
    }
}

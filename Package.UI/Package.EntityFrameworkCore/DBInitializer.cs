using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Package.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Package.EntityFrameworkCore
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<User> userManager,
            RoleManager<Role> roleManager, ILogger<DbInitializer> logger)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return; // DB has been seeded
            }

            await CreateDefaultUserAndRoleForApplication(userManager, roleManager, logger);
        }

        private static async Task CreateDefaultUserAndRoleForApplication(UserManager<User> um, RoleManager<Role> rm, ILogger<DbInitializer> logger)
        {
            const string administratorRole = "Administrator";
            const string email = "r.man.abi@gmail.com";

            await CreateDefaultAdministratorRole(rm, logger, administratorRole);
            var user = await CreateDefaultUser(um, logger, email);
            await SetPasswordForDefaultUser(um, logger, email, user);
            await AddDefaultRoleToDefaultUser(um, logger, email, administratorRole, user);
        }

        private static async Task CreateDefaultAdministratorRole(RoleManager<Role> rm, ILogger<DbInitializer> logger, string administratorRole)
        {
            logger.LogInformation($"Create the role `{administratorRole}` for application");
            var ir = await rm.CreateAsync(new Role(administratorRole));
            if (ir.Succeeded)
            {
                logger.LogDebug($"Created the role `{administratorRole}` successfully");
            }
            else
            {
                var exception = new ApplicationException($"Default role `{administratorRole}` cannot be created");
                logger.LogError(exception, GetIdentiryErrorsInCommaSeperatedList(ir));
                throw exception;
            }
        }

        private static async Task<User> CreateDefaultUser(UserManager<User> um, ILogger<DbInitializer> logger, string email)
        {
            logger.LogInformation($"Create default user with email `{email}` for application");
            var user = new User(email, "Admin", "Admini", "Admin");

            var ir = await um.CreateAsync(user);
            if (ir.Succeeded)
            {
                logger.LogDebug($"Created default user `{email}` successfully");
            }
            else
            {
                var exception = new ApplicationException($"Default user `{email}` cannot be created");
                logger.LogError(exception, GetIdentiryErrorsInCommaSeperatedList(ir));
                throw exception;
            }

            var createdUser = await um.FindByEmailAsync(email);
            return createdUser;
        }

        private static async Task SetPasswordForDefaultUser(UserManager<User> um, ILogger<DbInitializer> logger, string email, User user)
        {
            logger.LogInformation($"Set password for default user `{email}`");
            const string password = "YourPassword01!";
            var ir = await um.AddPasswordAsync(user, password);
            if (ir.Succeeded)
            {
                logger.LogTrace($"Set password `{password}` for default user `{email}` successfully");
            }
            else
            {
                var exception = new ApplicationException($"Password for the user `{email}` cannot be set");
                logger.LogError(exception, GetIdentiryErrorsInCommaSeperatedList(ir));
                throw exception;
            }
        }

        private static async Task AddDefaultRoleToDefaultUser(UserManager<User> um, ILogger<DbInitializer> logger, string email, string administratorRole, User user)
        {
            logger.LogInformation($"Add default user `{email}` to role '{administratorRole}'");
            var ir = await um.AddToRoleAsync(user, administratorRole);
            if (ir.Succeeded)
            {
                logger.LogDebug($"Added the role '{administratorRole}' to default user `{email}` successfully");
            }
            else
            {
                var exception = new ApplicationException($"The role `{administratorRole}` cannot be set for the user `{email}`");
                logger.LogError(exception, GetIdentiryErrorsInCommaSeperatedList(ir));
                throw exception;
            }
        }

        private static string GetIdentiryErrorsInCommaSeperatedList(IdentityResult ir)
        {
            string errors = null;
            foreach (var identityError in ir.Errors)
            {
                errors += identityError.Description;
                errors += ", ";
            }
            return errors;
        }
    }
}
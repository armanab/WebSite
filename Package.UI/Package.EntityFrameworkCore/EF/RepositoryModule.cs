using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Package.EntityFrameworkCore.EF
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterModule(new CoreModule());

            //builder.RegisterType<BookingEngineDbContext>().As<IDbContext>().WithParameter("conStr", "DefaultConnection").InstancePerLifetimeScope();
            //builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<DbContextFactory>().As<IDbContextFactory>().InstancePerLifetimeScope();
            //builder.RegisterType<BookingEngineDbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}

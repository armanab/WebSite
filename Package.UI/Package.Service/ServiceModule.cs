using System.Diagnostics;
using Autofac;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Package.Core.Domain.Application;
using Package.Core.Domain.Content;
using Package.EntityFrameworkCore.EF;
using Package.Service.Application;
using Package.Service.Content;
using Package.Service.Implementation;

namespace Package.Service
{
    //"DefaultConnection"
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.Register(c => new ApplicationSettingService(c.Resolve<IRepository<ApplicationSetting>>(), c.Resolve<ICacheService>()))
           .As<IApplicationSettingService>()
           .InstancePerLifetimeScope();

            builder.Register(c => new ProductService(c.Resolve<IMapper>(), c.Resolve<IRepository<Product>>()))
              .As<IProductService>()
              .InstancePerLifetimeScope();

            builder.Register(c => new CacheService(c.Resolve<IMemoryCache>()))
          .As<ICacheService>()
          .InstancePerLifetimeScope();
            //builder.RegisterType<UserResetPasswordTask>().As<UserResetPasswordTask>().InstancePerLifetimeScope();
            //builder.RegisterType<UserRegisterTask>().As<UserRegisterTask>().InstancePerLifetimeScope();
            //builder.RegisterType<UserSendEmailNotifyTask>().As<UserSendEmailNotifyTask>().InstancePerLifetimeScope(); 
        }
    }
}
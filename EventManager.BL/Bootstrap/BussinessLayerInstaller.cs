using System;
using System.Data.Entity;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EventManager.BL.AppEfConfiguration;
using EventManager.BL.Miscellaneous.DateTimeProvider;
using EventManager.BL.Services;
using EventManager.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace EventManager.BL.Bootstrap
{
    public class BussinessLayerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<Func<DbContext>>()
                    .Instance(() => new EventManagerDbContext())
                    .LifestyleTransient(),

                Component.For<IUnitOfWorkProvider>()
                    .ImplementedBy<AppUnitOfWorkProvider>()
                    .LifestyleSingleton(),

                Component.For<IUnitOfWorkRegistry>()
                    .Instance(new HttpContextUnitOfWorkRegistry(new ThreadLocalUnitOfWorkRegistry()))
                    .LifestyleSingleton(),

                Component.For(typeof(IRepository<,>))
                    .ImplementedBy(typeof(EntityFrameworkRepository<,>))
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<AppUnitOfWork>()
                    .BasedOn(typeof(AppQuery<>))
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<AppUnitOfWork>()
                    .BasedOn(typeof(IRepository<,>))
                    .LifestyleTransient(),

                Classes.FromThisAssembly()
                    .BasedOn<EventManagerService>()
                    .WithServiceDefaultInterfaces()
                    .LifestyleTransient(),

                Component.For<IDateTimeProvider>()
                    .Instance(new DateTimeProvider())
                    .LifestyleSingleton(),

                Classes.FromThisAssembly().InNamespace("EventManager.BL.Facades")
                );
        }
    }
}

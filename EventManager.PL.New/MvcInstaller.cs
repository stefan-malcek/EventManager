using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EventManager.PL.Helpers;

namespace EventManager.PL
{
    public class MvcInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<SignInManager>()
                    .ImplementedBy<SignInManager>()
                    .LifestyleTransient(),

                Classes.FromThisAssembly()
                    .BasedOn<IController>()
                    .LifestyleTransient()
                    );
        }
    }
}
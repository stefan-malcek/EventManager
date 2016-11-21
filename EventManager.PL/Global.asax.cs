using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using EventManager.BL.Bootstrap;

namespace EventManager.PL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer _container;

        public MvcApplication()
        {
            _container = new WindsorContainer();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureBoostrap();
        }

        private void ConfigureBoostrap()
        { 
            // configure DI            
            _container.Install(new BussinessLayerInstaller());
            _container.Install(new MvcInstaller());

            // configure mapping within BL
            AutoMapperConfig.Initialize();

            // initialize default user accounts (admin, ...)
            // UserAccountInit.InitializeUserAccounts(container);

            // set controller factory
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}

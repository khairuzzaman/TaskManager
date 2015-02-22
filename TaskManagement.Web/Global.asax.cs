using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TaskManagement.Web.DIContainer;
using Autofac;
using System.Reflection;
using Autofac.Integration.WebApi;

namespace TaskManagement.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Autofac Configuration
            var config = GlobalConfiguration.Configuration;

            var builder = new Autofac.ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();


            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());

            //var container = builder.Build();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //config.DependencyResolver = new au
            //DependencyResolver.SetResolver(new AutofacWebApiDependencyResolver(container));
        }
    }
}

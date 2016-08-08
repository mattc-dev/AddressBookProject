using AddressBook.DAL;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Http;
using System.Web.Mvc;

namespace AddressBook
{
    public static class WebApiConfig
    {
        private static IContainer Container { get; set; }

        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //IoC registration (normally this would be a separate class)
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<DataAccessImpl>().As<IDataAccess>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

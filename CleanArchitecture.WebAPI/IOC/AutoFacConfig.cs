using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.WebApi;
using CleanArchitecture.Application.Common;
using System.Linq;
using System.Reflection;
namespace CleanArchitecture.WebAPI.IOC
{
    /// <summary>
    /// Contains method to initiate IoC and register types and modules.
    /// </summary>
    public static class AutoFacConfig
    {
        /// <summary>
        /// Build IoC Container and register types and modules.
        /// </summary>
        public static Autofac.IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            //Register All API Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Get All assemblies
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            //Register all types by its implements interface
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .Where(t => t.Namespace != null
            //        && t.Namespace.StartsWith("CleanArchitecture")
            //        && t != typeof(FileLogging))
            //    .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t != typeof(FileLogging))
                .AsImplementedInterfaces();
            //Register modules that may override configuration from assembly scan.
            //builder.RegisterAssemblyModules(assemblies
            //    .Where(c => c.FullName.StartsWith("LinkDev"))
            //    .ToArray());


            // The Microsoft.Extensions.DependencyInjection.ServiceCollection
            // has extension methods provided by other .NET Core libraries to
            // register services with DI.
            var serviceCollection = new ServiceCollection();

            // The Microsoft.Extensions.Logging package provides this one-liner
            // to add logging services.
            serviceCollection.AddLogging();

            var containerBuilder = new ContainerBuilder();

            // Once you've registered everything in the ServiceCollection, call
            // Populate to bring those registrations into Autofac. This is
            // just like a foreach over the list of things in the collection
            // to add them to Autofac.
            containerBuilder.Populate(serviceCollection);

            // Make your Autofac registrations. Order is important!
            // If you make them BEFORE you call Populate, then the
            // registrations in the ServiceCollection will override Autofac
            // registrations; if you make them AFTER Populate, the Autofac
            // registrations will override. You can make registrations
            // before or after Populate, however you choose.
            //containerBuilder.RegisterType<MessageHandler>().As<IHandler>();

            // Creating a new AutofacServiceProvider makes the container
            // available to your app using the Microsoft IServiceProvider
            // interface so you can use those abstractions rather than
            // binding directly to Autofac.
            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            return builder.Build();
        }

    }
}
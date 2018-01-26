using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OlmeLabs.LogAggregator.Configuration;
using OlmeLabs.LogAggregator.Repositories;

namespace OlmeLabs.LogAggregator
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<AppSettings>().As<IAppSettings>().SingleInstance();

            //http://mongodb.github.io/mongo-csharp-driver/2.0/reference/driver/connecting/
            //It is recommended to store a MongoClient instance in a global place, either as a static variable or 
            //in an IoC container with a singleton lifetime.         
            //prod storage
            builder.RegisterType<MongoDbStorage>().Named<IStorage>("MongoDbStorage").SingleInstance();
            builder.RegisterType<FileStrorage>().Named<IStorage>("FileSystemStorage").InstancePerRequest();
            builder.RegisterType<NoStorage>().Named<IStorage>("NoStorage").InstancePerRequest();

            builder.RegisterType<StorageFactory>().As<IStorageFactory>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
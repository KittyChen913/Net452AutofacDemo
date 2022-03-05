using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Utility.Logging.NLog.Autofac;

namespace Net452WebAPI
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //取得目前正在執行之程式碼的組件
            Assembly assembly = Assembly.GetExecutingAssembly();

            //註冊 NLog
            builder.RegisterModule(new NLogLoggerAutofacModule());

            //註冊 API controller
            builder.RegisterApiControllers(assembly);

            //註冊 HttpContext
            builder.Register(c => new HttpContextWrapper(HttpContext.Current))
                .As<HttpContextBase>()
                .InstancePerRequest();

            //註冊此方案內的其他專案 dll
            var libraryAssemblies = Directory.EnumerateFiles(
                    AppDomain.CurrentDomain.BaseDirectory, @"Net452*.dll",
                    SearchOption.AllDirectories)
                .Select(Assembly.LoadFrom);

            builder.RegisterAssemblyTypes(libraryAssemblies.ToArray())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //建立 Container
            Container = builder.Build();

            return Container;
        }
    }
}
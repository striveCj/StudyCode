using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using EFDI.DI.Core;

namespace EFDI.DI
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            //TODO:在控制器中依赖注入
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //TODO:在过滤器中依赖注入
            builder.RegisterFilterProvider();
            //TODO:在自定义视图中依赖注入
            builder.RegisterSource(new ViewRegistrationSource());
            //TODO:注册我们自定义的依赖
            builder.RegisterModule(new AutofacModule());

            var container = builder.Build();
            //TODO：设置Autofac容器到MVC依赖关系中
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
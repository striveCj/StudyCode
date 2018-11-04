using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using EFDI.DI.Core;

namespace EFDI.DI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //TODO:初始化Autofac容器
            AutofacConfig.ConfigureContainer();
            //TODO:AutoMapper映射配置
            Mapper.Initialize(cfg=>cfg.AddProfile<AutoMapperProfile>());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

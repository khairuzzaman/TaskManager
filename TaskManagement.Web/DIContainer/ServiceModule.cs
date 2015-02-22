using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;

namespace TaskManagement.Web.DIContainer
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.Load("TaskManagement.Service"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
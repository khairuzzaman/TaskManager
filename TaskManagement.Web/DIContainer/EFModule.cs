using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement.Core;

namespace TaskManagement.Web.DIContainer
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(TaskManagementContext)).As(typeof(IContext)).InstancePerLifetimeScope();
        }
    }
}
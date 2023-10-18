using Autofac;
using MillionAndUp.BL.V1.Services.Owner;
using MillionAndUp.BL.V1.Services.Property;
using MillionAndUp.BL.V1.Services.PropertyImage;
using MillionAndUp.BL.V1.Services.PropertyTrace;
using MillionAndUp.BL.V1.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.BL.V1
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterRepositories(builder);
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {            
            builder.RegisterType<OwnerService>().As<IOwnerService>();
            builder.RegisterType<PropertyService>().As<IPropertyService>();
            builder.RegisterType<PropertyImageService>().As<IPropertyImageService>();
            builder.RegisterType<PropertyTraceService>().As<IPropertyTraceService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}

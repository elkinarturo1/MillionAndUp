using Autofac;
using MillionAndUp.BL.V1.Properties.Property;
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
            builder.RegisterType<PropertyBL>().As<IPropertyBL>();
        }
    }
}

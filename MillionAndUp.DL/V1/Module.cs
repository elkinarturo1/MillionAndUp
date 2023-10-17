using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1
{
    public class Module: Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            RegisterRepositoriesBuilder(builder);
        }

        private void RegisterRepositoriesBuilder(ContainerBuilder builder)
        {
            builder.RegisterType<MapeoProperty>().As<IMapeoProperty>();
        }

    }
}

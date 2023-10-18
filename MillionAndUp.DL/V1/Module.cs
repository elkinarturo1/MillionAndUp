using Autofac;
using MillionAndUp.DL.V1.Maping.Property;
using MillionAndUp.DL.V1.Repositories.Property;
using MillionAndUp.DL.V1.Unit_Of_Work.Property;
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
            builder.RegisterType<Map_Property_DataSet_To_Entity>().As<IMap_Property_DataSet_To_Entity>();
            builder.RegisterType<Unit_Of_Work_Property>().As<IUnit_Of_Work_Property>();
            builder.RegisterType<PropertyRepository>().As<IPropertyRepository>();
        }

    }
}

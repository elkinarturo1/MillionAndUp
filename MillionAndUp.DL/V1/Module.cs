using Autofac;
using MillionAndUp.DL.V1.Maping.Owner;
using MillionAndUp.DL.V1.Maping.Property;
using MillionAndUp.DL.V1.Maping.PropertyImage;
using MillionAndUp.DL.V1.Maping.PropertyTrace;
using MillionAndUp.DL.V1.Repositories.Owner;
using MillionAndUp.DL.V1.Repositories.Property;
using MillionAndUp.DL.V1.Repositories.PropertyImage;
using MillionAndUp.DL.V1.Repositories.PropertyTrace;
using MillionAndUp.DL.V1.Unit_Of_Work.Owner;
using MillionAndUp.DL.V1.Unit_Of_Work.Property;
using MillionAndUp.DL.V1.Unit_Of_Work.PropertyImage;
using MillionAndUp.DL.V1.Unit_Of_Work.PropertyTrace;
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
            //Map Inyection
            builder.RegisterType<Map_Owner_DataSet_To_Entity>().As<IMap_Owner_DataSet_To_Entity>();
            builder.RegisterType<Map_Property_DataSet_To_Entity>().As<IMap_Property_DataSet_To_Entity>();
            builder.RegisterType<Map_PropertyImage_DataSet_To_Entity>().As<IMap_PropertyImage_DataSet_To_Entity>();
            builder.RegisterType<Map_PropertyTrace_DataSet_To_Entity>().As<IMap_PropertyTrace_DataSet_To_Entity>();

            //Unit Inyection
            builder.RegisterType<Unit_Of_Work_Owner>().As<IUnit_Of_Work_Owner>();
            builder.RegisterType<Unit_Of_Work_Property>().As<IUnit_Of_Work_Property>();
            builder.RegisterType<Unit_Of_Work_PropertyImage>().As<IUnit_Of_Work_PropertyImage>();
            builder.RegisterType<Unit_Of_Work_PropertyTrace>().As<IUnit_Of_Work_PropertyTrace>();

            //Repository Inyection
            builder.RegisterType<OwnerRepository>().As<IOwnerRepository>();
            builder.RegisterType<PropertyRepository>().As<IPropertyRepository>();
            builder.RegisterType<PropertyImageRepository>().As<IPropertyImageRepository>();
            builder.RegisterType<PropertyTraceRepository>().As<IPropertyTraceRepository>();
        }

    }
}

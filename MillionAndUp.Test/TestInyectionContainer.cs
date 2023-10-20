using Autofac;
using AutoMapper;
using MillionAndUp.API.Controllers;
using MillionAndUp.BL.V1.Converters;
using MillionAndUp.BL.V1.Services.Owner;
using MillionAndUp.BL.V1.Services.Property;
using MillionAndUp.BL.V1.Services.PropertyImage;
using MillionAndUp.BL.V1.Services.PropertyTrace;
using MillionAndUp.DL.V1.Repositories.Owner;
using MillionAndUp.DL.V1.Repositories.Property;
using MillionAndUp.DL.V1.Repositories.PropertyImage;
using MillionAndUp.DL.V1.Repositories.PropertyTrace;
using MillionAndUp.DL.V1.Unit_Of_Work.Owner;
using MillionAndUp.DL.V1.Unit_Of_Work.Property;
using MillionAndUp.DL.V1.Unit_Of_Work.PropertyImage;
using MillionAndUp.DL.V1.Unit_Of_Work.PropertyTrace;

namespace MillionAndUp.Test
{
    public class TestInyectionContainer
    {
        public IContainer Container { get; private set; }

        public TestInyectionContainer()
        {
            var builder = new ContainerBuilder();

            // Configura AutoMapper y registra IMapper
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<OwnerMapping>();
                cfg.AddProfile<PropertyMapping>();
                cfg.AddProfile<PropertyImageMapping>();
                cfg.AddProfile<PropertyTraceMapping>();
            });
            IMapper mapper = new Mapper(mapperConfig);

            //registra IMapper
            builder.RegisterInstance(mapper)
                .As<IMapper>()
                .SingleInstance();

            builder.RegisterModule<MillionAndUp.BL.V1.Module>();
            builder.RegisterModule<MillionAndUp.DL.V1.Module>();

            builder.RegisterType<OwnerService>().As<IOwnerService>();
            builder.RegisterType<PropertyService>().As<IPropertyService>();
            builder.RegisterType<PropertyImageService>().As<IPropertyImageService>();
            builder.RegisterType<PropertyTraceService>().As<IPropertyTraceService>();

            builder.RegisterType<OwnerController>();
            builder.RegisterType<PropertyController>();
            builder.RegisterType<PropertyImageController>();
            builder.RegisterType<PropertyTraceController>();

            builder.RegisterType<OwnerRepository>().As<IOwnerRepository>();
            builder.RegisterType<PropertyRepository>().As<IPropertyRepository>();
            builder.RegisterType<PropertyImageRepository>().As<IPropertyImageRepository>();
            builder.RegisterType<PropertyTraceRepository>().As<IPropertyTraceRepository>();

            builder.RegisterType<OwnerService>();
            builder.RegisterType<PropertyService>();
            builder.RegisterType<PropertyImageService>();
            builder.RegisterType<PropertyTraceService>();


            builder.RegisterType<Unit_Of_Work_Owner>().As<IUnit_Of_Work_Owner>();
            builder.RegisterType<Unit_Of_Work_Property>().As<Unit_Of_Work_Property>();
            builder.RegisterType<Unit_Of_Work_PropertyImage>().As<Unit_Of_Work_PropertyImage>();
            builder.RegisterType<Unit_Of_Work_PropertyTrace>().As<Unit_Of_Work_PropertyTrace>();

            builder.RegisterType<OwnerRepository>();
            builder.RegisterType<PropertyRepository>();
            builder.RegisterType<PropertyImageRepository>();
            builder.RegisterType<PropertyTraceRepository>();

            Container = builder.Build();
        }

    }
}

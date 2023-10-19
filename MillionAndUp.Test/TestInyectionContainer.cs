using Autofac;
using AutoMapper;
using MillionAndUp.API.Controllers;
using MillionAndUp.BL.V1.Converters;
using MillionAndUp.BL.V1.Services.Owner;
using MillionAndUp.BL.V1.Services.Property;
using MillionAndUp.BL.V1.Services.PropertyImage;
using MillionAndUp.BL.V1.Services.PropertyTrace;

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

            // Registra implementaciones específicas de pruebas o mocks si es necesario
            // builder.Register...

            Container = builder.Build();
        }

    }
}

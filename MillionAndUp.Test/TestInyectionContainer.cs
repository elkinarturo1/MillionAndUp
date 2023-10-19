using Autofac;
using AutoMapper;
using MillionAndUp.API.Controllers;
using MillionAndUp.BL.V1.Converters;
using MillionAndUp.BL.V1.Services.Property;


namespace MillionAndUp.Test
{
    public class TestInyectionContainer
    {
        public IContainer Container { get; private set; }

        public TestInyectionContainer()
        {
            var builder = new ContainerBuilder();

            // Configura AutoMapper y registra IMapper
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<PropertyMapping>());
            IMapper mapper = new Mapper(mapperConfig);

            //registra IMapper
            builder.RegisterInstance(mapper)
                .As<IMapper>()
                .SingleInstance();

            builder.RegisterModule<MillionAndUp.BL.V1.Module>();
            builder.RegisterModule<MillionAndUp.DL.V1.Module>();
            builder.RegisterType<PropertyService>().As<IPropertyService>();
            builder.RegisterType<PropertyController>();

            // Registra implementaciones específicas de pruebas o mocks si es necesario
            // builder.Register...

            Container = builder.Build();
        }

    }
}

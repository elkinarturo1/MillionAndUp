using MillionAndUp.DL.V1.Repositories.Property;
using MillionAndUp.Entities.V1;
using MillionAndUp.Dtos.V1;
using AutoMapper;
using MillionAndUp.Dtos.V1.PropertiesDtos;

namespace MillionAndUp.BL.V1.Properties.Property
{
    public class PropertyBL: IPropertyBL
    {

        private readonly IMapper autoMapper;
        IPropertyRepository propertyRepository;

        public PropertyBL(IMapper p_autoMapper, IPropertyRepository p_propertyRepository)
        {
            autoMapper = p_autoMapper;
            propertyRepository = p_propertyRepository;
        }

        public IEnumerable<PropertyEntity> accessData(Dictionary<string, object> parameters)
        {            
            IEnumerable<PropertyEntity> data;           

            try
            {            
                data = propertyRepository.Read(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al consultar la propiedad " + ex.Message);
            }

            return data;

        }


        public void Create(PropertyDto propertyDto)
        {

            try
            {
                var value = autoMapper.Map<PropertyEntity>(propertyDto);
                propertyRepository.Create(value);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al crear la propiedad " + ex.Message);
            }            

        }


    }
}

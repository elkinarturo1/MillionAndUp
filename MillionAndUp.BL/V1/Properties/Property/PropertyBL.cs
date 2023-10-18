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

        public PropertyBL(IMapper p_autoMapper) {
            autoMapper = p_autoMapper;            
        }

        public IEnumerable<PropertyEntity> accessData(Dictionary<string, object> parameters)
        {            
            IEnumerable<PropertyEntity> data;
            PropertyRepository propertyRepository = new PropertyRepository();

            try
            {            
                data = propertyRepository.AccesData(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al consultar la propiedad " + ex.Message);
            }

            return data;

        }


        public void Create(PropertyDto propertyDto)
        {
            
            PropertyRepository propertyRepository = new PropertyRepository();

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

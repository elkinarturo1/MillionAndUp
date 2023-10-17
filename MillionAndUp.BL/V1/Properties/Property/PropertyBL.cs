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

                //parametersDTO.parameters.Add("@IdProperty",HttpContext.Request.Query["IdProperty"]);
                //parametersDTO.parameters.Add("@Name", HttpContext.Request.Query["Name"]);
                //parametersDTO.parameters.Add("@Address", HttpContext.Request.Query["Address"]);
                //parametersDTO.parameters.Add("@Price", HttpContext.Request.Query["Price"]);
                //parametersDTO.parameters.Add("@CodeInternal", HttpContext.Request.Query["CodeInternal"]);
                //parametersDTO.parameters.Add("@Year", HttpContext.Request.Query["Year"]);

                //parametersDTO.parameters.Add("@page", HttpContext.Request.Query["page"].ToString());
                //parametersDTO.parameters.Add("@RowsCount", HttpContext.Request.Query["RowsCount"].ToString());


                data = propertyRepository.AccesData(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al consultar la propiedad " + ex.Message);
            }

            return data;

        }
        

    }
}

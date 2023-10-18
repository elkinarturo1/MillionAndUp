using AutoMapper;
using MillionAndUp.Dtos.V1;
using MillionAndUp.Entities.V1;

namespace MillionAndUp.BL.V1.Converters
{
    public class PropertyMapping : Profile
    {

        public PropertyMapping()
        {
            // Entity to Dto
            CreateMap<PropertyEntity, PropertyDto>();

            // Dto to Entity
            CreateMap<PropertyDto, PropertyEntity>();
        }      

    }
}

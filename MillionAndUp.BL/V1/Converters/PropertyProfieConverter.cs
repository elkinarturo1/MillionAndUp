using AutoMapper;
using MillionAndUp.Dtos.V1.PropertiesDtos;
using MillionAndUp.Entities.V1;

namespace MillionAndUp.BL.V1.Converters
{
    public class PropertyProfieConverter : Profile
    {

        public PropertyProfieConverter()
        {
            // Entity to Dto
            CreateMap<PropertyEntity, PropertyDto>();

            // Dto to Entity
            CreateMap<PropertyDto, PropertyEntity>();
        }      

    }
}

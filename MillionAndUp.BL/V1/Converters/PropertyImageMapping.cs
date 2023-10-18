using AutoMapper;
using MillionAndUp.Dtos.V1;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.BL.V1.Converters
{
    public class PropertyImageMapping : Profile
    {

        public PropertyImageMapping()
        {
            // Entity to Dto
            CreateMap<PropertyImageEntity, PropertyImageDto>();

            // Dto to Entity
            CreateMap<PropertyImageDto, PropertyImageEntity>();
        }

    }
}

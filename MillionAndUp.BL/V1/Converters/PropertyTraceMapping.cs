
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
    internal class PropertyTraceMapping : Profile
    {

        public PropertyTraceMapping()
        {
            // Entity to Dto
            CreateMap<PropertyTraceEntity, PropertyTraceDto>();

            // Dto to Entity
            CreateMap<PropertyTraceDto, PropertyTraceEntity>();
        }

    }
}

using MillionAndUp.Dtos.V1;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MillionAndUp.BL.V1.Converters
{
    public class OwnerMapping : Profile
    {
        public OwnerMapping()
        {
            // Entity to Dto
            CreateMap<OwnerEntity, OwnerDto>();

            // Dto to Entity
            CreateMap<OwnerDto, OwnerEntity>();
        }
    }
}

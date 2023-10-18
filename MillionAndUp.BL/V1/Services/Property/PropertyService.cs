using AutoMapper;
using MillionAndUp.DL.V1.Repositories.Property;
using MillionAndUp.Dtos.V1;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.BL.V1.Services.Property
{
    public class PropertyService : IPropertyService
    {
        private readonly IMapper autoMapper;
        IPropertyRepository propertyRepository;

        public PropertyService(IMapper p_autoMapper, IPropertyRepository p_propertyRepository)
        {
            autoMapper = p_autoMapper;
            propertyRepository = p_propertyRepository;
        }


        public void Create(PropertyDto dto)
        {
            var entity = autoMapper.Map<PropertyEntity>(dto);
            propertyRepository.Create(entity);
        }

        public IEnumerable<PropertyDto> Read(Dictionary<string, object> parameters)
        {
            IEnumerable<PropertyDto> data;

            var entity = propertyRepository.Read(parameters);
            data = autoMapper.Map<IEnumerable<PropertyDto>>(entity);

            return data;
        }

        public void Update(PropertyDto dto)
        {
            var entity = autoMapper.Map<PropertyEntity>(dto);
            propertyRepository.Update(entity);
        }

        public void Delete(int id)
        {
            propertyRepository.Delete(id);
        }

    }
}

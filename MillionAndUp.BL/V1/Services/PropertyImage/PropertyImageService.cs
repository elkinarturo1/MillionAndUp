using AutoMapper;
using MillionAndUp.DL.V1.Repositories.PropertyImage;
using MillionAndUp.Dtos.V1;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.BL.V1.Services.PropertyImage
{
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IMapper autoMapper;
        IPropertyImageRepository propertyRepository;

        public PropertyImageService(IMapper p_autoMapper, IPropertyImageRepository p_propertyRepository)
        {
            autoMapper = p_autoMapper;
            propertyRepository = p_propertyRepository;
        }


        public void Create(PropertyImageDto dto)
        {
            var entity = autoMapper.Map<PropertyImageEntity>(dto);
            propertyRepository.Create(entity);
        }

        public IEnumerable<PropertyImageDto> Read(Dictionary<string, object> parameters)
        {
            IEnumerable<PropertyImageDto> data;

            var entity = propertyRepository.Read(parameters);
            data = autoMapper.Map<IEnumerable<PropertyImageDto>>(entity);

            return data;
        }

        public void Update(PropertyImageDto dto)
        {
            var entity = autoMapper.Map<PropertyImageEntity>(dto);
            propertyRepository.Update(entity);
        }

        public void Delete(int id)
        {
            propertyRepository.Delete(id);
        }

    }
}

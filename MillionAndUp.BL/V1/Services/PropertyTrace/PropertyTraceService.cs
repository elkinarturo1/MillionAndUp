using AutoMapper;
using MillionAndUp.BL.V1.Services.PropertyImage;
using MillionAndUp.DL.V1.Repositories.PropertyImage;
using MillionAndUp.DL.V1.Repositories.PropertyTrace;
using MillionAndUp.Dtos.V1;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.BL.V1.Services.PropertyTrace
{
    public class PropertyTraceService : IPropertyTraceService
    {
        private readonly IMapper autoMapper;
        IPropertyTraceRepository propertyRepository;

        public PropertyTraceService(IMapper p_autoMapper, IPropertyTraceRepository p_propertyRepository)
        {
            autoMapper = p_autoMapper;
            propertyRepository = p_propertyRepository;
        }


        public void Create(PropertyTraceDto dto)
        {
            var entity = autoMapper.Map<PropertyTraceEntity>(dto);
            propertyRepository.Create(entity);
        }

        public IEnumerable<PropertyTraceDto> Read(Dictionary<string, object> parameters)
        {
            IEnumerable<PropertyTraceDto> data;

            var entity = propertyRepository.Read(parameters);
            data = autoMapper.Map<IEnumerable<PropertyTraceDto>>(entity);

            return data;
        }

        public void Update(PropertyTraceDto dto)
        {
            var entity = autoMapper.Map<PropertyTraceEntity>(dto);
            propertyRepository.Update(entity);
        }

        public void Delete(int id)
        {
            propertyRepository.Delete(id);
        }

    }
}

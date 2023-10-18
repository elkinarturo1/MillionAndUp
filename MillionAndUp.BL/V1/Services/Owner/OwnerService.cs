using AutoMapper;
using MillionAndUp.DL.V1.Repositories.Owner;
using MillionAndUp.DL.V1.Repositories.Property;
using MillionAndUp.Dtos.V1;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.BL.V1.Services.Owner
{
    public class OwnerService : IOwnerService
    {
        private readonly IMapper autoMapper;
        IOwnerRepository propertyRepository;

        public OwnerService(IMapper p_autoMapper, IOwnerRepository p_propertyRepository)
        {
            autoMapper = p_autoMapper;
            propertyRepository = p_propertyRepository;
        }


        public void Create(OwnerDto dto)
        {
            var entity = autoMapper.Map<OwnerEntity>(dto);
            propertyRepository.Create(entity);
        }

        public IEnumerable<OwnerDto> Read(Dictionary<string, object> parameters)
        {
            IEnumerable<OwnerDto> data;

            var entity = propertyRepository.Read(parameters);
            data = autoMapper.Map<IEnumerable<OwnerDto>>(entity);

            return data;
        }

        public void Update(OwnerDto dto)
        {
            var entity = autoMapper.Map<OwnerEntity>(dto);
            propertyRepository.Update(entity);
        }

        public void Delete(int id)
        {
            propertyRepository.Delete(id);
        }

    }
}

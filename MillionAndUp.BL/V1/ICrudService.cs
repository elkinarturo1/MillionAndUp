using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.BL.V1
{
    public interface ICrudService<TEntity>
    {
        void Create(TEntity dto);
        IEnumerable<TEntity> Read(Dictionary<string, object> parameters);
        void Update(TEntity dto);
        void Delete(int id);
    }
}

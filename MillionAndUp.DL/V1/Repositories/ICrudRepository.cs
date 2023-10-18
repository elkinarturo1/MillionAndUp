using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Repositories
{
    public interface ICrudRepository<TEntity>
    {
        void Create(TEntity entity);
        List<TEntity> Read(Dictionary<string, object> parameters);
        void Update(TEntity entity);
        void Delete(int id);      
       
    }
}

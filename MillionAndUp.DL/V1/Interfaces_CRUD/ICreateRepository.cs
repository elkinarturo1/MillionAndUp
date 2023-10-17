using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Interfaces_CRUD
{
    public interface ICreateRepository<TEntity>
    {
        void create(TEntity entity);
    }
}

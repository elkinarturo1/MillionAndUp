using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Interfaces_CRUD
{
    public interface IDeleteRepository<TEntity>
    {
        void DeleteRepository(int id);
    }
}

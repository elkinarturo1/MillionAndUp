using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1
{
    public interface IMapeoDataSet_to_Entity<TEntity>
    {
        List<TEntity> mapeo();
    }
}

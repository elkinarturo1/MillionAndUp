using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1
{
    public interface IStrategy<TEntity>
    {
        IEnumerable<TEntity> AccesData();

        void ModifyData();

    }
}

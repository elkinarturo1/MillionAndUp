using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.DAO
{
    public interface DAO_SQL <TEntity>
    {
        IEnumerable<TEntity> Consultar(string[] parametros);
        void Modificar(TEntity entity);
    }
}

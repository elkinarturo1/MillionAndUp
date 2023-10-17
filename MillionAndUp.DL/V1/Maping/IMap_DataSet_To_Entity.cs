using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Maping
{
    public interface IMap_DataSet_To_Entity<Tentity>
    {
        List<Tentity> Map();
    }
}

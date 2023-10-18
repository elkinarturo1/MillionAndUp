using MillionAndUp.DL.V1.Maping.Property;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Unit_Of_Work
{
    public interface IUnit_Of_Work<TEntity>
    {

        public List<TEntity> Read(string sp, Dictionary<string, object> parameters);
        void Modify(string sp, TEntity propertyEntity);
        public void Delete(string sp, int id);
        

    }
}

using MillionAndUp.DL.Properties;
using MillionAndUp.DL.V1.Repositories.Property;
using MillionAndUp.DL.V1.Unit_Of_Work.Property;
using MillionAndUp.DL.V1.Unit_Of_Work.PropertyTrace;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Repositories.PropertyTrace
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {

        private string strConexion;
        IUnit_Of_Work_PropertyTrace unit_of_work;

        public PropertyTraceRepository(IUnit_Of_Work_PropertyTrace p_unit_of_work)
        {
            strConexion = Resources.strConexion;
            unit_of_work = p_unit_of_work;
        }


        public void Create(PropertyTraceEntity entity)
        {
            unit_of_work.Modify("sp_PropertyTrace_Insert", entity);
        }


        public List<PropertyTraceEntity> Read(Dictionary<string, object> parameters)
        {
            List<PropertyTraceEntity> lstData = new List<PropertyTraceEntity>();
            lstData = unit_of_work.Read("sp_PropertyTrace_Select", parameters);
            return lstData;
        }


        public void Update(PropertyTraceEntity PropertyTraceEntity)
        {
            unit_of_work.Modify("sp_PropertyTrace_Update", PropertyTraceEntity);
        }


        public void Delete(int id)
        {
            unit_of_work.Delete("sp_PropertyTrace_Delete", id);
        }

    }
}

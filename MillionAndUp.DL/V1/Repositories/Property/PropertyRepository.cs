using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillionAndUp.DL.V1.Maping.Property;
using MillionAndUp.DL.Properties;
using MillionAndUp.DL.V1.Unit_Of_Work.Property;

namespace MillionAndUp.DL.V1.Repositories.Property
{
    public class PropertyRepository: IPropertyRepository
    {

        private string strConexion;
        IUnit_Of_Work_Property unit_of_work; 

        public PropertyRepository(IUnit_Of_Work_Property p_unit_of_work)
        {
            strConexion = Resources.strConexion;
            unit_of_work = p_unit_of_work;
        }


        public void Create(PropertyEntity entity)
        {
            unit_of_work.Modify("sp_Property_Insert", entity);
        }      


        public List<PropertyEntity> Read(Dictionary<string, object> parameters)
        {
            List<PropertyEntity> lstData = new List<PropertyEntity>();
            lstData = unit_of_work.Read("sp_Property_Select", parameters);
            return lstData;
        }        


        public void Update(PropertyEntity propertyEntity)
        {
            unit_of_work.Modify("sp_Property_Update", propertyEntity);
        }


        public void Delete(int id)
        {
            unit_of_work.Delete("sp_Property_Delete", id);
        }
      
    }
}

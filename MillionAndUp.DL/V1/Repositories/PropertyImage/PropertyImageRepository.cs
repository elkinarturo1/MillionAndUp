using MillionAndUp.DL.Properties;
using MillionAndUp.DL.V1.Repositories.Property;
using MillionAndUp.DL.V1.Unit_Of_Work.Property;
using MillionAndUp.DL.V1.Unit_Of_Work.PropertyImage;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Repositories.PropertyImage
{
    internal class PropertyImageRepository : IPropertyImageRepository
    {

        private string strConexion;
        IUnit_Of_Work_PropertyImage unit_of_work;

        public PropertyImageRepository(IUnit_Of_Work_PropertyImage p_unit_of_work)
        {
            strConexion = Resources.strConexion;
            unit_of_work = p_unit_of_work;
        }


        public void Create(PropertyImageEntity entity)
        {
            unit_of_work.Modify("sp_PropertyImage_Insert", entity);
        }


        public List<PropertyImageEntity> Read(Dictionary<string, object> parameters)
        {
            List<PropertyImageEntity> lstData = new List<PropertyImageEntity>();
            lstData = unit_of_work.Read("sp_PropertyImage_Select", parameters);
            return lstData;
        }


        public void Update(PropertyImageEntity PropertyImageEntity)
        {
            unit_of_work.Modify("sp_PropertyImage_Update", PropertyImageEntity);
        }


        public void Delete(int id)
        {
            unit_of_work.Delete("sp_PropertyImage_Delete", id);
        }

    }
}

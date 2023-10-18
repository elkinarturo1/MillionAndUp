using MillionAndUp.DL.V1.Maping.Owner;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Maping.PropertyImage
{
    public class Map_PropertyImage_DataSet_To_Entity : IMap_PropertyImage_DataSet_To_Entity
    {

        private DataSet ds;

        public Map_PropertyImage_DataSet_To_Entity(DataSet p_ds)
        {
            ds = p_ds;
        }

        public List<PropertyImageEntity> Map()
        {

            List<PropertyImageEntity> lstData = new List<PropertyImageEntity>();

            try
            {

                if (ds.Tables.Count > 0)
                {

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {

                        PropertyImageEntity PropertyImageEntity = new PropertyImageEntity();

                        PropertyImageEntity.IdPropertyImage = int.Parse(item["IdPropertyImage"].ToString());
                        PropertyImageEntity.IdProperty = int.Parse(item["IdProperty"].ToString());
                        PropertyImageEntity.File = item["File"].ToString();
                        PropertyImageEntity.Enabled = item["Enabled"].ToString();                       

                        lstData.Add(PropertyImageEntity);

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al mapear la property" + ex.Message);
            }

            return lstData;

        }

    }
}

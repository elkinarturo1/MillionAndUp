using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Maping.Property
{
    public class Map_Property_DataSet_To_Entity : IMap_Property_DataSet_To_Entity
    {

        private DataSet ds;

        public Map_Property_DataSet_To_Entity(DataSet p_ds)
        {
            ds = p_ds;
        }

        public List<PropertyEntity> Map()
        {

            List<PropertyEntity> lstData = new List<PropertyEntity>();

            try
            {

                if(ds.Tables.Count > 0)
                {

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {

                        PropertyEntity propertyEntity = new PropertyEntity();

                        propertyEntity.IdProperty = int.Parse(item["IdProperty"].ToString());
                        propertyEntity.Name = item["Name"].ToString();
                        propertyEntity.Address = item["Address"].ToString();
                        propertyEntity.Price = item["Price"].ToString();
                        propertyEntity.CodeInternal = item["CodeInternal"].ToString();
                        propertyEntity.Year = item["Year"].ToString();
                        propertyEntity.IdOwner = int.Parse(item["IdOwner"].ToString());

                        lstData.Add(propertyEntity);

                    }

                }              

            }
            catch (Exception ex)
            {
                throw new Exception ("Ha ocurrido un error al mapear la property" + ex.Message);
            }

            return lstData;

        }
    }
}

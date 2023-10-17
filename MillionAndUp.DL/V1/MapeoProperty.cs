using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1
{
    public class MapeoProperty : IMapeoProperty
    {
        private DataSet ds;

        public MapeoProperty(DataSet newDS)
        {
            ds = newDS;
        }

        public List<PropertyEntity> mapeo()
        {
            List<PropertyEntity> dataMap = new List<PropertyEntity>();

            try
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        PropertyEntity propertyEntity = new PropertyEntity();

                        propertyEntity.Address = row["Address"].ToString();
                        propertyEntity.CodeInternal = row["CodeInternal"].ToString();
                        propertyEntity.Year = row["Year"].ToString();
                        propertyEntity.Price = row["Price"].ToString();

                        dataMap.Add(propertyEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al mapera los datos", ex);
            }

            return dataMap;
        }
    }
}

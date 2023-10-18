using MillionAndUp.DL.V1.Maping.PropertyImage;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Maping.PropertyTrace
{
    public class Map_PropertyTrace_DataSet_To_Entity : IMap_PropertyTrace_DataSet_To_Entity
    {

        private DataSet ds;

        public Map_PropertyTrace_DataSet_To_Entity(DataSet p_ds)
        {
            ds = p_ds;
        }

        public List<PropertyTraceEntity> Map()
        {

            List<PropertyTraceEntity> lstData = new List<PropertyTraceEntity>();

            try
            {

                if (ds.Tables.Count > 0)
                {

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {

                        PropertyTraceEntity PropertyTraceEntity = new PropertyTraceEntity();

                        PropertyTraceEntity.IdPropertyTrace = int.Parse(item["IdPropertyTrace"].ToString());
                        PropertyTraceEntity.DateSale = item["DateSale"].ToString();
                        PropertyTraceEntity.Name = item["Name"].ToString();
                        PropertyTraceEntity.Value = item["Value"].ToString();
                        PropertyTraceEntity.Tax = item["Tax"].ToString();
                        PropertyTraceEntity.IdProperty = int.Parse(item["IdProperty"].ToString());


                        lstData.Add(PropertyTraceEntity);

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

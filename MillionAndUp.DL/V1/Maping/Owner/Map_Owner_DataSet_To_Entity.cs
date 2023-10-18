using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Maping.Owner
{
    public class Map_Owner_DataSet_To_Entity : IMap_Owner_DataSet_To_Entity
    {

        private DataSet ds;

        public Map_Owner_DataSet_To_Entity(DataSet p_ds)
        {
            ds = p_ds;
        }

        public List<OwnerEntity> Map()
        {

            List<OwnerEntity> lstData = new List<OwnerEntity>();

            try
            {

                if (ds.Tables.Count > 0)
                {

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {

                        OwnerEntity OwnerEntity = new OwnerEntity();

                        OwnerEntity.IdOwner = int.Parse(item["IdOwner"].ToString());
                        OwnerEntity.Name = item["Name"].ToString();
                        OwnerEntity.Address = item["Address"].ToString();
                        OwnerEntity.Photo = item["Photo"].ToString();
                        OwnerEntity.Birthday = item["Birthday"].ToString();
                    
                        lstData.Add(OwnerEntity);

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

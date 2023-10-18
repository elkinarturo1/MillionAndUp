using MillionAndUp.DL.Properties;
using MillionAndUp.DL.V1.Repositories.Property;
using MillionAndUp.DL.V1.Unit_Of_Work.Owner;
using MillionAndUp.DL.V1.Unit_Of_Work.Property;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Repositories.Owner
{
    internal class OwnerRepository : IOwnerRepository
    {

        private string strConexion;
        IUnit_Of_Work_Owner unit_of_work;

        public OwnerRepository(IUnit_Of_Work_Owner p_unit_of_work)
        {
            strConexion = Resources.strConexion;
            unit_of_work = p_unit_of_work;
        }


        public void Create(OwnerEntity entity)
        {
            unit_of_work.Modify("sp_Owner_Insert", entity);
        }


        public List<OwnerEntity> Read(Dictionary<string, object> parameters)
        {
            List<OwnerEntity> lstData = new List<OwnerEntity>();
            lstData = unit_of_work.Read("sp_Owner_Select", parameters);
            return lstData;
        }


        public void Update(OwnerEntity OwnerEntity)
        {
            unit_of_work.Modify("sp_Owner_Update", OwnerEntity);
        }


        public void Delete(int id)
        {
            unit_of_work.Delete("sp_Owner_Delete", id);
        }

    }
}

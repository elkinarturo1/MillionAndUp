using MillionAndUp.DL.V1.Strategies.Property;
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

namespace MillionAndUp.DL.V1.Repositories.Property
{
    public class PropertyRepository
    {       

        public List<PropertyEntity> AccesData(Dictionary<string, object> parameters)
        {             

            List<PropertyEntity> lstData = new List<PropertyEntity>();
            SqlConnection sqlConnection = new SqlConnection(Resources.strConexion);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_Property_Select";

                if (parameters != null )
                {
                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        string key = parameter.Key;
                        object value = parameter.Value;

                        sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }                

                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);

                IMap_Property_DataSet_To_Entity objMap = new Map_Property_DataSet_To_Entity(ds);
                lstData = objMap.Map();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al acceder a los datos en SQL " + ex.Message);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Connection.Close();
            }

            return lstData;

        }

        public void ModifyData(ParametersEntitiy p_parametersEntity)
        {
            SqlConnection sqlConnection = new SqlConnection("stringconexion");
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp";

                foreach (KeyValuePair<string, object> parameter in p_parametersEntity.parameters)
                {
                    string key = parameter.Key;
                    object value = parameter.Value;

                    sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al ejecutar el comando en SQL", ex);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Connection.Close();
            }

        }

    }
}

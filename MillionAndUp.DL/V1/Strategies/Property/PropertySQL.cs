using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Strategies.Property
{
    public class PropertySQL
    {

        IDictionary<string, object> parameters;
        //private IMapeoDatos<PropertyEntity> mapeoDatos;

        public List<PropertyEntity> AccesData()
        {

            List<PropertyEntity> data = new List<PropertyEntity>();
            SqlConnection sqlConnection = new SqlConnection("stringconexion");
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp";

                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    string key = parameter.Key;
                    object value = parameter.Value;

                    sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);
                 
                //data = mapeoDatos.mapeo(ds);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al acceder a los datos en SQL", ex);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Connection.Close();
            }

            return data;

        }

        public void ModifyData()
        {
            SqlConnection sqlConnection = new SqlConnection("stringconexion");
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp";

                foreach (KeyValuePair<string, object> parameter in parameters)
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

using MillionAndUp.DL.Properties;
using MillionAndUp.DL.V1.Maping.Property;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillionAndUp.DL.V1.Unit_Of_Work.PropertyImage;
using MillionAndUp.DL.V1.Maping.PropertyTrace;

namespace MillionAndUp.DL.V1.Unit_Of_Work.PropertyTrace
{
    public class Unit_Of_Work_PropertyTrace : IUnit_Of_Work_PropertyTrace
    {

        private string strConexion;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public Unit_Of_Work_PropertyTrace()
        {
            strConexion = Resources.strConexion;
            sqlConnection = new SqlConnection(strConexion);
        }


        public void Modify(string sp, PropertyTraceEntity PropertyTraceEntity)
        {

            sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = sp;

                sqlCommand.Parameters.AddWithValue("@IdPropertyTrace", PropertyTraceEntity.IdPropertyTrace);
                sqlCommand.Parameters.AddWithValue("@DateSale", PropertyTraceEntity.DateSale);
                sqlCommand.Parameters.AddWithValue("@Name", PropertyTraceEntity.Name);
                sqlCommand.Parameters.AddWithValue("@Value", PropertyTraceEntity.Value);
                sqlCommand.Parameters.AddWithValue("@Tax", PropertyTraceEntity.Tax);
                sqlCommand.Parameters.AddWithValue("@IdProperty", PropertyTraceEntity.IdProperty);    

                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el comando en SQL " + ex);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Connection.Close();
            }

        }

        public List<PropertyTraceEntity> Read(string sp, Dictionary<string, object> parameters)
        {

            List<PropertyTraceEntity> lstData = new List<PropertyTraceEntity>();
            sqlCommand = new SqlCommand();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = sp;

                if (parameters != null)
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

                IMap_PropertyTrace_DataSet_To_Entity objMap = new Map_PropertyTrace_DataSet_To_Entity(ds);
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



        public void Delete(string sp, int id)
        {

            sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = sp;

                sqlCommand.Parameters.AddWithValue("@IdProperty", id);

                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al eliminar los datos en SQL " + ex.Message);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Connection.Close();
            }

        }


    }
}

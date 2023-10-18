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
using MillionAndUp.DL.V1.Unit_Of_Work.Property;
using MillionAndUp.DL.V1.Maping.PropertyImage;

namespace MillionAndUp.DL.V1.Unit_Of_Work.PropertyImage
{
    public class Unit_Of_Work_PropertyImage : IUnit_Of_Work_PropertyImage
    {

        private string strConexion;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public Unit_Of_Work_PropertyImage()
        {
            strConexion = Resources.strConexion;
            sqlConnection = new SqlConnection(strConexion);
        }


        public void Modify(string sp, PropertyImageEntity PropertyImageEntity)
        {

            sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = sp;

                sqlCommand.Parameters.AddWithValue("@IdPropertyImage", PropertyImageEntity.IdPropertyImage);
                sqlCommand.Parameters.AddWithValue("@IdProperty", PropertyImageEntity.IdProperty);
                sqlCommand.Parameters.AddWithValue("@File", PropertyImageEntity.File);
                sqlCommand.Parameters.AddWithValue("@Enabled", PropertyImageEntity.Enabled);               

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

        public List<PropertyImageEntity> Read(string sp, Dictionary<string, object> parameters)
        {

            List<PropertyImageEntity> lstData = new List<PropertyImageEntity>();
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

                IMap_PropertyImage_DataSet_To_Entity objMap = new Map_PropertyImage_DataSet_To_Entity(ds);
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

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

namespace MillionAndUp.DL.V1.Unit_Of_Work.Property
{
    public class Unit_Of_Work_Property : IUnit_Of_Work_Property
    {
        private string strConexion;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public Unit_Of_Work_Property()
        {
            strConexion = Resources.strConexion;
            sqlConnection = new SqlConnection(strConexion);
        }


        public void Modify(string sp, PropertyEntity propertyEntity)
        {

            sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = sp;

                sqlCommand.Parameters.AddWithValue("@IdProperty", propertyEntity.IdProperty);
                sqlCommand.Parameters.AddWithValue("@Name", propertyEntity.Name);
                sqlCommand.Parameters.AddWithValue("@Address", propertyEntity.Address);
                sqlCommand.Parameters.AddWithValue("@Price", propertyEntity.Price);
                sqlCommand.Parameters.AddWithValue("@CodeInternal", propertyEntity.CodeInternal);
                sqlCommand.Parameters.AddWithValue("@Year", propertyEntity.Year);
                sqlCommand.Parameters.AddWithValue("@IdOwner", propertyEntity.IdOwner);

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

        public List<PropertyEntity> Read(string sp, Dictionary<string, object> parameters)
        {

            List<PropertyEntity> lstData = new List<PropertyEntity>();
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

using MillionAndUp.DL.V1.Interfaces_CRUD;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Repositories.Property
{
    public class PropertyRepositorySQL : IPropertyRepository
    {


        private string connectionString;

        public PropertyRepositorySQL(string connectionStr)
        {
            connectionString = connectionStr;
        }

        public DataSet FindAll()
        {
            DataSet ds = new DataSet();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_Property_Select";

                sqlCommand.Parameters.AddWithValue("@IdProperty", -1);
                sqlCommand.Parameters.AddWithValue("@Name", "-1");

                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);
            }
            return ds;
        }

        public DataSet FindById(int id)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand();
            DataSet ds = new DataSet();

            try
            {
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_Property_Insert";

                sqlCommand.Parameters.AddWithValue("@IdProperty", id);
                sqlCommand.Parameters.AddWithValue("@Name", "-1");

                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la propiedad en la base de datos", ex);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Connection.Close();
            }

            return ds;
          
        }


        public void create(PropertyEntity entity)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_Property_Insert";

                sqlCommand.Parameters.AddWithValue("@IdProperty", entity.IdProperty);
                sqlCommand.Parameters.AddWithValue("@Name", entity.Name);
                sqlCommand.Parameters.AddWithValue("@Address", entity.Address);
                sqlCommand.Parameters.AddWithValue("@Price", entity.Price);
                sqlCommand.Parameters.AddWithValue("@CodeInternal", entity.CodeInternal);
                sqlCommand.Parameters.AddWithValue("@Year", entity.Year);
                sqlCommand.Parameters.AddWithValue("@IdOwner", entity.IdOwner);

                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception ("Error al insertar la propiedad en la base de datos",ex);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Connection.Close();
            }           

        }


        public void Update(PropertyEntity entity)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_Property_Updatet";

                sqlCommand.Parameters.AddWithValue("@IdProperty", entity.IdProperty);
                sqlCommand.Parameters.AddWithValue("@Name", entity.Name);
                sqlCommand.Parameters.AddWithValue("@Address", entity.Address);
                sqlCommand.Parameters.AddWithValue("@Price", entity.Price);
                sqlCommand.Parameters.AddWithValue("@CodeInternal", entity.CodeInternal);
                sqlCommand.Parameters.AddWithValue("@Year", entity.Year);
                sqlCommand.Parameters.AddWithValue("@IdOwner", entity.IdOwner);

                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la propiedad en la base de datos", ex);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Connection.Close();
            }
        }
    }
}

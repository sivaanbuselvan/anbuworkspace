using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CrudOperations.Models;

namespace CrudOperations.Data_Access_layer
{
    public class LoginRepository
    {
        private SqlConnection connection;
        
        // AddUser --> enter a data to the table
        public bool AddUser(Model userobject)
        {
            int entry = 0;
            string connectionstring = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("insert_into", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@loginid", userobject.login_id);
                command.Parameters.AddWithValue("@username", userobject.user_name);
                command.Parameters.AddWithValue("@password", userobject.password);
                connection.Open();
                entry = command.ExecuteNonQuery();
                connection.Close();
            }
            if (entry > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // it is used to get all the user from table
        public List<Model> GetUsers()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ToString();
            List<Model> users = new List<Model>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("select_all", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();
                connection.Open();
                adapter.Fill(datatable);
                connection.Close();

                foreach (DataRow row in datatable.Rows)
                    users.Add(
                        new Model
                        {
                            login_id = Convert.ToInt32(row["login_id"]),
                            user_name = Convert.ToString(row["user_name"]),
                            password = Convert.ToString(row["password"])
                        }
                    );
                return users;
            }
        }
        // used to update the data wirh respect to id
        public bool EditUser(Model modelobject)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("Update_login", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login_Id", modelobject.login_id);
                command.Parameters.AddWithValue("@user_name", modelobject.user_name);
                command.Parameters.AddWithValue("@password", modelobject.password);
                connection.Open();
                int entry = command.ExecuteNonQuery();
                connection.Close();
                if (entry > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }
        // this method is used to delete a record from the table
        public bool DeleteUser(int id)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            { 
                SqlCommand command = new SqlCommand("insert_into", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@loginId", id);

                
              connection.Open();
               int entry = command.ExecuteNonQuery();
                if (entry > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                } 
            }
        }
        // it is used to select a particular data from the database using the id
        public List<Model> SelectUser(int login_id)
        {
            List<Model> list = new List<Model>();
            string connectionstring = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("select_particular", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login_id",login_id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();
                connection.Open();
                adapter.Fill(datatable);
                connection.Close();

                foreach (DataRow row in datatable.Rows)
                    list.Add(
                        new Model
                        {
                            login_id = Convert.ToInt32(row["login_id"]),
                            user_name = Convert.ToString(row["user_name"]),
                            password = Convert.ToString(row["password"])
                        }
                    );
                return list;
            }
        }
    }
}





   
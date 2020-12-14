using Activity1_3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Activity1_3.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool FindByUser(UserModel user)
        {
            bool success = false;

            string queryString = "select * from dbo.Users where username = @USERNAME and password = @PASSWORD";

            using(SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connect);
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 20).Value = user.Username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 20).Value = user.Password;

                try
                {
                    connect.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        success = true;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }
    }
}

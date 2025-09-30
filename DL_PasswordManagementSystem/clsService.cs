using System;
using System.Data;
using System.Data.SqlClient;

namespace DL_PasswordManagementSystem
{
    static public class clsService
    {
        static public bool GetServiceInfoByID(
                int ServiceID,
                ref string ServiceName,
                ref string Url,
                SqlConnection Connection = null,
                SqlTransaction Transaction = null)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Services WHERE ServiceID = @ServiceID";

            bool localConnection = false;
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;
                }

                using (SqlCommand command = new SqlCommand(query, Connection, Transaction))
                {
                    command.Parameters.AddWithValue("@ServiceID", ServiceID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ServiceName = (string)reader["ServiceName"];
                            Url = reader["Url"] == DBNull.Value ? null : (string)reader["Url"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }

            return isFound;
        }


        static public bool GetServiceInfoByServiceName(
            ref int ServiceID,
            string ServiceName,
            ref string Url,
            SqlConnection Connection = null,
            SqlTransaction Transaction = null)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Services WHERE ServiceName = @ServiceName";

            bool localConnection = false;
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;
                }

                using (SqlCommand command = new SqlCommand(query, Connection, Transaction))
                {
                    command.Parameters.AddWithValue("@ServiceName", ServiceName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ServiceID = (int)reader["ServiceID"];
                            Url = reader["Url"] == DBNull.Value ? null : (string)reader["Url"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }

            return isFound;
        }

        public static DataTable GetServiceByType(string ServiceType)
        {
            DataTable dataTable = new DataTable();

            string query = @"
                           SELECT Accounts.Username, Accounts.Password, Services.ServiceName,Services.Url, Accounts.Email, Accounts.CreationDate, Accounts.EditDate, Accounts.Notes
                            FROM   Services INNER JOIN
                                         AccountsServices ON Services.ServiceID = AccountsServices.ServiceID INNER JOIN
                                         Accounts ON AccountsServices.AccountID = Accounts.AccountID
                            WHERE (Services.ServiceName = @ServiceType);";
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceType", ServiceType);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string decryptedPassword = clsAesHelper.Decrypt(row["Password"].ToString());

                                row["Password"] = decryptedPassword;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }
            return dataTable;
        }
        static public int CreateService(int ServiceID, string ServiceName, string Url, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {

            string query = @"
                INSERT INTO Services (ServiceName, Url) 
                VALUES (@ServiceName,@Url);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            bool localConnection = false;
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;
                }
                    using (SqlCommand command = new SqlCommand(query, Connection,Transaction))
                    {
                        command.Parameters.AddWithValue("@ServiceName", ServiceName);
                        command.Parameters.AddWithValue("@Url", string.IsNullOrEmpty(Url) ? (object)DBNull.Value : Url);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ServiceID = insertedID;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }

            return ServiceID;
        }

        static public bool UpdateService(int ServiceID, string ServiceName, string Url, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            int rowsAffected = 0;
            string query = @"
                            UPDATE Services 
                            SET ServiceName = @ServiceName, Url = @Url WHERE ServiceID = @ServiceID;";

            bool localConnection = false;
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;
                }
                    using (SqlCommand command = new SqlCommand(query, Connection,Transaction))
                    {
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);
                        command.Parameters.AddWithValue("@ServiceName", ServiceName);
                        command.Parameters.AddWithValue("@Url", Url);

                        rowsAffected = command.ExecuteNonQuery();     
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }
            return rowsAffected > 0;
        }

        static public bool DeleteService(int ServiceID)
        {
            int rowsAffected = 0;
            string query = @" DELETE FROM Services WHERE ServiceID=@ServiceID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);
                       
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rowsAffected > 0;
        }

        static public bool IsExist(int ServiceID, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            bool isFound = false;
            string query = @"SELECT Found=1 FROM Services WHERE ServiceID=@ServiceID;";

            bool localConnection = false;
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;
                }
                using (SqlCommand command = new SqlCommand(query, Connection, Transaction))
                    {
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }        
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }
            return isFound;
        }

        static public bool IsExist(string ServiceName, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            bool isFound = false;
            string query = @" SELECT Found=1 FROM Services WHERE ServiceName=@ServiceName;";
            bool localConnection = false;
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;
                }

                    using (SqlCommand command = new SqlCommand(query, Connection, Transaction))
                    {
                        command.Parameters.AddWithValue("@ServiceName", ServiceName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }
            return isFound;
        }

        static public DataTable GetListServices()
        {
            DataTable ServicesTable = new DataTable();
            string query = @" SELECT * FROM Services;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                ServicesTable.Load(reader);
                            else
                                ServicesTable = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ServicesTable;
        }
    }
}

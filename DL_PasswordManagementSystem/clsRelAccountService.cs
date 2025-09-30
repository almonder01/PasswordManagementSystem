using System;
using System.Data;
using System.Data.SqlClient;

namespace DL_PasswordManagementSystem
{
    static public class clsRelAccountService
    {

        static public int GetAccountIDByUserName(string Username, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            string query = @"SELECT AccountID FROM   Accounts	WHERE Username = @Username;";
            bool localConnection = false;
            int AccountID = -1;
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;

                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        if (Transaction != null)
                            command.Transaction = Transaction;

                        command.Parameters.AddWithValue("@Username", Username);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int accountID))
                        {
                            AccountID = accountID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAccountIDByUserName: " + ex.Message);
                return -1;
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }

            return AccountID;
        }
        static public int GetServiceIDByServiceName(string ServiceName, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            string query = @"SELECT ServiceID FROM Services WHERE ServiceName = @ServiceName;";
            bool localConnection = false;
            int CategoryID = -1;
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;

                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        if (Transaction != null)
                            command.Transaction = Transaction;

                        command.Parameters.AddWithValue("@ServiceName", ServiceName);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int categoryID))
                        {
                            CategoryID = categoryID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAccountIDByUserName: " + ex.Message);
                return -1;
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }

            return CategoryID;
        }

        public static DataTable GetServicesByAccountID(int accountID)
        {
            DataTable RelationshipTable = new DataTable();

            string query = @"
                        SELECT Services.ServiceID, Services.ServiceName, Services.Url
                        FROM   Services INNER JOIN
                               AccountsServices ON Services.ServiceID = AccountsServices.ServiceID
	                  	WHERE AccountsServices.AccountID = @accountID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@accountID", accountID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                RelationshipTable.Load(reader);
                            else
                                RelationshipTable = null;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }
            return RelationshipTable;
        }



        static public bool AddRelationship(int AccountID, int ServiceID, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            string query = @"INSERT INTO AccountsServices (AccountID, ServiceID) VALUES (@AccountID, @ServiceID);";
            int rowAffected = 0;
            bool localConnection = false;

            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;
                }

                // تأكد أن الحساب والخدمة موجودين
                if (clsAccount.IsExist(AccountID, Connection, Transaction) && clsService.IsExist(ServiceID, Connection, Transaction))
                {
                    using (SqlCommand command = new SqlCommand(query, Connection, Transaction))
                    {
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);

                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }

            return rowAffected > 0;
        }

        static public bool GetRelationshipInfoByAccountID(int AccountID, ref string UserName, ref int ServiceID,
            ref string ServiceName,ref string Url, ref string Password, ref string Email,
            ref string Notes, ref DateTime CreationDate, ref DateTime EditDate)
        {
            bool isFound = false;
            string quey = @"SELECT Accounts.AccountID, Accounts.Username, Services.ServiceID, Services.ServiceName, Services.Url,
                            Accounts.Password, Accounts.Email, Accounts.CreationDate, Accounts.EditDate, Accounts.Notes
                            FROM   AccountsServices INNER JOIN
                                         Accounts ON AccountsServices.AccountID = Accounts.AccountID INNER JOIN
                                         Services ON AccountsServices.ServiceID = Services.ServiceID
                            WHERE (Accounts.AccountID = @AccountID);";
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(quey, connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserName = (string)reader["Username"];
                                ServiceID = reader["ServiceID"] == DBNull.Value ? -1 : (int)reader["ServiceID"];
                                ServiceName = reader["ServiceName"] == DBNull.Value ? null : (string)reader["ServiceName"];
                                Url = reader["Url"] == DBNull.Value ? null : (string)reader["Url"];
                                Password = (string)reader["Password"];
                                Email = (string)reader["Email"];
                                Notes = reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"];
                                CreationDate = (DateTime)reader["CreationDate"];
                                EditDate = (DateTime)reader["EditDate"];
                            }
                        }
                    }
                }

            }catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }
            return isFound;
        }

        static public bool GetRelationshipInfoByAccountUserName(ref int AccountID, string UserName, ref int ServiceID,
         ref string ServiceName, ref string Url, ref string Password, ref string Email,
         ref string Notes, ref DateTime CreationDate, ref DateTime EditDate)
        {
            bool isFound = false;
            string quey = @"SELECT Accounts.AccountID, Accounts.Username, Services.ServiceID, Services.ServiceName, Services.Url,
                            Accounts.Password, Accounts.Email, Accounts.CreationDate, Accounts.EditDate, Accounts.Notes
                            FROM   AccountsServices INNER JOIN
                                         Accounts ON AccountsServices.AccountID = Accounts.AccountID INNER JOIN
                                         Services ON AccountsServices.ServiceID = Services.ServiceID
                            WHERE (Accounts.UserName = @UserName);";
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(quey, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                AccountID = (int)reader["AccountID"];
                                ServiceID = reader["ServiceID"] == DBNull.Value ? -1 : (int)reader["ServiceID"];
                                ServiceName = reader["ServiceName"] == DBNull.Value ? null : (string)reader["ServiceName"];
                                Url = reader["Url"] == DBNull.Value ? null : (string)reader["Url"];
                                Password = (string)reader["Password"];
                                Email = (string)reader["Email"];
                                Notes = reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"];
                                CreationDate = (DateTime)reader["CreationDate"];
                                EditDate = (DateTime)reader["EditDate"];
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }
            return isFound;
        }

        static public bool GetRelationshipInfoByServiceID(ref int AccountID, ref string UserName, int ServiceID,
         ref string ServiceName, ref string Url, ref string Password, ref string Email,
         ref string Notes, ref DateTime CreationDate, ref DateTime EditDate)
        {
            bool isFound = false;
            string quey = @"SELECT Accounts.AccountID, Accounts.Username, Services.ServiceID, Services.ServiceName, Services.Url,
                            Accounts.Password, Accounts.Email, Accounts.CreationDate, Accounts.EditDate, Accounts.Notes
                            FROM   AccountsServices INNER JOIN
                                         Accounts ON AccountsServices.AccountID = Accounts.AccountID INNER JOIN
                                         Services ON AccountsServices.ServiceID = Services.ServiceID
                            WHERE (Services.ServiceID = @ServiceID);";
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(quey, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserName = (string)reader["Username"];
                                AccountID = (int)reader["AccountID"];
                                ServiceName = reader["ServiceName"] == DBNull.Value ? null : (string)reader["ServiceName"];
                                Url = reader["Url"] == DBNull.Value ? null : (string)reader["Url"];
                                Password = (string)reader["Password"];
                                Email = (string)reader["Email"];
                                Notes = reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"];
                                CreationDate = (DateTime)reader["CreationDate"];
                                EditDate = (DateTime)reader["EditDate"];
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
                isFound = false;
            }
            return isFound;
        }

        static public bool GetRelationshipInfoByServiceName(ref int AccountID,ref string UserName, ref int ServiceID,
         string ServiceName, ref string Url, ref string Password, ref string Email,
         ref string Notes, ref DateTime CreationDate, ref DateTime EditDate)
        {
            bool isFound = false;
            string quey = @"SELECT Accounts.AccountID, Accounts.Username, Services.ServiceID, Services.ServiceName, Service.Url,
                            Accounts.Password, Accounts.Email, Accounts.CreationDate, Accounts.EditDate, Accounts.Notes
                            FROM   AccountsServices INNER JOIN
                                         Accounts ON AccountsServices.AccountID = Accounts.AccountID INNER JOIN
                                         Services ON AccountsServices.ServiceID = Services.ServiceID
                            WHERE (Services.ServiceName = @ServiceName);";
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(quey, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceName", ServiceName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                AccountID = (int)reader["AccountID"];
                                UserName = reader["UserName"] == DBNull.Value ? null : (string)reader["UserName"];
                                ServiceID = reader["ServiceID"] == DBNull.Value ? -1 : (int)reader["ServiceID"];
                                Url = reader["Url"] == DBNull.Value ? null : (string)reader["Url"];
                                Password = (string)reader["Password"];
                                Email = (string)reader["Email"];
                                Notes = reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"];
                                CreationDate = (DateTime)reader["CreationDate"];
                                EditDate = (DateTime)reader["EditDate"];
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
                isFound = false;
            }
            return isFound;
        }

        static public bool UpdateRelationshipByAccountID(int AccountID,int SetServiceID, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            int rowsAffected = 0;
            string query = @"
                            UPDATE AccountsServices 
                            SET ServiceID = @SetServiceID WHERE AccountID = @AccountID;";

            bool localConnection = false;
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;
                }
                if (!clsAccount.IsExist(AccountID, Connection, Transaction) && !clsService.IsExist(SetServiceID, Connection, Transaction))
                    return false;

                    using (SqlCommand command = new SqlCommand(query, Connection, Transaction))
                    {
                        command.Parameters.AddWithValue("@SetServiceID", SetServiceID);
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        
                        rowsAffected = command.ExecuteNonQuery();     
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }
            return rowsAffected > 0;
        }

        static public bool DeleteRelationshipByAccountID(int AccountID)
        {
            int rowsAffected = 0;
            string query = @"DELETE FROM AccountsServices WHERE AccountID=@AccountID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                       
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message.ToString());
            }
            return rowsAffected > 0;
        }
        static public bool DeleteRelationship(int AccountID, int ServiceID)
        {
            int rowsAffected = 0;
            string query = @"DELETE FROM AccountsServices WHERE AccountID=@AccountID and ServiceID = @ServiceID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", AccountID);

                        command.Parameters.AddWithValue("@ServiceID", ServiceID);

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }
            return rowsAffected > 0;
        }
        static public DataTable GetListRelationship()
        {
            DataTable RelationshipTable = new DataTable();
            string query = @"
                            SELECT Accounts.AccountID, Accounts.Username, Services.ServiceID, Services.ServiceName, Services.Url
                            FROM   AccountsServices INNER JOIN
                                         Accounts ON AccountsServices.AccountID = Accounts.AccountID INNER JOIN
                                         Services ON AccountsServices.ServiceID = Services.ServiceID";

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
                                RelationshipTable.Load(reader);
                            else
                                RelationshipTable = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }
            return RelationshipTable;
        }
   
        static public bool IsExist(int AccountID, int ServiceID, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            bool isFound = false;
            string quey = @"SELECT Found=1 FROM AccountsServices WHERE AccountID = @AccountID and ServiceID = @ServiceID";
            bool localConnection = false;
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;
                }

                    using(SqlCommand command = new SqlCommand(quey, Connection, Transaction))
                    {
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }

                    }
            }catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());

                isFound = false;
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }
            return isFound;
        }

        static public bool IsExist(int ServiceID)
        {
            bool isFound = false;

            string query = @"SELECT Found = 1 
                     FROM AccountsServices
                     WHERE ServiceID = @ServiceID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in IsExistByServiceID: " + ex.Message);
            }

            return isFound;
        }

    }
}

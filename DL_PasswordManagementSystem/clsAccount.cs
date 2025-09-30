using System;
using System.Data;
using System.Data.SqlClient;

namespace DL_PasswordManagementSystem
{
    static public class clsAccount
    {
        static public bool GetAccountInfoByID(int AccountID, ref string UserName, ref string Password, ref string Email,
            ref string Notes, ref DateTime CreationDate, ref DateTime EditDate)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Accounts WHERE AccountID = @AccountID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                AccountID = (int)reader["AccountID"];
                                UserName = (string)reader["Username"];
                                Password = clsAesHelper.Decrypt((string)reader["Password"]);
                                Email = (string)reader["Email"];
                                Notes = reader["Notes"] == DBNull.Value ? "" : (string)reader["Notes"];
                                CreationDate = (DateTime)reader["CreationDate"];
                                EditDate = (DateTime)reader["EditDate"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }

            return isFound;
        }

        static public bool GetAccountInfoByUserName(ref int AccountID, string UserName, ref string Password, ref string Email,
            ref string Notes, ref DateTime CreationDate, ref DateTime EditDate)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Accounts WHERE Username = @UserName";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                AccountID = (int)reader["AccountID"];
                                UserName = (string)reader["Username"];
                                Password = clsAesHelper.Decrypt((string)reader["Password"]);
                                Email = (string)reader["Email"];
                                Notes = reader["Notes"] == DBNull.Value ? "" : (string)reader["Notes"];
                                CreationDate = (DateTime)reader["CreationDate"];
                                EditDate = (DateTime)reader["EditDate"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }

            return isFound;
        }

        static public int CreateAccount(int AccountID, string UserName, string Password, string Email,
            string Notes, DateTime CreationDate, DateTime EditDate, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            string query = @"
                INSERT INTO Accounts (UserName, Password, Email, Notes, CreationDate, EditDate) 
                VALUES (@UserName, @Password, @Email, @Notes, @CreationDate, @EditDate);
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
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", clsAesHelper.Encrypt(Password));
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@CreationDate", CreationDate);
                        command.Parameters.AddWithValue("@EditDate", EditDate);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            AccountID = insertedID;
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

            return AccountID;
        }

        static public bool UpdateAccount(int AccountID, string UserName, string Password, string Email,
            string Notes, DateTime CreationDate, DateTime EditDate, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            int rowsAffected = 0;
            string query = @"
                            UPDATE Accounts 
                            SET UserName = @UserName, Password = @Password, Email = @Email, Notes = @Notes, CreationDate = @CreationDate, EditDate = @EditDate
                            WHERE AccountID = @AccountID;";
          
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
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", clsAesHelper.Encrypt(Password));
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@CreationDate", CreationDate);
                        command.Parameters.AddWithValue("@EditDate", EditDate);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);

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

        static public bool DeleteAccount(int AccountID)
        {
            int rowsAffected = 0;
            string query = @" DELETE FROM Accounts WHERE AccountID=@AccountID;";

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
                Console.WriteLine(ex.Message);
            }
            return rowsAffected > 0;
        }

        static public bool IsExist(int AccountID, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            bool isFound = false;
            string query = @" SELECT Found=1 FROM Accounts WHERE AccountID=@AccountID;";
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
                        command.Parameters.AddWithValue("@AccountID", AccountID);

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
        static public bool IsExist(string UserName, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            bool isFound = false;
            string query = @" SELECT Found=1 FROM Accounts WHERE UserName=@UserName;";
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
                        command.Parameters.AddWithValue("@UserName", UserName);

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

        static public DataTable GetListAccounts()
        {
            DataTable AccountsTable = new DataTable();
            string query = @" SELECT * FROM Accounts;";

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
                            {
                                AccountsTable.Load(reader);

                                foreach (DataRow row in AccountsTable.Rows)
                                {
                                    string decryptedPassword = clsAesHelper.Decrypt(row["Password"].ToString());

                                    row["Password"] = decryptedPassword;
                                }
                            }
                            else
                                AccountsTable = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return AccountsTable;
        }
    }
}

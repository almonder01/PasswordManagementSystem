using System;
using System.Data;
using System.Data.SqlClient;

namespace DL_PasswordManagementSystem
{
    static public class clsRelAccountCategory
    {

        static public int GetAccountIDByUserName(string Username, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            string query = @"SELECT AccountID FROM   Accounts	WHERE Username = @Username;";
            bool localConnection = false;
            int AccountID = -1;
            try
            {
                if(Connection == null)
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
                        if(result != null && int.TryParse(result.ToString(),out int accountID))
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
        static public int GetCategoryIDByCategoryName(string CategoryName, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            string query = @"SELECT CategoryID FROM Categories WHERE CategoryName = @CategoryName;";
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

                        command.Parameters.AddWithValue("@CategoryName", CategoryName);

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
        static public bool AddRelationship(int AccountID, int CategoryID, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {

            string query = @"INSERT INTO AccountsCategories (AccountID, CategoryID) VALUES (@AccountID, @CategoryID);";
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

                if (clsAccount.IsExist(AccountID,Connection,Transaction) && clsCategory.IsExist(CategoryID,Connection,Transaction))
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        if (Transaction != null)
                            command.Transaction = Transaction;

                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddRelationship: " + ex.Message);
                return false;
            }
            finally
            {
                if (localConnection)
                    Connection.Close();
            }

            return rowAffected > 0;
        }


        static public bool GetRelationshipInfoByAccountID(int AccountID, ref string UserName, ref int CategoryID,
            ref string CategoryName, ref string Password, ref string Email,
            ref string Notes, ref DateTime CreationDate, ref DateTime EditDate)
        {
            bool isFound = false;
            string quey = @"SELECT Accounts.AccountID, Accounts.Username, Categories.CategoryID, Categories.CategoryName,
                            Accounts.Password, Accounts.Email, Accounts.CreationDate, Accounts.EditDate, Accounts.Notes
                            FROM   AccountsCategories INNER JOIN
                                         Accounts ON AccountsCategories.AccountID = Accounts.AccountID INNER JOIN
                                         Categories ON AccountsCategories.CategoryID = Categories.CategoryID
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
                                CategoryID = reader["CategoryID"] == DBNull.Value ? -1 : (int)reader["CategoryID"];
                                CategoryName = reader["CategoryName"] == DBNull.Value ? null : (string)reader["CategoryName"];
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

            }
            return isFound;
        }

        static public bool GetRelationshipInfoByAccountUserName(ref int AccountID, string UserName, ref int CategoryID,
         ref string CategoryName, ref string Password, ref string Email,
         ref string Notes, ref DateTime CreationDate, ref DateTime EditDate)
        {
            bool isFound = false;
            string quey = @"SELECT Accounts.AccountID, Accounts.Username, Categories.CategoryID, Categories.CategoryName,
                            Accounts.Password, Accounts.Email, Accounts.CreationDate, Accounts.EditDate, Accounts.Notes
                            FROM   AccountsCategories INNER JOIN
                                         Accounts ON AccountsCategories.AccountID = Accounts.AccountID INNER JOIN
                                         Categories ON AccountsCategories.CategoryID = Categories.CategoryID
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
                                CategoryID = reader["CategoryID"] == DBNull.Value ? -1 : (int)reader["CategoryID"];
                                CategoryName = reader["CategoryName"] == DBNull.Value ? null : (string)reader["CategoryName"];
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

            }
            return isFound;
        }

        static public bool GetRelationshipInfoByCategoryID(ref int AccountID, ref string UserName, int CategoryID,
         ref string CategoryName, ref string Password, ref string Email,
         ref string Notes, ref DateTime CreationDate, ref DateTime EditDate)
        {
            bool isFound = false;
            string quey = @"SELECT Accounts.AccountID, Accounts.Username, Categories.CategoryID, Categories.CategoryName,
                            Accounts.Password, Accounts.Email, Accounts.CreationDate, Accounts.EditDate, Accounts.Notes
                            FROM   AccountsCategories INNER JOIN
                                         Accounts ON AccountsCategories.AccountID = Accounts.AccountID INNER JOIN
                                         Categories ON AccountsCategories.CategoryID = Categories.CategoryID
                            WHERE (Categories.CategoryID = @CategoryID);";
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(quey, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserName = (string)reader["Username"];
                                AccountID = (int)reader["AccountID"];
                                CategoryName = reader["CategoryName"] == DBNull.Value ? null : (string)reader["CategoryName"];
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
                isFound = false;
            }
            return isFound;
        }

        static public bool GetRelationshipInfoByCategoryName(ref int AccountID,ref string UserName, ref int CategoryID,
         string CategoryName, ref string Password, ref string Email,
         ref string Notes, ref DateTime CreationDate, ref DateTime EditDate)
        {
            bool isFound = false;
            string quey = @"SELECT Accounts.AccountID, Accounts.Username, Categories.CategoryID, Categories.CategoryName,
                            Accounts.Password, Accounts.Email, Accounts.CreationDate, Accounts.EditDate, Accounts.Notes
                            FROM   AccountsCategories INNER JOIN
                                         Accounts ON AccountsCategories.AccountID = Accounts.AccountID INNER JOIN
                                         Categories ON AccountsCategories.CategoryID = Categories.CategoryID
                            WHERE (Categories.CategoryName = @CategoryName);";
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(quey, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                AccountID = (int)reader["AccountID"];
                                UserName = reader["UserName"] == DBNull.Value ? null : (string)reader["UserName"];
                                CategoryID = reader["CategoryID"] == DBNull.Value ? -1 : (int)reader["CategoryID"];
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
                isFound = false;
            }
            return isFound;
        }

        static public bool UpdateRelationshipByAccountID(int AccountID, int SetCategoryID, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            int rowsAffected = 0;
            string query = @"
                    UPDATE AccountsCategories 
                    SET CategoryID = @SetCategoryID 
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

                if (clsAccount.IsExist(AccountID, Connection, Transaction) && clsCategory.IsExist(SetCategoryID, Connection, Transaction))
                { 
                      using (SqlCommand command = new SqlCommand(query, Connection, Transaction))
                      {
                          command.Parameters.AddWithValue("@SetCategoryID", SetCategoryID);
                          command.Parameters.AddWithValue("@AccountID", AccountID);

                          rowsAffected = command.ExecuteNonQuery();
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
            return rowsAffected > 0;
        }


        static public bool DeleteRelationshipByAccountID(int AccountID)
        {
            int rowsAffected = 0;
            string query = @" DELETE FROM AccountsCategories WHERE AccountID=@AccountID;";

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
        static public bool DeleteRelationship(int AccountID, int CategoryID)
        {
            int rowsAffected = 0;
            string query = @" DELETE FROM AccountsCategories WHERE AccountID=@AccountID and CategoryID = @CategoryID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

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
        static public DataTable GetListRelationship()
        {
            DataTable RelationshipTable = new DataTable();
            string query = @"
                            SELECT Accounts.AccountID, Accounts.Username, Categories.CategoryID, Categories.CategoryName
                            FROM   AccountsCategories INNER JOIN
                                         Accounts ON AccountsCategories.AccountID = Accounts.AccountID INNER JOIN
                                         Categories ON AccountsCategories.CategoryID = Categories.CategoryID";

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
                Console.WriteLine(ex.Message);
            }
            return RelationshipTable;
        }
   
        static public bool IsExist(int AccountID, int CategoryID, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            bool isFound = false;
            string quey = @"SELECT Found=1 FROM AccountsCategories WHERE AccountID = @AccountID and CategoryID = @CategoryID";
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
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

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

        static public bool IsExist(int categoryID)
        {
            bool isExist = false;

            string query = @"SELECT Found = 1 
                     FROM AccountsCategories
                     WHERE CategoryID = @CategoryID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID);

                        object result = command.ExecuteScalar();
                        if (result != null)
                            isExist = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in IsExistByCategoryID: " + ex.Message);
            }

            return isExist;
        }

    }
}

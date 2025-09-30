using System;
using System.Data;
using System.Data.SqlClient;

namespace DL_PasswordManagementSystem
{
    static public class clsCategory
    {
        static public bool GetCategoryInfoByID(
             int CategoryID,
             ref string CategoryName,
             SqlConnection Connection = null,
             SqlTransaction Transaction = null)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Categories WHERE CategoryID = @CategoryID";

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
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            CategoryName = (string)reader["CategoryName"];
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


        static public bool GetCategoryInfoByCategoryName(
            ref int CategoryID,
            string CategoryName,
            SqlConnection Connection = null,
            SqlTransaction Transaction = null)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Categories WHERE CategoryName = @CategoryName";

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
                    command.Parameters.AddWithValue("@CategoryName", CategoryName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            CategoryID = (int)reader["CategoryID"];
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

        public static DataTable GetCategoriesByType(string categoryType)
        {
            DataTable dataTable = new DataTable();

            string query = @"
                           SELECT Accounts.Username, Accounts.Password, Categories.CategoryName, Accounts.Email, Accounts.CreationDate, Accounts.EditDate, Accounts.Notes
                            FROM   Categories INNER JOIN
                                         AccountsCategories ON Categories.CategoryID = AccountsCategories.CategoryID INNER JOIN
                                         Accounts ON AccountsCategories.AccountID = Accounts.AccountID
                            WHERE (Categories.CategoryName = @categoryType);";
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryType", categoryType);

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

        static public int CreateCategory(int CategoryID, string CategoryName, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            string query = @"
                INSERT INTO Categories (CategoryName) 
                VALUES (@CategoryName);
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
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            CategoryID = insertedID;
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

            return CategoryID;
        }

        static public bool UpdateCategory(int CategoryID, string CategoryName, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            int rowsAffected = 0;
            string query = @"
                            UPDATE Categories 
                            SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID;";
          
            bool localConnection = false;
            try
            {
                if(Connection == null)
                {
                    Connection = new SqlConnection(clsDBSettings.ConnectionString);
                    Connection.Open();
                    localConnection = true;
                }
                    using (SqlCommand command = new SqlCommand(query, Connection,Transaction))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);
                        
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

        static public bool DeleteCategory(int CategoryID)
        {
            int rowsAffected = 0;
            string query = @" DELETE FROM Categories WHERE CategoryID=@CategoryID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        static public bool IsExist(int CategoryID, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            bool isFound = false;
            string query = @" SELECT Found=1 FROM Categories WHERE CategoryID=@CategoryID;";

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
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
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
            return isFound;
        }
     
        static public bool IsExist(string CategoryName, SqlConnection Connection = null, SqlTransaction Transaction = null)
        {
            bool isFound = false;
            string query = @" SELECT Found=1 FROM Categories WHERE CategoryName=@CategoryName;";

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
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);

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

        static public DataTable GetListCategories()
        {
            DataTable CategoriesTable = new DataTable();
            string query = @" SELECT * FROM Categories;";

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
                                CategoriesTable.Load(reader);
                            else
                                CategoriesTable = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CategoriesTable;
        }
    }
}

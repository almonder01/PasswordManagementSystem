using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;

namespace DL_PasswordManagementSystem
{
    static public class clsFullyAccountInformation
    {
        static public bool GetFullyAccountInfoByAccountID(int AccountID,
            ref string Username,
            ref int CategoryID,
            ref string CategoryName,
            ref int ServiceID,
            ref string ServiceName,
            ref string Url,
            ref string Password,
            ref string Email,
            ref DateTime CreationDate,
            ref DateTime EditDate,
            ref string Notes)
        {
            bool isFound = false;

            string query = @"SELECT * from AllAccountInformation WHERE AccountID = @AccountID;";

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
                                Username = (string)reader["Username"];
                                CategoryID = reader["CategoryID"] == DBNull.Value ? -1 : (int)reader["CategoryID"];
                                CategoryName = reader["CategoryName"] == DBNull.Value ? null : (string)reader["CategoryName"];
                                ServiceID = reader["ServiceID"] == DBNull.Value ? -1 : (int)reader["ServiceID"];
                                ServiceName = reader["ServiceName"] == DBNull.Value ? null : (string)reader["ServiceName"];
                                Url = reader["Url"] == DBNull.Value ? null : (string)reader["Url"];
                                Password = clsAesHelper.Decrypt((string)reader["Password"]);
                                Email = (string)reader["Email"] ;
                                CreationDate = (DateTime)reader["CreationDate"];
                                EditDate = (DateTime)reader["EditDate"];
                                Notes = reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"];
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

        static public bool GetFullyAccountInfoByUserName(ref int AccountID,
          string Username,
          ref int CategoryID,
          ref string CategoryName,
          ref int ServiceID,
          ref string ServiceName,
          ref string Url,
          ref string Password,
          ref string Email,
          ref DateTime CreationDate,
          ref DateTime EditDate,
          ref string Notes)
        {
            bool isFound = false;

            string query = @"SELECT * from AllAccountInformation WHERE Username = @Username;";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                AccountID = (int)reader["AccountID"];
                                CategoryID = reader["CategoryID"] == DBNull.Value ? -1 : (int)reader["CategoryID"];
                                CategoryName = reader["CategoryName"] == DBNull.Value ? null : (string)reader["CategoryName"];
                                ServiceID = reader["ServiceID"] == DBNull.Value ? -1 : (int)reader["ServiceID"];
                                ServiceName = reader["ServiceName"] == DBNull.Value ? null : (string)reader["ServiceName"];
                                Url = reader["Url"] == DBNull.Value ? null : (string)reader["Url"];
                                Password = clsAesHelper.Decrypt((string)reader["Password"]);
                                Email = (string)reader["Email"];
                                CreationDate = (DateTime)reader["CreationDate"];
                                EditDate = (DateTime)reader["EditDate"];
                                Notes = reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"];
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

        static public DataTable GetFullyListAccounts()
        {
            DataTable ListAccounts = new DataTable();

            string query = @"SELECT * FROM AllAccountInformation;";

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                ListAccounts.Load(reader);
                                foreach (DataRow row in ListAccounts.Rows)
                                {
                                    string decryptedPassword = clsAesHelper.Decrypt(row["Password"].ToString());

                                    row["Password"] = decryptedPassword;
                                }
                            }
                        }
                        
                    }
                        
                }
            }catch(Exception ex)
            {
                ListAccounts = null;
                Console.WriteLine("Error:" + ex.Message.ToString());
            }
            return ListAccounts;
        }



        static public int CreateFullyAccount(int AccountID, string UserName, int CategoryID, string CategoryName,
            int ServiceID, string ServiceName, string Url, string Password,
            string Email, string Notes, DateTime CreationDate, DateTime EditDate)
        {

            AccountID = clsRelAccountCategory.GetAccountIDByUserName(UserName);
            CategoryID = clsRelAccountCategory.GetCategoryIDByCategoryName(CategoryName);
            ServiceID = clsRelAccountService.GetServiceIDByServiceName(ServiceName);

            using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        AccountID = clsAccount.CreateAccount(AccountID, UserName, Password, Email, Notes, CreationDate, EditDate, connection, transaction);
                        if (!clsCategory.IsExist(CategoryName, connection, transaction))
                        {
                            CategoryID = clsCategory.CreateCategory(CategoryID, CategoryName, connection, transaction);
                        }

                        if (!clsRelAccountCategory.IsExist(AccountID, CategoryID, connection, transaction))
                        {
                            clsRelAccountCategory.AddRelationship(AccountID, CategoryID, connection, transaction);
                        }

                        if (!clsService.IsExist(ServiceID, connection, transaction))
                        {
                            ServiceID = clsService.CreateService(ServiceID, ServiceName, Url, connection, transaction);

                        }

                        if (!clsRelAccountService.IsExist(AccountID, ServiceID, connection, transaction))
                            clsRelAccountService.AddRelationship(AccountID, ServiceID, connection, transaction);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error: " + ex.Message);
                        AccountID = -1;
                    }
                }
            }
            return AccountID;
        }

    }
}

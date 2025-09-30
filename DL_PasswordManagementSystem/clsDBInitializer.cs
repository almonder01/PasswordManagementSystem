using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace DL_PasswordManagementSystem
{
    public static class clsDBInitializer
    {
        static string createDBQuery = @"
         IF DB_ID('PasswordsDB') IS NULL
             CREATE DATABASE PasswordsDB;";


        static string queryCreateTableAccount = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Accounts' AND xtype='U')
            CREATE TABLE Accounts (
                AccountID INT IDENTITY(1,1) PRIMARY KEY,
                Username NVARCHAR(50) NOT NULL,
                Password NVARCHAR(50) NOT NULL,
                Email NVARCHAR(100) NOT NULL,
                CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
                EditDate DATETIME NOT NULL DEFAULT GETDATE(),
                Notes NVARCHAR(MAX)
            );";

        static string queryCreateTableService = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Services' AND xtype='U')
            CREATE TABLE Services (
                ServiceID INT IDENTITY(1,1) PRIMARY KEY,
                ServiceName NVARCHAR(100) UNIQUE NOT NULL,
                Url NVARCHAR(200)
            );";

        static string queryCreateTableCategory = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Categories' AND xtype='U')
            CREATE TABLE Categories (
                CategoryID INT IDENTITY(1,1) PRIMARY KEY,
                CategoryName NVARCHAR(100) UNIQUE NOT NULL
            );";

        static string queryCreateTableAccountsServices = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AccountsServices' AND xtype='U')
            CREATE TABLE AccountsServices (
                ServiceID INT NOT NULL,
                AccountID INT NOT NULL,
                PRIMARY KEY (ServiceID, AccountID),
                FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID) ON DELETE CASCADE,
                FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE
            );";

        static string queryCreateTableAccountsCategories = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AccountsCategories' AND xtype='U')
            CREATE TABLE AccountsCategories (
                CategoryID INT NOT NULL,
                AccountID INT NOT NULL,
                PRIMARY KEY (CategoryID, AccountID),
                FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE CASCADE,
                FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID) ON DELETE CASCADE
            );";

        static string queryCreateViewAllAcountInformation = @"
            IF NOT EXISTS (SELECT * FROM sys.views WHERE name = 'AllAccountInformation')
            EXEC('
                CREATE VIEW AllAccountInformation AS
                SELECT 
                    Accounts.AccountID, 
                    Accounts.Username,
                    Accounts.Password,
                    Accounts.Email, 
                    Categories.CategoryID, 
                    Categories.CategoryName, 
                    Services.ServiceID, 
                    Services.ServiceName,
                    Accounts.CreationDate, 
                    Accounts.EditDate, 
                    Services.Url,
                    Accounts.Notes  
                FROM Accounts
                LEFT JOIN AccountsCategories ON Accounts.AccountID = AccountsCategories.AccountID
                LEFT JOIN Categories ON AccountsCategories.CategoryID = Categories.CategoryID
                LEFT JOIN AccountsServices ON Accounts.AccountID = AccountsServices.AccountID
                LEFT JOIN Services ON AccountsServices.ServiceID = Services.ServiceID
            ');
            ";
        private static bool _InitializerCreateTables()
        {
            string[] queriesCreationTables = new string[]
            {
                queryCreateTableAccount,
                queryCreateTableService,
                queryCreateTableCategory,
                queryCreateTableAccountsServices,
                queryCreateTableAccountsCategories
            };

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();

                    foreach (string query in queriesCreationTables)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static bool _InitializerCreateDataBase()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.masterConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(createDBQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            } 
        }
   
        private static bool _InitializerCreateViews()
        {
            string[] queriesCreationViews = new string[]
           {
                queryCreateViewAllAcountInformation
           };

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDBSettings.ConnectionString))
                {
                    connection.Open();

                    foreach (string query in queriesCreationViews)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
   
       public static bool Initializer()
        {

            try
            {
                return _InitializerCreateDataBase() &&
                       _InitializerCreateTables() &&
                       _InitializerCreateViews();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Initialization failed: " + ex.Message);
                return false;
            }
           
        }
    }
}

using BL_PasswordManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Test_PasswordManagementSystem
{

// TODO: Verification is incomplete. Consider adding more test cases or checks here.
    
    static public class TestAccount
    {
        static public void TestAdd()
        {
            clsLogicAccount account = new clsLogicAccount();

            account.UserName = "Almonder 2";
            account.Password = "1234";
            account.Email = "Almonder@gmail.com";
            account.Notes = "Test Add Account 2";
  

            if (account.Save())
            {
                Console.WriteLine(account.AccountID);
                Console.WriteLine(account.UserName);
                Console.WriteLine(account.Email);
                Console.WriteLine(account.Password);
                Console.WriteLine(account.Notes);
                Console.WriteLine(account.CreationDate.ToString());
                Console.WriteLine(account.EditDate.ToString());
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        static public void TestFind(int ID)
        {

            clsLogicAccount account = clsLogicAccount.Find(ID);
            if (account != null)
            {
                Console.WriteLine(account.AccountID);
                Console.WriteLine(account.UserName);
                Console.WriteLine(account.Email);
                Console.WriteLine(account.Password);
                Console.WriteLine(account.Notes);
                Console.WriteLine(account.CreationDate.ToString());
                Console.WriteLine(account.EditDate.ToString());
             

            }
            else
            {
                Console.WriteLine("No found!");
            }
        }

        static public void TestUpdate(int ID)
        {

            clsLogicAccount account = clsLogicAccount.Find(ID);
            if (account != null)
            {

                account.Password = "12345";
                if (account.Save())
                {
                    Console.WriteLine("Update sucssfully!");
                    Console.WriteLine("Passowrd: "+ account.Password);
                }
                else
                    Console.WriteLine("Update faild!");
            }
            else
            {
                Console.WriteLine("No found!");
            }
        }

        static public void TestDelete(int AID)
        {
            if (clsLogicAccount.IsExist(AID))
                if (clsLogicAccount.DeleteAccount(AID))
                {
                    Console.WriteLine("Deleted sucssfully");
                }
                else
                {
                    Console.WriteLine("Deleted Faild");
                }
            else
                Console.WriteLine("Not Exist");

        }
       
        static public void TestIsExist(int ID)
        {
            if (clsLogicAccount.IsExist(ID))
                Console.WriteLine("Exist");
            else
                Console.WriteLine("Not Exist");
        }
        static public void TestGetAll()
        {
            DataTable accounts = clsLogicAccount.GetListAccounts();
            if (accounts != null)
            {
                foreach (DataRow dataRow in accounts.Rows)
                {
                    Console.WriteLine($"{dataRow[0]}");
                    Console.WriteLine($"{dataRow[1]}");
                    Console.WriteLine($"{dataRow[2]}");
                    Console.WriteLine($"{dataRow[3]}");
                    Console.WriteLine($"{dataRow[4]}");
                    Console.WriteLine($"{dataRow[5]}");
                    Console.WriteLine($"{dataRow[6]}");
                }
            }
            else
            {
                Console.WriteLine($"Error");
            }
        }
    }
    public class TestCategory
    {
        static public void TestAdd()
        {
            clsLogicCategory account = new clsLogicCategory();

            account.CategoryName = "Personal 2";
           
            if (account.Save())
            {
                Console.WriteLine(account.CategoryName);
                
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        static public void TestFind(int ID)
        {

            clsLogicCategory account = clsLogicCategory.Find(ID);
            if (account != null)
            {
                Console.WriteLine(account.CategoryID);
                Console.WriteLine(account.CategoryName);
                


            }
            else
            {
                Console.WriteLine("No found!");
            }
        }

        static public void TestUpdate(int ID)
        {

            clsLogicCategory account = clsLogicCategory.Find(ID);
            if (account != null)
            {

                account.CategoryName = "Personal \"1\" Updated";
                if (account.Save())
                    Console.WriteLine("Update sucssfully!");
                else
                    Console.WriteLine("Update faild!");
            }
            else
            {
                Console.WriteLine("No found!");
            }
        }

        static public void TestDelete(int ID)
        {
            if (clsLogicCategory.IsExist(ID))
                if (clsLogicCategory.DeleteCategory(ID))
                {
                    Console.WriteLine("Deleted sucssfully");
                }
                else
                {
                    Console.WriteLine("Deleted Faild");
                }
            else
                Console.WriteLine("Not Exist");

        }

        static public void TestIsExist(int ID)
        {
            if (clsLogicCategory.IsExist(ID))
                Console.WriteLine("Exist");
            else
                Console.WriteLine("Not Exist");
        }
        static public void TestGetAll()
        {
            DataTable accounts = clsLogicCategory.GetListCategory();
            if (accounts != null)
            {
                foreach (DataRow dataRow in accounts.Rows)
                {
                    Console.WriteLine($"{dataRow[0]}");
                    Console.WriteLine($"{dataRow[1]}");
                }
            }
            else
            {
                Console.WriteLine($"Error");
            }
        }
    }
    public class TestService
    {
        static public void TestAdd()
        {
            clsLogicService account = new clsLogicService();

            account.ServiceName = "Facebook 3";
            account.Url = "";

            if (account.Save())
            {
                Console.WriteLine(account.ServiceName);
                Console.WriteLine(account.Url);

            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        static public void TestFind(int ID)
        {

            clsLogicService account = clsLogicService.Find(ID);
            if (account != null)
            {
                Console.WriteLine(account.ServiceID);
                Console.WriteLine(account.ServiceName);
                Console.WriteLine(account.Url);


            }
            else
            {
                Console.WriteLine("No found!");
            }
        }

        static public void TestUpdate(int ID)
        {

            clsLogicService account = clsLogicService.Find(ID);
            if (account != null)
            {

                account.ServiceName = "FaceBook \"B\" Updated";
                account.Url = "";
                if (account.Save())
                    Console.WriteLine("Update sucssfully!");
                else
                    Console.WriteLine("Update faild!");
            }
            else
            {
                Console.WriteLine("No found!");
            }
        }

        static public void TestDelete(int ID)
        {
            if (clsLogicService.IsExist(ID))
                if (clsLogicService.DeleteService(ID))
                {
                    Console.WriteLine("Deleted sucssfully");
                }
                else
                {
                    Console.WriteLine("Deleted Faild");
                }
            else
                Console.WriteLine("Not Exist");

        }

        static public void TestIsExist(int ID)
        {
            if (clsLogicService.IsExist(ID))
                Console.WriteLine("Exist");
            else
                Console.WriteLine("Not Exist");
        }
        static public void TestGetAll()
        {
            DataTable accounts = clsLogicService.GetListService();
            if (accounts != null)
            {
                foreach (DataRow dataRow in accounts.Rows)
                {
                    Console.WriteLine($"{dataRow[0]}");
                    Console.WriteLine($"{dataRow[1]}");
                    Console.WriteLine($"{dataRow[2]}");
                }
            }
            else
            {
                Console.WriteLine($"Error");
            }
        }
    }
    public class TestRelAccountCategory
    {
        static public void TestAdd()
        {
            clsLogicRelAccountCategory account = new clsLogicRelAccountCategory();

            account.AccountID = 8;
            account.CategoryID = 5;


            if (account.Save())
            {
                Console.WriteLine(account.CategoryName);
                Console.WriteLine(account.UserName);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        static public void TestFind(int ID)
        {

            clsLogicRelAccountCategory account = clsLogicRelAccountCategory.Find(ID);
            if (account != null)
            {
                Console.WriteLine(account.AccountID);
                Console.WriteLine(account.UserName);
                Console.WriteLine(account.CategoryID);
                Console.WriteLine(account.CategoryName);
                Console.WriteLine(account.Email);
                Console.WriteLine(account.Password);
                Console.WriteLine(account.Notes);
                Console.WriteLine(account.CreationDate.ToString());
                Console.WriteLine(account.EditDate.ToString());


            }
            else
            {
                Console.WriteLine("No found!");
            }
        }

        static public void TestUpdate(int ID)
        {

            clsLogicRelAccountCategory account = clsLogicRelAccountCategory.Find(ID);
            if (account != null)
            {
                
                account.CategoryID = 8;
                if (account.Save())
                    Console.WriteLine("Update sucssfully!");
                else
                    Console.WriteLine("Update faild!");
            }
            else
            {
                Console.WriteLine("No found!");
            }
        }

        static public void TestDelete(int AID, int CID)
        {
            if (clsLogicRelAccountCategory.IsExist(AID,CID))
                if (clsLogicRelAccountCategory.DeleteRelationship(AID, CID))
                {
                    Console.WriteLine("Deleted sucssfully");
                }
                else
                {
                    Console.WriteLine("Deleted Faild");
                }
            else
                Console.WriteLine("Not Exist");

        }

        static public void TestIsExist(int AID, int CID)
        {
            if (clsLogicRelAccountCategory.IsExist(AID,CID))
                Console.WriteLine("Exist");
            else
                Console.WriteLine("Not Exist");
        }
        static public void TestGetAll()
        {
            DataTable accounts = clsLogicRelAccountCategory.GetListRelationship();
            if (accounts != null)
            {
                foreach (DataRow dataRow in accounts.Rows)
                {
                    Console.WriteLine($"{dataRow[0]}");
                    Console.WriteLine($"{dataRow[1]}");
                    Console.WriteLine($"{dataRow[2]}");
                    Console.WriteLine($"{dataRow[3]}");
                }
            }
            else
            {
                Console.WriteLine($"Error");
            }
        }
    }
    public class TestRelAccountService
    {
        static public void TestAdd()
        {
            clsLogicRelAccountService account = new clsLogicRelAccountService();

            account.ServiceID = 9;
            account.AccountID = 9;

            if (account.Save())
            {
                Console.WriteLine(account.ServiceName);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        static public void TestFind(int ID)
        {

            DataTable dt = clsLogicRelAccountService.GetServicesByAccountID(ID);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["ServiceID"]} {row["ServiceName"]} {row["Url"]}");
            }
        }

        static public void TestUpdate(int ID)
        {

            //clsLogicRelAccountService account = clsLogicRelAccountService.Find(ID);
            //if (account != null)
            //{
            //    account.ServiceID = 5;
            //    if (account.Save())
            //        Console.WriteLine("Update sucssfully!");
            //    else
            //        Console.WriteLine("Update faild!");
            //}
            //else
            //{
            //    Console.WriteLine("No found!");
            //}
        }

        static public void TestDelete(int AID, int CID)
        {
            if (clsLogicRelAccountService.IsExist(AID, CID))
                if (clsLogicRelAccountService.DeleteRelationship(AID, CID))
                {
                    Console.WriteLine("Deleted sucssfully");
                }
                else
                {
                    Console.WriteLine("Deleted Faild");
                }
            else
                Console.WriteLine("Not Exist");

        }

        static public void TestIsExist(int AID, int CID)
        {
            if (clsLogicRelAccountService.IsExist(AID, CID))
                Console.WriteLine("Exist");
            else
                Console.WriteLine("Not Exist");
        }
        static public void TestGetAll()
        {
            DataTable accounts = clsLogicRelAccountService.GetListRelationship();
            if (accounts != null)
            {
                foreach (DataRow dataRow in accounts.Rows)
                {
                    Console.WriteLine($"{dataRow[0]}");
                    Console.WriteLine($"{dataRow[1]}");
                    Console.WriteLine($"{dataRow[2]}");
                    Console.WriteLine($"{dataRow[3]}");
                }
            }
            else
            {
                Console.WriteLine($"Error");
            }
        }
    }
    public class TestFullyAccount
    {

        static public void TestAdd()
        {
            clsLogicFullyAccountInformation account = new clsLogicFullyAccountInformation();

            account.UserName = "Saeed Ali 2";
            account.Password = "1234";
            account.Email = "SaeedAli@gmail.com";
            account.Notes = "Test Add Fully Account";
            account.ServiceName = "Facebook 2";
            account.CategoryName = "Personal 2";
            account.Url = "Https//";

            if (account.Save())
            {
                Console.WriteLine(account.AccountID);
                Console.WriteLine(account.UserName);
                Console.WriteLine(account.Email);
                Console.WriteLine(account.Password);
                Console.WriteLine(account.Notes);
                Console.WriteLine(account.CreationDate.ToString());
                Console.WriteLine(account.EditDate.ToString());
            }
            else
            {
                Console.WriteLine("Erroe");
            }
        }

        static public void TestFind(int ID)
        {
            clsLogicFullyAccountInformation account = clsLogicFullyAccountInformation.Find(ID);

            if (account != null)
            {
                Console.WriteLine(account.AccountID);
                Console.WriteLine(account.UserName);
                Console.WriteLine(account.Email);
                Console.WriteLine(account.Password);
                Console.WriteLine(account.Notes);
                Console.WriteLine(account.CreationDate.ToString());
                Console.WriteLine(account.EditDate.ToString());
                Console.WriteLine(account.CategoryName.ToString());
                Console.WriteLine(account.ServiceName.ToString());

            }
            else
            {
                Console.WriteLine("No found!");
            }
        }

        static public void TestUpdate(int ID)
        {
            Console.WriteLine("Comming Soon!");
        }
        static public void TestGetAll()
        {
            DataTable accounts = clsLogicFullyAccountInformation.GetFullyListAccounts();
            if (accounts != null)
            {
                foreach (DataRow dataRow in accounts.Rows)
                {
                    Console.WriteLine($"{dataRow[0]}");
                    Console.WriteLine($"{dataRow[1]}");
                    Console.WriteLine($"{dataRow[2]}");
                    Console.WriteLine($"{dataRow[3]}");
                    Console.WriteLine($"{dataRow[4]}");
                    Console.WriteLine($"{dataRow[5]}");
                    Console.WriteLine($"{dataRow[6]}");
                }
            }
            else
            {
                Console.WriteLine($"Error");
            }
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            //TestAccount.TestDelete(4);

            TestRelAccountService.TestFind(9);

            //TestCategory.TestDelete(3);
            //TestService.TestDelete(4);
            //TestRelAccountCategory.TestDelete(8, 9);
            //TestRelAccountService.TestDelete(8, 6);

            //TestAccount.TestAdd();
            //TestCategory.TestAdd();
            //TestService.TestAdd();
            //TestRelAccountCategory.TestAdd();
            //TestRelAccountService.TestAdd();
            //TestFullyAccount.TestAdd();

            //TestAccount.TestUpdate(4);
            //TestCategory.TestUpdate(5);
            //TestService.TestUpdate(5);
            //TestRelAccountCategory.TestUpdate(6);
            //TestRelAccountService.TestUpdate(7);

            //TestAccount.TestGetAll();
            //TestCategory.TestGetAll();
            //TestService.TestGetAll();
            //TestRelAccountCategory.TestGetAll();
            //TestRelAccountService.TestGetAll();
            //TestFullyAccount.TestGetAll();

            DataTable dt = clsLogicCategory.GetCategoriesByType("Facebook 2");

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[3]);
            }
        }
    }
}

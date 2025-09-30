using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DL_PasswordManagementSystem;
namespace BL_PasswordManagementSystem
{
    public enum enFullyAccountInformationMode { Update = 0, AddNew = 1 };

    public class clsLogicFullyAccountInformation
    {
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime EditDate { get; private set; }

        public enFullyAccountInformationMode Mode { get; set; }
        private clsLogicFullyAccountInformation(int AccountID, string UserName, int CategoryID, string CategoryName, int ServiceID, string ServiceName, string Url, string Password, string Email, DateTime CreationDate, DateTime EditDate, string Notes)
        {
            this.AccountID = AccountID;
            this.UserName = UserName;
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            this.ServiceID = ServiceID;
            this.ServiceName = ServiceName;
            this.Url = Url;
            this.Password = Password;
            this.Email = Email;
            this.Notes = Notes;
            this.CreationDate = CreationDate;
            this.EditDate = EditDate;


            Mode = enFullyAccountInformationMode.Update;

        }

        public clsLogicFullyAccountInformation()
        {
            this.AccountID = -1;
            this.UserName = "";
            this.CategoryID = -1;
            this.CategoryName = "";
            this.ServiceID = -1;
            this.ServiceName = "";
            this.Url = "";
            this.Password = "";
            this.Email = "";
            this.CreationDate = DateTime.Now;
            this.EditDate = DateTime.Now;
            this.Notes = "";

            Mode = enFullyAccountInformationMode.AddNew;
        }

        static public clsLogicFullyAccountInformation Find(int AccountID)
        {
            int ServiceID = -1, CategoryID = -1;
            string UserName = "", CategoryName = "", ServiceName = "", Url = "", Password = "", Email = "", Notes = "";
            DateTime CreationDate = DateTime.Now, EditDate = DateTime.Now;

            if (DL_PasswordManagementSystem.clsFullyAccountInformation.GetFullyAccountInfoByAccountID(AccountID,ref UserName,ref CategoryID,ref CategoryName, ref ServiceID, ref ServiceName, ref Url, ref Password, ref Email,ref CreationDate, ref EditDate, ref Notes))
            {
                return new clsLogicFullyAccountInformation(AccountID,UserName, CategoryID, CategoryName, ServiceID, ServiceName,Url, Password, Email, CreationDate, EditDate, Notes);
            }
            return null;
        }
        static public clsLogicFullyAccountInformation Find(string UserName)
        {
            int AccountID = -1, ServiceID = -1, CategoryID = -1;
            string CategoryName = "", ServiceName = "", Url = "", Password = "", Email = "", Notes = "";
            DateTime CreationDate = DateTime.Now, EditDate = DateTime.Now;

            if (DL_PasswordManagementSystem.clsFullyAccountInformation.GetFullyAccountInfoByUserName(ref AccountID, UserName, ref CategoryID, ref CategoryName,ref ServiceID, ref ServiceName,ref Url, ref Password, ref Email, ref CreationDate, ref EditDate, ref Notes))
            {
                return new clsLogicFullyAccountInformation(AccountID, UserName, CategoryID, CategoryName, ServiceID, ServiceName, Url, Password, Email, CreationDate, EditDate, Notes);
            }
            return null;
        }

        private bool _AddFullyAccount()
        {
             this.AccountID = DL_PasswordManagementSystem.clsFullyAccountInformation.CreateFullyAccount(this.AccountID,this.UserName,this.CategoryID,this.CategoryName,this.ServiceID,this.ServiceName,this.Url,this.Password,this.Email,this.Notes,this.CreationDate,this.EditDate);
            return AccountID != -1;
        }
        private bool _UpdateFullyAccount()
        {
            //Comming soon
            //this.EditDate = DateTime.Now;
            return false;
        }
       
        static public DataTable GetFullyListAccounts()
        {
            return DL_PasswordManagementSystem.clsFullyAccountInformation.GetFullyListAccounts();
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enFullyAccountInformationMode.AddNew:
                    if (_AddFullyAccount())
                    {
                        this.Mode = enFullyAccountInformationMode.Update;
                        return true;
                    }
                    break;
                case enFullyAccountInformationMode.Update:
                    return _UpdateFullyAccount();
            }
            return false;
        }
    }
}

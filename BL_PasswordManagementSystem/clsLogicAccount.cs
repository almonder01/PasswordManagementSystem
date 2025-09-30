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
    public enum enMode { Update = 0, AddNew = 1 };

    public class clsLogicAccount
    {

        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime EditDate { get; private set; }

        public enMode Mode { get; set; }
        private clsLogicAccount(int AccountID, string UserName, string Password, string Email, string Notes, DateTime CreationDate, DateTime EditDate)
        {
            this.AccountID = AccountID;
            this.UserName = UserName;
            this.Password = Password;
            this.Email = Email;
            this.Notes = Notes;
            this.CreationDate = CreationDate;
            this.EditDate = EditDate;
            Mode = enMode.Update;

        }

        public clsLogicAccount()
        {
            this.AccountID = -1;
            this.UserName = "";
            this.Password = "";
            this.Email = "";
            this.Notes = "";
            this.CreationDate = DateTime.Now;
            this.EditDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        static public clsLogicAccount Find(int AccountID)
        {
            string UserName = "", Password = "", Email = "", Notes = "";
            DateTime CreationDate = DateTime.Now, EditDate = DateTime.Now;

            if(DL_PasswordManagementSystem.clsAccount.GetAccountInfoByID(AccountID, ref UserName, ref Password, ref Email, ref Notes, ref CreationDate, ref EditDate))
            {
                return new clsLogicAccount(AccountID, UserName, Password, Email, Notes, CreationDate, EditDate);
            }
            return null;
        }
        static public clsLogicAccount Find(string UserName)
        {
            int AccountID = -1;
            string Password = "", Email = "", Notes = "";
            DateTime CreationDate = DateTime.Now, EditDate = DateTime.Now;

            if (DL_PasswordManagementSystem.clsAccount.GetAccountInfoByUserName(ref AccountID, UserName, ref Password, ref Email, ref Notes, ref CreationDate, ref EditDate))
            {
                return new clsLogicAccount(AccountID, UserName, Password, Email, Notes, CreationDate, EditDate);
            }
            return null;
        }

        private bool _AddAccount()
        {
            this.AccountID = DL_PasswordManagementSystem.clsAccount.CreateAccount(this.AccountID,this.UserName,this.Password,this.Email,this.Notes,this.CreationDate,this.EditDate);
            return this.AccountID != -1;
        }

        private bool _UpdateAccount()
        {
            this.EditDate = DateTime.Now;
            return DL_PasswordManagementSystem.clsAccount.UpdateAccount(this.AccountID, this.UserName, this.Password, this.Email, this.Notes, this.CreationDate, this.EditDate);
        }
        static public bool DeleteAccount(int AccountID)
        {
            return DL_PasswordManagementSystem.clsAccount.DeleteAccount(AccountID);
        }
        static public bool IsExist(int AccountID)
        {
            return DL_PasswordManagementSystem.clsAccount.IsExist(AccountID);
        }
        static public DataTable GetListAccounts()
        {
            return DL_PasswordManagementSystem.clsAccount.GetListAccounts();
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddAccount())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateAccount();
            }
            return false;
        }
    }
}

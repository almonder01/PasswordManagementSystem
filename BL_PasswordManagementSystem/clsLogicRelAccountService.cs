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
    public enum enRelAccountServiceMode { Update = 0, AddNew = 1 };

    public class clsLogicRelAccountService
    {
        public int AccountID { get; set; }
        public string UserName { get; set; }

        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime EditDate { get; private set; }

        public enRelAccountServiceMode Mode { get; set; }
        private clsLogicRelAccountService(int AccountID, string UserName, int ServiceID, string ServiceName, string Url, string Password, string Email, string Notes, DateTime CreationDate, DateTime EditDate)
        {
            this.AccountID = AccountID;
            this.UserName = UserName;
            this.ServiceID = ServiceID;
            this.ServiceName = ServiceName;
            this.Url = Url;
            this.Password = Password;
            this.Email = Email;
            this.Notes = Notes;
            this.CreationDate = CreationDate;
            this.EditDate = EditDate;


            Mode = enRelAccountServiceMode.Update;

        }

        public clsLogicRelAccountService()
        {
            this.ServiceID = -1;
            this.AccountID = -1;
            
            Mode = enRelAccountServiceMode.AddNew;
        }

        static public clsLogicRelAccountService Find(int AccountID)
        {
            int ServiceID = -1;
            string UserName = "", ServiceName = "", Url = "", Password = "", Email = "", Notes = "";
            DateTime CreationDate = DateTime.Now, EditDate = DateTime.Now;

            if (DL_PasswordManagementSystem.clsRelAccountService.GetRelationshipInfoByAccountID(AccountID, ref UserName, ref ServiceID, ref ServiceName, ref Url, ref Password, ref Email, ref Notes, ref CreationDate, ref EditDate))
            {
                return new clsLogicRelAccountService(AccountID, UserName, ServiceID, ServiceName, Url, Password, Email, Notes, CreationDate, EditDate);
            }
            return null;
        }
        static public clsLogicRelAccountService Find(string UserName)
        {
            int AccountID = -1, ServiceID = -1;
            string ServiceName = "", Url = "", Password = "", Email = "", Notes = "";
            DateTime CreationDate = DateTime.Now, EditDate = DateTime.Now;

            if (DL_PasswordManagementSystem.clsRelAccountService.GetRelationshipInfoByAccountUserName(ref AccountID, UserName,ref ServiceID, ref ServiceName,ref Url, ref Password, ref Email, ref Notes, ref CreationDate, ref EditDate))
            {
                return new clsLogicRelAccountService(AccountID, UserName, ServiceID, ServiceName,Url, Password, Email, Notes, CreationDate, EditDate);
            }
            return null;
        }
        static public DataTable GetServicesByAccountID(int AccountID)
        {
            return DL_PasswordManagementSystem.clsRelAccountService.GetServicesByAccountID(AccountID);
        }

        private bool _AddRelationship()
        {
            if(this.AccountID == -1)
                this.AccountID = clsRelAccountService.GetAccountIDByUserName(this.UserName);
            if(this.ServiceID == -1)
                this.ServiceID = clsRelAccountService.GetServiceIDByServiceName(this.ServiceName);
            return DL_PasswordManagementSystem.clsRelAccountService.AddRelationship(this.AccountID,this.ServiceID);     
        }
        private bool _UpdateRelationship()
        {
            this.EditDate = DateTime.Now;
            return DL_PasswordManagementSystem.clsRelAccountService.UpdateRelationshipByAccountID(this.AccountID, this.ServiceID);
        }
        static public bool DeleteRelationship(int AccountID, int ServiceID)
        {
            return DL_PasswordManagementSystem.clsRelAccountService.DeleteRelationship(AccountID, ServiceID);
        }
        static public bool IsExist(int AccountID, int ServiceID)
        {
            return DL_PasswordManagementSystem.clsRelAccountService.IsExist(AccountID, ServiceID);
        }
        static public bool IsExist(int ServiceID)
        {
            return DL_PasswordManagementSystem.clsRelAccountService.IsExist(ServiceID);
        }
        static public DataTable GetListRelationship()
        {
            return DL_PasswordManagementSystem.clsRelAccountService.GetListRelationship();
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enRelAccountServiceMode.AddNew:
                    if (_AddRelationship())
                    {
                        this.Mode = enRelAccountServiceMode.Update;
                        return true;
                    }
                    break;
                case enRelAccountServiceMode.Update:
                    return _UpdateRelationship();
            }
            return false;
        }
    }
}

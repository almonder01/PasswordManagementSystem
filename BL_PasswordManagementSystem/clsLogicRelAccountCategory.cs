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
    public enum enRelAccountCategoryMode { Update = 0, AddNew = 1 };

    public class clsLogicRelAccountCategory
    {
        public int AccountID { get; set; }
        public string UserName { get; set; }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime EditDate { get; private set; }

        public enRelAccountCategoryMode Mode { get; set; }
        private clsLogicRelAccountCategory(int AccountID, string UserName, int CategoryID, string CategoryName ,string Password, string Email, string Notes, DateTime CreationDate, DateTime EditDate)
        {
            this.AccountID = AccountID;
            this.UserName = UserName;
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            this.Password = Password;
            this.Email = Email;
            this.Notes = Notes;
            this.CreationDate = CreationDate;
            this.EditDate = EditDate;


            Mode = enRelAccountCategoryMode.Update;

        }

        public clsLogicRelAccountCategory()
        {
            this.CategoryID = -1;
            this.AccountID = -1;
            
            Mode = enRelAccountCategoryMode.AddNew;
        }

        static public clsLogicRelAccountCategory Find(int AccountID)
        {
            int CategoryID = -1;
            string UserName = "", CategoryName = "", Password = "", Email = "", Notes = "";
            DateTime CreationDate = DateTime.Now, EditDate = DateTime.Now;

            if (DL_PasswordManagementSystem.clsRelAccountCategory.GetRelationshipInfoByAccountID(AccountID,ref UserName, ref CategoryID,ref CategoryName, ref Password, ref Email, ref Notes, ref CreationDate, ref EditDate))
            {
                return new clsLogicRelAccountCategory(AccountID,UserName,CategoryID, CategoryName, Password, Email, Notes, CreationDate, EditDate);
            }
            return null;
        }
        static public clsLogicRelAccountCategory Find(string UserName)
        {
            int AccountID = -1, CategoryID = -1;
            string CategoryName = "", Password = "", Email = "", Notes = "";
            DateTime CreationDate = DateTime.Now, EditDate = DateTime.Now;

            if (DL_PasswordManagementSystem.clsRelAccountCategory.GetRelationshipInfoByAccountUserName(ref AccountID, UserName,ref CategoryID, ref CategoryName, ref Password, ref Email, ref Notes, ref CreationDate, ref EditDate))
            {
                return new clsLogicRelAccountCategory(AccountID, UserName, CategoryID, CategoryName, Password, Email, Notes, CreationDate, EditDate);
            }
            return null;
        }

        private bool _AddRelAccountCategory()
        {
            if(this.AccountID == -1)
                this.AccountID = clsRelAccountCategory.GetAccountIDByUserName(this.UserName);
            if (this.CategoryID == -1) 
                this.CategoryID = clsRelAccountCategory.GetCategoryIDByCategoryName(this.CategoryName);
             return DL_PasswordManagementSystem.clsRelAccountCategory.AddRelationship(this.AccountID,this.CategoryID);     
        }
        private bool _UpdateRelAccountCategory()
        {
            this.EditDate = DateTime.Now;
            return DL_PasswordManagementSystem.clsRelAccountCategory.UpdateRelationshipByAccountID(this.AccountID, this.CategoryID);
        }
        static public bool DeleteRelationship(int AccountID,int CategoryID)
        {

            return DL_PasswordManagementSystem.clsRelAccountCategory.DeleteRelationship(AccountID,CategoryID);
        }
        static public bool IsExist(int AccountID, int CategoryID)
        {
            return DL_PasswordManagementSystem.clsRelAccountCategory.IsExist(AccountID, CategoryID);
        }
        static public bool IsExist(int CategoryID)
        {
            return DL_PasswordManagementSystem.clsRelAccountCategory.IsExist(CategoryID);
        }
        static public DataTable GetListRelationship()
        {
            return DL_PasswordManagementSystem.clsRelAccountCategory.GetListRelationship();
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enRelAccountCategoryMode.AddNew:
                    if (_AddRelAccountCategory())
                    {
                        this.Mode = enRelAccountCategoryMode.Update;
                        return true;
                    }
                    break;
                case enRelAccountCategoryMode.Update:
                    return _UpdateRelAccountCategory();
            }
            return false;
        }
    }
}

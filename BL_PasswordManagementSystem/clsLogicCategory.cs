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
    public enum enCategoryMode { Update = 0, AddNew = 1 };

    public class clsLogicCategory
    {

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        
        public enCategoryMode Mode { get; set; }
        private clsLogicCategory(int CategoryID, string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            
            Mode = enCategoryMode.Update;

        }

        public clsLogicCategory()
        {
            this.CategoryID = -1;
            this.CategoryName = "";
            
            Mode = enCategoryMode.AddNew;
        }

        static public clsLogicCategory Find(int CategoryID)
        {
            string CategoryName = "";

            if(DL_PasswordManagementSystem.clsCategory.GetCategoryInfoByID(CategoryID , ref CategoryName))
            {
                return new clsLogicCategory(CategoryID, CategoryName);
            }
            return null;
        }
        static public clsLogicCategory Find(string CategoryName)
        {
            int CategoryID = -1;

            if (DL_PasswordManagementSystem.clsCategory.GetCategoryInfoByCategoryName(ref CategoryID, CategoryName))
            {
                return new clsLogicCategory(CategoryID, CategoryName);
            }
            return null;
        }

        private bool _AddCategory()
        {
            this.CategoryID = DL_PasswordManagementSystem.clsCategory.CreateCategory(this.CategoryID,this.CategoryName);
            return this.CategoryID != -1;
        }
        private bool _UpdateCategory()
        {
            return DL_PasswordManagementSystem.clsCategory.UpdateCategory(this.CategoryID, this.CategoryName);
        }
        static public bool DeleteCategory(int CategoryID)
        {
            return DL_PasswordManagementSystem.clsCategory.DeleteCategory(CategoryID);
        }
        static public bool IsExist(int CategoryID)
        {
            return DL_PasswordManagementSystem.clsCategory.IsExist(CategoryID);
        }
        static public bool IsExist(string CategoryName)
        {
            return DL_PasswordManagementSystem.clsCategory.IsExist(CategoryName);
        }
        static public DataTable GetListCategory()
        {
            return DL_PasswordManagementSystem.clsCategory.GetListCategories();
        }
        static public DataTable GetCategoriesByType(string CategoryType)
        {
            return DL_PasswordManagementSystem.clsCategory.GetCategoriesByType(CategoryType);
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enCategoryMode.AddNew:
                    if (_AddCategory())
                    {
                        this.Mode = enCategoryMode.Update;
                        return true;
                    }
                    break;
                case enCategoryMode.Update:
                    return _UpdateCategory();
            }
            return false;
        }
    }
}

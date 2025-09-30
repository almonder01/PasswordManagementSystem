using BL_PasswordManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_PasswordManagementSystem
{
    public partial class frm_EditRelationship : Form
    {
        string _IDType_CategoryOrService;
        int _accountID;
        int _CategoryIDOrServiceID;
        clsLogicRelAccountCategory _accountCategory;
        clsLogicRelAccountService _accountService;
        public frm_EditRelationship(int AccountID,int CategoryIDOrServiceID,string IDType_CategoryOrService)
        {
            InitializeComponent();
            _IDType_CategoryOrService = IDType_CategoryOrService;
            _CategoryIDOrServiceID = CategoryIDOrServiceID;
            _accountID = AccountID;
            _InitializeTypeOfClass();

        }
        private void _InitializeTypeOfClass()
        {
            if (_IDType_CategoryOrService == "Category")
            {
                if (clsLogicRelAccountCategory.IsExist(_CategoryIDOrServiceID))
                    _accountCategory = clsLogicRelAccountCategory.Find(_accountID);
                else
                {
                    MessageBox.Show("Please Add Correct Category ID");
                    this.Close();
                }
            }
            else if (_IDType_CategoryOrService == "Service")
            {
                if (clsLogicRelAccountService.IsExist(_CategoryIDOrServiceID))
                    _accountService = clsLogicRelAccountService.Find(_accountID);
                else
                {
                    MessageBox.Show("Please Add Correct Service ID ");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Add Correct Type \"Category\" or \"Service\"");
                this.Close();
            }
        }
      
        
        private bool _EditRelAccountCategory()
        {
            if (_accountCategory != null)
            {
                mtb_SetID.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (string.IsNullOrWhiteSpace(mtb_SetID.Text))
                {
                    MessageBox.Show("ID cannot be empty");
                    return false;
                }
                if (!int.TryParse(mtb_SetID.Text, out int NewRelCategoryID))
                {
                    MessageBox.Show("Invalid ID. Please enter numbers only without spaces or letters.");
                    return false;
                }
                if (NewRelCategoryID <= 0)
                {
                    MessageBox.Show("ID must be greater than zero");
                    return false;
                }

                if (clsLogicCategory.IsExist(NewRelCategoryID))
                {
                    _accountCategory.CategoryID = NewRelCategoryID;
                    if (_accountCategory.Save())
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Sorry there is an error to save relationship");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("ID number not found");
                    return false;
                }
            }
            MessageBox.Show("No relationship found");
            return false;
        }
        private bool _EditRelAccountService()
        {
            if (_accountService != null)
            {
                int NewRelServiceID = Convert.ToInt32(mtb_SetID.Text);
                if (clsLogicService.IsExist(NewRelServiceID))
                {
                    _accountService.ServiceID = NewRelServiceID;
                    if (_accountService.Save())
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Sorry there is an error to save relationship");
                        return false;
                    }
                } else
                {
                    MessageBox.Show("Invalid ID number");
                    return false;
                }
            }
            MessageBox.Show("No relationship found");
            return false;
        }
        private void frm_EditRelationship_Load(object sender, EventArgs e)
        {
            if(_accountService != null)
            {
                l_Username.Text = _accountService.UserName;
                l_SetServiceID.Text = "Set Service ID";
                this.Text = "Edit Relationship with Service";
            }else if (_accountCategory != null)
            {
                l_Username.Text = _accountCategory.UserName;
                l_SetServiceID.Text = "Set Category ID";
                this.Text = "Edit Relationship with Category";
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (_accountService != null)
            {
                if (!string.IsNullOrEmpty(mtb_SetID.Text))
                {
                    if (_EditRelAccountService())
                    {
                        MessageBox.Show("Edited Successfully");
                        this.Close();
                    }
                }           
            }
            else if (_accountCategory != null)
            {
                if (!string.IsNullOrEmpty(mtb_SetID.Text))
                {
                    if (_EditRelAccountCategory())
                    {
                        MessageBox.Show("Edited Successfully");
                        this.Close();
                    }
                }
            }
        }


    }
}

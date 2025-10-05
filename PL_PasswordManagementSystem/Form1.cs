using BL_PasswordManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_PasswordManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void _RefreshDisplayType()
        {
            string selectedType = cb_DisplayType.SelectedItem.ToString();
            switch (selectedType)
            {
                case "Accounts":
                    dgv_DisplayType.DataSource = clsLogicAccount.GetListAccounts();
                    //_HidingAndVisionPassword();
                    break;

                case "Services":
                    dgv_DisplayType.DataSource = clsLogicService.GetListService();
                    break;

                case "Categories":
                    dgv_DisplayType.DataSource = clsLogicCategory.GetListCategory();
                    break;

                case "Fully Accounts Information":
                    dgv_DisplayType.DataSource = clsLogicFullyAccountInformation.GetFullyListAccounts();
                    //_HidingAndVisionPassword();
                    break;

                case "Rel Accounts, Categories":
                    dgv_DisplayType.DataSource = clsLogicRelAccountCategory.GetListRelationship();
                    break;

                case "Rel Accounts, Services":
                    dgv_DisplayType.DataSource = clsLogicRelAccountService.GetListRelationship();
                    break;

                default:
                    dgv_DisplayType.DataSource = null;
                    break;
            }
        }

        private void _RefreshCategoryType()
        {
            if (cb_CategoryType == null)
                return;

            cb_CategoryType.Items.Clear();

            DataTable Categories = clsLogicCategory.GetListCategory();
            if (Categories == null || Categories.Rows.Count == 0)
                return;

            foreach (DataRow Row in Categories.Rows)
            {
                cb_CategoryType.Items.Add(Row["CategoryName"]);
            }

            if (cb_CategoryType.Items.Count > 0)
                cb_CategoryType.SelectedIndex = 0;
        }
        private void _RefreshServiceType()
        {
            if (cb_ServiceType == null)
                return;

            cb_ServiceType.Items.Clear();

            DataTable Services = clsLogicService.GetListService();
            if (Services == null || Services.Rows.Count == 0)
                return;

            foreach (DataRow row in Services.Rows)
            {
                cb_ServiceType.Items.Add(row["ServiceName"]);
            }
            if (cb_ServiceType.Items.Count > 0)
                cb_ServiceType.SelectedIndex = 0;
        }
      


        private void _OpenRegisterForm()
        {
            frm_RegisterAuthentication frm_Register = new frm_RegisterAuthentication();
            frm_Register.ShowDialog();
            if (frm_Register._DidRegisteredSuccessfully)
            {
                dgv_DisplayCategoryType.Visible = false;
                dgv_DisplayServiceType.Visible = false;
                dgv_DisplayType.Visible = true;

                _RefreshCategoryType();
                _RefreshServiceType();
                if (cb_DisplayType.Items.Count > 0)
                    cb_DisplayType.SelectedIndex = 0;
            }
            else
            {
                this.Close();
            }
        }
        private void _OpenLoginForm()
        {
            frm_LoginAuthentication frm_Login = new frm_LoginAuthentication();
            frm_Login.ShowDialog();

            if (frm_Login._DidLoggedSuccessfully)
            {
                dgv_DisplayCategoryType.Visible = false;
                dgv_DisplayServiceType.Visible = false;
                dgv_DisplayType.Visible = true;

                _RefreshCategoryType();
                _RefreshServiceType();
                if (cb_DisplayType.Items.Count > 0)
                    cb_DisplayType.SelectedIndex = 0;
            }
            else
            {
                this.Close();
            }
        }

        //To Next Version

        //private void _AddPasswordToggleButton(DataGridView dgv, string columnName)
        //{
        //    if (dgv.Columns.Contains(columnName))
        //    {
        //        if (!dgv.Columns.Contains("TogglePassword"))
        //        {
        //            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
        //            imgCol.Name = "TogglePassword";
        //            imgCol.HeaderText = "";
        //            imgCol.Image = Properties.Resources.hiding;
        //            imgCol.Width = 30;
        //            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
        //            dgv.Columns.Add(imgCol);
        //        }
        //    }
        //}

        //private void _HidingAndVisionPassword()
        //{
        //    if(dgv_DisplayType != null && dgv_DisplayType.RowCount > 0)
        //    {
        //        if (dgv_DisplayType.Columns.Contains("Password"))
        //        {
        //            _AddPasswordToggleButton(dgv_DisplayType, "Password");
        //        }
        //    }
        //}


        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable data = clsLogicAccount.GetListAccounts();
            if (data == null || data.Rows.Count == 0)
            {
                _OpenRegisterForm();
                DataTable dataAfterRegister = clsLogicAccount.GetListAccounts();
                if (dataAfterRegister != null && dataAfterRegister.Rows.Count > 0)
                {
                    DataRow firstRow = dataAfterRegister.Rows[0];
                    l_UserName.Text = firstRow["Username"].ToString(); ;
                }
            }
            else
            {
                _OpenLoginForm();
                DataTable dataAfterRegister = clsLogicAccount.GetListAccounts();
                if (dataAfterRegister != null && dataAfterRegister.Rows.Count > 0)
                {
                    DataRow firstRow = dataAfterRegister.Rows[0];
                    l_UserName.Text = firstRow["Username"].ToString();
                }
            }
        }

        private void cb_DisplayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_DisplayCategoryType.Visible = false;
            dgv_DisplayServiceType.Visible = false;
            dgv_DisplayType.Visible = true;
            _RefreshDisplayType();
        }

        private void cb_CategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_DisplayCategoryType.Visible = true;
            dgv_DisplayServiceType.Visible = false;
            dgv_DisplayType.Visible = false;

            if (cb_CategoryType.SelectedItem != null)
            {
                dgv_DisplayCategoryType.DataSource = null;
                dgv_DisplayCategoryType.DataSource = clsLogicCategory.GetCategoriesByType(cb_CategoryType.SelectedItem.ToString());
            }
        }

        private void cb_ServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_DisplayCategoryType.Visible = false;
            dgv_DisplayServiceType.Visible = true;
            dgv_DisplayType.Visible = false;
            if(cb_ServiceType.SelectedItem != null)
            {
                dgv_DisplayServiceType.DataSource = null;
                dgv_DisplayServiceType.DataSource = clsLogicService.GetServiceByType(cb_ServiceType.SelectedItem.ToString());
            }
        }



        private void _SelectedRowTypeRelAccountCategoryForDelete()
        {
            int AccountID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["AccountID"].Value);
            int CategoryID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["CategoryID"].Value);

            if (!clsLogicRelAccountCategory.IsExist(CategoryID))
            {
                MessageBox.Show($"This Account with ID:: \"{AccountID}\" has no Relationship to Deleted.");
                return;
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show($"Relationship Between Category ID = {CategoryID} and Account ID = {AccountID}, will deleting. Are you sure", "Delete Relationship", MessageBoxButtons.OKCancel))
                {
                    if (clsLogicRelAccountCategory.DeleteRelationship(AccountID, CategoryID))
                        MessageBox.Show("Deleted Successfully");
                    else
                        MessageBox.Show("Deletion filed");
                    _Refresh();
                }
                else
                {
                    MessageBox.Show("Deletion is canceled");
                }
            }
        }
        private void _SelectedRowTypeRelAccountServiceForDelete()
        {
            int AccountID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["AccountID"].Value);
            int ServiceID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["ServiceID"].Value);

            if (!clsLogicRelAccountCategory.IsExist(ServiceID))
            {
                MessageBox.Show($"This Account with ID:: \"{AccountID}\" has no Relationship to Deleted.");
                return;
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show($"Relationship Between Service ID = {ServiceID} and Account ID = {AccountID}, will deleting. Are you sure", "Delete Relationship", MessageBoxButtons.OKCancel))
                {
                    if (clsLogicRelAccountService.DeleteRelationship(AccountID, ServiceID))
                        MessageBox.Show("Deleted Successfully");
                    else
                        MessageBox.Show("Deletion filed");
                    _Refresh();
                }
                else
                {
                    MessageBox.Show("Deletion is canceled");
                }
            }
        }
        private void _SelectedRowTypeCategoryForDelete()
        {
            string CategoryName = dgv_DisplayType.CurrentRow.Cells["CategoryName"].Value.ToString();
            int CategoryID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["CategoryID"].Value);

            if (clsLogicRelAccountCategory.IsExist(CategoryID))
            {
                MessageBox.Show($"This category: \"{CategoryName}\" has Relationship with account(s) pleese go to Relationship Table and delete the exist Relationship then you can delete this category.");
                return;
            }
            if (clsLogicCategory.IsExist(CategoryID))
            {
                if (DialogResult.OK == MessageBox.Show($"Category with ID = {CategoryID} will deleting. Are you sure", "Delete Category", MessageBoxButtons.OKCancel))
                {
                    if(clsLogicCategory.DeleteCategory(CategoryID))
                        MessageBox.Show("Deleted Successfully");
                    else
                        MessageBox.Show("Deletion filed");
                    _Refresh();
                }
                else
                {
                    MessageBox.Show("Deletion is canceled");
                }
            }    
        }
        private void _SelectedRowTypeServiceForDelete()
        {
            string ServiceName = dgv_DisplayType.CurrentRow.Cells["ServiceName"].Value.ToString();
            int ServiceID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["ServiceID"].Value);

            if (clsLogicRelAccountService.IsExist(ServiceID))
            {
                MessageBox.Show($"This Service: \"{ServiceName}\" has Relationship with account(s) pleese go to Relationship Table and delete the exist Relationship then you can delete this Service.");
                return;
            }
            if (clsLogicService.IsExist(ServiceID))
            {
                if (DialogResult.OK == MessageBox.Show($"Service with ID = {ServiceID} will deleting. Are you sure", "Delete Service", MessageBoxButtons.OKCancel))
                {
                    if(clsLogicService.DeleteService(ServiceID))
                        MessageBox.Show("Deleted Successfully");
                    else
                        MessageBox.Show("Deletion filed");
                    _Refresh();
                }
                else
                {
                    MessageBox.Show("Deletion is canceled");
                }
            }
        }
        private void _SelectedRowTypeAccountForDelete()
        {
            string Username = dgv_DisplayType.CurrentRow.Cells["Username"].Value.ToString();
            int AccountID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["AccountID"].Value);
            if (DialogResult.OK == MessageBox.Show("Are you sure want to delete this account: " + Username,"Delete Account", MessageBoxButtons.OKCancel))
            {
                if (clsLogicAccount.DeleteAccount(AccountID))
                    MessageBox.Show("Deleted Successfully");
                else
                    MessageBox.Show("Deletion filed");
                _Refresh();
            }
            else
                MessageBox.Show($"Deletion Canceled");
            
        }
       
        
         private void _DeleteAccount()
        {
            if (dgv_DisplayType.Columns.Contains("Password") && dgv_DisplayType.CurrentRow != null)
            {
                _SelectedRowTypeAccountForDelete();
            }else if (dgv_DisplayType.Columns.Contains("CategoryName") &&
                      dgv_DisplayType.Columns.Contains("Username") &&
                      dgv_DisplayType.CurrentRow != null)
            {
                _SelectedRowTypeRelAccountCategoryForDelete();
            }
            else if (dgv_DisplayType.Columns.Contains("ServiceName") &&
                      dgv_DisplayType.Columns.Contains("Username") &&
                      dgv_DisplayType.CurrentRow != null)
            {
                _SelectedRowTypeRelAccountServiceForDelete();
            }
            else if (dgv_DisplayType.Columns.Contains("CategoryName") &&
                    ! dgv_DisplayType.Columns.Contains("Username") && 
                     dgv_DisplayType.CurrentRow != null)
            {
                _SelectedRowTypeCategoryForDelete();
            }
            else if (dgv_DisplayType.Columns.Contains("ServiceName") &&
                    ! dgv_DisplayType.Columns.Contains("Username") &&
                     dgv_DisplayType.CurrentRow != null)
            {
                _SelectedRowTypeServiceForDelete();
            }


        }
        
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeleteAccount();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            frm_AddEditPassword addEditPassword = new frm_AddEditPassword(-1);

            addEditPassword.ShowDialog();
            _Refresh();
        }
        private void _Refresh()
        {
            _RefreshCategoryType();
            _RefreshServiceType();

            dgv_DisplayCategoryType.Visible = false;
            dgv_DisplayServiceType.Visible = false;
            dgv_DisplayType.Visible = true;      
            _RefreshDisplayType();


        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _SelectedRowTypeRelAccountCategoryForEdit()
        {
            int AccountID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["AccountID"].Value);
            int CategoryID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["CategoryID"].Value);

            if (!clsLogicRelAccountCategory.IsExist(CategoryID))
            {
                MessageBox.Show($"This Account with ID:: \"{AccountID}\" has no Relationship to Deleted.");
                return;
            }
            else
            {
                clsLogicRelAccountCategory accountService = clsLogicRelAccountCategory.Find(AccountID);
                if (accountService != null)
                {
                    frm_EditRelationship relationship = new frm_EditRelationship(AccountID, CategoryID, "Category");
                    relationship.ShowDialog();
                    _Refresh();
                }
            }
        }
        private void _SelectedRowTypeRelAccountServiceForEdit()
        {
            int AccountID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["AccountID"].Value);
            int ServiceID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["ServiceID"].Value);

            if (!clsLogicRelAccountService.IsExist(ServiceID))
            {
                MessageBox.Show($"This Account with ID:: \"{AccountID}\" has no Relationship to Deleted.");
                return;
            }
            else
            {
                clsLogicRelAccountService accountService = clsLogicRelAccountService.Find(AccountID);
                if(accountService != null)
                {
                    frm_EditRelationship relationship = new frm_EditRelationship(AccountID,ServiceID,"Service");
                    relationship.ShowDialog();
                    _Refresh();
                }
            }
        }
        private void _SelectedRowTypeCategoryForEdit()
        {
            clsLogicCategory category = clsLogicCategory.Find(dgv_DisplayType.CurrentRow.Cells["CategoryName"].Value.ToString());
            frm_EditCategoryOrService editCategory = new frm_EditCategoryOrService(category.CategoryID, "Category");
            editCategory.ShowDialog();
            _Refresh();
        }
        private void _SelectedRowTypeServiceForEdit()
        {
            clsLogicService Service = clsLogicService.Find(dgv_DisplayType.CurrentRow.Cells["ServiceName"].Value.ToString());
            frm_EditCategoryOrService editService = new frm_EditCategoryOrService(Service.ServiceID, "Service");
            editService.ShowDialog();
            _Refresh();
        }
        private void _SelectedRowTypeAccountForEdit()
        {
            int accountID = Convert.ToInt32(dgv_DisplayType.CurrentRow.Cells["AccountID"].Value.ToString());
            clsLogicAccount account = clsLogicAccount.Find(accountID);
            frm_AddEditPassword editAccount = new frm_AddEditPassword(account.AccountID);
            editAccount.ShowDialog();
            _Refresh();
        }

        private void _EditAccount()
        {
            if(dgv_DisplayType.CurrentRow != null && dgv_DisplayType.CurrentRow.Index >= 0)
            {
                if (dgv_DisplayType.Columns.Contains("Password") && dgv_DisplayType.CurrentRow != null)
                {
                    _SelectedRowTypeAccountForEdit();
                }
                else if (dgv_DisplayType.Columns.Contains("CategoryName") &&
                          dgv_DisplayType.Columns.Contains("Username"))
                {
                    _SelectedRowTypeRelAccountCategoryForEdit();
                }
                else if (dgv_DisplayType.Columns.Contains("ServiceName") &&
                          dgv_DisplayType.Columns.Contains("Username"))
                {
                    _SelectedRowTypeRelAccountServiceForEdit();
                }
                else if (dgv_DisplayType.Columns.Contains("CategoryName") &&
                        !dgv_DisplayType.Columns.Contains("Username"))
                {
                    _SelectedRowTypeCategoryForEdit();
                }
                else if (dgv_DisplayType.Columns.Contains("ServiceName") &&
                        !dgv_DisplayType.Columns.Contains("Username"))
                {
                    _SelectedRowTypeServiceForEdit();
                }
            }
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
                _EditAccount();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Are you sure want to exit?", "Close program", MessageBoxButtons.YesNo))
            {
                this.Close();
            }
        }

        private void dgv_DisplayType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        bool _showAllPasswords = false;
        private void dgv_DisplayType_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_DisplayType.Columns[e.ColumnIndex].Name == "Password" && e.Value != null)
            {
                if (_showAllPasswords)
                {
                    
                    e.Value = e.Value.ToString();
                }
                else
                {
                   
                    e.Value = new string('●', e.Value.ToString().Length);
                }

                e.FormattingApplied = true;
            }
        }

        private void dgv_DisplayType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void _ShowPasswords()
        {
            _showAllPasswords = !_showAllPasswords;

            pb_ShowAllPasswords.Image = _showAllPasswords
                ? Properties.Resources.vision
                : Properties.Resources.hiding;

            dgv_DisplayType.Refresh();
        }
        private void pb_ShowAllPasswords_Click(object sender, EventArgs e)
        {
            if (dgv_DisplayType.Visible
                 && dgv_DisplayType.Columns.Contains("Password")
                 && dgv_DisplayType.RowCount > 0)
            {
                _ShowPasswords();
            }
        }
    }
}

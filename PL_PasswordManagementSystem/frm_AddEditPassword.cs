using BL_PasswordManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_PasswordManagementSystem
{
    public partial class frm_AddEditPassword : Form
    {
        private int _AccountID = -1;
        clsLogicAccount _account; 
        public frm_AddEditPassword(int AccountID)
        {
            InitializeComponent();
            this._AccountID = AccountID;
            if(_AccountID != -1)
                _account = clsLogicAccount.Find(_AccountID);
            else
                _account = new clsLogicAccount();
        }

        private void _RefreshCategoryType()
        {

         if (cb_Categories == null)
             return;

         cb_Categories.Items.Clear();

         DataTable Categories = clsLogicCategory.GetListCategory();
         if (Categories == null || Categories.Rows.Count == 0)
             return;

         foreach (DataRow Row in Categories.Rows)
         {
             cb_Categories.Items.Add(Row["CategoryName"]);
         }
         clsLogicRelAccountCategory relAccountCategory = clsLogicRelAccountCategory.Find(_AccountID);
         if (relAccountCategory != null && cb_Categories.Items.Count > 0)
         {
             if (cb_Categories.Items.Contains(relAccountCategory.CategoryName))
                 cb_Categories.SelectedItem = relAccountCategory.CategoryName;
         }
         else if(cb_Categories.Items.Count > 0)
         {
             cb_Categories.SelectedItem = 0;
         }
        }
        private void _RefreshServiceType()
        {
         if (lb_AllServices == null)
             return;

         lb_AllServices.Items.Clear();

         DataTable Services = clsLogicService.GetListService();
         if (Services == null || Services.Rows.Count == 0)
             return;

         lb_AllServices.DisplayMember = "ServiceName";
         foreach (DataRow row in Services.Rows)
         {
             lb_AllServices.Items.Add(new clsLogicService { ServiceID = Convert.ToInt32(row["ServiceID"]), ServiceName = row["ServiceName"].ToString(), Url = row["Url"].ToString() });
         }
        }
        private int _AddNewCategory()
        {
            clsLogicCategory category = new clsLogicCategory();
            category.CategoryName = tb_AddCategory.Text;
            if (category.Save())
            {
                _RefreshCategoryType();
                if (cb_Categories.Items.Contains(tb_AddCategory.Text))
                    cb_Categories.SelectedItem = tb_AddCategory.Text;
                return category.CategoryID;
            } else
            {
                return -1;
            }
            
        }
        private bool _AddNewRelationshipAccountCategory(int AccountID, int CategoryID)
        {
            clsLogicRelAccountCategory relAccountCategory = new clsLogicRelAccountCategory();
            relAccountCategory.AccountID = AccountID;
            relAccountCategory.CategoryID = CategoryID;
            cb_Categories.SelectedItem = relAccountCategory.CategoryName;
            if (relAccountCategory.Save())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void __AddNewRelationshipAccountServices(int ServiceID, int AccountID)
        {
            clsLogicRelAccountService relAccountService = new clsLogicRelAccountService();
            relAccountService.ServiceID = ServiceID;
            relAccountService.AccountID = AccountID;
            if (relAccountService.Save())
            {

            } else
            {

            }
        }
       
        private void _AddNewServices(ListBox listBox, int accountID)
        {

            if (listBox.Items.Count == 0)
                return;
            foreach (var item in listBox.Items)
            {
                clsLogicService service = item as clsLogicService;
                if (service != null)
                {
                    if (!clsLogicService.IsExist(service.ServiceName))
                    {

                        if (service.Save())
                        {
                            __AddNewRelationshipAccountServices(service.ServiceID, accountID);
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        clsLogicService ExistService = clsLogicService.Find(service.ServiceName);
                        if (!clsLogicRelAccountService.IsExist(accountID, ExistService.ServiceID))
                        {
                            __AddNewRelationshipAccountServices(ExistService.ServiceID, accountID);
                        }
                    }

                }
            }
        }
        private void _AddListBoxService()
        {
            lb_AccountServices.DisplayMember = "ServiceName";

            string newServiceName = tb_AddWebsiteName.Text;
            string newUrl = tb_AddWebsiteUrl.Text;

            foreach (clsLogicService item in lb_AccountServices.Items)
            {
                if(item.ServiceName.Equals(newServiceName, StringComparison.OrdinalIgnoreCase)
                        && item.Url.Equals(newUrl, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
 
            }
            lb_AccountServices.Items.Add( new clsLogicService {ServiceName =  tb_AddWebsiteName.Text , Url = tb_AddWebsiteUrl.Text });
        }
        private void _FillLastListBoxService()
        {
            DataTable Relationships  = clsLogicRelAccountService.GetServicesByAccountID(_AccountID);
            lb_AccountServices.DisplayMember = "ServiceName";
            if(Relationships != null) 
            {
                foreach (DataRow relationship in Relationships.Rows)
                {
                    lb_AccountServices.Items.Add(new clsLogicService { ServiceID = Convert.ToInt32(relationship["ServiceID"]), Url = relationship["Url"].ToString(), ServiceName = relationship["ServiceName"].ToString() });
                }
            }
            
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        private int _AddNewAccount()
        {
            if(!string.IsNullOrEmpty(tb_Username.Text) && !string.IsNullOrEmpty(tb_Password.Text) &&
                !string.IsNullOrEmpty(tb_Email.Text))
            {
                if (!IsValidEmail(tb_Email.Text)) {
                    MessageBox.Show("Invalid email. please write correct email");
                    return -1;
                }
                _account.UserName = tb_Username.Text;
                _account.Email = tb_Email.Text;
                _account.Password = tb_Password.Text;
                _account.Notes = rtb_Notes.Text;
                if (_account.Save())
                {
                    return _account.AccountID;
                }
                else
                {
                    MessageBox.Show("Sorry there is an error to save relationship between category and the current account");
                    return -1;
                }
            }
            MessageBox.Show("Username, password or email is empty!, please fill up before saving. or there is an error.");
            return -1;

        }
       
        
        private bool _IsEditAccount()
        {
            
            if(_account != null)
            {
                if (!string.IsNullOrEmpty(tb_Username.Text) && !string.IsNullOrEmpty(tb_Password.Text) &&
                !string.IsNullOrEmpty(tb_Email.Text))
                {
                    if (!IsValidEmail(tb_Email.Text))
                    {
                        MessageBox.Show("Invalid email. please write correct email");
                        return false;
                    }
                    _account.UserName = tb_Username.Text;
                    _account.Email = tb_Email.Text;
                    _account.Password = tb_Password.Text;
                    _account.Notes = rtb_Notes.Text;
                    if (_account.Save())
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Sorry there is an error to save relationship between category and the current account");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Username, password or email is empty!, please fill up before saving. or there is an error.");
                    return false;
                }
            }
            return false;
        }

        private void _EditRelationshipAccountCategory(int AccountID, int CategoryID)
        {
            clsLogicRelAccountCategory accountCategory = clsLogicRelAccountCategory.Find(AccountID);

            if(accountCategory != null)
            {
                accountCategory.AccountID = AccountID;
                accountCategory.CategoryID = CategoryID;
                if (accountCategory.Save())
                {

                }
                else
                {
                    MessageBox.Show("Sorry there is an error to save relationship between category and the current account");
                }
            }
            else
            {
                _AddNewRelationshipAccountCategory(AccountID, CategoryID);
            }
            
        }
        private void _EditGetLastParameters()
        {
            tb_Username.Text = _account.UserName;
            tb_Password.Text = _account.Password;
            tb_Email.Text = _account.Email;
            rtb_Notes.Text = _account.Notes;
            mtb_CreationDate.Text = _account.CreationDate.ToString("yyyy-MM-dd HH:mm:ss");
            
            mtb_EditDate.Text = _account.EditDate.ToString("yyyy-MM-dd HH:mm:ss");

            if (cb_Categories.SelectedItem != null)
            {
                tb_AddCategory.Text = cb_Categories.SelectedItem.ToString();
            }

            _FillLastListBoxService();
        }
        private void frm_AddEditPassword_Load(object sender, EventArgs e)
        {
            
            if (_AccountID != -1)
            {
                l_AccountID.Text = _AccountID.ToString();
                this.Text = "Edit Account";
                _EditGetLastParameters();
            }
               
            else
            {
                l_AccountID.Text = "---";
                this.Text = "Add Account";
           
            }
            _RefreshServiceType();
            _RefreshCategoryType();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cb_Categories.SelectedItem == null)
            {
                if (cb_Categories.Items.Count > 0)
                {
                    cb_Categories.SelectedIndex = 0;
                }
                else
                {
                    tb_AddCategory.Text = "Personal";
                    _AddNewCategory();
                    cb_Categories.SelectedIndex = 0;
                }
            }
            clsLogicCategory category = clsLogicCategory.Find(cb_Categories.SelectedItem.ToString());
            if ( _AccountID == -1)
            {
                int accountID = _AddNewAccount();
                if(accountID != -1)
                {
                    _AddNewServices(lb_AccountServices, accountID);
                    _AddNewRelationshipAccountCategory(accountID, category.CategoryID);
                    MessageBox.Show("Saved Successfully");
                    this.Close();
                }
                else
                {

                }
                
            }
            else
            {
                if (_IsEditAccount())
                {
                    _EditRelationshipAccountCategory(_AccountID, category.CategoryID);
                    _AddNewServices(lb_AccountServices, _AccountID);
                    MessageBox.Show("Saved Successfully");
                    this.Close();
                }
                else
                {

                }

            }
           
        }

        private void pb_AddWebsite_Click(object sender, EventArgs e)
        {

                if (!string.IsNullOrWhiteSpace(tb_AddWebsiteName.Text) && !string.IsNullOrWhiteSpace(tb_AddWebsiteUrl.Text))
                    _AddListBoxService();

          
        }

        private void pb_AddCategory_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tb_AddCategory.Text))
               _AddNewCategory();
        }

        private void lb_AllServices_DoubleClick(object sender, EventArgs e)
        {
            if(lb_AllServices.SelectedItems != null)
            {
                clsLogicService service = (clsLogicService)lb_AllServices.SelectedItem;

                tb_AddWebsiteName.Text = service.ServiceName;
                tb_AddWebsiteUrl.Text = service.Url;
                _AddListBoxService();
            }
        }

        private void lb_AllServices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lb_AccountServices_DoubleClick(object sender, EventArgs e)
        {
            if (lb_AccountServices.SelectedItem != null)
            {
                clsLogicService service = (clsLogicService)lb_AccountServices.SelectedItem;

                if (clsLogicRelAccountService.IsExist(service.ServiceID))
                    clsLogicRelAccountService.DeleteRelationship(_AccountID, service.ServiceID);
                lb_AccountServices.Items.Remove(service);
            }
        }

        private void cb_Categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Categories.SelectedItem != null)
            {
                tb_AddCategory.Text = cb_Categories.SelectedItem.ToString();
            }
        }

        private void tb_AddCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lb_AccountServices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pb_ShowPassword_Click(object sender, EventArgs e)
        {
            if (tb_Password.UseSystemPasswordChar)
            {
                tb_Password.UseSystemPasswordChar = false;
                pb_ShowPassword.Image = Properties.Resources.vision;
            }
            else
            {
                tb_Password.UseSystemPasswordChar = true;
                pb_ShowPassword.Image = Properties.Resources.hiding;
            }
        }
    }
}

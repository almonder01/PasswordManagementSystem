using BL_PasswordManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_PasswordManagementSystem
{
    public partial class frm_LoginAuthentication : Form
    {
        public bool _DidLoggedSuccessfully { get; private set; }

        public frm_LoginAuthentication()
        {
            InitializeComponent();
        }
        DataTable _dataTable = clsLogicAccount.GetListAccounts();

        private string _GetRandomly6Digits()
        {
            Random random = new Random();
            int code = random.Next(100000, 999999);
            return code.ToString();
        }
        string _CodeDigits = "";
        bool isForgetPassword = false;
        private bool _CheckExistAccount()
        {
            if(_dataTable != null)
            {
                foreach(DataRow dataRow in _dataTable.Rows)
                {
                    if (dataRow["Password"].ToString() == tb_Password.Text && dataRow["Username"].ToString() == tb_Username.Text)
                    {
                        MessageBox.Show("Login Successfully");
                        return true;
                    }
                }
                MessageBox.Show("Username or password not true");
                return false;
            }
            else
            {
                MessageBox.Show("No data in this system please Register first");
                return false;
            }
        }
      
        private void b_Login_Click(object sender, EventArgs e)
        {
        
            if (!isForgetPassword)
            {
                if (string.IsNullOrEmpty(tb_Username.Text.Trim()) || string.IsNullOrEmpty(tb_Password.Text.Trim()))
                {
                    MessageBox.Show("User name or password is empty.");
                    return;
                }
                if (_CheckExistAccount())
                {
                    _DidLoggedSuccessfully = true;
                    this.Close();
                }
                else
                {
                    _DidLoggedSuccessfully = false;
                }
            }
            else if (isForgetPassword)
            {
                if (_CheckExis6Digits())
                {
                    _DidLoggedSuccessfully = true;
                    this.Close();
                }
                else
                {
                    _DidLoggedSuccessfully = false;
                }
            }
            
        }

        
        private bool _CheckExis6Digits()
        {
            if(_CodeDigits == tb_Password.Text.ToString())
            {
                MessageBox.Show("Login Successfully");
                return true;
            }
            MessageBox.Show("Login failed. 6 digits were Not matching");
            return false;
        }
        private void ll_ForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            isForgetPassword = !isForgetPassword;
            if (isForgetPassword)
            {
                l_Password.Text = "6 Digits";
                _CodeDigits = _GetRandomly6Digits();
                MessageBox.Show($"The Code: {_CodeDigits}");
                ll_ForgetPassword.Text = "Remembered?";
                tt_Info.SetToolTip(ll_ForgetPassword, "Just if you want to return to add your password");
                tb_Password.Text = _CodeDigits.ToString();
            }
            else
            {
                l_Password.Text = "Password";
                ll_ForgetPassword.Text = "Forget password";
                tb_Password.Text = string.Empty;

            }
        }

        private void frm_LoginAuthentication_Load(object sender, EventArgs e)
        {
            l_Password.Text = "Password";
            isForgetPassword = false;
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

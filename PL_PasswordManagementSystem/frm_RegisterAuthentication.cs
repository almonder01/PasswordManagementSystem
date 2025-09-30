using BL_PasswordManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_PasswordManagementSystem
{
    public partial class frm_RegisterAuthentication : Form
    {
        public bool _DidRegisteredSuccessfully { get; private set; }
        public frm_RegisterAuthentication()
        {
            InitializeComponent();
        }
        clsLogicAccount _account = new clsLogicAccount();
        int _accountID = -1;

        private int _AddNewAccount()
        {
            if(!string.IsNullOrEmpty(tb_MasterUserName.Text) || !string.IsNullOrEmpty(tb_HelperEmail.Text) || !string.IsNullOrEmpty(tb_MasterPassword.Text))
            {
                _account.UserName = tb_MasterUserName.Text;
                _account.Email = tb_HelperEmail.Text;
                _account.Notes = "This is Master Account, you can login by it, and in this version you can login by any account you added in the system";
                if (tb_MasterPassword.Text == tb_RePassword.Text)
                {
                    _account.Password = tb_MasterPassword.Text;
                }
                else
                {
                    MessageBox.Show("Passwords is not matching");
                    return -1;
                }

                if (_account.Save())
                {
                    MessageBox.Show("Account is Saved successfully");
                    return _account.AccountID;
                }
                else
                {
                    MessageBox.Show("\"Please fill in the fields");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("Saving failed");
                return -1;
            }
 
        }

        private void frm_RegisterAuthentication_Load(object sender, EventArgs e)
        {

        }


        private void btn_Register_Click(object sender, EventArgs e)
        {
            if(_AddNewAccount() == -1)
            {
                _DidRegisteredSuccessfully = false;
            }
            else
            {
                _DidRegisteredSuccessfully = true;
                this.Close();
            }

        }

        private void pb_ShowPassword_Click(object sender, EventArgs e)
        {
            if (tb_MasterPassword.UseSystemPasswordChar)
            {
                tb_MasterPassword.UseSystemPasswordChar = false;
                pb_ShowPassword.Image = Properties.Resources.vision;
            }
            else
            {
                tb_MasterPassword.UseSystemPasswordChar = true;
                pb_ShowPassword.Image = Properties.Resources.hiding;
            }
        }

        private void pb_ShowRePassword_Click(object sender, EventArgs e)
        {
            if (tb_RePassword.UseSystemPasswordChar)
            {
                tb_RePassword.UseSystemPasswordChar = false;
                pb_ShowRePassword.Image = Properties.Resources.vision;
            }
            else
            {
                tb_RePassword.UseSystemPasswordChar = true;
                pb_ShowRePassword.Image = Properties.Resources.hiding;
            }
        }
    }
}

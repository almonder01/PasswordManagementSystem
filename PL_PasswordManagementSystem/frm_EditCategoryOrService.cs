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
    public partial class frm_EditCategoryOrService : Form
    {
        int _ID = -1;
        string _IDType_CategoryOrService = "";
        clsLogicCategory _category;
        clsLogicService _service;
        public frm_EditCategoryOrService(int ID, string IDType_CategoryOrService)
        {
            InitializeComponent();

            _ID = ID;
            _IDType_CategoryOrService = IDType_CategoryOrService;
            _InitializeTypeOfClass();

        }
        private void _InitializeTypeOfClass()
        {
            if (_IDType_CategoryOrService == "Category")
            {
                if (clsLogicCategory.IsExist(_ID))
                    _category = clsLogicCategory.Find(_ID);
                else
                {
                    MessageBox.Show("Please Add Correct ID");
                    this.Close();
                }
            }
            else if (_IDType_CategoryOrService == "Service")
            {
                if (clsLogicService.IsExist(_ID))
                    _service = clsLogicService.Find(_ID);
                else
                {
                    MessageBox.Show("Please Add Correct ID ");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Add Correct Type \"Category\" or \"Service\"");
                this.Close();
            }
        }

        private void _EditCategory()
        {
            _category.CategoryName = tb_Name.Text;
            if (_category.Save())
            {
                MessageBox.Show("Edited successfully");
            }
            else
            {
           
            }

        }
        private void _EditService()
        {
             _service.Url = tb_ServiceUrl.Text;
            _service.ServiceName = tb_Name.Text;
             if (_service.Save())
             {
                MessageBox.Show("Edited successfully");
            }
            else
             {

             }
          
        }
        private void _InitializeCategory()
        {
            l_Name.Text = "Category Name";
            l_ServiceUrl.Visible = false;
            tb_ServiceUrl.Visible = false;
            tb_Name.Text = _category.CategoryName;
        }
        private void _InitializeService()
        {
            l_Name.Text = "Service Name";
            l_ServiceUrl.Visible = true;
            tb_ServiceUrl.Visible = true;
            tb_Name.Text = _service.ServiceName;
            tb_ServiceUrl.Text = _service.Url;
        }
        private void frm_EditCategoryOrService_Load(object sender, EventArgs e)
        {
            if(_category != null)
            {
                _InitializeCategory();
            }else if(_service != null)
            {
                _InitializeService();
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (_category != null)
            {
                _EditCategory();
                this.Close();
            }
            else if (_service != null)
            {
                _EditService();
                this.Close();
            }
        }


    }
}

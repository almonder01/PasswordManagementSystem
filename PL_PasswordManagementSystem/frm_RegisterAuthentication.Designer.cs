namespace PL_PasswordManagementSystem
{
    partial class frm_RegisterAuthentication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Register = new System.Windows.Forms.Button();
            this.tb_MasterPassword = new System.Windows.Forms.TextBox();
            this.tb_MasterUserName = new System.Windows.Forms.TextBox();
            this.l_LoginAuthentication = new System.Windows.Forms.Label();
            this.l_Password = new System.Windows.Forms.Label();
            this.l_MasterUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_RePassword = new System.Windows.Forms.TextBox();
            this.l_HelperEmail = new System.Windows.Forms.Label();
            this.tb_HelperEmail = new System.Windows.Forms.TextBox();
            this.pb_ShowRePassword = new System.Windows.Forms.PictureBox();
            this.pb_ShowPassword = new System.Windows.Forms.PictureBox();
            this.pb_folderPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShowRePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShowPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_folderPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Register
            // 
            this.btn_Register.AutoSize = true;
            this.btn_Register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(23)))), ((int)(((byte)(230)))));
            this.btn_Register.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(3)))), ((int)(((byte)(210)))));
            this.btn_Register.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(3)))), ((int)(((byte)(210)))));
            this.btn_Register.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(43)))), ((int)(((byte)(250)))));
            this.btn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Register.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Register.ForeColor = System.Drawing.Color.White;
            this.btn_Register.Location = new System.Drawing.Point(251, 318);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(128, 44);
            this.btn_Register.TabIndex = 4;
            this.btn_Register.Text = "Register";
            this.btn_Register.UseVisualStyleBackColor = false;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // tb_MasterPassword
            // 
            this.tb_MasterPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tb_MasterPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_MasterPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MasterPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_MasterPassword.Location = new System.Drawing.Point(256, 138);
            this.tb_MasterPassword.Name = "tb_MasterPassword";
            this.tb_MasterPassword.Size = new System.Drawing.Size(344, 34);
            this.tb_MasterPassword.TabIndex = 1;
            this.tb_MasterPassword.UseSystemPasswordChar = true;
            // 
            // tb_MasterUserName
            // 
            this.tb_MasterUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tb_MasterUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_MasterUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MasterUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_MasterUserName.Location = new System.Drawing.Point(256, 86);
            this.tb_MasterUserName.Name = "tb_MasterUserName";
            this.tb_MasterUserName.Size = new System.Drawing.Size(344, 34);
            this.tb_MasterUserName.TabIndex = 0;
            // 
            // l_LoginAuthentication
            // 
            this.l_LoginAuthentication.AutoSize = true;
            this.l_LoginAuthentication.BackColor = System.Drawing.Color.Transparent;
            this.l_LoginAuthentication.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_LoginAuthentication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.l_LoginAuthentication.Location = new System.Drawing.Point(254, 17);
            this.l_LoginAuthentication.Name = "l_LoginAuthentication";
            this.l_LoginAuthentication.Size = new System.Drawing.Size(123, 38);
            this.l_LoginAuthentication.TabIndex = 8;
            this.l_LoginAuthentication.Text = "Register";
            // 
            // l_Password
            // 
            this.l_Password.AutoSize = true;
            this.l_Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_Password.Location = new System.Drawing.Point(30, 139);
            this.l_Password.Name = "l_Password";
            this.l_Password.Size = new System.Drawing.Size(191, 32);
            this.l_Password.TabIndex = 9;
            this.l_Password.Text = "Master Password";
            // 
            // l_MasterUserName
            // 
            this.l_MasterUserName.AutoSize = true;
            this.l_MasterUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_MasterUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_MasterUserName.Location = new System.Drawing.Point(30, 87);
            this.l_MasterUserName.Name = "l_MasterUserName";
            this.l_MasterUserName.Size = new System.Drawing.Size(212, 32);
            this.l_MasterUserName.TabIndex = 10;
            this.l_MasterUserName.Text = "Master User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Location = new System.Drawing.Point(30, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Re Password";
            // 
            // tb_RePassword
            // 
            this.tb_RePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tb_RePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_RePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_RePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_RePassword.Location = new System.Drawing.Point(256, 190);
            this.tb_RePassword.Name = "tb_RePassword";
            this.tb_RePassword.Size = new System.Drawing.Size(344, 34);
            this.tb_RePassword.TabIndex = 2;
            this.tb_RePassword.UseSystemPasswordChar = true;
            // 
            // l_HelperEmail
            // 
            this.l_HelperEmail.AutoSize = true;
            this.l_HelperEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_HelperEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_HelperEmail.Location = new System.Drawing.Point(30, 243);
            this.l_HelperEmail.Name = "l_HelperEmail";
            this.l_HelperEmail.Size = new System.Drawing.Size(149, 32);
            this.l_HelperEmail.TabIndex = 9;
            this.l_HelperEmail.Text = "Helper Email";
            // 
            // tb_HelperEmail
            // 
            this.tb_HelperEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tb_HelperEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_HelperEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_HelperEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_HelperEmail.Location = new System.Drawing.Point(256, 242);
            this.tb_HelperEmail.Name = "tb_HelperEmail";
            this.tb_HelperEmail.Size = new System.Drawing.Size(344, 34);
            this.tb_HelperEmail.TabIndex = 3;
            // 
            // pb_ShowRePassword
            // 
            this.pb_ShowRePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_ShowRePassword.Image = global::PL_PasswordManagementSystem.Properties.Resources.hiding;
            this.pb_ShowRePassword.Location = new System.Drawing.Point(565, 193);
            this.pb_ShowRePassword.Name = "pb_ShowRePassword";
            this.pb_ShowRePassword.Size = new System.Drawing.Size(33, 29);
            this.pb_ShowRePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ShowRePassword.TabIndex = 12;
            this.pb_ShowRePassword.TabStop = false;
            this.pb_ShowRePassword.Click += new System.EventHandler(this.pb_ShowRePassword_Click);
            // 
            // pb_ShowPassword
            // 
            this.pb_ShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_ShowPassword.Image = global::PL_PasswordManagementSystem.Properties.Resources.hiding;
            this.pb_ShowPassword.Location = new System.Drawing.Point(565, 140);
            this.pb_ShowPassword.Name = "pb_ShowPassword";
            this.pb_ShowPassword.Size = new System.Drawing.Size(33, 29);
            this.pb_ShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ShowPassword.TabIndex = 11;
            this.pb_ShowPassword.TabStop = false;
            this.pb_ShowPassword.Click += new System.EventHandler(this.pb_ShowPassword_Click);
            // 
            // pb_folderPassword
            // 
            this.pb_folderPassword.Image = global::PL_PasswordManagementSystem.Properties.Resources.folder_password;
            this.pb_folderPassword.Location = new System.Drawing.Point(1, 0);
            this.pb_folderPassword.Name = "pb_folderPassword";
            this.pb_folderPassword.Size = new System.Drawing.Size(53, 40);
            this.pb_folderPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_folderPassword.TabIndex = 14;
            this.pb_folderPassword.TabStop = false;
            // 
            // frm_RegisterAuthentication
            // 
            this.AcceptButton = this.btn_Register;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(631, 374);
            this.Controls.Add(this.pb_folderPassword);
            this.Controls.Add(this.pb_ShowRePassword);
            this.Controls.Add(this.pb_ShowPassword);
            this.Controls.Add(this.btn_Register);
            this.Controls.Add(this.tb_HelperEmail);
            this.Controls.Add(this.tb_RePassword);
            this.Controls.Add(this.tb_MasterPassword);
            this.Controls.Add(this.l_HelperEmail);
            this.Controls.Add(this.tb_MasterUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_LoginAuthentication);
            this.Controls.Add(this.l_Password);
            this.Controls.Add(this.l_MasterUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_RegisterAuthentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Management System Register";
            this.Load += new System.EventHandler(this.frm_RegisterAuthentication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShowRePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShowPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_folderPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.TextBox tb_MasterPassword;
        private System.Windows.Forms.TextBox tb_MasterUserName;
        private System.Windows.Forms.Label l_LoginAuthentication;
        private System.Windows.Forms.Label l_Password;
        private System.Windows.Forms.Label l_MasterUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_RePassword;
        private System.Windows.Forms.Label l_HelperEmail;
        private System.Windows.Forms.TextBox tb_HelperEmail;
        private System.Windows.Forms.PictureBox pb_ShowPassword;
        private System.Windows.Forms.PictureBox pb_ShowRePassword;
        private System.Windows.Forms.PictureBox pb_folderPassword;
    }
}
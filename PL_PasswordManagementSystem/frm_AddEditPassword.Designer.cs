namespace PL_PasswordManagementSystem
{
    partial class frm_AddEditPassword
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
            this.components = new System.ComponentModel.Container();
            this.cb_Categories = new System.Windows.Forms.ComboBox();
            this.l_UserName = new System.Windows.Forms.Label();
            this.l_Category = new System.Windows.Forms.Label();
            this.l_Email = new System.Windows.Forms.Label();
            this.l_Password = new System.Windows.Forms.Label();
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.mtb_CreationDate = new System.Windows.Forms.MaskedTextBox();
            this.mtb_EditDate = new System.Windows.Forms.MaskedTextBox();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.rtb_Notes = new System.Windows.Forms.RichTextBox();
            this.lb_AccountServices = new System.Windows.Forms.ListBox();
            this.tb_AddWebsiteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l_AccountID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_AddCategory = new System.Windows.Forms.TextBox();
            this.pb_AddWebsite = new System.Windows.Forms.PictureBox();
            this.pb_AddCategory = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_AddWebsiteUrl = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_AllServices = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tt_Info = new System.Windows.Forms.ToolTip(this.components);
            this.pb_ShowPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AddWebsite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AddCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShowPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_Categories
            // 
            this.cb_Categories.BackColor = System.Drawing.Color.White;
            this.cb_Categories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Categories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Categories.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Categories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cb_Categories.FormattingEnabled = true;
            this.cb_Categories.Location = new System.Drawing.Point(142, 80);
            this.cb_Categories.Name = "cb_Categories";
            this.cb_Categories.Size = new System.Drawing.Size(195, 36);
            this.cb_Categories.TabIndex = 3;
            this.tt_Info.SetToolTip(this.cb_Categories, "Select the category for the current account");
            this.cb_Categories.SelectedIndexChanged += new System.EventHandler(this.cb_Categories_SelectedIndexChanged);
            // 
            // l_UserName
            // 
            this.l_UserName.AutoSize = true;
            this.l_UserName.BackColor = System.Drawing.Color.Transparent;
            this.l_UserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_UserName.Location = new System.Drawing.Point(25, 156);
            this.l_UserName.Name = "l_UserName";
            this.l_UserName.Size = new System.Drawing.Size(132, 32);
            this.l_UserName.TabIndex = 1;
            this.l_UserName.Text = "UserName";
            // 
            // l_Category
            // 
            this.l_Category.AutoSize = true;
            this.l_Category.BackColor = System.Drawing.Color.Transparent;
            this.l_Category.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Category.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_Category.Location = new System.Drawing.Point(12, 80);
            this.l_Category.Name = "l_Category";
            this.l_Category.Size = new System.Drawing.Size(118, 32);
            this.l_Category.TabIndex = 1;
            this.l_Category.Text = "Category";
            // 
            // l_Email
            // 
            this.l_Email.AutoSize = true;
            this.l_Email.BackColor = System.Drawing.Color.Transparent;
            this.l_Email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_Email.Location = new System.Drawing.Point(25, 196);
            this.l_Email.Name = "l_Email";
            this.l_Email.Size = new System.Drawing.Size(76, 32);
            this.l_Email.TabIndex = 1;
            this.l_Email.Text = "Email";
            // 
            // l_Password
            // 
            this.l_Password.AutoSize = true;
            this.l_Password.BackColor = System.Drawing.Color.Transparent;
            this.l_Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_Password.Location = new System.Drawing.Point(25, 236);
            this.l_Password.Name = "l_Password";
            this.l_Password.Size = new System.Drawing.Size(122, 32);
            this.l_Password.TabIndex = 1;
            this.l_Password.Text = "Password";
            // 
            // tb_Username
            // 
            this.tb_Username.BackColor = System.Drawing.Color.White;
            this.tb_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Username.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Username.Location = new System.Drawing.Point(175, 155);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(382, 34);
            this.tb_Username.TabIndex = 0;
            // 
            // mtb_CreationDate
            // 
            this.mtb_CreationDate.Cursor = System.Windows.Forms.Cursors.No;
            this.mtb_CreationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtb_CreationDate.Location = new System.Drawing.Point(18, 590);
            this.mtb_CreationDate.Mask = "0000-00-00 00:00:00";
            this.mtb_CreationDate.Name = "mtb_CreationDate";
            this.mtb_CreationDate.ReadOnly = true;
            this.mtb_CreationDate.Size = new System.Drawing.Size(192, 30);
            this.mtb_CreationDate.TabIndex = 4;
            this.mtb_CreationDate.TabStop = false;
            this.mtb_CreationDate.ValidatingType = typeof(System.DateTime);
            // 
            // mtb_EditDate
            // 
            this.mtb_EditDate.Cursor = System.Windows.Forms.Cursors.No;
            this.mtb_EditDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtb_EditDate.Location = new System.Drawing.Point(568, 590);
            this.mtb_EditDate.Mask = "0000-00-00 00:00:00";
            this.mtb_EditDate.Name = "mtb_EditDate";
            this.mtb_EditDate.ReadOnly = true;
            this.mtb_EditDate.Size = new System.Drawing.Size(192, 30);
            this.mtb_EditDate.TabIndex = 4;
            this.mtb_EditDate.TabStop = false;
            this.mtb_EditDate.ValidatingType = typeof(System.DateTime);
            // 
            // tb_Email
            // 
            this.tb_Email.BackColor = System.Drawing.Color.White;
            this.tb_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Email.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Email.Location = new System.Drawing.Point(175, 195);
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(382, 34);
            this.tb_Email.TabIndex = 1;
            // 
            // tb_Password
            // 
            this.tb_Password.BackColor = System.Drawing.Color.White;
            this.tb_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Password.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Password.Location = new System.Drawing.Point(175, 235);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(382, 34);
            this.tb_Password.TabIndex = 2;
            this.tb_Password.UseSystemPasswordChar = true;
            // 
            // rtb_Notes
            // 
            this.rtb_Notes.BackColor = System.Drawing.Color.White;
            this.rtb_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_Notes.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_Notes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtb_Notes.Location = new System.Drawing.Point(142, 451);
            this.rtb_Notes.Name = "rtb_Notes";
            this.rtb_Notes.Size = new System.Drawing.Size(415, 74);
            this.rtb_Notes.TabIndex = 6;
            this.rtb_Notes.Text = "";
            this.tt_Info.SetToolTip(this.rtb_Notes, "You can write your recovery email, recovery phone number, or any other notes that" +
        " will help.");
            // 
            // lb_AccountServices
            // 
            this.lb_AccountServices.BackColor = System.Drawing.Color.White;
            this.lb_AccountServices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_AccountServices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_AccountServices.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_AccountServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lb_AccountServices.FormattingEnabled = true;
            this.lb_AccountServices.ItemHeight = 28;
            this.lb_AccountServices.Location = new System.Drawing.Point(569, 383);
            this.lb_AccountServices.Name = "lb_AccountServices";
            this.lb_AccountServices.Size = new System.Drawing.Size(192, 142);
            this.lb_AccountServices.TabIndex = 9;
            this.tt_Info.SetToolTip(this.lb_AccountServices, "The wibsite for this Account. You can double click and one of them to delete it.");
            this.lb_AccountServices.SelectedIndexChanged += new System.EventHandler(this.lb_AccountServices_SelectedIndexChanged);
            this.lb_AccountServices.DoubleClick += new System.EventHandler(this.lb_AccountServices_DoubleClick);
            // 
            // tb_AddWebsiteName
            // 
            this.tb_AddWebsiteName.BackColor = System.Drawing.Color.White;
            this.tb_AddWebsiteName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_AddWebsiteName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_AddWebsiteName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_AddWebsiteName.Location = new System.Drawing.Point(262, 301);
            this.tb_AddWebsiteName.Name = "tb_AddWebsiteName";
            this.tb_AddWebsiteName.Size = new System.Drawing.Size(295, 34);
            this.tb_AddWebsiteName.TabIndex = 4;
            this.tt_Info.SetToolTip(this.tb_AddWebsiteName, "New website name that is not with \"All Services\"");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Location = new System.Drawing.Point(23, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Website Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label4.Location = new System.Drawing.Point(40, 472);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Notes";
            // 
            // l_AccountID
            // 
            this.l_AccountID.AutoSize = true;
            this.l_AccountID.BackColor = System.Drawing.Color.Transparent;
            this.l_AccountID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_AccountID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_AccountID.Location = new System.Drawing.Point(177, 25);
            this.l_AccountID.Name = "l_AccountID";
            this.l_AccountID.Size = new System.Drawing.Size(108, 28);
            this.l_AccountID.TabIndex = 7;
            this.l_AccountID.Text = "Account ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label2.Location = new System.Drawing.Point(22, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Account ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label3.Location = new System.Drawing.Point(351, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Add Category";
            // 
            // tb_AddCategory
            // 
            this.tb_AddCategory.BackColor = System.Drawing.Color.White;
            this.tb_AddCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_AddCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_AddCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_AddCategory.Location = new System.Drawing.Point(529, 74);
            this.tb_AddCategory.Name = "tb_AddCategory";
            this.tb_AddCategory.Size = new System.Drawing.Size(198, 34);
            this.tb_AddCategory.TabIndex = 7;
            this.tt_Info.SetToolTip(this.tb_AddCategory, "New category name that is not with your \"Category list\" in all accounts");
            this.tb_AddCategory.TextChanged += new System.EventHandler(this.tb_AddCategory_TextChanged);
            // 
            // pb_AddWebsite
            // 
            this.pb_AddWebsite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_AddWebsite.Image = global::PL_PasswordManagementSystem.Properties.Resources.volume_up;
            this.pb_AddWebsite.Location = new System.Drawing.Point(368, 383);
            this.pb_AddWebsite.Name = "pb_AddWebsite";
            this.pb_AddWebsite.Size = new System.Drawing.Size(59, 43);
            this.pb_AddWebsite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_AddWebsite.TabIndex = 8;
            this.pb_AddWebsite.TabStop = false;
            this.tt_Info.SetToolTip(this.pb_AddWebsite, "Add new website");
            this.pb_AddWebsite.Click += new System.EventHandler(this.pb_AddWebsite_Click);
            // 
            // pb_AddCategory
            // 
            this.pb_AddCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_AddCategory.Image = global::PL_PasswordManagementSystem.Properties.Resources.volume_up;
            this.pb_AddCategory.Location = new System.Drawing.Point(733, 74);
            this.pb_AddCategory.Name = "pb_AddCategory";
            this.pb_AddCategory.Size = new System.Drawing.Size(34, 34);
            this.pb_AddCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_AddCategory.TabIndex = 8;
            this.pb_AddCategory.TabStop = false;
            this.tt_Info.SetToolTip(this.pb_AddCategory, "Add Category");
            this.pb_AddCategory.Click += new System.EventHandler(this.pb_AddCategory_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label5.Location = new System.Drawing.Point(579, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Account Services";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label6.Location = new System.Drawing.Point(30, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "Add Website Url";
            // 
            // tb_AddWebsiteUrl
            // 
            this.tb_AddWebsiteUrl.BackColor = System.Drawing.Color.White;
            this.tb_AddWebsiteUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_AddWebsiteUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_AddWebsiteUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_AddWebsiteUrl.Location = new System.Drawing.Point(262, 343);
            this.tb_AddWebsiteUrl.Name = "tb_AddWebsiteUrl";
            this.tb_AddWebsiteUrl.Size = new System.Drawing.Size(295, 34);
            this.tb_AddWebsiteUrl.TabIndex = 5;
            this.tt_Info.SetToolTip(this.tb_AddWebsiteUrl, "New website Url that is not with \"All Services\"");
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(23)))), ((int)(((byte)(230)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(3)))), ((int)(((byte)(219)))));
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(3)))), ((int)(((byte)(219)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(43)))), ((int)(((byte)(250)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(320, 543);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 45);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label7.Location = new System.Drawing.Point(600, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 28);
            this.label7.TabIndex = 1;
            this.label7.Text = "All Services";
            // 
            // lb_AllServices
            // 
            this.lb_AllServices.BackColor = System.Drawing.Color.White;
            this.lb_AllServices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_AllServices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_AllServices.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_AllServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lb_AllServices.FormattingEnabled = true;
            this.lb_AllServices.ItemHeight = 28;
            this.lb_AllServices.Location = new System.Drawing.Point(569, 155);
            this.lb_AllServices.Name = "lb_AllServices";
            this.lb_AllServices.Size = new System.Drawing.Size(192, 170);
            this.lb_AllServices.TabIndex = 8;
            this.tt_Info.SetToolTip(this.lb_AllServices, "All websites in all accounts. You can double-click each one to add it to your cur" +
        "rent account.");
            this.lb_AllServices.SelectedIndexChanged += new System.EventHandler(this.lb_AllServices_SelectedIndexChanged);
            this.lb_AllServices.DoubleClick += new System.EventHandler(this.lb_AllServices_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label8.Location = new System.Drawing.Point(13, 552);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 28);
            this.label8.TabIndex = 1;
            this.label8.Text = "Creation Date";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label9.Location = new System.Drawing.Point(617, 552);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 28);
            this.label9.TabIndex = 1;
            this.label9.Text = "Last Edit Date";
            // 
            // tt_Info
            // 
            this.tt_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(43)))), ((int)(((byte)(250)))));
            this.tt_Info.ForeColor = System.Drawing.Color.White;
            // 
            // pb_ShowPassword
            // 
            this.pb_ShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_ShowPassword.Image = global::PL_PasswordManagementSystem.Properties.Resources.hiding;
            this.pb_ShowPassword.Location = new System.Drawing.Point(523, 237);
            this.pb_ShowPassword.Name = "pb_ShowPassword";
            this.pb_ShowPassword.Size = new System.Drawing.Size(32, 31);
            this.pb_ShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ShowPassword.TabIndex = 13;
            this.pb_ShowPassword.TabStop = false;
            this.pb_ShowPassword.Click += new System.EventHandler(this.pb_ShowPassword_Click);
            // 
            // frm_AddEditPassword
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(782, 629);
            this.Controls.Add(this.pb_ShowPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pb_AddCategory);
            this.Controls.Add(this.pb_AddWebsite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l_AccountID);
            this.Controls.Add(this.lb_AllServices);
            this.Controls.Add(this.lb_AccountServices);
            this.Controls.Add(this.rtb_Notes);
            this.Controls.Add(this.mtb_EditDate);
            this.Controls.Add(this.mtb_CreationDate);
            this.Controls.Add(this.tb_AddCategory);
            this.Controls.Add(this.tb_AddWebsiteUrl);
            this.Controls.Add(this.tb_AddWebsiteName);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Email);
            this.Controls.Add(this.tb_Username);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.l_Category);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_Password);
            this.Controls.Add(this.l_Email);
            this.Controls.Add(this.l_UserName);
            this.Controls.Add(this.cb_Categories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_AddEditPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Account";
            this.Load += new System.EventHandler(this.frm_AddEditPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_AddWebsite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AddCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShowPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Categories;
        private System.Windows.Forms.Label l_UserName;
        private System.Windows.Forms.Label l_Category;
        private System.Windows.Forms.Label l_Email;
        private System.Windows.Forms.Label l_Password;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.MaskedTextBox mtb_CreationDate;
        private System.Windows.Forms.MaskedTextBox mtb_EditDate;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.RichTextBox rtb_Notes;
        private System.Windows.Forms.ListBox lb_AccountServices;
        private System.Windows.Forms.TextBox tb_AddWebsiteName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label l_AccountID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_AddCategory;
        private System.Windows.Forms.PictureBox pb_AddWebsite;
        private System.Windows.Forms.PictureBox pb_AddCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_AddWebsiteUrl;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lb_AllServices;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip tt_Info;
        private System.Windows.Forms.PictureBox pb_ShowPassword;
    }
}
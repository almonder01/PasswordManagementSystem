namespace PL_PasswordManagementSystem
{
    partial class frm_EditCategoryOrService
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
            this.l_ServiceUrl = new System.Windows.Forms.Label();
            this.tb_ServiceUrl = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.l_Name = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // l_ServiceUrl
            // 
            this.l_ServiceUrl.AutoSize = true;
            this.l_ServiceUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ServiceUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_ServiceUrl.Location = new System.Drawing.Point(35, 68);
            this.l_ServiceUrl.Name = "l_ServiceUrl";
            this.l_ServiceUrl.Size = new System.Drawing.Size(142, 29);
            this.l_ServiceUrl.TabIndex = 1;
            this.l_ServiceUrl.Text = "Service Url";
            // 
            // tb_ServiceUrl
            // 
            this.tb_ServiceUrl.BackColor = System.Drawing.Color.White;
            this.tb_ServiceUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ServiceUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ServiceUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_ServiceUrl.Location = new System.Drawing.Point(239, 65);
            this.tb_ServiceUrl.Name = "tb_ServiceUrl";
            this.tb_ServiceUrl.Size = new System.Drawing.Size(239, 34);
            this.tb_ServiceUrl.TabIndex = 1;
            // 
            // btn_Save
            // 
            this.btn_Save.AutoSize = true;
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(23)))), ((int)(((byte)(230)))));
            this.btn_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(43)))), ((int)(((byte)(250)))));
            this.btn_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(3)))), ((int)(((byte)(210)))));
            this.btn_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(43)))), ((int)(((byte)(250)))));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(164, 116);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(115, 44);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // l_Name
            // 
            this.l_Name.AutoSize = true;
            this.l_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_Name.Location = new System.Drawing.Point(35, 22);
            this.l_Name.Name = "l_Name";
            this.l_Name.Size = new System.Drawing.Size(82, 29);
            this.l_Name.TabIndex = 1;
            this.l_Name.Text = "Name";
            // 
            // tb_Name
            // 
            this.tb_Name.BackColor = System.Drawing.Color.White;
            this.tb_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Name.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Name.Location = new System.Drawing.Point(239, 19);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(239, 34);
            this.tb_Name.TabIndex = 0;
            // 
            // frm_EditCategoryOrService
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(492, 179);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.l_ServiceUrl);
            this.Controls.Add(this.l_Name);
            this.Controls.Add(this.tb_ServiceUrl);
            this.Controls.Add(this.tb_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_EditCategoryOrService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Category";
            this.Load += new System.EventHandler(this.frm_EditCategoryOrService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label l_ServiceUrl;
        private System.Windows.Forms.TextBox tb_ServiceUrl;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label l_Name;
        private System.Windows.Forms.TextBox tb_Name;
    }
}
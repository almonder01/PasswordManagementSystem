namespace PL_PasswordManagementSystem
{
    partial class frm_EditRelationship
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.l_SetServiceID = new System.Windows.Forms.Label();
            this.l_Username = new System.Windows.Forms.Label();
            this.mtb_SetID = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.AutoSize = true;
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(23)))), ((int)(((byte)(250)))));
            this.btn_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(43)))), ((int)(((byte)(250)))));
            this.btn_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(3)))), ((int)(((byte)(210)))));
            this.btn_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(43)))), ((int)(((byte)(250)))));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(133, 143);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(115, 44);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // l_SetServiceID
            // 
            this.l_SetServiceID.AutoSize = true;
            this.l_SetServiceID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_SetServiceID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_SetServiceID.Location = new System.Drawing.Point(17, 64);
            this.l_SetServiceID.Name = "l_SetServiceID";
            this.l_SetServiceID.Size = new System.Drawing.Size(78, 32);
            this.l_SetServiceID.TabIndex = 4;
            this.l_SetServiceID.Text = "Set ID";
            this.l_SetServiceID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Username
            // 
            this.l_Username.AutoSize = true;
            this.l_Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.l_Username.Location = new System.Drawing.Point(12, 9);
            this.l_Username.Name = "l_Username";
            this.l_Username.Size = new System.Drawing.Size(121, 32);
            this.l_Username.TabIndex = 5;
            this.l_Username.Text = "Username";
            // 
            // mtb_SetID
            // 
            this.mtb_SetID.BackColor = System.Drawing.Color.White;
            this.mtb_SetID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtb_SetID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtb_SetID.Location = new System.Drawing.Point(187, 64);
            this.mtb_SetID.Mask = "0000000";
            this.mtb_SetID.Name = "mtb_SetID";
            this.mtb_SetID.Size = new System.Drawing.Size(92, 34);
            this.mtb_SetID.TabIndex = 7;
            this.mtb_SetID.ValidatingType = typeof(int);
            // 
            // frm_EditRelationship
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(380, 199);
            this.Controls.Add(this.mtb_SetID);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.l_SetServiceID);
            this.Controls.Add(this.l_Username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_EditRelationship";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Relationship";
            this.Load += new System.EventHandler(this.frm_EditRelationship_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label l_SetServiceID;
        private System.Windows.Forms.Label l_Username;
        private System.Windows.Forms.MaskedTextBox mtb_SetID;
    }
}
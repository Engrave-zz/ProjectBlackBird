namespace WSC
{
    partial class DashBoardSelectionForm
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
            this.lbl_SelectRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbx_UserRole = new System.Windows.Forms.GroupBox();
            this.pbx_Logo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.gbx_UserRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_SelectRole
            // 
            this.lbl_SelectRole.AutoSize = true;
            this.lbl_SelectRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SelectRole.Location = new System.Drawing.Point(38, 27);
            this.lbl_SelectRole.Name = "lbl_SelectRole";
            this.lbl_SelectRole.Size = new System.Drawing.Size(220, 24);
            this.lbl_SelectRole.TabIndex = 0;
            this.lbl_SelectRole.Text = "Select Desired User Role";
            // 
            // cbRole
            // 
            this.cbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Operations Manager",
            "Sales Person",
            "Printing / Engraving Specialist",
            "Stock Room Clerk"});
            this.cbRole.Location = new System.Drawing.Point(23, 72);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(251, 23);
            this.cbRole.TabIndex = 1;
            // 
            // btnGO
            // 
            this.btnGO.BackColor = System.Drawing.Color.YellowGreen;
            this.btnGO.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGO.Location = new System.Drawing.Point(23, 114);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 30);
            this.btnGO.TabIndex = 2;
            this.btnGO.Text = "GO";
            this.btnGO.UseVisualStyleBackColor = false;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.YellowGreen;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(199, 114);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 30);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.gbx_UserRole);
            this.panel1.Location = new System.Drawing.Point(23, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 200);
            this.panel1.TabIndex = 4;
            // 
            // gbx_UserRole
            // 
            this.gbx_UserRole.Controls.Add(this.lbl_SelectRole);
            this.gbx_UserRole.Controls.Add(this.btnLogout);
            this.gbx_UserRole.Controls.Add(this.btnGO);
            this.gbx_UserRole.Controls.Add(this.cbRole);
            this.gbx_UserRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_UserRole.Location = new System.Drawing.Point(19, 13);
            this.gbx_UserRole.Name = "gbx_UserRole";
            this.gbx_UserRole.Size = new System.Drawing.Size(301, 166);
            this.gbx_UserRole.TabIndex = 5;
            this.gbx_UserRole.TabStop = false;
            this.gbx_UserRole.Text = "User Role";
            // 
            // pbx_Logo
            // 
            this.pbx_Logo.Image = global::WSC.Properties.Resources.wsc_logo1;
            this.pbx_Logo.Location = new System.Drawing.Point(-1, 0);
            this.pbx_Logo.Name = "pbx_Logo";
            this.pbx_Logo.Size = new System.Drawing.Size(390, 133);
            this.pbx_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_Logo.TabIndex = 5;
            this.pbx_Logo.TabStop = false;
            // 
            // DashBoardSelectionForm
            // 
            this.AcceptButton = this.btnGO;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnLogout;
            this.ClientSize = new System.Drawing.Size(388, 366);
            this.Controls.Add(this.pbx_Logo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DashBoardSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DashBoardSelectionForm_Load);
            this.panel1.ResumeLayout(false);
            this.gbx_UserRole.ResumeLayout(false);
            this.gbx_UserRole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_SelectRole;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbx_UserRole;
        private System.Windows.Forms.PictureBox pbx_Logo;
    }
}
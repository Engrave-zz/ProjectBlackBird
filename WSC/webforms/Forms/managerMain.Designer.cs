namespace WSC
{
    partial class ManagerMain
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
            this.lnkLogout = new System.Windows.Forms.LinkLabel();
            this.lnkNewUser = new System.Windows.Forms.LinkLabel();
            this.lnkManageUsers = new System.Windows.Forms.LinkLabel();
            this.lnkCustomerInfo = new System.Windows.Forms.LinkLabel();
            this.tmrCheckNotifications = new System.Windows.Forms.Timer(this.components);
            this.gbx_Notifications = new System.Windows.Forms.GroupBox();
            this.btn_DeleteNotification = new System.Windows.Forms.Button();
            this.rbox_ClerkNotifications = new System.Windows.Forms.RichTextBox();
            this.lbl_Notifications = new System.Windows.Forms.Label();
            this.cbx_Notifications = new System.Windows.Forms.ComboBox();
            this.btnRefreshNotifications = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkViewOrders = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbx_Logo = new System.Windows.Forms.PictureBox();
            this.gbx_Notifications.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkLogout
            // 
            this.lnkLogout.AutoSize = true;
            this.lnkLogout.Location = new System.Drawing.Point(625, 23);
            this.lnkLogout.Name = "lnkLogout";
            this.lnkLogout.Size = new System.Drawing.Size(40, 13);
            this.lnkLogout.TabIndex = 3;
            this.lnkLogout.TabStop = true;
            this.lnkLogout.Text = "Logout";
            this.lnkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // lnkNewUser
            // 
            this.lnkNewUser.AutoSize = true;
            this.lnkNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkNewUser.Location = new System.Drawing.Point(108, 223);
            this.lnkNewUser.Name = "lnkNewUser";
            this.lnkNewUser.Size = new System.Drawing.Size(130, 20);
            this.lnkNewUser.TabIndex = 8;
            this.lnkNewUser.TabStop = true;
            this.lnkNewUser.Text = "Create New User";
            this.lnkNewUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewUser_LinkClicked);
            // 
            // lnkManageUsers
            // 
            this.lnkManageUsers.AutoSize = true;
            this.lnkManageUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkManageUsers.Location = new System.Drawing.Point(116, 179);
            this.lnkManageUsers.Name = "lnkManageUsers";
            this.lnkManageUsers.Size = new System.Drawing.Size(113, 20);
            this.lnkManageUsers.TabIndex = 10;
            this.lnkManageUsers.TabStop = true;
            this.lnkManageUsers.Text = "Manage Users";
            this.lnkManageUsers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkManageUsers_LinkClicked);
            // 
            // lnkCustomerInfo
            // 
            this.lnkCustomerInfo.AutoSize = true;
            this.lnkCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCustomerInfo.Location = new System.Drawing.Point(70, 268);
            this.lnkCustomerInfo.Name = "lnkCustomerInfo";
            this.lnkCustomerInfo.Size = new System.Drawing.Size(207, 20);
            this.lnkCustomerInfo.TabIndex = 12;
            this.lnkCustomerInfo.TabStop = true;
            this.lnkCustomerInfo.Text = "Search Customer Database";
            this.lnkCustomerInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomerInfo_LinkClicked);
            // 
            // tmrCheckNotifications
            // 
            this.tmrCheckNotifications.Enabled = true;
            this.tmrCheckNotifications.Interval = 10000;
            // 
            // gbx_Notifications
            // 
            this.gbx_Notifications.Controls.Add(this.btn_DeleteNotification);
            this.gbx_Notifications.Controls.Add(this.rbox_ClerkNotifications);
            this.gbx_Notifications.Controls.Add(this.lbl_Notifications);
            this.gbx_Notifications.Controls.Add(this.cbx_Notifications);
            this.gbx_Notifications.Controls.Add(this.btnRefreshNotifications);
            this.gbx_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_Notifications.Location = new System.Drawing.Point(361, 51);
            this.gbx_Notifications.Name = "gbx_Notifications";
            this.gbx_Notifications.Size = new System.Drawing.Size(303, 295);
            this.gbx_Notifications.TabIndex = 16;
            this.gbx_Notifications.TabStop = false;
            this.gbx_Notifications.Text = "Notifications";
            // 
            // btn_DeleteNotification
            // 
            this.btn_DeleteNotification.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DeleteNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteNotification.Location = new System.Drawing.Point(82, 255);
            this.btn_DeleteNotification.Name = "btn_DeleteNotification";
            this.btn_DeleteNotification.Size = new System.Drawing.Size(138, 29);
            this.btn_DeleteNotification.TabIndex = 12;
            this.btn_DeleteNotification.Text = "Delete Notification";
            this.btn_DeleteNotification.UseVisualStyleBackColor = false;
            this.btn_DeleteNotification.Click += new System.EventHandler(this.btn_DeleteNotification_Click);
            // 
            // rbox_ClerkNotifications
            // 
            this.rbox_ClerkNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbox_ClerkNotifications.Location = new System.Drawing.Point(6, 90);
            this.rbox_ClerkNotifications.Name = "rbox_ClerkNotifications";
            this.rbox_ClerkNotifications.Size = new System.Drawing.Size(291, 120);
            this.rbox_ClerkNotifications.TabIndex = 11;
            this.rbox_ClerkNotifications.Text = "";
            // 
            // lbl_Notifications
            // 
            this.lbl_Notifications.AutoSize = true;
            this.lbl_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Notifications.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_Notifications.Location = new System.Drawing.Point(95, 29);
            this.lbl_Notifications.Name = "lbl_Notifications";
            this.lbl_Notifications.Size = new System.Drawing.Size(113, 13);
            this.lbl_Notifications.TabIndex = 10;
            this.lbl_Notifications.Text = "22 Total Notification(s)";
            // 
            // cbx_Notifications
            // 
            this.cbx_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Notifications.FormattingEnabled = true;
            this.cbx_Notifications.Location = new System.Drawing.Point(36, 55);
            this.cbx_Notifications.Name = "cbx_Notifications";
            this.cbx_Notifications.Size = new System.Drawing.Size(230, 21);
            this.cbx_Notifications.TabIndex = 9;
            this.cbx_Notifications.SelectedIndexChanged += new System.EventHandler(this.cbx_Notifications_SelectedIndexChanged);
            // 
            // btnRefreshNotifications
            // 
            this.btnRefreshNotifications.BackColor = System.Drawing.Color.YellowGreen;
            this.btnRefreshNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshNotifications.Location = new System.Drawing.Point(82, 219);
            this.btnRefreshNotifications.Name = "btnRefreshNotifications";
            this.btnRefreshNotifications.Size = new System.Drawing.Size(138, 29);
            this.btnRefreshNotifications.TabIndex = 7;
            this.btnRefreshNotifications.Text = "Refresh Notifications";
            this.btnRefreshNotifications.UseVisualStyleBackColor = false;
            this.btnRefreshNotifications.Click += new System.EventHandler(this.btnRefreshNotifications_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lnkViewOrders);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.gbx_Notifications);
            this.panel1.Controls.Add(this.lnkLogout);
            this.panel1.Controls.Add(this.lnkCustomerInfo);
            this.panel1.Controls.Add(this.lnkNewUser);
            this.panel1.Controls.Add(this.lnkManageUsers);
            this.panel1.Location = new System.Drawing.Point(25, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 386);
            this.panel1.TabIndex = 17;
            // 
            // lnkViewOrders
            // 
            this.lnkViewOrders.AutoSize = true;
            this.lnkViewOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkViewOrders.Location = new System.Drawing.Point(116, 134);
            this.lnkViewOrders.Name = "lnkViewOrders";
            this.lnkViewOrders.Size = new System.Drawing.Size(116, 20);
            this.lnkViewOrders.TabIndex = 18;
            this.lnkViewOrders.TabStop = true;
            this.lnkViewOrders.Text = "View All Orders";
            this.lnkViewOrders.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkViewOrders_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 31);
            this.label1.TabIndex = 17;
            this.label1.Text = "Manager\'s Dashboard";
            // 
            // pbx_Logo
            // 
            this.pbx_Logo.Image = global::WSC.Properties.Resources.wsc_logo1;
            this.pbx_Logo.Location = new System.Drawing.Point(0, 0);
            this.pbx_Logo.Name = "pbx_Logo";
            this.pbx_Logo.Size = new System.Drawing.Size(753, 133);
            this.pbx_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_Logo.TabIndex = 18;
            this.pbx_Logo.TabStop = false;
            // 
            // ManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(753, 555);
            this.Controls.Add(this.pbx_Logo);
            this.Controls.Add(this.panel1);
            this.Name = "ManagerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ManagerMain_Load);
            this.gbx_Notifications.ResumeLayout(false);
            this.gbx_Notifications.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkLogout;
        private System.Windows.Forms.LinkLabel lnkNewUser;
        private System.Windows.Forms.LinkLabel lnkManageUsers;
        private System.Windows.Forms.LinkLabel lnkCustomerInfo;
        private System.Windows.Forms.Timer tmrCheckNotifications;
        private System.Windows.Forms.GroupBox gbx_Notifications;
        private System.Windows.Forms.RichTextBox rbox_ClerkNotifications;
        private System.Windows.Forms.Label lbl_Notifications;
        private System.Windows.Forms.ComboBox cbx_Notifications;
        private System.Windows.Forms.Button btnRefreshNotifications;
        private System.Windows.Forms.Button btn_DeleteNotification;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbx_Logo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkViewOrders;
    }
}


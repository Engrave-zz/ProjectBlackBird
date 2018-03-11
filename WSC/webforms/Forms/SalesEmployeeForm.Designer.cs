namespace WSC
{
    partial class SalesEmployeeForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbox_search = new System.Windows.Forms.GroupBox();
            this.btn_CreateNewOrder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_CatalogResultsFound = new System.Windows.Forms.Label();
            this.cbx_CatalogResultsList = new System.Windows.Forms.ComboBox();
            this.tbx_CatalogQueryInput = new System.Windows.Forms.TextBox();
            this.lbl_CatalogQueryInput = new System.Windows.Forms.Label();
            this.lbl_CatalogQueryType = new System.Windows.Forms.Label();
            this.cbx_CatalogQueryType = new System.Windows.Forms.ComboBox();
            this.btn_SearchSubmit = new System.Windows.Forms.Button();
            this.rbx_CatalogSearchResults = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkOrders = new System.Windows.Forms.LinkLabel();
            this.gbx_Notifications = new System.Windows.Forms.GroupBox();
            this.btn_DeleteNotification = new System.Windows.Forms.Button();
            this.rbox_ClerkNotifications = new System.Windows.Forms.RichTextBox();
            this.lbl_Notifications = new System.Windows.Forms.Label();
            this.cbx_Notifications = new System.Windows.Forms.ComboBox();
            this.btnRefreshNotifications = new System.Windows.Forms.Button();
            this.lnkLogout = new System.Windows.Forms.LinkLabel();
            this.lnkCustomer = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.gbox_search.SuspendLayout();
            this.gbx_Notifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.gbox_search);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lnkOrders);
            this.panel1.Controls.Add(this.gbx_Notifications);
            this.panel1.Controls.Add(this.lnkLogout);
            this.panel1.Controls.Add(this.lnkCustomer);
            this.panel1.Location = new System.Drawing.Point(27, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 492);
            this.panel1.TabIndex = 26;
            // 
            // gbox_search
            // 
            this.gbox_search.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbox_search.Controls.Add(this.btn_CreateNewOrder);
            this.gbox_search.Controls.Add(this.label6);
            this.gbox_search.Controls.Add(this.label8);
            this.gbox_search.Controls.Add(this.lbl_CatalogResultsFound);
            this.gbox_search.Controls.Add(this.cbx_CatalogResultsList);
            this.gbox_search.Controls.Add(this.tbx_CatalogQueryInput);
            this.gbox_search.Controls.Add(this.lbl_CatalogQueryInput);
            this.gbox_search.Controls.Add(this.lbl_CatalogQueryType);
            this.gbox_search.Controls.Add(this.cbx_CatalogQueryType);
            this.gbox_search.Controls.Add(this.btn_SearchSubmit);
            this.gbox_search.Controls.Add(this.rbx_CatalogSearchResults);
            this.gbox_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbox_search.Location = new System.Drawing.Point(14, 63);
            this.gbox_search.Name = "gbox_search";
            this.gbox_search.Size = new System.Drawing.Size(272, 405);
            this.gbox_search.TabIndex = 32;
            this.gbox_search.TabStop = false;
            this.gbox_search.Text = "Search Catalog";
            // 
            // btn_CreateNewOrder
            // 
            this.btn_CreateNewOrder.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_CreateNewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateNewOrder.ForeColor = System.Drawing.Color.Black;
            this.btn_CreateNewOrder.Location = new System.Drawing.Point(69, 366);
            this.btn_CreateNewOrder.Name = "btn_CreateNewOrder";
            this.btn_CreateNewOrder.Size = new System.Drawing.Size(132, 32);
            this.btn_CreateNewOrder.TabIndex = 2;
            this.btn_CreateNewOrder.Text = "Create New Order";
            this.btn_CreateNewOrder.UseVisualStyleBackColor = false;
            this.btn_CreateNewOrder.Click += new System.EventHandler(this.btn_CreateNewOrder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "(search results listed by catalog item ID)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 10;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CatalogResultsFound
            // 
            this.lbl_CatalogResultsFound.AutoSize = true;
            this.lbl_CatalogResultsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CatalogResultsFound.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_CatalogResultsFound.Location = new System.Drawing.Point(85, 127);
            this.lbl_CatalogResultsFound.Name = "lbl_CatalogResultsFound";
            this.lbl_CatalogResultsFound.Size = new System.Drawing.Size(100, 13);
            this.lbl_CatalogResultsFound.TabIndex = 10;
            this.lbl_CatalogResultsFound.Text = "xx results found!";
            this.lbl_CatalogResultsFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbx_CatalogResultsList
            // 
            this.cbx_CatalogResultsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_CatalogResultsList.FormattingEnabled = true;
            this.cbx_CatalogResultsList.Location = new System.Drawing.Point(22, 147);
            this.cbx_CatalogResultsList.Name = "cbx_CatalogResultsList";
            this.cbx_CatalogResultsList.Size = new System.Drawing.Size(230, 21);
            this.cbx_CatalogResultsList.TabIndex = 9;
            // 
            // tbx_CatalogQueryInput
            // 
            this.tbx_CatalogQueryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_CatalogQueryInput.Location = new System.Drawing.Point(98, 48);
            this.tbx_CatalogQueryInput.Name = "tbx_CatalogQueryInput";
            this.tbx_CatalogQueryInput.Size = new System.Drawing.Size(156, 20);
            this.tbx_CatalogQueryInput.TabIndex = 6;
            // 
            // lbl_CatalogQueryInput
            // 
            this.lbl_CatalogQueryInput.AutoSize = true;
            this.lbl_CatalogQueryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CatalogQueryInput.Location = new System.Drawing.Point(19, 52);
            this.lbl_CatalogQueryInput.Name = "lbl_CatalogQueryInput";
            this.lbl_CatalogQueryInput.Size = new System.Drawing.Size(68, 13);
            this.lbl_CatalogQueryInput.TabIndex = 5;
            this.lbl_CatalogQueryInput.Text = "Query Input :";
            // 
            // lbl_CatalogQueryType
            // 
            this.lbl_CatalogQueryType.AutoSize = true;
            this.lbl_CatalogQueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CatalogQueryType.Location = new System.Drawing.Point(19, 26);
            this.lbl_CatalogQueryType.Name = "lbl_CatalogQueryType";
            this.lbl_CatalogQueryType.Size = new System.Drawing.Size(68, 13);
            this.lbl_CatalogQueryType.TabIndex = 4;
            this.lbl_CatalogQueryType.Text = "Query Type :";
            // 
            // cbx_CatalogQueryType
            // 
            this.cbx_CatalogQueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_CatalogQueryType.FormattingEnabled = true;
            this.cbx_CatalogQueryType.Items.AddRange(new object[] {
            "Catalog ID",
            "Item Name",
            "Manufacturer"});
            this.cbx_CatalogQueryType.Location = new System.Drawing.Point(98, 22);
            this.cbx_CatalogQueryType.Name = "cbx_CatalogQueryType";
            this.cbx_CatalogQueryType.Size = new System.Drawing.Size(156, 21);
            this.cbx_CatalogQueryType.TabIndex = 3;
            // 
            // btn_SearchSubmit
            // 
            this.btn_SearchSubmit.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_SearchSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SearchSubmit.ForeColor = System.Drawing.Color.Black;
            this.btn_SearchSubmit.Location = new System.Drawing.Point(69, 83);
            this.btn_SearchSubmit.Name = "btn_SearchSubmit";
            this.btn_SearchSubmit.Size = new System.Drawing.Size(132, 32);
            this.btn_SearchSubmit.TabIndex = 2;
            this.btn_SearchSubmit.Text = "Search";
            this.btn_SearchSubmit.UseVisualStyleBackColor = false;
            this.btn_SearchSubmit.Click += new System.EventHandler(this.btn_SearchSubmit_Click);
            // 
            // rbx_CatalogSearchResults
            // 
            this.rbx_CatalogSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbx_CatalogSearchResults.ForeColor = System.Drawing.Color.Black;
            this.rbx_CatalogSearchResults.Location = new System.Drawing.Point(3, 188);
            this.rbx_CatalogSearchResults.Name = "rbx_CatalogSearchResults";
            this.rbx_CatalogSearchResults.Size = new System.Drawing.Size(264, 167);
            this.rbx_CatalogSearchResults.TabIndex = 2;
            this.rbx_CatalogSearchResults.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 29);
            this.label1.TabIndex = 31;
            this.label1.Text = "Sales Associate Dashboard";
            // 
            // lnkOrders
            // 
            this.lnkOrders.AutoSize = true;
            this.lnkOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOrders.Location = new System.Drawing.Point(407, 392);
            this.lnkOrders.Name = "lnkOrders";
            this.lnkOrders.Size = new System.Drawing.Size(116, 20);
            this.lnkOrders.TabIndex = 30;
            this.lnkOrders.TabStop = true;
            this.lnkOrders.Text = "View All Orders";
            this.lnkOrders.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOrders_LinkClicked);
            // 
            // gbx_Notifications
            // 
            this.gbx_Notifications.Controls.Add(this.btn_DeleteNotification);
            this.gbx_Notifications.Controls.Add(this.rbox_ClerkNotifications);
            this.gbx_Notifications.Controls.Add(this.lbl_Notifications);
            this.gbx_Notifications.Controls.Add(this.cbx_Notifications);
            this.gbx_Notifications.Controls.Add(this.btnRefreshNotifications);
            this.gbx_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_Notifications.Location = new System.Drawing.Point(317, 63);
            this.gbx_Notifications.Name = "gbx_Notifications";
            this.gbx_Notifications.Size = new System.Drawing.Size(303, 296);
            this.gbx_Notifications.TabIndex = 29;
            this.gbx_Notifications.TabStop = false;
            this.gbx_Notifications.Text = "Notifications";
            // 
            // btn_DeleteNotification
            // 
            this.btn_DeleteNotification.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DeleteNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteNotification.Location = new System.Drawing.Point(85, 255);
            this.btn_DeleteNotification.Name = "btn_DeleteNotification";
            this.btn_DeleteNotification.Size = new System.Drawing.Size(132, 32);
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
            this.lbl_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Notifications.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_Notifications.Location = new System.Drawing.Point(83, 29);
            this.lbl_Notifications.Name = "lbl_Notifications";
            this.lbl_Notifications.Size = new System.Drawing.Size(137, 13);
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
            this.btnRefreshNotifications.Location = new System.Drawing.Point(85, 218);
            this.btnRefreshNotifications.Name = "btnRefreshNotifications";
            this.btnRefreshNotifications.Size = new System.Drawing.Size(132, 32);
            this.btnRefreshNotifications.TabIndex = 7;
            this.btnRefreshNotifications.Text = "Refresh Notifications";
            this.btnRefreshNotifications.UseVisualStyleBackColor = false;
            // 
            // lnkLogout
            // 
            this.lnkLogout.AutoSize = true;
            this.lnkLogout.Location = new System.Drawing.Point(580, 12);
            this.lnkLogout.Name = "lnkLogout";
            this.lnkLogout.Size = new System.Drawing.Size(40, 13);
            this.lnkLogout.TabIndex = 28;
            this.lnkLogout.TabStop = true;
            this.lnkLogout.Text = "Logout";
            this.lnkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // lnkCustomer
            // 
            this.lnkCustomer.AutoSize = true;
            this.lnkCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCustomer.Location = new System.Drawing.Point(362, 433);
            this.lnkCustomer.Name = "lnkCustomer";
            this.lnkCustomer.Size = new System.Drawing.Size(207, 20);
            this.lnkCustomer.TabIndex = 27;
            this.lnkCustomer.TabStop = true;
            this.lnkCustomer.Text = "Search Customer Database";
            this.lnkCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomer_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WSC.Properties.Resources.wsc_logo1;
            this.pictureBox1.InitialImage = global::WSC.Properties.Resources.wsc_logo1;
            this.pictureBox1.Location = new System.Drawing.Point(1, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // SalesEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(686, 667);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SalesEmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SalesEmployeeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbox_search.ResumeLayout(false);
            this.gbox_search.PerformLayout();
            this.gbx_Notifications.ResumeLayout(false);
            this.gbx_Notifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbox_search;
        private System.Windows.Forms.Button btn_CreateNewOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_CatalogResultsFound;
        private System.Windows.Forms.ComboBox cbx_CatalogResultsList;
        private System.Windows.Forms.TextBox tbx_CatalogQueryInput;
        private System.Windows.Forms.Label lbl_CatalogQueryInput;
        private System.Windows.Forms.Label lbl_CatalogQueryType;
        private System.Windows.Forms.ComboBox cbx_CatalogQueryType;
        private System.Windows.Forms.Button btn_SearchSubmit;
        private System.Windows.Forms.RichTextBox rbx_CatalogSearchResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkOrders;
        private System.Windows.Forms.GroupBox gbx_Notifications;
        private System.Windows.Forms.Button btn_DeleteNotification;
        private System.Windows.Forms.RichTextBox rbox_ClerkNotifications;
        private System.Windows.Forms.Label lbl_Notifications;
        private System.Windows.Forms.ComboBox cbx_Notifications;
        private System.Windows.Forms.Button btnRefreshNotifications;
        private System.Windows.Forms.LinkLabel lnkLogout;
        private System.Windows.Forms.LinkLabel lnkCustomer;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}
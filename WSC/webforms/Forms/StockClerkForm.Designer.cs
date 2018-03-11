namespace WSC
{
    partial class StockClerkForm
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
            this.gbox_clerknotify = new System.Windows.Forms.GroupBox();
            this.btn_clerknotifysubmit = new System.Windows.Forms.Button();
            this.rbtn_NotifyDelivered = new System.Windows.Forms.RadioButton();
            this.rbtn_NotifyEnRoute = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.tbox_clerknotifyid = new System.Windows.Forms.TextBox();
            this.lbl_OrderId = new System.Windows.Forms.Label();
            this.gbox_clerksearch = new System.Windows.Forms.GroupBox();
            this.btn_DeleteFromInventory = new System.Windows.Forms.Button();
            this.lbl_InventoryStatus = new System.Windows.Forms.Label();
            this.cbx_InventoryStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_ResultsFound = new System.Windows.Forms.Label();
            this.cbx_ResultsList = new System.Windows.Forms.ComboBox();
            this.tbx_QueryInput = new System.Windows.Forms.TextBox();
            this.lbl_QueryInput = new System.Windows.Forms.Label();
            this.lbl_QueryType = new System.Windows.Forms.Label();
            this.cbx_QueryType = new System.Windows.Forms.ComboBox();
            this.btn_SearchSubmit = new System.Windows.Forms.Button();
            this.rbox_clerkSearchDisplay = new System.Windows.Forms.RichTextBox();
            this.gbx_Notifications = new System.Windows.Forms.GroupBox();
            this.lbl_NotificationInstruction2 = new System.Windows.Forms.Label();
            this.btn_DeleteNotification = new System.Windows.Forms.Button();
            this.lbl_NotificationInstruction1 = new System.Windows.Forms.Label();
            this.rbox_ClerkNotifications = new System.Windows.Forms.RichTextBox();
            this.lbl_Notifications = new System.Windows.Forms.Label();
            this.cbx_Notifications = new System.Windows.Forms.ComboBox();
            this.btnRefreshNotifications = new System.Windows.Forms.Button();
            this.pbx_Logo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkLogout = new System.Windows.Forms.LinkLabel();
            this.gbox_clerknotify.SuspendLayout();
            this.gbox_clerksearch.SuspendLayout();
            this.gbx_Notifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbox_clerknotify
            // 
            this.gbox_clerknotify.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbox_clerknotify.Controls.Add(this.btn_clerknotifysubmit);
            this.gbox_clerknotify.Controls.Add(this.rbtn_NotifyDelivered);
            this.gbox_clerknotify.Controls.Add(this.rbtn_NotifyEnRoute);
            this.gbox_clerknotify.Controls.Add(this.label15);
            this.gbox_clerknotify.Controls.Add(this.tbox_clerknotifyid);
            this.gbox_clerknotify.Controls.Add(this.lbl_OrderId);
            this.gbox_clerknotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbox_clerknotify.Location = new System.Drawing.Point(312, 361);
            this.gbox_clerknotify.Name = "gbox_clerknotify";
            this.gbox_clerknotify.Size = new System.Drawing.Size(303, 118);
            this.gbox_clerknotify.TabIndex = 2;
            this.gbox_clerknotify.TabStop = false;
            this.gbox_clerknotify.Text = "Order Status";
            // 
            // btn_clerknotifysubmit
            // 
            this.btn_clerknotifysubmit.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_clerknotifysubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clerknotifysubmit.ForeColor = System.Drawing.Color.Black;
            this.btn_clerknotifysubmit.Location = new System.Drawing.Point(85, 80);
            this.btn_clerknotifysubmit.Name = "btn_clerknotifysubmit";
            this.btn_clerknotifysubmit.Size = new System.Drawing.Size(132, 28);
            this.btn_clerknotifysubmit.TabIndex = 30;
            this.btn_clerknotifysubmit.Text = "Update Status";
            this.btn_clerknotifysubmit.UseVisualStyleBackColor = false;
            this.btn_clerknotifysubmit.Click += new System.EventHandler(this.btn_clerknotifysubmit_Click);
            // 
            // rbtn_NotifyDelivered
            // 
            this.rbtn_NotifyDelivered.AutoSize = true;
            this.rbtn_NotifyDelivered.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_NotifyDelivered.Location = new System.Drawing.Point(195, 55);
            this.rbtn_NotifyDelivered.Name = "rbtn_NotifyDelivered";
            this.rbtn_NotifyDelivered.Size = new System.Drawing.Size(70, 17);
            this.rbtn_NotifyDelivered.TabIndex = 27;
            this.rbtn_NotifyDelivered.TabStop = true;
            this.rbtn_NotifyDelivered.Text = "Delivered";
            this.rbtn_NotifyDelivered.UseVisualStyleBackColor = true;
            // 
            // rbtn_NotifyEnRoute
            // 
            this.rbtn_NotifyEnRoute.AutoSize = true;
            this.rbtn_NotifyEnRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_NotifyEnRoute.Location = new System.Drawing.Point(104, 54);
            this.rbtn_NotifyEnRoute.Name = "rbtn_NotifyEnRoute";
            this.rbtn_NotifyEnRoute.Size = new System.Drawing.Size(65, 17);
            this.rbtn_NotifyEnRoute.TabIndex = 25;
            this.rbtn_NotifyEnRoute.TabStop = true;
            this.rbtn_NotifyEnRoute.Text = "En route";
            this.rbtn_NotifyEnRoute.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(38, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Status:";
            // 
            // tbox_clerknotifyid
            // 
            this.tbox_clerknotifyid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_clerknotifyid.Location = new System.Drawing.Point(60, 23);
            this.tbox_clerknotifyid.Name = "tbox_clerknotifyid";
            this.tbox_clerknotifyid.Size = new System.Drawing.Size(213, 20);
            this.tbox_clerknotifyid.TabIndex = 11;
            // 
            // lbl_OrderId
            // 
            this.lbl_OrderId.AutoSize = true;
            this.lbl_OrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OrderId.Location = new System.Drawing.Point(6, 26);
            this.lbl_OrderId.Name = "lbl_OrderId";
            this.lbl_OrderId.Size = new System.Drawing.Size(51, 13);
            this.lbl_OrderId.TabIndex = 10;
            this.lbl_OrderId.Text = "Order Id: ";
            // 
            // gbox_clerksearch
            // 
            this.gbox_clerksearch.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbox_clerksearch.Controls.Add(this.btn_DeleteFromInventory);
            this.gbox_clerksearch.Controls.Add(this.lbl_InventoryStatus);
            this.gbox_clerksearch.Controls.Add(this.cbx_InventoryStatus);
            this.gbox_clerksearch.Controls.Add(this.label6);
            this.gbox_clerksearch.Controls.Add(this.label8);
            this.gbox_clerksearch.Controls.Add(this.lbl_ResultsFound);
            this.gbox_clerksearch.Controls.Add(this.cbx_ResultsList);
            this.gbox_clerksearch.Controls.Add(this.tbx_QueryInput);
            this.gbox_clerksearch.Controls.Add(this.lbl_QueryInput);
            this.gbox_clerksearch.Controls.Add(this.lbl_QueryType);
            this.gbox_clerksearch.Controls.Add(this.cbx_QueryType);
            this.gbox_clerksearch.Controls.Add(this.btn_SearchSubmit);
            this.gbox_clerksearch.Controls.Add(this.rbox_clerkSearchDisplay);
            this.gbox_clerksearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbox_clerksearch.Location = new System.Drawing.Point(12, 56);
            this.gbox_clerksearch.Name = "gbox_clerksearch";
            this.gbox_clerksearch.Size = new System.Drawing.Size(272, 423);
            this.gbox_clerksearch.TabIndex = 10;
            this.gbox_clerksearch.TabStop = false;
            this.gbox_clerksearch.Text = "Search Inventory";
            // 
            // btn_DeleteFromInventory
            // 
            this.btn_DeleteFromInventory.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DeleteFromInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteFromInventory.ForeColor = System.Drawing.Color.Black;
            this.btn_DeleteFromInventory.Location = new System.Drawing.Point(53, 388);
            this.btn_DeleteFromInventory.Name = "btn_DeleteFromInventory";
            this.btn_DeleteFromInventory.Size = new System.Drawing.Size(158, 28);
            this.btn_DeleteFromInventory.TabIndex = 2;
            this.btn_DeleteFromInventory.Text = "Delete From Inventory";
            this.btn_DeleteFromInventory.UseVisualStyleBackColor = false;
            this.btn_DeleteFromInventory.Click += new System.EventHandler(this.btn_DeleteFromInventory_Click);
            // 
            // lbl_InventoryStatus
            // 
            this.lbl_InventoryStatus.AutoSize = true;
            this.lbl_InventoryStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_InventoryStatus.Location = new System.Drawing.Point(15, 78);
            this.lbl_InventoryStatus.Name = "lbl_InventoryStatus";
            this.lbl_InventoryStatus.Size = new System.Drawing.Size(87, 13);
            this.lbl_InventoryStatus.TabIndex = 13;
            this.lbl_InventoryStatus.Text = "Inventory Status:";
            // 
            // cbx_InventoryStatus
            // 
            this.cbx_InventoryStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_InventoryStatus.FormattingEnabled = true;
            this.cbx_InventoryStatus.Items.AddRange(new object[] {
            "Stock",
            "Sold",
            "Delivered"});
            this.cbx_InventoryStatus.Location = new System.Drawing.Point(117, 74);
            this.cbx_InventoryStatus.Name = "cbx_InventoryStatus";
            this.cbx_InventoryStatus.Size = new System.Drawing.Size(137, 21);
            this.cbx_InventoryStatus.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "(search results listed by inventory item ID)";
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
            // lbl_ResultsFound
            // 
            this.lbl_ResultsFound.AutoSize = true;
            this.lbl_ResultsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ResultsFound.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_ResultsFound.Location = new System.Drawing.Point(86, 149);
            this.lbl_ResultsFound.Name = "lbl_ResultsFound";
            this.lbl_ResultsFound.Size = new System.Drawing.Size(100, 13);
            this.lbl_ResultsFound.TabIndex = 10;
            this.lbl_ResultsFound.Text = "xx results found!";
            this.lbl_ResultsFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbx_ResultsList
            // 
            this.cbx_ResultsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_ResultsList.FormattingEnabled = true;
            this.cbx_ResultsList.Location = new System.Drawing.Point(21, 167);
            this.cbx_ResultsList.Name = "cbx_ResultsList";
            this.cbx_ResultsList.Size = new System.Drawing.Size(230, 21);
            this.cbx_ResultsList.TabIndex = 9;
            this.cbx_ResultsList.SelectedIndexChanged += new System.EventHandler(this.cbx_ResultsList_SelectedIndexChanged);
            // 
            // tbx_QueryInput
            // 
            this.tbx_QueryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_QueryInput.Location = new System.Drawing.Point(98, 48);
            this.tbx_QueryInput.Name = "tbx_QueryInput";
            this.tbx_QueryInput.Size = new System.Drawing.Size(156, 20);
            this.tbx_QueryInput.TabIndex = 6;
            // 
            // lbl_QueryInput
            // 
            this.lbl_QueryInput.AutoSize = true;
            this.lbl_QueryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QueryInput.Location = new System.Drawing.Point(19, 52);
            this.lbl_QueryInput.Name = "lbl_QueryInput";
            this.lbl_QueryInput.Size = new System.Drawing.Size(68, 13);
            this.lbl_QueryInput.TabIndex = 5;
            this.lbl_QueryInput.Text = "Query Input :";
            // 
            // lbl_QueryType
            // 
            this.lbl_QueryType.AutoSize = true;
            this.lbl_QueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QueryType.Location = new System.Drawing.Point(19, 26);
            this.lbl_QueryType.Name = "lbl_QueryType";
            this.lbl_QueryType.Size = new System.Drawing.Size(68, 13);
            this.lbl_QueryType.TabIndex = 4;
            this.lbl_QueryType.Text = "Query Type :";
            // 
            // cbx_QueryType
            // 
            this.cbx_QueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_QueryType.FormattingEnabled = true;
            this.cbx_QueryType.Items.AddRange(new object[] {
            "Inventory ID",
            "Item Name",
            "Manufacturer",
            "Catalog Number"});
            this.cbx_QueryType.Location = new System.Drawing.Point(98, 22);
            this.cbx_QueryType.Name = "cbx_QueryType";
            this.cbx_QueryType.Size = new System.Drawing.Size(156, 21);
            this.cbx_QueryType.TabIndex = 3;
            // 
            // btn_SearchSubmit
            // 
            this.btn_SearchSubmit.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_SearchSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SearchSubmit.ForeColor = System.Drawing.Color.Black;
            this.btn_SearchSubmit.Location = new System.Drawing.Point(70, 106);
            this.btn_SearchSubmit.Name = "btn_SearchSubmit";
            this.btn_SearchSubmit.Size = new System.Drawing.Size(132, 28);
            this.btn_SearchSubmit.TabIndex = 2;
            this.btn_SearchSubmit.Text = "Search";
            this.btn_SearchSubmit.UseVisualStyleBackColor = false;
            this.btn_SearchSubmit.Click += new System.EventHandler(this.btn_SearchSubmit_Click);
            // 
            // rbox_clerkSearchDisplay
            // 
            this.rbox_clerkSearchDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbox_clerkSearchDisplay.ForeColor = System.Drawing.Color.Black;
            this.rbox_clerkSearchDisplay.Location = new System.Drawing.Point(4, 210);
            this.rbox_clerkSearchDisplay.Name = "rbox_clerkSearchDisplay";
            this.rbox_clerkSearchDisplay.Size = new System.Drawing.Size(264, 167);
            this.rbox_clerkSearchDisplay.TabIndex = 2;
            this.rbox_clerkSearchDisplay.Text = "";
            // 
            // gbx_Notifications
            // 
            this.gbx_Notifications.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbx_Notifications.Controls.Add(this.lbl_NotificationInstruction2);
            this.gbx_Notifications.Controls.Add(this.btn_DeleteNotification);
            this.gbx_Notifications.Controls.Add(this.lbl_NotificationInstruction1);
            this.gbx_Notifications.Controls.Add(this.rbox_ClerkNotifications);
            this.gbx_Notifications.Controls.Add(this.lbl_Notifications);
            this.gbx_Notifications.Controls.Add(this.cbx_Notifications);
            this.gbx_Notifications.Controls.Add(this.btnRefreshNotifications);
            this.gbx_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_Notifications.Location = new System.Drawing.Point(312, 56);
            this.gbx_Notifications.Name = "gbx_Notifications";
            this.gbx_Notifications.Size = new System.Drawing.Size(303, 288);
            this.gbx_Notifications.TabIndex = 11;
            this.gbx_Notifications.TabStop = false;
            this.gbx_Notifications.Text = "Notifications";
            // 
            // lbl_NotificationInstruction2
            // 
            this.lbl_NotificationInstruction2.AutoSize = true;
            this.lbl_NotificationInstruction2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NotificationInstruction2.Location = new System.Drawing.Point(68, 74);
            this.lbl_NotificationInstruction2.Name = "lbl_NotificationInstruction2";
            this.lbl_NotificationInstruction2.Size = new System.Drawing.Size(167, 12);
            this.lbl_NotificationInstruction2.TabIndex = 15;
            this.lbl_NotificationInstruction2.Text = "to view details in display window below";
            // 
            // btn_DeleteNotification
            // 
            this.btn_DeleteNotification.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DeleteNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteNotification.ForeColor = System.Drawing.Color.Black;
            this.btn_DeleteNotification.Location = new System.Drawing.Point(85, 251);
            this.btn_DeleteNotification.Name = "btn_DeleteNotification";
            this.btn_DeleteNotification.Size = new System.Drawing.Size(132, 28);
            this.btn_DeleteNotification.TabIndex = 12;
            this.btn_DeleteNotification.Text = "Delete Notification";
            this.btn_DeleteNotification.UseVisualStyleBackColor = false;
            this.btn_DeleteNotification.Click += new System.EventHandler(this.btn_DeleteNotification_Click);
            // 
            // lbl_NotificationInstruction1
            // 
            this.lbl_NotificationInstruction1.AutoSize = true;
            this.lbl_NotificationInstruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NotificationInstruction1.Location = new System.Drawing.Point(79, 63);
            this.lbl_NotificationInstruction1.Name = "lbl_NotificationInstruction1";
            this.lbl_NotificationInstruction1.Size = new System.Drawing.Size(144, 12);
            this.lbl_NotificationInstruction1.TabIndex = 14;
            this.lbl_NotificationInstruction1.Text = "select notification from drop-down";
            // 
            // rbox_ClerkNotifications
            // 
            this.rbox_ClerkNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbox_ClerkNotifications.ForeColor = System.Drawing.Color.Black;
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
            this.lbl_Notifications.Location = new System.Drawing.Point(83, 19);
            this.lbl_Notifications.Name = "lbl_Notifications";
            this.lbl_Notifications.Size = new System.Drawing.Size(137, 13);
            this.lbl_Notifications.TabIndex = 10;
            this.lbl_Notifications.Text = "22 Total Notification(s)";
            // 
            // cbx_Notifications
            // 
            this.cbx_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Notifications.ForeColor = System.Drawing.Color.Black;
            this.cbx_Notifications.FormattingEnabled = true;
            this.cbx_Notifications.Location = new System.Drawing.Point(36, 39);
            this.cbx_Notifications.Name = "cbx_Notifications";
            this.cbx_Notifications.Size = new System.Drawing.Size(230, 21);
            this.cbx_Notifications.TabIndex = 9;
            this.cbx_Notifications.SelectedIndexChanged += new System.EventHandler(this.cbx_Notifications_SelectedIndexChanged);
            // 
            // btnRefreshNotifications
            // 
            this.btnRefreshNotifications.BackColor = System.Drawing.Color.YellowGreen;
            this.btnRefreshNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshNotifications.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshNotifications.Location = new System.Drawing.Point(85, 217);
            this.btnRefreshNotifications.Name = "btnRefreshNotifications";
            this.btnRefreshNotifications.Size = new System.Drawing.Size(132, 28);
            this.btnRefreshNotifications.TabIndex = 7;
            this.btnRefreshNotifications.Text = "Refresh Notifications";
            this.btnRefreshNotifications.UseVisualStyleBackColor = false;
            this.btnRefreshNotifications.Click += new System.EventHandler(this.btnRefreshNotifications_Click);
            // 
            // pbx_Logo
            // 
            this.pbx_Logo.Image = global::WSC.Properties.Resources.wsc_logo1;
            this.pbx_Logo.Location = new System.Drawing.Point(0, 0);
            this.pbx_Logo.Name = "pbx_Logo";
            this.pbx_Logo.Size = new System.Drawing.Size(678, 138);
            this.pbx_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_Logo.TabIndex = 12;
            this.pbx_Logo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lnkLogout);
            this.panel1.Controls.Add(this.gbox_clerksearch);
            this.panel1.Controls.Add(this.gbx_Notifications);
            this.panel1.Controls.Add(this.gbox_clerknotify);
            this.panel1.Location = new System.Drawing.Point(23, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 497);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 31);
            this.label1.TabIndex = 25;
            this.label1.Text = "Stock Clerk Dashboard";
            // 
            // lnkLogout
            // 
            this.lnkLogout.AutoSize = true;
            this.lnkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLogout.Location = new System.Drawing.Point(581, 9);
            this.lnkLogout.Name = "lnkLogout";
            this.lnkLogout.Size = new System.Drawing.Size(40, 13);
            this.lnkLogout.TabIndex = 12;
            this.lnkLogout.TabStop = true;
            this.lnkLogout.Text = "Logout";
            this.lnkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // StockClerkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(676, 663);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbx_Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "StockClerkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.StockClerkForm_Load);
            this.gbox_clerknotify.ResumeLayout(false);
            this.gbox_clerknotify.PerformLayout();
            this.gbox_clerksearch.ResumeLayout(false);
            this.gbox_clerksearch.PerformLayout();
            this.gbx_Notifications.ResumeLayout(false);
            this.gbx_Notifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox_clerknotify;
        private System.Windows.Forms.TextBox tbox_clerknotifyid;
        private System.Windows.Forms.Label lbl_OrderId;
        private System.Windows.Forms.Button btn_clerknotifysubmit;
        private System.Windows.Forms.RadioButton rbtn_NotifyDelivered;
        private System.Windows.Forms.RadioButton rbtn_NotifyEnRoute;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbox_clerksearch;
        private System.Windows.Forms.Label lbl_InventoryStatus;
        private System.Windows.Forms.ComboBox cbx_InventoryStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_ResultsFound;
        private System.Windows.Forms.ComboBox cbx_ResultsList;
        private System.Windows.Forms.Button btn_DeleteFromInventory;
        private System.Windows.Forms.TextBox tbx_QueryInput;
        private System.Windows.Forms.Label lbl_QueryInput;
        private System.Windows.Forms.Label lbl_QueryType;
        private System.Windows.Forms.ComboBox cbx_QueryType;
        private System.Windows.Forms.Button btn_SearchSubmit;
        private System.Windows.Forms.RichTextBox rbox_clerkSearchDisplay;
        private System.Windows.Forms.GroupBox gbx_Notifications;
        private System.Windows.Forms.RichTextBox rbox_ClerkNotifications;
        private System.Windows.Forms.Label lbl_Notifications;
        private System.Windows.Forms.ComboBox cbx_Notifications;
        private System.Windows.Forms.Button btnRefreshNotifications;
        private System.Windows.Forms.Button btn_DeleteNotification;
        private System.Windows.Forms.PictureBox pbx_Logo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_NotificationInstruction2;
        private System.Windows.Forms.Label lbl_NotificationInstruction1;
        private System.Windows.Forms.LinkLabel lnkLogout;
        private System.Windows.Forms.Label label1;

    }
}


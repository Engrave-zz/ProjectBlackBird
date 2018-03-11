namespace WSC
{
    partial class WorkSpecialistForm
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
            this.gbx_InventoryRequest = new System.Windows.Forms.GroupBox();
            this.tbx_OrderId = new System.Windows.Forms.TextBox();
            this.lbl_OrderId = new System.Windows.Forms.Label();
            this.tbx_CatalogId = new System.Windows.Forms.TextBox();
            this.lbl_CatalogId = new System.Windows.Forms.Label();
            this.btn_InventoryRequest = new System.Windows.Forms.Button();
            this.tbx_Quantity = new System.Windows.Forms.TextBox();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.gbx_MarkAsSold = new System.Windows.Forms.GroupBox();
            this.lbl_SoldInstructions3 = new System.Windows.Forms.Label();
            this.lbl_SoldInstructions2 = new System.Windows.Forms.Label();
            this.lbl_SoldInstructions1 = new System.Windows.Forms.Label();
            this.lbl_OrderIdSold = new System.Windows.Forms.Label();
            this.btn_SubmitRequest = new System.Windows.Forms.Button();
            this.tbx_OrderSold = new System.Windows.Forms.TextBox();
            this.btnRefreshNotifications = new System.Windows.Forms.Button();
            this.tmrCheckNotifications = new System.Windows.Forms.Timer(this.components);
            this.gbx_clerksearch = new System.Windows.Forms.GroupBox();
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
            this.btn_DeleteNotificaiton = new System.Windows.Forms.Button();
            this.lbl_NotificationInstruction2 = new System.Windows.Forms.Label();
            this.lbl_NotificationInstruction1 = new System.Windows.Forms.Label();
            this.rbox_ClerkNotifications = new System.Windows.Forms.RichTextBox();
            this.lbl_Notifications = new System.Windows.Forms.Label();
            this.cbx_Notifications = new System.Windows.Forms.ComboBox();
            this.gbx_CompleteOrder = new System.Windows.Forms.GroupBox();
            this.btn_CompleteOrder = new System.Windows.Forms.Button();
            this.tbx_CompleteOrder = new System.Windows.Forms.TextBox();
            this.lbl_CompleteOrder = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.txtViewOrderId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkLogout = new System.Windows.Forms.LinkLabel();
            this.gbx_InventoryRequest.SuspendLayout();
            this.gbx_MarkAsSold.SuspendLayout();
            this.gbx_clerksearch.SuspendLayout();
            this.gbx_Notifications.SuspendLayout();
            this.gbx_CompleteOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_InventoryRequest
            // 
            this.gbx_InventoryRequest.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbx_InventoryRequest.Controls.Add(this.tbx_OrderId);
            this.gbx_InventoryRequest.Controls.Add(this.lbl_OrderId);
            this.gbx_InventoryRequest.Controls.Add(this.tbx_CatalogId);
            this.gbx_InventoryRequest.Controls.Add(this.lbl_CatalogId);
            this.gbx_InventoryRequest.Controls.Add(this.btn_InventoryRequest);
            this.gbx_InventoryRequest.Controls.Add(this.tbx_Quantity);
            this.gbx_InventoryRequest.Controls.Add(this.lbl_Quantity);
            this.gbx_InventoryRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_InventoryRequest.Location = new System.Drawing.Point(653, 58);
            this.gbx_InventoryRequest.Name = "gbx_InventoryRequest";
            this.gbx_InventoryRequest.Size = new System.Drawing.Size(274, 203);
            this.gbx_InventoryRequest.TabIndex = 2;
            this.gbx_InventoryRequest.TabStop = false;
            this.gbx_InventoryRequest.Text = "Inventory Request";
            // 
            // tbx_OrderId
            // 
            this.tbx_OrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_OrderId.Location = new System.Drawing.Point(64, 76);
            this.tbx_OrderId.Name = "tbx_OrderId";
            this.tbx_OrderId.Size = new System.Drawing.Size(198, 18);
            this.tbx_OrderId.TabIndex = 43;
            // 
            // lbl_OrderId
            // 
            this.lbl_OrderId.AutoSize = true;
            this.lbl_OrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OrderId.Location = new System.Drawing.Point(12, 80);
            this.lbl_OrderId.Name = "lbl_OrderId";
            this.lbl_OrderId.Size = new System.Drawing.Size(50, 13);
            this.lbl_OrderId.TabIndex = 42;
            this.lbl_OrderId.Text = "Order ID:";
            // 
            // tbx_CatalogId
            // 
            this.tbx_CatalogId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_CatalogId.Location = new System.Drawing.Point(75, 33);
            this.tbx_CatalogId.Name = "tbx_CatalogId";
            this.tbx_CatalogId.Size = new System.Drawing.Size(187, 20);
            this.tbx_CatalogId.TabIndex = 41;
            // 
            // lbl_CatalogId
            // 
            this.lbl_CatalogId.AutoSize = true;
            this.lbl_CatalogId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CatalogId.Location = new System.Drawing.Point(12, 37);
            this.lbl_CatalogId.Name = "lbl_CatalogId";
            this.lbl_CatalogId.Size = new System.Drawing.Size(60, 13);
            this.lbl_CatalogId.TabIndex = 40;
            this.lbl_CatalogId.Text = "Catalog ID:";
            // 
            // btn_InventoryRequest
            // 
            this.btn_InventoryRequest.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_InventoryRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InventoryRequest.Location = new System.Drawing.Point(72, 160);
            this.btn_InventoryRequest.Name = "btn_InventoryRequest";
            this.btn_InventoryRequest.Size = new System.Drawing.Size(132, 31);
            this.btn_InventoryRequest.TabIndex = 39;
            this.btn_InventoryRequest.Text = "Submit Request";
            this.btn_InventoryRequest.UseVisualStyleBackColor = false;
            this.btn_InventoryRequest.Click += new System.EventHandler(this.btn_InventoryRequest_Click);
            // 
            // tbx_Quantity
            // 
            this.tbx_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Quantity.Location = new System.Drawing.Point(141, 117);
            this.tbx_Quantity.Name = "tbx_Quantity";
            this.tbx_Quantity.Size = new System.Drawing.Size(47, 20);
            this.tbx_Quantity.TabIndex = 38;
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Quantity.Location = new System.Drawing.Point(79, 122);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(46, 13);
            this.lbl_Quantity.TabIndex = 37;
            this.lbl_Quantity.Text = "Quanity:";
            // 
            // gbx_MarkAsSold
            // 
            this.gbx_MarkAsSold.Controls.Add(this.lbl_SoldInstructions3);
            this.gbx_MarkAsSold.Controls.Add(this.lbl_SoldInstructions2);
            this.gbx_MarkAsSold.Controls.Add(this.lbl_SoldInstructions1);
            this.gbx_MarkAsSold.Controls.Add(this.lbl_OrderIdSold);
            this.gbx_MarkAsSold.Controls.Add(this.btn_SubmitRequest);
            this.gbx_MarkAsSold.Controls.Add(this.tbx_OrderSold);
            this.gbx_MarkAsSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_MarkAsSold.Location = new System.Drawing.Point(5, 394);
            this.gbx_MarkAsSold.Name = "gbx_MarkAsSold";
            this.gbx_MarkAsSold.Size = new System.Drawing.Size(264, 124);
            this.gbx_MarkAsSold.TabIndex = 7;
            this.gbx_MarkAsSold.TabStop = false;
            this.gbx_MarkAsSold.Text = "Mark As Sold";
            // 
            // lbl_SoldInstructions3
            // 
            this.lbl_SoldInstructions3.AutoSize = true;
            this.lbl_SoldInstructions3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SoldInstructions3.Location = new System.Drawing.Point(79, 106);
            this.lbl_SoldInstructions3.Name = "lbl_SoldInstructions3";
            this.lbl_SoldInstructions3.Size = new System.Drawing.Size(117, 12);
            this.lbl_SoldInstructions3.TabIndex = 10;
            this.lbl_SoldInstructions3.Text = "and click the submit button.";
            // 
            // lbl_SoldInstructions2
            // 
            this.lbl_SoldInstructions2.AutoSize = true;
            this.lbl_SoldInstructions2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SoldInstructions2.Location = new System.Drawing.Point(63, 95);
            this.lbl_SoldInstructions2.Name = "lbl_SoldInstructions2";
            this.lbl_SoldInstructions2.Size = new System.Drawing.Size(148, 12);
            this.lbl_SoldInstructions2.TabIndex = 10;
            this.lbl_SoldInstructions2.Text = "from drop-down box, enter order ID";
            // 
            // lbl_SoldInstructions1
            // 
            this.lbl_SoldInstructions1.AutoSize = true;
            this.lbl_SoldInstructions1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SoldInstructions1.Location = new System.Drawing.Point(59, 85);
            this.lbl_SoldInstructions1.Name = "lbl_SoldInstructions1";
            this.lbl_SoldInstructions1.Size = new System.Drawing.Size(157, 12);
            this.lbl_SoldInstructions1.TabIndex = 7;
            this.lbl_SoldInstructions1.Text = "To mark an item as \"sold\", select item";
            // 
            // lbl_OrderIdSold
            // 
            this.lbl_OrderIdSold.AutoSize = true;
            this.lbl_OrderIdSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OrderIdSold.Location = new System.Drawing.Point(6, 23);
            this.lbl_OrderIdSold.Name = "lbl_OrderIdSold";
            this.lbl_OrderIdSold.Size = new System.Drawing.Size(53, 13);
            this.lbl_OrderIdSold.TabIndex = 6;
            this.lbl_OrderIdSold.Text = "Order ID :";
            // 
            // btn_SubmitRequest
            // 
            this.btn_SubmitRequest.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_SubmitRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SubmitRequest.Location = new System.Drawing.Point(71, 45);
            this.btn_SubmitRequest.Name = "btn_SubmitRequest";
            this.btn_SubmitRequest.Size = new System.Drawing.Size(132, 31);
            this.btn_SubmitRequest.TabIndex = 2;
            this.btn_SubmitRequest.Text = "Click to Submit";
            this.btn_SubmitRequest.UseVisualStyleBackColor = false;
            this.btn_SubmitRequest.Click += new System.EventHandler(this.btn_SubmitRequest_Click);
            // 
            // tbx_OrderSold
            // 
            this.tbx_OrderSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_OrderSold.Location = new System.Drawing.Point(60, 21);
            this.tbx_OrderSold.Name = "tbx_OrderSold";
            this.tbx_OrderSold.Size = new System.Drawing.Size(198, 18);
            this.tbx_OrderSold.TabIndex = 1;
            // 
            // btnRefreshNotifications
            // 
            this.btnRefreshNotifications.BackColor = System.Drawing.Color.YellowGreen;
            this.btnRefreshNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshNotifications.Location = new System.Drawing.Point(88, 313);
            this.btnRefreshNotifications.Name = "btnRefreshNotifications";
            this.btnRefreshNotifications.Size = new System.Drawing.Size(132, 31);
            this.btnRefreshNotifications.TabIndex = 7;
            this.btnRefreshNotifications.Text = "Refresh Notifications";
            this.btnRefreshNotifications.UseVisualStyleBackColor = false;
            this.btnRefreshNotifications.Click += new System.EventHandler(this.btnRefreshNotifications_Click);
            // 
            // tmrCheckNotifications
            // 
            this.tmrCheckNotifications.Enabled = true;
            this.tmrCheckNotifications.Interval = 10000;
            // 
            // gbx_clerksearch
            // 
            this.gbx_clerksearch.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbx_clerksearch.Controls.Add(this.lbl_InventoryStatus);
            this.gbx_clerksearch.Controls.Add(this.cbx_InventoryStatus);
            this.gbx_clerksearch.Controls.Add(this.label6);
            this.gbx_clerksearch.Controls.Add(this.label8);
            this.gbx_clerksearch.Controls.Add(this.lbl_ResultsFound);
            this.gbx_clerksearch.Controls.Add(this.cbx_ResultsList);
            this.gbx_clerksearch.Controls.Add(this.gbx_MarkAsSold);
            this.gbx_clerksearch.Controls.Add(this.tbx_QueryInput);
            this.gbx_clerksearch.Controls.Add(this.lbl_QueryInput);
            this.gbx_clerksearch.Controls.Add(this.lbl_QueryType);
            this.gbx_clerksearch.Controls.Add(this.cbx_QueryType);
            this.gbx_clerksearch.Controls.Add(this.btn_SearchSubmit);
            this.gbx_clerksearch.Controls.Add(this.rbox_clerkSearchDisplay);
            this.gbx_clerksearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_clerksearch.Location = new System.Drawing.Point(11, 58);
            this.gbx_clerksearch.Name = "gbx_clerksearch";
            this.gbx_clerksearch.Size = new System.Drawing.Size(274, 524);
            this.gbx_clerksearch.TabIndex = 9;
            this.gbx_clerksearch.TabStop = false;
            this.gbx_clerksearch.Text = "Search Inventory";
            // 
            // lbl_InventoryStatus
            // 
            this.lbl_InventoryStatus.AutoSize = true;
            this.lbl_InventoryStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_InventoryStatus.Location = new System.Drawing.Point(18, 77);
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
            this.cbx_InventoryStatus.Location = new System.Drawing.Point(122, 74);
            this.cbx_InventoryStatus.Name = "cbx_InventoryStatus";
            this.cbx_InventoryStatus.Size = new System.Drawing.Size(137, 21);
            this.cbx_InventoryStatus.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 200);
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
            this.lbl_ResultsFound.Location = new System.Drawing.Point(87, 150);
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
            this.cbx_ResultsList.Location = new System.Drawing.Point(22, 174);
            this.cbx_ResultsList.Name = "cbx_ResultsList";
            this.cbx_ResultsList.Size = new System.Drawing.Size(230, 21);
            this.cbx_ResultsList.TabIndex = 9;
            this.cbx_ResultsList.SelectedIndexChanged += new System.EventHandler(this.cbx_ResultsList_SelectedIndexChanged);
            // 
            // tbx_QueryInput
            // 
            this.tbx_QueryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_QueryInput.Location = new System.Drawing.Point(103, 48);
            this.tbx_QueryInput.Name = "tbx_QueryInput";
            this.tbx_QueryInput.Size = new System.Drawing.Size(156, 20);
            this.tbx_QueryInput.TabIndex = 6;
            // 
            // lbl_QueryInput
            // 
            this.lbl_QueryInput.AutoSize = true;
            this.lbl_QueryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QueryInput.Location = new System.Drawing.Point(18, 52);
            this.lbl_QueryInput.Name = "lbl_QueryInput";
            this.lbl_QueryInput.Size = new System.Drawing.Size(68, 13);
            this.lbl_QueryInput.TabIndex = 5;
            this.lbl_QueryInput.Text = "Query Input :";
            // 
            // lbl_QueryType
            // 
            this.lbl_QueryType.AutoSize = true;
            this.lbl_QueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QueryType.Location = new System.Drawing.Point(18, 26);
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
            this.cbx_QueryType.Location = new System.Drawing.Point(103, 22);
            this.cbx_QueryType.Name = "cbx_QueryType";
            this.cbx_QueryType.Size = new System.Drawing.Size(156, 21);
            this.cbx_QueryType.TabIndex = 3;
            // 
            // btn_SearchSubmit
            // 
            this.btn_SearchSubmit.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_SearchSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SearchSubmit.Location = new System.Drawing.Point(71, 108);
            this.btn_SearchSubmit.Name = "btn_SearchSubmit";
            this.btn_SearchSubmit.Size = new System.Drawing.Size(132, 31);
            this.btn_SearchSubmit.TabIndex = 2;
            this.btn_SearchSubmit.Text = "Search";
            this.btn_SearchSubmit.UseVisualStyleBackColor = false;
            this.btn_SearchSubmit.Click += new System.EventHandler(this.btn_SearchSubmit_Click);
            // 
            // rbox_clerkSearchDisplay
            // 
            this.rbox_clerkSearchDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbox_clerkSearchDisplay.ForeColor = System.Drawing.Color.Black;
            this.rbox_clerkSearchDisplay.Location = new System.Drawing.Point(5, 221);
            this.rbox_clerkSearchDisplay.Name = "rbox_clerkSearchDisplay";
            this.rbox_clerkSearchDisplay.Size = new System.Drawing.Size(264, 167);
            this.rbox_clerkSearchDisplay.TabIndex = 2;
            this.rbox_clerkSearchDisplay.Text = "";
            // 
            // gbx_Notifications
            // 
            this.gbx_Notifications.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbx_Notifications.Controls.Add(this.btn_DeleteNotificaiton);
            this.gbx_Notifications.Controls.Add(this.lbl_NotificationInstruction2);
            this.gbx_Notifications.Controls.Add(this.lbl_NotificationInstruction1);
            this.gbx_Notifications.Controls.Add(this.rbox_ClerkNotifications);
            this.gbx_Notifications.Controls.Add(this.lbl_Notifications);
            this.gbx_Notifications.Controls.Add(this.cbx_Notifications);
            this.gbx_Notifications.Controls.Add(this.btnRefreshNotifications);
            this.gbx_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_Notifications.Location = new System.Drawing.Point(321, 58);
            this.gbx_Notifications.Name = "gbx_Notifications";
            this.gbx_Notifications.Size = new System.Drawing.Size(308, 430);
            this.gbx_Notifications.TabIndex = 10;
            this.gbx_Notifications.TabStop = false;
            this.gbx_Notifications.Text = "Notifications";
            // 
            // btn_DeleteNotificaiton
            // 
            this.btn_DeleteNotificaiton.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_DeleteNotificaiton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteNotificaiton.Location = new System.Drawing.Point(88, 370);
            this.btn_DeleteNotificaiton.Name = "btn_DeleteNotificaiton";
            this.btn_DeleteNotificaiton.Size = new System.Drawing.Size(132, 31);
            this.btn_DeleteNotificaiton.TabIndex = 14;
            this.btn_DeleteNotificaiton.Text = "Delete Notification";
            this.btn_DeleteNotificaiton.UseVisualStyleBackColor = false;
            this.btn_DeleteNotificaiton.Click += new System.EventHandler(this.btn_DeleteNotificaiton_Click);
            // 
            // lbl_NotificationInstruction2
            // 
            this.lbl_NotificationInstruction2.AutoSize = true;
            this.lbl_NotificationInstruction2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NotificationInstruction2.Location = new System.Drawing.Point(71, 112);
            this.lbl_NotificationInstruction2.Name = "lbl_NotificationInstruction2";
            this.lbl_NotificationInstruction2.Size = new System.Drawing.Size(167, 12);
            this.lbl_NotificationInstruction2.TabIndex = 13;
            this.lbl_NotificationInstruction2.Text = "to view details in display window below";
            // 
            // lbl_NotificationInstruction1
            // 
            this.lbl_NotificationInstruction1.AutoSize = true;
            this.lbl_NotificationInstruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NotificationInstruction1.Location = new System.Drawing.Point(82, 101);
            this.lbl_NotificationInstruction1.Name = "lbl_NotificationInstruction1";
            this.lbl_NotificationInstruction1.Size = new System.Drawing.Size(144, 12);
            this.lbl_NotificationInstruction1.TabIndex = 12;
            this.lbl_NotificationInstruction1.Text = "select notification from drop-down";
            // 
            // rbox_ClerkNotifications
            // 
            this.rbox_ClerkNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbox_ClerkNotifications.ForeColor = System.Drawing.Color.Black;
            this.rbox_ClerkNotifications.Location = new System.Drawing.Point(7, 145);
            this.rbox_ClerkNotifications.Name = "rbox_ClerkNotifications";
            this.rbox_ClerkNotifications.Size = new System.Drawing.Size(295, 147);
            this.rbox_ClerkNotifications.TabIndex = 11;
            this.rbox_ClerkNotifications.Text = "";
            // 
            // lbl_Notifications
            // 
            this.lbl_Notifications.AutoSize = true;
            this.lbl_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Notifications.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_Notifications.Location = new System.Drawing.Point(64, 40);
            this.lbl_Notifications.Name = "lbl_Notifications";
            this.lbl_Notifications.Size = new System.Drawing.Size(195, 13);
            this.lbl_Notifications.TabIndex = 10;
            this.lbl_Notifications.Text = "You have 22 Total Notification(s)";
            // 
            // cbx_Notifications
            // 
            this.cbx_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Notifications.FormattingEnabled = true;
            this.cbx_Notifications.Location = new System.Drawing.Point(46, 74);
            this.cbx_Notifications.Name = "cbx_Notifications";
            this.cbx_Notifications.Size = new System.Drawing.Size(230, 21);
            this.cbx_Notifications.TabIndex = 9;
            this.cbx_Notifications.SelectedIndexChanged += new System.EventHandler(this.cbx_Notifications_SelectedIndexChanged);
            // 
            // gbx_CompleteOrder
            // 
            this.gbx_CompleteOrder.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbx_CompleteOrder.Controls.Add(this.btn_CompleteOrder);
            this.gbx_CompleteOrder.Controls.Add(this.tbx_CompleteOrder);
            this.gbx_CompleteOrder.Controls.Add(this.lbl_CompleteOrder);
            this.gbx_CompleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_CompleteOrder.Location = new System.Drawing.Point(653, 302);
            this.gbx_CompleteOrder.Name = "gbx_CompleteOrder";
            this.gbx_CompleteOrder.Size = new System.Drawing.Size(274, 118);
            this.gbx_CompleteOrder.TabIndex = 11;
            this.gbx_CompleteOrder.TabStop = false;
            this.gbx_CompleteOrder.Text = "Complete Order";
            // 
            // btn_CompleteOrder
            // 
            this.btn_CompleteOrder.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_CompleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CompleteOrder.Location = new System.Drawing.Point(72, 66);
            this.btn_CompleteOrder.Name = "btn_CompleteOrder";
            this.btn_CompleteOrder.Size = new System.Drawing.Size(132, 31);
            this.btn_CompleteOrder.TabIndex = 46;
            this.btn_CompleteOrder.Text = "Complete Order";
            this.btn_CompleteOrder.UseVisualStyleBackColor = false;
            this.btn_CompleteOrder.Click += new System.EventHandler(this.btn_CompleteOrder_Click);
            // 
            // tbx_CompleteOrder
            // 
            this.tbx_CompleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_CompleteOrder.Location = new System.Drawing.Point(66, 27);
            this.tbx_CompleteOrder.Name = "tbx_CompleteOrder";
            this.tbx_CompleteOrder.Size = new System.Drawing.Size(198, 18);
            this.tbx_CompleteOrder.TabIndex = 45;
            // 
            // lbl_CompleteOrder
            // 
            this.lbl_CompleteOrder.AutoSize = true;
            this.lbl_CompleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CompleteOrder.Location = new System.Drawing.Point(9, 30);
            this.lbl_CompleteOrder.Name = "lbl_CompleteOrder";
            this.lbl_CompleteOrder.Size = new System.Drawing.Size(50, 13);
            this.lbl_CompleteOrder.TabIndex = 44;
            this.lbl_CompleteOrder.Text = "Order ID:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WSC.Properties.Resources.wsc_logo1;
            this.pictureBox1.Location = new System.Drawing.Point(42, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(894, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lnkLogout);
            this.panel1.Controls.Add(this.gbx_InventoryRequest);
            this.panel1.Controls.Add(this.gbx_clerksearch);
            this.panel1.Controls.Add(this.gbx_Notifications);
            this.panel1.Controls.Add(this.gbx_CompleteOrder);
            this.panel1.Location = new System.Drawing.Point(14, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 593);
            this.panel1.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnViewOrder);
            this.groupBox1.Controls.Add(this.txtViewOrderId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(653, 428);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 88);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Order";
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.BackColor = System.Drawing.Color.YellowGreen;
            this.btnViewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewOrder.Location = new System.Drawing.Point(72, 47);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(132, 31);
            this.btnViewOrder.TabIndex = 48;
            this.btnViewOrder.Text = "View Order";
            this.btnViewOrder.UseVisualStyleBackColor = false;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            // 
            // txtViewOrderId
            // 
            this.txtViewOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtViewOrderId.Location = new System.Drawing.Point(69, 22);
            this.txtViewOrderId.Name = "txtViewOrderId";
            this.txtViewOrderId.Size = new System.Drawing.Size(198, 18);
            this.txtViewOrderId.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Order ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 31);
            this.label1.TabIndex = 26;
            this.label1.Text = "Printing / Engraving Specialist Dashboard";
            // 
            // lnkLogout
            // 
            this.lnkLogout.AutoSize = true;
            this.lnkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLogout.Location = new System.Drawing.Point(868, 11);
            this.lnkLogout.Name = "lnkLogout";
            this.lnkLogout.Size = new System.Drawing.Size(59, 20);
            this.lnkLogout.TabIndex = 13;
            this.lnkLogout.TabStop = true;
            this.lnkLogout.Text = "Logout";
            this.lnkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // WorkSpecialistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(978, 742);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "WorkSpecialistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.WorkSpecialistForm_Load);
            this.gbx_InventoryRequest.ResumeLayout(false);
            this.gbx_InventoryRequest.PerformLayout();
            this.gbx_MarkAsSold.ResumeLayout(false);
            this.gbx_MarkAsSold.PerformLayout();
            this.gbx_clerksearch.ResumeLayout(false);
            this.gbx_clerksearch.PerformLayout();
            this.gbx_Notifications.ResumeLayout(false);
            this.gbx_Notifications.PerformLayout();
            this.gbx_CompleteOrder.ResumeLayout(false);
            this.gbx_CompleteOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_InventoryRequest;
        private System.Windows.Forms.Button btn_InventoryRequest;
        private System.Windows.Forms.TextBox tbx_Quantity;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.Button btnRefreshNotifications;
        private System.Windows.Forms.Timer tmrCheckNotifications;
        private System.Windows.Forms.GroupBox gbx_clerksearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_ResultsFound;
        private System.Windows.Forms.ComboBox cbx_ResultsList;
        private System.Windows.Forms.GroupBox gbx_MarkAsSold;
        private System.Windows.Forms.Label lbl_OrderIdSold;
        private System.Windows.Forms.Button btn_SubmitRequest;
        private System.Windows.Forms.TextBox tbx_OrderSold;
        private System.Windows.Forms.TextBox tbx_QueryInput;
        private System.Windows.Forms.Label lbl_QueryInput;
        private System.Windows.Forms.Label lbl_QueryType;
        private System.Windows.Forms.ComboBox cbx_QueryType;
        private System.Windows.Forms.Button btn_SearchSubmit;
        private System.Windows.Forms.RichTextBox rbox_clerkSearchDisplay;
        private System.Windows.Forms.Label lbl_SoldInstructions1;
        private System.Windows.Forms.Label lbl_SoldInstructions2;
        private System.Windows.Forms.Label lbl_SoldInstructions3;
        private System.Windows.Forms.Label lbl_InventoryStatus;
        private System.Windows.Forms.ComboBox cbx_InventoryStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbx_CatalogId;
        private System.Windows.Forms.Label lbl_CatalogId;
        private System.Windows.Forms.GroupBox gbx_Notifications;
        private System.Windows.Forms.Label lbl_Notifications;
        private System.Windows.Forms.ComboBox cbx_Notifications;
        private System.Windows.Forms.RichTextBox rbox_ClerkNotifications;
        private System.Windows.Forms.GroupBox gbx_CompleteOrder;
        private System.Windows.Forms.Button btn_CompleteOrder;
        private System.Windows.Forms.TextBox tbx_CompleteOrder;
        private System.Windows.Forms.Label lbl_CompleteOrder;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbx_OrderId;
        private System.Windows.Forms.Label lbl_OrderId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_DeleteNotificaiton;
        private System.Windows.Forms.Label lbl_NotificationInstruction2;
        private System.Windows.Forms.Label lbl_NotificationInstruction1;
        private System.Windows.Forms.LinkLabel lnkLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnViewOrder;
        private System.Windows.Forms.TextBox txtViewOrderId;
        private System.Windows.Forms.Label label2;

    }
}
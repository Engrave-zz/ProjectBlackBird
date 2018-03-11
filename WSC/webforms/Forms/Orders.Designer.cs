namespace WSC
{
    partial class Orders
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbl_SearchBy = new System.Windows.Forms.Label();
            this.btnMainPage = new System.Windows.Forms.Button();
            this.btnReviewOrder = new System.Windows.Forms.Button();
            this.btnOrderForm = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnDelivered = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSearchFields = new System.Windows.Forms.ComboBox();
            this.btnRefreshGrid = new System.Windows.Forms.Button();
            this.pbx_Logo = new System.Windows.Forms.PictureBox();
            this.gbx_NewSearch = new System.Windows.Forms.GroupBox();
            this.btnOrderSearch = new System.Windows.Forms.Button();
            this.lbl_SearchFor = new System.Windows.Forms.Label();
            this.tbx_Search = new System.Windows.Forms.TextBox();
            this.gbx_RefineResults = new System.Windows.Forms.GroupBox();
            this.lbx_RefineSearch = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).BeginInit();
            this.gbx_NewSearch.SuspendLayout();
            this.gbx_RefineResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(456, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Order List";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(55, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(286, 22);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbl_SearchBy
            // 
            this.lbl_SearchBy.AutoSize = true;
            this.lbl_SearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SearchBy.Location = new System.Drawing.Point(16, 66);
            this.lbl_SearchBy.Name = "lbl_SearchBy";
            this.lbl_SearchBy.Size = new System.Drawing.Size(73, 16);
            this.lbl_SearchBy.TabIndex = 4;
            this.lbl_SearchBy.Text = "Search By:";
            // 
            // btnMainPage
            // 
            this.btnMainPage.BackColor = System.Drawing.Color.YellowGreen;
            this.btnMainPage.Location = new System.Drawing.Point(892, 518);
            this.btnMainPage.Name = "btnMainPage";
            this.btnMainPage.Size = new System.Drawing.Size(117, 30);
            this.btnMainPage.TabIndex = 12;
            this.btnMainPage.Text = "Main Page >>";
            this.btnMainPage.UseVisualStyleBackColor = false;
            this.btnMainPage.Click += new System.EventHandler(this.btnMainPage_Click_1);
            // 
            // btnReviewOrder
            // 
            this.btnReviewOrder.BackColor = System.Drawing.Color.YellowGreen;
            this.btnReviewOrder.Location = new System.Drawing.Point(23, 518);
            this.btnReviewOrder.Name = "btnReviewOrder";
            this.btnReviewOrder.Size = new System.Drawing.Size(117, 30);
            this.btnReviewOrder.TabIndex = 13;
            this.btnReviewOrder.Text = "Review Order Details";
            this.btnReviewOrder.UseVisualStyleBackColor = false;
            this.btnReviewOrder.Click += new System.EventHandler(this.btnReviewOrder_Click);
            // 
            // btnOrderForm
            // 
            this.btnOrderForm.BackColor = System.Drawing.Color.YellowGreen;
            this.btnOrderForm.Location = new System.Drawing.Point(176, 518);
            this.btnOrderForm.Name = "btnOrderForm";
            this.btnOrderForm.Size = new System.Drawing.Size(117, 30);
            this.btnOrderForm.TabIndex = 14;
            this.btnOrderForm.Text = "Create New Order";
            this.btnOrderForm.UseVisualStyleBackColor = false;
            this.btnOrderForm.Click += new System.EventHandler(this.btnOrderForm_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToOrderColumns = true;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(23, 224);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(986, 265);
            this.dgvOrders.TabIndex = 15;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellContentClick);
            // 
            // btnDelivered
            // 
            this.btnDelivered.BackColor = System.Drawing.Color.YellowGreen;
            this.btnDelivered.Location = new System.Drawing.Point(328, 518);
            this.btnDelivered.Name = "btnDelivered";
            this.btnDelivered.Size = new System.Drawing.Size(117, 30);
            this.btnDelivered.TabIndex = 16;
            this.btnDelivered.Text = "Mark as Delivered";
            this.btnDelivered.UseVisualStyleBackColor = false;
            this.btnDelivered.Visible = false;
            this.btnDelivered.Click += new System.EventHandler(this.btnDelivered_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gbx_RefineResults);
            this.panel1.Controls.Add(this.gbx_NewSearch);
            this.panel1.Controls.Add(this.btnRefreshGrid);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnDelivered);
            this.panel1.Controls.Add(this.dgvOrders);
            this.panel1.Controls.Add(this.btnOrderForm);
            this.panel1.Controls.Add(this.btnReviewOrder);
            this.panel1.Controls.Add(this.btnMainPage);
            this.panel1.Location = new System.Drawing.Point(23, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 570);
            this.panel1.TabIndex = 17;
            // 
            // cbSearchFields
            // 
            this.cbSearchFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchFields.FormattingEnabled = true;
            this.cbSearchFields.Items.AddRange(new object[] {
            "Order Id",
            "First Name",
            "Last Name",
            "Entry Date",
            "Fulfilled Date",
            "Number of Items",
            "Order Status"});
            this.cbSearchFields.Location = new System.Drawing.Point(99, 64);
            this.cbSearchFields.Name = "cbSearchFields";
            this.cbSearchFields.Size = new System.Drawing.Size(121, 21);
            this.cbSearchFields.TabIndex = 18;
            // 
            // btnRefreshGrid
            // 
            this.btnRefreshGrid.BackColor = System.Drawing.Color.YellowGreen;
            this.btnRefreshGrid.Location = new System.Drawing.Point(758, 518);
            this.btnRefreshGrid.Name = "btnRefreshGrid";
            this.btnRefreshGrid.Size = new System.Drawing.Size(117, 30);
            this.btnRefreshGrid.TabIndex = 17;
            this.btnRefreshGrid.Text = "Refresh Grid";
            this.btnRefreshGrid.UseVisualStyleBackColor = false;
            this.btnRefreshGrid.Click += new System.EventHandler(this.btnRefreshGrid_Click);
            // 
            // pbx_Logo
            // 
            this.pbx_Logo.Image = global::WSC.Properties.Resources.wsc_logo1;
            this.pbx_Logo.Location = new System.Drawing.Point(0, -1);
            this.pbx_Logo.Name = "pbx_Logo";
            this.pbx_Logo.Size = new System.Drawing.Size(1085, 133);
            this.pbx_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_Logo.TabIndex = 18;
            this.pbx_Logo.TabStop = false;
            // 
            // gbx_NewSearch
            // 
            this.gbx_NewSearch.Controls.Add(this.tbx_Search);
            this.gbx_NewSearch.Controls.Add(this.lbl_SearchFor);
            this.gbx_NewSearch.Controls.Add(this.btnOrderSearch);
            this.gbx_NewSearch.Controls.Add(this.cbSearchFields);
            this.gbx_NewSearch.Controls.Add(this.lbl_SearchBy);
            this.gbx_NewSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_NewSearch.Location = new System.Drawing.Point(615, 92);
            this.gbx_NewSearch.Name = "gbx_NewSearch";
            this.gbx_NewSearch.Size = new System.Drawing.Size(394, 100);
            this.gbx_NewSearch.TabIndex = 19;
            this.gbx_NewSearch.TabStop = false;
            this.gbx_NewSearch.Text = "New Search";
            // 
            // btnOrderSearch
            // 
            this.btnOrderSearch.BackColor = System.Drawing.Color.YellowGreen;
            this.btnOrderSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderSearch.Location = new System.Drawing.Point(273, 62);
            this.btnOrderSearch.Name = "btnOrderSearch";
            this.btnOrderSearch.Size = new System.Drawing.Size(106, 24);
            this.btnOrderSearch.TabIndex = 19;
            this.btnOrderSearch.Text = "Search";
            this.btnOrderSearch.UseVisualStyleBackColor = false;
            this.btnOrderSearch.Click += new System.EventHandler(this.btnOrderSearch_Click);
            // 
            // lbl_SearchFor
            // 
            this.lbl_SearchFor.AutoSize = true;
            this.lbl_SearchFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SearchFor.Location = new System.Drawing.Point(12, 28);
            this.lbl_SearchFor.Name = "lbl_SearchFor";
            this.lbl_SearchFor.Size = new System.Drawing.Size(77, 16);
            this.lbl_SearchFor.TabIndex = 20;
            this.lbl_SearchFor.Text = "Search For:";
            // 
            // tbx_Search
            // 
            this.tbx_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Search.Location = new System.Drawing.Point(99, 26);
            this.tbx_Search.Name = "tbx_Search";
            this.tbx_Search.Size = new System.Drawing.Size(280, 20);
            this.tbx_Search.TabIndex = 21;
            // 
            // gbx_RefineResults
            // 
            this.gbx_RefineResults.Controls.Add(this.lbx_RefineSearch);
            this.gbx_RefineResults.Controls.Add(this.txtSearch);
            this.gbx_RefineResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_RefineResults.Location = new System.Drawing.Point(23, 92);
            this.gbx_RefineResults.Name = "gbx_RefineResults";
            this.gbx_RefineResults.Size = new System.Drawing.Size(394, 100);
            this.gbx_RefineResults.TabIndex = 20;
            this.gbx_RefineResults.TabStop = false;
            this.gbx_RefineResults.Text = "Refine Order List";
            // 
            // lbx_RefineSearch
            // 
            this.lbx_RefineSearch.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lbx_RefineSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbx_RefineSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_RefineSearch.FormattingEnabled = true;
            this.lbx_RefineSearch.ItemHeight = 12;
            this.lbx_RefineSearch.Items.AddRange(new object[] {
            "To refine the displayd list of orders, enter",
            "the desired search criteria in the box above."});
            this.lbx_RefineSearch.Location = new System.Drawing.Point(106, 58);
            this.lbx_RefineSearch.Name = "lbx_RefineSearch";
            this.lbx_RefineSearch.Size = new System.Drawing.Size(184, 24);
            this.lbx_RefineSearch.TabIndex = 4;
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1083, 730);
            this.Controls.Add(this.pbx_Logo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Orders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Orders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).EndInit();
            this.gbx_NewSearch.ResumeLayout(false);
            this.gbx_NewSearch.PerformLayout();
            this.gbx_RefineResults.ResumeLayout(false);
            this.gbx_RefineResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbl_SearchBy;
        private System.Windows.Forms.Button btnMainPage;
        private System.Windows.Forms.Button btnReviewOrder;
        private System.Windows.Forms.Button btnOrderForm;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnDelivered;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbx_Logo;
        private System.Windows.Forms.Button btnRefreshGrid;
        private System.Windows.Forms.ComboBox cbSearchFields;
        private System.Windows.Forms.GroupBox gbx_NewSearch;
        private System.Windows.Forms.Button btnOrderSearch;
        private System.Windows.Forms.TextBox tbx_Search;
        private System.Windows.Forms.Label lbl_SearchFor;
        private System.Windows.Forms.GroupBox gbx_RefineResults;
        private System.Windows.Forms.ListBox lbx_RefineSearch;
    }
}
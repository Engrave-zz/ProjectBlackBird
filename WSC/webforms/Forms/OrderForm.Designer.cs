namespace WSC
{
    partial class OrderForm
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
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtQuote = new System.Windows.Forms.TextBox();
            this.lnkLogout = new System.Windows.Forms.LinkLabel();
            this.cboxOrderStatus = new System.Windows.Forms.ComboBox();
            this.cboxJobType = new System.Windows.Forms.ComboBox();
            this.grpMailingAddress = new System.Windows.Forms.GroupBox();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtZipcode = new System.Windows.Forms.TextBox();
            this.txtStreetNumber = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblStreetName = new System.Windows.Forms.Label();
            this.lblStreetNumber = new System.Windows.Forms.Label();
            this.grpBillingAddress = new System.Windows.Forms.GroupBox();
            this.txtBillingStreetName = new System.Windows.Forms.TextBox();
            this.txtBillingCity = new System.Windows.Forms.TextBox();
            this.txtBillingState = new System.Windows.Forms.TextBox();
            this.txtBillingZipcode = new System.Windows.Forms.TextBox();
            this.txtBillingStreetNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbSameAsMailing = new System.Windows.Forms.CheckBox();
            this.lstOrderItems = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMainPage = new System.Windows.Forms.Button();
            this.gbx_OrderDetails = new System.Windows.Forms.GroupBox();
            this.pbx_Logo = new System.Windows.Forms.PictureBox();
            this.grpMailingAddress.SuspendLayout();
            this.grpBillingAddress.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbx_OrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(86, 70);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(177, 20);
            this.txtCustomer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "OrderID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(310, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Job Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Order Items:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Order Status: ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSave.Location = new System.Drawing.Point(31, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 32);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOrderList
            // 
            this.btnOrderList.BackColor = System.Drawing.Color.YellowGreen;
            this.btnOrderList.Location = new System.Drawing.Point(406, 374);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(117, 32);
            this.btnOrderList.TabIndex = 21;
            this.btnOrderList.Text = "Order List";
            this.btnOrderList.UseVisualStyleBackColor = false;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.BackColor = System.Drawing.Color.YellowGreen;
            this.btnValidate.Location = new System.Drawing.Point(154, 374);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(117, 32);
            this.btnValidate.TabIndex = 18;
            this.btnValidate.Text = "Validate Check List";
            this.btnValidate.UseVisualStyleBackColor = false;
            this.btnValidate.Visible = false;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(283, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Phone Number:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(329, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Email:";
            // 
            // lblOrder
            // 
            this.lblOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.Location = new System.Drawing.Point(87, 37);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(177, 20);
            this.lblOrder.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(259, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(311, 29);
            this.label14.TabIndex = 20;
            this.label14.Text = "Customer Order Information";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(365, 83);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(121, 20);
            this.txtPhoneNumber.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(365, 129);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(121, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(301, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Entry Date: ";
            // 
            // lblDate
            // 
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(365, 37);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(121, 20);
            this.lblDate.TabIndex = 29;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(298, 229);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Quote Price:";
            // 
            // txtQuote
            // 
            this.txtQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuote.Location = new System.Drawing.Point(365, 222);
            this.txtQuote.Name = "txtQuote";
            this.txtQuote.Size = new System.Drawing.Size(121, 20);
            this.txtQuote.TabIndex = 6;
            // 
            // lnkLogout
            // 
            this.lnkLogout.AutoSize = true;
            this.lnkLogout.Location = new System.Drawing.Point(767, 31);
            this.lnkLogout.Name = "lnkLogout";
            this.lnkLogout.Size = new System.Drawing.Size(40, 13);
            this.lnkLogout.TabIndex = 34;
            this.lnkLogout.TabStop = true;
            this.lnkLogout.Text = "Logout";
            this.lnkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // cboxOrderStatus
            // 
            this.cboxOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxOrderStatus.FormattingEnabled = true;
            this.cboxOrderStatus.Items.AddRange(new object[] {
            "Submitted",
            "FailedValidation",
            "WorkComplete",
            "Delivered",
            "EnRoute",
            "Complete",
            "None"});
            this.cboxOrderStatus.Location = new System.Drawing.Point(86, 108);
            this.cboxOrderStatus.Name = "cboxOrderStatus";
            this.cboxOrderStatus.Size = new System.Drawing.Size(177, 21);
            this.cboxOrderStatus.TabIndex = 3;
            // 
            // cboxJobType
            // 
            this.cboxJobType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxJobType.FormattingEnabled = true;
            this.cboxJobType.Items.AddRange(new object[] {
            "Printing",
            "Engraving",
            "Both"});
            this.cboxJobType.Location = new System.Drawing.Point(365, 175);
            this.cboxJobType.Name = "cboxJobType";
            this.cboxJobType.Size = new System.Drawing.Size(121, 21);
            this.cboxJobType.TabIndex = 4;
            // 
            // grpMailingAddress
            // 
            this.grpMailingAddress.Controls.Add(this.txtStreetName);
            this.grpMailingAddress.Controls.Add(this.txtCity);
            this.grpMailingAddress.Controls.Add(this.txtState);
            this.grpMailingAddress.Controls.Add(this.txtZipcode);
            this.grpMailingAddress.Controls.Add(this.txtStreetNumber);
            this.grpMailingAddress.Controls.Add(this.lblZip);
            this.grpMailingAddress.Controls.Add(this.lblState);
            this.grpMailingAddress.Controls.Add(this.lblCity);
            this.grpMailingAddress.Controls.Add(this.lblStreetName);
            this.grpMailingAddress.Controls.Add(this.lblStreetNumber);
            this.grpMailingAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMailingAddress.Location = new System.Drawing.Point(535, 77);
            this.grpMailingAddress.Name = "grpMailingAddress";
            this.grpMailingAddress.Size = new System.Drawing.Size(280, 149);
            this.grpMailingAddress.TabIndex = 43;
            this.grpMailingAddress.TabStop = false;
            this.grpMailingAddress.Text = "Mailing Address";
            // 
            // txtStreetName
            // 
            this.txtStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreetName.Location = new System.Drawing.Point(92, 42);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(180, 20);
            this.txtStreetName.TabIndex = 8;
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(92, 68);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(180, 20);
            this.txtCity.TabIndex = 9;
            // 
            // txtState
            // 
            this.txtState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtState.Location = new System.Drawing.Point(92, 94);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(180, 20);
            this.txtState.TabIndex = 10;
            // 
            // txtZipcode
            // 
            this.txtZipcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZipcode.Location = new System.Drawing.Point(92, 120);
            this.txtZipcode.Name = "txtZipcode";
            this.txtZipcode.Size = new System.Drawing.Size(180, 20);
            this.txtZipcode.TabIndex = 11;
            // 
            // txtStreetNumber
            // 
            this.txtStreetNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreetNumber.Location = new System.Drawing.Point(92, 16);
            this.txtStreetNumber.Name = "txtStreetNumber";
            this.txtStreetNumber.Size = new System.Drawing.Size(180, 20);
            this.txtStreetNumber.TabIndex = 7;
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZip.Location = new System.Drawing.Point(37, 124);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(49, 13);
            this.lblZip.TabIndex = 6;
            this.lblZip.Text = "Zipcode:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(51, 98);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 3;
            this.lblState.Text = "State:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(59, 72);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 2;
            this.lblCity.Text = "City:";
            // 
            // lblStreetName
            // 
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreetName.Location = new System.Drawing.Point(17, 46);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(69, 13);
            this.lblStreetName.TabIndex = 1;
            this.lblStreetName.Text = "Street Name:";
            // 
            // lblStreetNumber
            // 
            this.lblStreetNumber.AutoSize = true;
            this.lblStreetNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreetNumber.Location = new System.Drawing.Point(8, 20);
            this.lblStreetNumber.Name = "lblStreetNumber";
            this.lblStreetNumber.Size = new System.Drawing.Size(78, 13);
            this.lblStreetNumber.TabIndex = 0;
            this.lblStreetNumber.Text = "Street Number:";
            // 
            // grpBillingAddress
            // 
            this.grpBillingAddress.Controls.Add(this.txtBillingStreetName);
            this.grpBillingAddress.Controls.Add(this.txtBillingCity);
            this.grpBillingAddress.Controls.Add(this.txtBillingState);
            this.grpBillingAddress.Controls.Add(this.txtBillingZipcode);
            this.grpBillingAddress.Controls.Add(this.txtBillingStreetNumber);
            this.grpBillingAddress.Controls.Add(this.label5);
            this.grpBillingAddress.Controls.Add(this.label7);
            this.grpBillingAddress.Controls.Add(this.label13);
            this.grpBillingAddress.Controls.Add(this.label16);
            this.grpBillingAddress.Controls.Add(this.label18);
            this.grpBillingAddress.Enabled = false;
            this.grpBillingAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBillingAddress.Location = new System.Drawing.Point(535, 270);
            this.grpBillingAddress.Name = "grpBillingAddress";
            this.grpBillingAddress.Size = new System.Drawing.Size(280, 149);
            this.grpBillingAddress.TabIndex = 44;
            this.grpBillingAddress.TabStop = false;
            this.grpBillingAddress.Text = "Billing Address";
            // 
            // txtBillingStreetName
            // 
            this.txtBillingStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillingStreetName.Location = new System.Drawing.Point(93, 42);
            this.txtBillingStreetName.Name = "txtBillingStreetName";
            this.txtBillingStreetName.Size = new System.Drawing.Size(180, 20);
            this.txtBillingStreetName.TabIndex = 14;
            // 
            // txtBillingCity
            // 
            this.txtBillingCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillingCity.Location = new System.Drawing.Point(93, 68);
            this.txtBillingCity.Name = "txtBillingCity";
            this.txtBillingCity.Size = new System.Drawing.Size(180, 20);
            this.txtBillingCity.TabIndex = 15;
            // 
            // txtBillingState
            // 
            this.txtBillingState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillingState.Location = new System.Drawing.Point(93, 94);
            this.txtBillingState.Name = "txtBillingState";
            this.txtBillingState.Size = new System.Drawing.Size(180, 20);
            this.txtBillingState.TabIndex = 16;
            // 
            // txtBillingZipcode
            // 
            this.txtBillingZipcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillingZipcode.Location = new System.Drawing.Point(93, 120);
            this.txtBillingZipcode.Name = "txtBillingZipcode";
            this.txtBillingZipcode.Size = new System.Drawing.Size(180, 20);
            this.txtBillingZipcode.TabIndex = 17;
            // 
            // txtBillingStreetNumber
            // 
            this.txtBillingStreetNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillingStreetNumber.Location = new System.Drawing.Point(93, 16);
            this.txtBillingStreetNumber.Name = "txtBillingStreetNumber";
            this.txtBillingStreetNumber.Size = new System.Drawing.Size(180, 20);
            this.txtBillingStreetNumber.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Zipcode:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(52, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "State:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(60, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "City:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(18, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "Street Name:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(9, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Street Number:";
            // 
            // cbSameAsMailing
            // 
            this.cbSameAsMailing.AutoSize = true;
            this.cbSameAsMailing.Checked = true;
            this.cbSameAsMailing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSameAsMailing.Location = new System.Drawing.Point(611, 242);
            this.cbSameAsMailing.Name = "cbSameAsMailing";
            this.cbSameAsMailing.Size = new System.Drawing.Size(130, 17);
            this.cbSameAsMailing.TabIndex = 12;
            this.cbSameAsMailing.Text = "Billing same as mailing";
            this.cbSameAsMailing.UseVisualStyleBackColor = true;
            this.cbSameAsMailing.CheckedChanged += new System.EventHandler(this.cbSameAsMailing_CheckedChanged);
            // 
            // lstOrderItems
            // 
            this.lstOrderItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOrderItems.FormattingEnabled = true;
            this.lstOrderItems.Location = new System.Drawing.Point(85, 147);
            this.lstOrderItems.Name = "lstOrderItems";
            this.lstOrderItems.Size = new System.Drawing.Size(177, 95);
            this.lstOrderItems.TabIndex = 45;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.btnMainPage);
            this.panel1.Controls.Add(this.gbx_OrderDetails);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cbSameAsMailing);
            this.panel1.Controls.Add(this.grpBillingAddress);
            this.panel1.Controls.Add(this.grpMailingAddress);
            this.panel1.Controls.Add(this.lnkLogout);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnOrderList);
            this.panel1.Controls.Add(this.btnValidate);
            this.panel1.Location = new System.Drawing.Point(23, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 446);
            this.panel1.TabIndex = 46;
            // 
            // btnMainPage
            // 
            this.btnMainPage.BackColor = System.Drawing.Color.YellowGreen;
            this.btnMainPage.Location = new System.Drawing.Point(283, 374);
            this.btnMainPage.Name = "btnMainPage";
            this.btnMainPage.Size = new System.Drawing.Size(117, 32);
            this.btnMainPage.TabIndex = 47;
            this.btnMainPage.Text = "Main Page";
            this.btnMainPage.UseVisualStyleBackColor = false;
            this.btnMainPage.Click += new System.EventHandler(this.btnMainPage_Click);
            // 
            // gbx_OrderDetails
            // 
            this.gbx_OrderDetails.Controls.Add(this.label2);
            this.gbx_OrderDetails.Controls.Add(this.txtPhoneNumber);
            this.gbx_OrderDetails.Controls.Add(this.lstOrderItems);
            this.gbx_OrderDetails.Controls.Add(this.lblOrder);
            this.gbx_OrderDetails.Controls.Add(this.txtCustomer);
            this.gbx_OrderDetails.Controls.Add(this.txtEmail);
            this.gbx_OrderDetails.Controls.Add(this.label12);
            this.gbx_OrderDetails.Controls.Add(this.label1);
            this.gbx_OrderDetails.Controls.Add(this.label15);
            this.gbx_OrderDetails.Controls.Add(this.label11);
            this.gbx_OrderDetails.Controls.Add(this.lblDate);
            this.gbx_OrderDetails.Controls.Add(this.label17);
            this.gbx_OrderDetails.Controls.Add(this.label3);
            this.gbx_OrderDetails.Controls.Add(this.txtQuote);
            this.gbx_OrderDetails.Controls.Add(this.cboxJobType);
            this.gbx_OrderDetails.Controls.Add(this.label8);
            this.gbx_OrderDetails.Controls.Add(this.label4);
            this.gbx_OrderDetails.Controls.Add(this.cboxOrderStatus);
            this.gbx_OrderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_OrderDetails.Location = new System.Drawing.Point(29, 77);
            this.gbx_OrderDetails.Name = "gbx_OrderDetails";
            this.gbx_OrderDetails.Size = new System.Drawing.Size(494, 255);
            this.gbx_OrderDetails.TabIndex = 46;
            this.gbx_OrderDetails.TabStop = false;
            this.gbx_OrderDetails.Text = "Order Details";
            // 
            // pbx_Logo
            // 
            this.pbx_Logo.Image = global::WSC.Properties.Resources.wsc_logo1;
            this.pbx_Logo.Location = new System.Drawing.Point(0, 0);
            this.pbx_Logo.Name = "pbx_Logo";
            this.pbx_Logo.Size = new System.Drawing.Size(889, 133);
            this.pbx_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_Logo.TabIndex = 47;
            this.pbx_Logo.TabStop = false;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(889, 611);
            this.Controls.Add(this.pbx_Logo);
            this.Controls.Add(this.panel1);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.grpMailingAddress.ResumeLayout(false);
            this.grpMailingAddress.PerformLayout();
            this.grpBillingAddress.ResumeLayout(false);
            this.grpBillingAddress.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbx_OrderDetails.ResumeLayout(false);
            this.gbx_OrderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtQuote;
        private System.Windows.Forms.LinkLabel lnkLogout;
        private System.Windows.Forms.ComboBox cboxOrderStatus;
        private System.Windows.Forms.ComboBox cboxJobType;
        private System.Windows.Forms.GroupBox grpMailingAddress;
        private System.Windows.Forms.Label lblStreetNumber;
        private System.Windows.Forms.GroupBox grpBillingAddress;
        private System.Windows.Forms.CheckBox cbSameAsMailing;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblStreetName;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtZipcode;
        private System.Windows.Forms.TextBox txtStreetNumber;
        private System.Windows.Forms.TextBox txtBillingStreetName;
        private System.Windows.Forms.TextBox txtBillingCity;
        private System.Windows.Forms.TextBox txtBillingState;
        private System.Windows.Forms.TextBox txtBillingZipcode;
        private System.Windows.Forms.TextBox txtBillingStreetNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox lstOrderItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbx_OrderDetails;
        private System.Windows.Forms.PictureBox pbx_Logo;
        private System.Windows.Forms.Button btnMainPage;
    }
}
namespace WSC
{
    partial class NewCustomer
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
            this.chkBillingSameAsMailing = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateCustomer = new System.Windows.Forms.Button();
            this.gbx_BillingAddress = new System.Windows.Forms.GroupBox();
            this.tbx_BillingZipCode = new System.Windows.Forms.TextBox();
            this.tbx_BillingState = new System.Windows.Forms.TextBox();
            this.tbx_BillingCity = new System.Windows.Forms.TextBox();
            this.tbx_BillingStreetName = new System.Windows.Forms.TextBox();
            this.tbx_BillingStreetNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_BillingStreetNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbx_MailingAddress = new System.Windows.Forms.GroupBox();
            this.tbx_MailingZipCode = new System.Windows.Forms.TextBox();
            this.tbx_MailingState = new System.Windows.Forms.TextBox();
            this.tbx_MailingCity = new System.Windows.Forms.TextBox();
            this.tbx_MailingStreetName = new System.Windows.Forms.TextBox();
            this.tbx_MailingStreetNumber = new System.Windows.Forms.TextBox();
            this.lbl_MailingZip = new System.Windows.Forms.Label();
            this.lbl_MailingStreetNumber = new System.Windows.Forms.Label();
            this.lbl_MailingStreetName = new System.Windows.Forms.Label();
            this.lbl_MailingState = new System.Windows.Forms.Label();
            this.lbl_MailingCity = new System.Windows.Forms.Label();
            this.gbx_PersonalInformation = new System.Windows.Forms.GroupBox();
            this.tbx_EMail = new System.Windows.Forms.TextBox();
            this.tbx_PhoneNumber = new System.Windows.Forms.TextBox();
            this.tbx_LastName = new System.Windows.Forms.TextBox();
            this.tbx_FirstName = new System.Windows.Forms.TextBox();
            this.lbl_FirstName = new System.Windows.Forms.Label();
            this.lbl_EMail = new System.Windows.Forms.Label();
            this.lbl_LastName = new System.Windows.Forms.Label();
            this.lbl_PhoneNumber = new System.Windows.Forms.Label();
            this.pbx_Logo = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbx_BillingAddress.SuspendLayout();
            this.gbx_MailingAddress.SuspendLayout();
            this.gbx_PersonalInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.chkBillingSameAsMailing);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCreateCustomer);
            this.panel1.Controls.Add(this.gbx_BillingAddress);
            this.panel1.Controls.Add(this.gbx_MailingAddress);
            this.panel1.Controls.Add(this.gbx_PersonalInformation);
            this.panel1.Location = new System.Drawing.Point(25, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 462);
            this.panel1.TabIndex = 0;
            // 
            // chkBillingSameAsMailing
            // 
            this.chkBillingSameAsMailing.AutoSize = true;
            this.chkBillingSameAsMailing.Location = new System.Drawing.Point(258, 388);
            this.chkBillingSameAsMailing.Name = "chkBillingSameAsMailing";
            this.chkBillingSameAsMailing.Size = new System.Drawing.Size(238, 17);
            this.chkBillingSameAsMailing.TabIndex = 10;
            this.chkBillingSameAsMailing.Text = "Billing address is the same as mailing address";
            this.chkBillingSameAsMailing.UseVisualStyleBackColor = true;
            this.chkBillingSameAsMailing.CheckedChanged += new System.EventHandler(this.chkBillingSameAsMailing_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "New Customer";
            // 
            // btnCreateCustomer
            // 
            this.btnCreateCustomer.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCreateCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCustomer.Location = new System.Drawing.Point(222, 415);
            this.btnCreateCustomer.Name = "btnCreateCustomer";
            this.btnCreateCustomer.Size = new System.Drawing.Size(136, 30);
            this.btnCreateCustomer.TabIndex = 8;
            this.btnCreateCustomer.Text = "Create Customer";
            this.btnCreateCustomer.UseVisualStyleBackColor = false;
            this.btnCreateCustomer.Click += new System.EventHandler(this.btnCreateCustomer_Click);
            // 
            // gbx_BillingAddress
            // 
            this.gbx_BillingAddress.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbx_BillingAddress.Controls.Add(this.tbx_BillingZipCode);
            this.gbx_BillingAddress.Controls.Add(this.tbx_BillingState);
            this.gbx_BillingAddress.Controls.Add(this.tbx_BillingCity);
            this.gbx_BillingAddress.Controls.Add(this.tbx_BillingStreetName);
            this.gbx_BillingAddress.Controls.Add(this.tbx_BillingStreetNumber);
            this.gbx_BillingAddress.Controls.Add(this.label1);
            this.gbx_BillingAddress.Controls.Add(this.lbl_BillingStreetNumber);
            this.gbx_BillingAddress.Controls.Add(this.label3);
            this.gbx_BillingAddress.Controls.Add(this.label4);
            this.gbx_BillingAddress.Controls.Add(this.label5);
            this.gbx_BillingAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_BillingAddress.Location = new System.Drawing.Point(390, 198);
            this.gbx_BillingAddress.Name = "gbx_BillingAddress";
            this.gbx_BillingAddress.Size = new System.Drawing.Size(341, 175);
            this.gbx_BillingAddress.TabIndex = 6;
            this.gbx_BillingAddress.TabStop = false;
            this.gbx_BillingAddress.Text = "Billing Address";
            // 
            // tbx_BillingZipCode
            // 
            this.tbx_BillingZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_BillingZipCode.Location = new System.Drawing.Point(121, 131);
            this.tbx_BillingZipCode.Name = "tbx_BillingZipCode";
            this.tbx_BillingZipCode.Size = new System.Drawing.Size(188, 20);
            this.tbx_BillingZipCode.TabIndex = 9;
            // 
            // tbx_BillingState
            // 
            this.tbx_BillingState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_BillingState.Location = new System.Drawing.Point(121, 105);
            this.tbx_BillingState.Name = "tbx_BillingState";
            this.tbx_BillingState.Size = new System.Drawing.Size(188, 20);
            this.tbx_BillingState.TabIndex = 8;
            // 
            // tbx_BillingCity
            // 
            this.tbx_BillingCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_BillingCity.Location = new System.Drawing.Point(121, 79);
            this.tbx_BillingCity.Name = "tbx_BillingCity";
            this.tbx_BillingCity.Size = new System.Drawing.Size(188, 20);
            this.tbx_BillingCity.TabIndex = 7;
            // 
            // tbx_BillingStreetName
            // 
            this.tbx_BillingStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_BillingStreetName.Location = new System.Drawing.Point(121, 53);
            this.tbx_BillingStreetName.Name = "tbx_BillingStreetName";
            this.tbx_BillingStreetName.Size = new System.Drawing.Size(188, 20);
            this.tbx_BillingStreetName.TabIndex = 6;
            // 
            // tbx_BillingStreetNumber
            // 
            this.tbx_BillingStreetNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_BillingStreetNumber.Location = new System.Drawing.Point(121, 27);
            this.tbx_BillingStreetNumber.Name = "tbx_BillingStreetNumber";
            this.tbx_BillingStreetNumber.Size = new System.Drawing.Size(188, 20);
            this.tbx_BillingStreetNumber.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zip Code:";
            // 
            // lbl_BillingStreetNumber
            // 
            this.lbl_BillingStreetNumber.AutoSize = true;
            this.lbl_BillingStreetNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BillingStreetNumber.Location = new System.Drawing.Point(28, 31);
            this.lbl_BillingStreetNumber.Name = "lbl_BillingStreetNumber";
            this.lbl_BillingStreetNumber.Size = new System.Drawing.Size(78, 13);
            this.lbl_BillingStreetNumber.TabIndex = 0;
            this.lbl_BillingStreetNumber.Text = "Street Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Street Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "State:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(79, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "City:";
            // 
            // gbx_MailingAddress
            // 
            this.gbx_MailingAddress.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbx_MailingAddress.Controls.Add(this.tbx_MailingZipCode);
            this.gbx_MailingAddress.Controls.Add(this.tbx_MailingState);
            this.gbx_MailingAddress.Controls.Add(this.tbx_MailingCity);
            this.gbx_MailingAddress.Controls.Add(this.tbx_MailingStreetName);
            this.gbx_MailingAddress.Controls.Add(this.tbx_MailingStreetNumber);
            this.gbx_MailingAddress.Controls.Add(this.lbl_MailingZip);
            this.gbx_MailingAddress.Controls.Add(this.lbl_MailingStreetNumber);
            this.gbx_MailingAddress.Controls.Add(this.lbl_MailingStreetName);
            this.gbx_MailingAddress.Controls.Add(this.lbl_MailingState);
            this.gbx_MailingAddress.Controls.Add(this.lbl_MailingCity);
            this.gbx_MailingAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_MailingAddress.Location = new System.Drawing.Point(17, 198);
            this.gbx_MailingAddress.Name = "gbx_MailingAddress";
            this.gbx_MailingAddress.Size = new System.Drawing.Size(341, 175);
            this.gbx_MailingAddress.TabIndex = 5;
            this.gbx_MailingAddress.TabStop = false;
            this.gbx_MailingAddress.Text = "Mailing Address";
            // 
            // tbx_MailingZipCode
            // 
            this.tbx_MailingZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_MailingZipCode.Location = new System.Drawing.Point(123, 131);
            this.tbx_MailingZipCode.Name = "tbx_MailingZipCode";
            this.tbx_MailingZipCode.Size = new System.Drawing.Size(188, 20);
            this.tbx_MailingZipCode.TabIndex = 9;
            // 
            // tbx_MailingState
            // 
            this.tbx_MailingState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_MailingState.Location = new System.Drawing.Point(122, 105);
            this.tbx_MailingState.Name = "tbx_MailingState";
            this.tbx_MailingState.Size = new System.Drawing.Size(188, 20);
            this.tbx_MailingState.TabIndex = 8;
            // 
            // tbx_MailingCity
            // 
            this.tbx_MailingCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_MailingCity.Location = new System.Drawing.Point(121, 79);
            this.tbx_MailingCity.Name = "tbx_MailingCity";
            this.tbx_MailingCity.Size = new System.Drawing.Size(188, 20);
            this.tbx_MailingCity.TabIndex = 7;
            // 
            // tbx_MailingStreetName
            // 
            this.tbx_MailingStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_MailingStreetName.Location = new System.Drawing.Point(121, 53);
            this.tbx_MailingStreetName.Name = "tbx_MailingStreetName";
            this.tbx_MailingStreetName.Size = new System.Drawing.Size(188, 20);
            this.tbx_MailingStreetName.TabIndex = 6;
            // 
            // tbx_MailingStreetNumber
            // 
            this.tbx_MailingStreetNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_MailingStreetNumber.Location = new System.Drawing.Point(121, 27);
            this.tbx_MailingStreetNumber.Name = "tbx_MailingStreetNumber";
            this.tbx_MailingStreetNumber.Size = new System.Drawing.Size(188, 20);
            this.tbx_MailingStreetNumber.TabIndex = 5;
            // 
            // lbl_MailingZip
            // 
            this.lbl_MailingZip.AutoSize = true;
            this.lbl_MailingZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MailingZip.Location = new System.Drawing.Point(55, 135);
            this.lbl_MailingZip.Name = "lbl_MailingZip";
            this.lbl_MailingZip.Size = new System.Drawing.Size(53, 13);
            this.lbl_MailingZip.TabIndex = 4;
            this.lbl_MailingZip.Text = "Zip Code:";
            // 
            // lbl_MailingStreetNumber
            // 
            this.lbl_MailingStreetNumber.AutoSize = true;
            this.lbl_MailingStreetNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MailingStreetNumber.Location = new System.Drawing.Point(28, 31);
            this.lbl_MailingStreetNumber.Name = "lbl_MailingStreetNumber";
            this.lbl_MailingStreetNumber.Size = new System.Drawing.Size(78, 13);
            this.lbl_MailingStreetNumber.TabIndex = 0;
            this.lbl_MailingStreetNumber.Text = "Street Number:";
            // 
            // lbl_MailingStreetName
            // 
            this.lbl_MailingStreetName.AutoSize = true;
            this.lbl_MailingStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MailingStreetName.Location = new System.Drawing.Point(37, 57);
            this.lbl_MailingStreetName.Name = "lbl_MailingStreetName";
            this.lbl_MailingStreetName.Size = new System.Drawing.Size(69, 13);
            this.lbl_MailingStreetName.TabIndex = 1;
            this.lbl_MailingStreetName.Text = "Street Name:";
            // 
            // lbl_MailingState
            // 
            this.lbl_MailingState.AutoSize = true;
            this.lbl_MailingState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MailingState.Location = new System.Drawing.Point(72, 109);
            this.lbl_MailingState.Name = "lbl_MailingState";
            this.lbl_MailingState.Size = new System.Drawing.Size(35, 13);
            this.lbl_MailingState.TabIndex = 3;
            this.lbl_MailingState.Text = "State:";
            // 
            // lbl_MailingCity
            // 
            this.lbl_MailingCity.AutoSize = true;
            this.lbl_MailingCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MailingCity.Location = new System.Drawing.Point(79, 83);
            this.lbl_MailingCity.Name = "lbl_MailingCity";
            this.lbl_MailingCity.Size = new System.Drawing.Size(27, 13);
            this.lbl_MailingCity.TabIndex = 2;
            this.lbl_MailingCity.Text = "City:";
            // 
            // gbx_PersonalInformation
            // 
            this.gbx_PersonalInformation.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbx_PersonalInformation.Controls.Add(this.tbx_EMail);
            this.gbx_PersonalInformation.Controls.Add(this.tbx_PhoneNumber);
            this.gbx_PersonalInformation.Controls.Add(this.tbx_LastName);
            this.gbx_PersonalInformation.Controls.Add(this.tbx_FirstName);
            this.gbx_PersonalInformation.Controls.Add(this.lbl_FirstName);
            this.gbx_PersonalInformation.Controls.Add(this.lbl_EMail);
            this.gbx_PersonalInformation.Controls.Add(this.lbl_LastName);
            this.gbx_PersonalInformation.Controls.Add(this.lbl_PhoneNumber);
            this.gbx_PersonalInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_PersonalInformation.Location = new System.Drawing.Point(41, 55);
            this.gbx_PersonalInformation.Name = "gbx_PersonalInformation";
            this.gbx_PersonalInformation.Size = new System.Drawing.Size(666, 116);
            this.gbx_PersonalInformation.TabIndex = 4;
            this.gbx_PersonalInformation.TabStop = false;
            this.gbx_PersonalInformation.Text = "Personal Information";
            // 
            // tbx_EMail
            // 
            this.tbx_EMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_EMail.Location = new System.Drawing.Point(452, 69);
            this.tbx_EMail.Name = "tbx_EMail";
            this.tbx_EMail.Size = new System.Drawing.Size(188, 20);
            this.tbx_EMail.TabIndex = 7;
            // 
            // tbx_PhoneNumber
            // 
            this.tbx_PhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_PhoneNumber.Location = new System.Drawing.Point(121, 69);
            this.tbx_PhoneNumber.Name = "tbx_PhoneNumber";
            this.tbx_PhoneNumber.Size = new System.Drawing.Size(188, 20);
            this.tbx_PhoneNumber.TabIndex = 6;
            // 
            // tbx_LastName
            // 
            this.tbx_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_LastName.Location = new System.Drawing.Point(452, 31);
            this.tbx_LastName.Name = "tbx_LastName";
            this.tbx_LastName.Size = new System.Drawing.Size(188, 20);
            this.tbx_LastName.TabIndex = 5;
            // 
            // tbx_FirstName
            // 
            this.tbx_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_FirstName.Location = new System.Drawing.Point(121, 31);
            this.tbx_FirstName.Name = "tbx_FirstName";
            this.tbx_FirstName.Size = new System.Drawing.Size(188, 20);
            this.tbx_FirstName.TabIndex = 4;
            // 
            // lbl_FirstName
            // 
            this.lbl_FirstName.AutoSize = true;
            this.lbl_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FirstName.Location = new System.Drawing.Point(49, 35);
            this.lbl_FirstName.Name = "lbl_FirstName";
            this.lbl_FirstName.Size = new System.Drawing.Size(57, 13);
            this.lbl_FirstName.TabIndex = 0;
            this.lbl_FirstName.Text = "FirstName:";
            // 
            // lbl_EMail
            // 
            this.lbl_EMail.AutoSize = true;
            this.lbl_EMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EMail.Location = new System.Drawing.Point(357, 73);
            this.lbl_EMail.Name = "lbl_EMail";
            this.lbl_EMail.Size = new System.Drawing.Size(80, 13);
            this.lbl_EMail.TabIndex = 3;
            this.lbl_EMail.Text = "E-Mail Address:";
            // 
            // lbl_LastName
            // 
            this.lbl_LastName.AutoSize = true;
            this.lbl_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LastName.Location = new System.Drawing.Point(376, 35);
            this.lbl_LastName.Name = "lbl_LastName";
            this.lbl_LastName.Size = new System.Drawing.Size(61, 13);
            this.lbl_LastName.TabIndex = 1;
            this.lbl_LastName.Text = "Last Name:";
            // 
            // lbl_PhoneNumber
            // 
            this.lbl_PhoneNumber.AutoSize = true;
            this.lbl_PhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PhoneNumber.Location = new System.Drawing.Point(25, 73);
            this.lbl_PhoneNumber.Name = "lbl_PhoneNumber";
            this.lbl_PhoneNumber.Size = new System.Drawing.Size(81, 13);
            this.lbl_PhoneNumber.TabIndex = 2;
            this.lbl_PhoneNumber.Text = "Phone Number:";
            // 
            // pbx_Logo
            // 
            this.pbx_Logo.Image = global::WSC.Properties.Resources.wsc_logo1;
            this.pbx_Logo.Location = new System.Drawing.Point(0, 0);
            this.pbx_Logo.Name = "pbx_Logo";
            this.pbx_Logo.Size = new System.Drawing.Size(798, 133);
            this.pbx_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_Logo.TabIndex = 1;
            this.pbx_Logo.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(390, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(798, 627);
            this.Controls.Add(this.pbx_Logo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "NewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbx_BillingAddress.ResumeLayout(false);
            this.gbx_BillingAddress.PerformLayout();
            this.gbx_MailingAddress.ResumeLayout(false);
            this.gbx_MailingAddress.PerformLayout();
            this.gbx_PersonalInformation.ResumeLayout(false);
            this.gbx_PersonalInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_LastName;
        private System.Windows.Forms.Label lbl_FirstName;
        private System.Windows.Forms.PictureBox pbx_Logo;
        private System.Windows.Forms.GroupBox gbx_MailingAddress;
        private System.Windows.Forms.Label lbl_MailingState;
        private System.Windows.Forms.Label lbl_MailingCity;
        private System.Windows.Forms.Label lbl_MailingStreetName;
        private System.Windows.Forms.Label lbl_MailingStreetNumber;
        private System.Windows.Forms.GroupBox gbx_PersonalInformation;
        private System.Windows.Forms.TextBox tbx_EMail;
        private System.Windows.Forms.TextBox tbx_PhoneNumber;
        private System.Windows.Forms.TextBox tbx_LastName;
        private System.Windows.Forms.TextBox tbx_FirstName;
        private System.Windows.Forms.Label lbl_EMail;
        private System.Windows.Forms.Label lbl_PhoneNumber;
        private System.Windows.Forms.TextBox tbx_MailingZipCode;
        private System.Windows.Forms.TextBox tbx_MailingState;
        private System.Windows.Forms.TextBox tbx_MailingCity;
        private System.Windows.Forms.TextBox tbx_MailingStreetName;
        private System.Windows.Forms.TextBox tbx_MailingStreetNumber;
        private System.Windows.Forms.Label lbl_MailingZip;
        private System.Windows.Forms.GroupBox gbx_BillingAddress;
        private System.Windows.Forms.TextBox tbx_BillingZipCode;
        private System.Windows.Forms.TextBox tbx_BillingState;
        private System.Windows.Forms.TextBox tbx_BillingCity;
        private System.Windows.Forms.TextBox tbx_BillingStreetName;
        private System.Windows.Forms.TextBox tbx_BillingStreetNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_BillingStreetNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreateCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBillingSameAsMailing;
        private System.Windows.Forms.Button btnCancel;
    }
}
namespace WSC
{
    partial class Checklist
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.chbSpelling = new System.Windows.Forms.CheckBox();
            this.chbCorrectInscriptions = new System.Windows.Forms.CheckBox();
            this.chbDamage = new System.Windows.Forms.CheckBox();
            this.chbMedia = new System.Windows.Forms.CheckBox();
            this.chbAllItems = new System.Windows.Forms.CheckBox();
            this.btnMainPage = new System.Windows.Forms.Button();
            this.pbx_Logo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quality Checklist";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.chbSpelling);
            this.panel1.Controls.Add(this.chbCorrectInscriptions);
            this.panel1.Controls.Add(this.chbDamage);
            this.panel1.Controls.Add(this.chbMedia);
            this.panel1.Controls.Add(this.chbAllItems);
            this.panel1.Controls.Add(this.btnMainPage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(19, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 419);
            this.panel1.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSubmit.Location = new System.Drawing.Point(48, 370);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 28);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit Validation";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // chbSpelling
            // 
            this.chbSpelling.AutoSize = true;
            this.chbSpelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSpelling.Location = new System.Drawing.Point(48, 294);
            this.chbSpelling.Name = "chbSpelling";
            this.chbSpelling.Size = new System.Drawing.Size(360, 24);
            this.chbSpelling.TabIndex = 6;
            this.chbSpelling.Text = "For each item, inscriptions are spelled correctly.";
            this.chbSpelling.UseVisualStyleBackColor = true;
            // 
            // chbCorrectInscriptions
            // 
            this.chbCorrectInscriptions.AutoSize = true;
            this.chbCorrectInscriptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCorrectInscriptions.Location = new System.Drawing.Point(48, 235);
            this.chbCorrectInscriptions.Name = "chbCorrectInscriptions";
            this.chbCorrectInscriptions.Size = new System.Drawing.Size(469, 24);
            this.chbCorrectInscriptions.TabIndex = 5;
            this.chbCorrectInscriptions.Text = "For each item, correct inscriptions was placed on correct items.";
            this.chbCorrectInscriptions.UseVisualStyleBackColor = true;
            // 
            // chbDamage
            // 
            this.chbDamage.AutoSize = true;
            this.chbDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDamage.Location = new System.Drawing.Point(48, 178);
            this.chbDamage.Name = "chbDamage";
            this.chbDamage.Size = new System.Drawing.Size(405, 24);
            this.chbDamage.TabIndex = 4;
            this.chbDamage.Text = "For each item, media is not worn, frayed, or damaged.";
            this.chbDamage.UseVisualStyleBackColor = true;
            // 
            // chbMedia
            // 
            this.chbMedia.AutoSize = true;
            this.chbMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMedia.Location = new System.Drawing.Point(48, 125);
            this.chbMedia.Name = "chbMedia";
            this.chbMedia.Size = new System.Drawing.Size(387, 24);
            this.chbMedia.TabIndex = 3;
            this.chbMedia.Text = "For each item, the correct catalog media was used.";
            this.chbMedia.UseVisualStyleBackColor = true;
            // 
            // chbAllItems
            // 
            this.chbAllItems.AutoSize = true;
            this.chbAllItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllItems.Location = new System.Drawing.Point(48, 71);
            this.chbAllItems.Name = "chbAllItems";
            this.chbAllItems.Size = new System.Drawing.Size(368, 24);
            this.chbAllItems.TabIndex = 2;
            this.chbAllItems.Text = "All items associated with the order are complete.";
            this.chbAllItems.UseVisualStyleBackColor = true;
            // 
            // btnMainPage
            // 
            this.btnMainPage.BackColor = System.Drawing.Color.YellowGreen;
            this.btnMainPage.Location = new System.Drawing.Point(469, 370);
            this.btnMainPage.Name = "btnMainPage";
            this.btnMainPage.Size = new System.Drawing.Size(105, 28);
            this.btnMainPage.TabIndex = 1;
            this.btnMainPage.Text = "Main Page >>";
            this.btnMainPage.UseVisualStyleBackColor = false;
            this.btnMainPage.Click += new System.EventHandler(this.btnMainPage_Click);
            // 
            // pbx_Logo
            // 
            this.pbx_Logo.Image = global::WSC.Properties.Resources.wsc_logo1;
            this.pbx_Logo.Location = new System.Drawing.Point(4, 1);
            this.pbx_Logo.Name = "pbx_Logo";
            this.pbx_Logo.Size = new System.Drawing.Size(640, 133);
            this.pbx_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_Logo.TabIndex = 2;
            this.pbx_Logo.TabStop = false;
            // 
            // Checklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(647, 578);
            this.Controls.Add(this.pbx_Logo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Checklist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMainPage;
        private System.Windows.Forms.PictureBox pbx_Logo;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.CheckBox chbSpelling;
        private System.Windows.Forms.CheckBox chbCorrectInscriptions;
        private System.Windows.Forms.CheckBox chbDamage;
        private System.Windows.Forms.CheckBox chbMedia;
        private System.Windows.Forms.CheckBox chbAllItems;
    }
}
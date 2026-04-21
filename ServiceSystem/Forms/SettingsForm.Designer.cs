namespace ServiceSystem.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpCompany = new System.Windows.Forms.GroupBox();
            this.txtCompanyAddress = new System.Windows.Forms.TextBox();
            this.lblCompanyAddress = new System.Windows.Forms.Label();
            this.txtCompanyPhone = new System.Windows.Forms.TextBox();
            this.lblCompanyPhone = new System.Windows.Forms.Label();
            this.txtCompanyNameKurdish = new System.Windows.Forms.TextBox();
            this.lblCompanyNameKurdish = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.grpInvoice = new System.Windows.Forms.GroupBox();
            this.lblLastInvoiceNumberValue = new System.Windows.Forms.Label();
            this.lblLastInvoiceNumber = new System.Windows.Forms.Label();
            this.txtInvoicePrefix = new System.Windows.Forms.TextBox();
            this.lblInvoicePrefix = new System.Windows.Forms.Label();
            this.grpElectric = new System.Windows.Forms.GroupBox();
            this.txtDefaultElectricPrice = new System.Windows.Forms.TextBox();
            this.lblDefaultElectricPrice = new System.Windows.Forms.Label();
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.txtAutoBackupIntervalDays = new System.Windows.Forms.TextBox();
            this.lblAutoBackupIntervalDays = new System.Windows.Forms.Label();
            this.chkAutoBackupEnabled = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBackupFolderPath = new System.Windows.Forms.TextBox();
            this.lblBackupFolderPath = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.grpCompany.SuspendLayout();
            this.grpInvoice.SuspendLayout();
            this.grpElectric.SuspendLayout();
            this.grpBackup.SuspendLayout();
            this.SuspendLayout();
            //
            // grpCompany
            //
            this.grpCompany.Controls.Add(this.txtCompanyAddress);
            this.grpCompany.Controls.Add(this.lblCompanyAddress);
            this.grpCompany.Controls.Add(this.txtCompanyPhone);
            this.grpCompany.Controls.Add(this.lblCompanyPhone);
            this.grpCompany.Controls.Add(this.txtCompanyNameKurdish);
            this.grpCompany.Controls.Add(this.lblCompanyNameKurdish);
            this.grpCompany.Controls.Add(this.txtCompanyName);
            this.grpCompany.Controls.Add(this.lblCompanyName);
            this.grpCompany.Location = new System.Drawing.Point(15, 15);
            this.grpCompany.Name = "grpCompany";
            this.grpCompany.Size = new System.Drawing.Size(520, 160);
            this.grpCompany.TabIndex = 0;
            this.grpCompany.TabStop = false;
            this.grpCompany.Text = "Company Information";
            //
            // lblCompanyName
            //
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(15, 30);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(82, 13);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "Company Name:";
            //
            // txtCompanyName
            //
            this.txtCompanyName.Location = new System.Drawing.Point(160, 27);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(340, 20);
            this.txtCompanyName.TabIndex = 1;
            //
            // lblCompanyNameKurdish
            //
            this.lblCompanyNameKurdish.AutoSize = true;
            this.lblCompanyNameKurdish.Location = new System.Drawing.Point(15, 60);
            this.lblCompanyNameKurdish.Name = "lblCompanyNameKurdish";
            this.lblCompanyNameKurdish.Size = new System.Drawing.Size(131, 13);
            this.lblCompanyNameKurdish.TabIndex = 2;
            this.lblCompanyNameKurdish.Text = "Company Name (Kurdish):";
            //
            // txtCompanyNameKurdish
            //
            this.txtCompanyNameKurdish.Location = new System.Drawing.Point(160, 57);
            this.txtCompanyNameKurdish.Name = "txtCompanyNameKurdish";
            this.txtCompanyNameKurdish.Size = new System.Drawing.Size(340, 20);
            this.txtCompanyNameKurdish.TabIndex = 3;
            //
            // lblCompanyPhone
            //
            this.lblCompanyPhone.AutoSize = true;
            this.lblCompanyPhone.Location = new System.Drawing.Point(15, 90);
            this.lblCompanyPhone.Name = "lblCompanyPhone";
            this.lblCompanyPhone.Size = new System.Drawing.Size(41, 13);
            this.lblCompanyPhone.TabIndex = 4;
            this.lblCompanyPhone.Text = "Phone:";
            //
            // txtCompanyPhone
            //
            this.txtCompanyPhone.Location = new System.Drawing.Point(160, 87);
            this.txtCompanyPhone.Name = "txtCompanyPhone";
            this.txtCompanyPhone.Size = new System.Drawing.Size(340, 20);
            this.txtCompanyPhone.TabIndex = 5;
            //
            // lblCompanyAddress
            //
            this.lblCompanyAddress.AutoSize = true;
            this.lblCompanyAddress.Location = new System.Drawing.Point(15, 120);
            this.lblCompanyAddress.Name = "lblCompanyAddress";
            this.lblCompanyAddress.Size = new System.Drawing.Size(48, 13);
            this.lblCompanyAddress.TabIndex = 6;
            this.lblCompanyAddress.Text = "Address:";
            //
            // txtCompanyAddress
            //
            this.txtCompanyAddress.Location = new System.Drawing.Point(160, 117);
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.Size = new System.Drawing.Size(340, 20);
            this.txtCompanyAddress.TabIndex = 7;
            //
            // grpInvoice
            //
            this.grpInvoice.Controls.Add(this.lblLastInvoiceNumberValue);
            this.grpInvoice.Controls.Add(this.lblLastInvoiceNumber);
            this.grpInvoice.Controls.Add(this.txtInvoicePrefix);
            this.grpInvoice.Controls.Add(this.lblInvoicePrefix);
            this.grpInvoice.Location = new System.Drawing.Point(15, 185);
            this.grpInvoice.Name = "grpInvoice";
            this.grpInvoice.Size = new System.Drawing.Size(520, 100);
            this.grpInvoice.TabIndex = 1;
            this.grpInvoice.TabStop = false;
            this.grpInvoice.Text = "Invoice Settings";
            //
            // lblInvoicePrefix
            //
            this.lblInvoicePrefix.AutoSize = true;
            this.lblInvoicePrefix.Location = new System.Drawing.Point(15, 30);
            this.lblInvoicePrefix.Name = "lblInvoicePrefix";
            this.lblInvoicePrefix.Size = new System.Drawing.Size(76, 13);
            this.lblInvoicePrefix.TabIndex = 0;
            this.lblInvoicePrefix.Text = "Invoice Prefix:";
            //
            // txtInvoicePrefix
            //
            this.txtInvoicePrefix.Location = new System.Drawing.Point(160, 27);
            this.txtInvoicePrefix.Name = "txtInvoicePrefix";
            this.txtInvoicePrefix.Size = new System.Drawing.Size(120, 20);
            this.txtInvoicePrefix.TabIndex = 1;
            //
            // lblLastInvoiceNumber
            //
            this.lblLastInvoiceNumber.AutoSize = true;
            this.lblLastInvoiceNumber.Location = new System.Drawing.Point(15, 60);
            this.lblLastInvoiceNumber.Name = "lblLastInvoiceNumber";
            this.lblLastInvoiceNumber.Size = new System.Drawing.Size(117, 13);
            this.lblLastInvoiceNumber.TabIndex = 2;
            this.lblLastInvoiceNumber.Text = "Last Invoice Number:";
            //
            // lblLastInvoiceNumberValue
            //
            this.lblLastInvoiceNumberValue.AutoSize = true;
            this.lblLastInvoiceNumberValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblLastInvoiceNumberValue.Location = new System.Drawing.Point(160, 60);
            this.lblLastInvoiceNumberValue.Name = "lblLastInvoiceNumberValue";
            this.lblLastInvoiceNumberValue.Size = new System.Drawing.Size(14, 13);
            this.lblLastInvoiceNumberValue.TabIndex = 3;
            this.lblLastInvoiceNumberValue.Text = "0";
            //
            // grpElectric
            //
            this.grpElectric.Controls.Add(this.txtDefaultElectricPrice);
            this.grpElectric.Controls.Add(this.lblDefaultElectricPrice);
            this.grpElectric.Location = new System.Drawing.Point(15, 295);
            this.grpElectric.Name = "grpElectric";
            this.grpElectric.Size = new System.Drawing.Size(520, 70);
            this.grpElectric.TabIndex = 2;
            this.grpElectric.TabStop = false;
            this.grpElectric.Text = "Electric";
            //
            // lblDefaultElectricPrice
            //
            this.lblDefaultElectricPrice.AutoSize = true;
            this.lblDefaultElectricPrice.Location = new System.Drawing.Point(15, 30);
            this.lblDefaultElectricPrice.Name = "lblDefaultElectricPrice";
            this.lblDefaultElectricPrice.Size = new System.Drawing.Size(138, 13);
            this.lblDefaultElectricPrice.TabIndex = 0;
            this.lblDefaultElectricPrice.Text = "Default Price per Unit ($):";
            //
            // txtDefaultElectricPrice
            //
            this.txtDefaultElectricPrice.Location = new System.Drawing.Point(160, 27);
            this.txtDefaultElectricPrice.Name = "txtDefaultElectricPrice";
            this.txtDefaultElectricPrice.Size = new System.Drawing.Size(120, 20);
            this.txtDefaultElectricPrice.TabIndex = 1;
            //
            // grpBackup
            //
            this.grpBackup.Controls.Add(this.txtAutoBackupIntervalDays);
            this.grpBackup.Controls.Add(this.lblAutoBackupIntervalDays);
            this.grpBackup.Controls.Add(this.chkAutoBackupEnabled);
            this.grpBackup.Controls.Add(this.btnBrowse);
            this.grpBackup.Controls.Add(this.txtBackupFolderPath);
            this.grpBackup.Controls.Add(this.lblBackupFolderPath);
            this.grpBackup.Location = new System.Drawing.Point(15, 375);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(520, 130);
            this.grpBackup.TabIndex = 3;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Backup";
            //
            // lblBackupFolderPath
            //
            this.lblBackupFolderPath.AutoSize = true;
            this.lblBackupFolderPath.Location = new System.Drawing.Point(15, 30);
            this.lblBackupFolderPath.Name = "lblBackupFolderPath";
            this.lblBackupFolderPath.Size = new System.Drawing.Size(78, 13);
            this.lblBackupFolderPath.TabIndex = 0;
            this.lblBackupFolderPath.Text = "Backup Folder:";
            //
            // txtBackupFolderPath
            //
            this.txtBackupFolderPath.Location = new System.Drawing.Point(160, 27);
            this.txtBackupFolderPath.Name = "txtBackupFolderPath";
            this.txtBackupFolderPath.Size = new System.Drawing.Size(260, 20);
            this.txtBackupFolderPath.TabIndex = 1;
            //
            // btnBrowse
            //
            this.btnBrowse.Location = new System.Drawing.Point(426, 25);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 24);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            //
            // chkAutoBackupEnabled
            //
            this.chkAutoBackupEnabled.AutoSize = true;
            this.chkAutoBackupEnabled.Location = new System.Drawing.Point(160, 60);
            this.chkAutoBackupEnabled.Name = "chkAutoBackupEnabled";
            this.chkAutoBackupEnabled.Size = new System.Drawing.Size(136, 17);
            this.chkAutoBackupEnabled.TabIndex = 3;
            this.chkAutoBackupEnabled.Text = "Enable Automatic Backup";
            this.chkAutoBackupEnabled.UseVisualStyleBackColor = true;
            //
            // lblAutoBackupIntervalDays
            //
            this.lblAutoBackupIntervalDays.AutoSize = true;
            this.lblAutoBackupIntervalDays.Location = new System.Drawing.Point(15, 95);
            this.lblAutoBackupIntervalDays.Name = "lblAutoBackupIntervalDays";
            this.lblAutoBackupIntervalDays.Size = new System.Drawing.Size(107, 13);
            this.lblAutoBackupIntervalDays.TabIndex = 4;
            this.lblAutoBackupIntervalDays.Text = "Backup Interval (days):";
            //
            // txtAutoBackupIntervalDays
            //
            this.txtAutoBackupIntervalDays.Location = new System.Drawing.Point(160, 92);
            this.txtAutoBackupIntervalDays.Name = "txtAutoBackupIntervalDays";
            this.txtAutoBackupIntervalDays.Size = new System.Drawing.Size(60, 20);
            this.txtAutoBackupIntervalDays.TabIndex = 5;
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(330, 520);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(440, 520);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // SettingsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 570);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpBackup);
            this.Controls.Add(this.grpElectric);
            this.Controls.Add(this.grpInvoice);
            this.Controls.Add(this.grpCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.grpCompany.ResumeLayout(false);
            this.grpCompany.PerformLayout();
            this.grpInvoice.ResumeLayout(false);
            this.grpInvoice.PerformLayout();
            this.grpElectric.ResumeLayout(false);
            this.grpElectric.PerformLayout();
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpCompany;
        private System.Windows.Forms.TextBox txtCompanyAddress;
        private System.Windows.Forms.Label lblCompanyAddress;
        private System.Windows.Forms.TextBox txtCompanyPhone;
        private System.Windows.Forms.Label lblCompanyPhone;
        private System.Windows.Forms.TextBox txtCompanyNameKurdish;
        private System.Windows.Forms.Label lblCompanyNameKurdish;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.GroupBox grpInvoice;
        private System.Windows.Forms.Label lblLastInvoiceNumberValue;
        private System.Windows.Forms.Label lblLastInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoicePrefix;
        private System.Windows.Forms.Label lblInvoicePrefix;
        private System.Windows.Forms.GroupBox grpElectric;
        private System.Windows.Forms.TextBox txtDefaultElectricPrice;
        private System.Windows.Forms.Label lblDefaultElectricPrice;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.TextBox txtAutoBackupIntervalDays;
        private System.Windows.Forms.Label lblAutoBackupIntervalDays;
        private System.Windows.Forms.CheckBox chkAutoBackupEnabled;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBackupFolderPath;
        private System.Windows.Forms.Label lblBackupFolderPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    }
}

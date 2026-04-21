using System;

namespace ServiceSystem.Forms
{
    partial class MaintenanceForm
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
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.lblBuilding = new System.Windows.Forms.Label();
            this.txtBuilding = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSaveSingle = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblOr = new System.Windows.Forms.Label();
            this.lblBulkTitle = new System.Windows.Forms.Label();
            this.lblBulkMonth = new System.Windows.Forms.Label();
            this.cmbBulkMonth = new System.Windows.Forms.ComboBox();
            this.lblBulkYear = new System.Windows.Forms.Label();
            this.cmbBulkYear = new System.Windows.Forms.ComboBox();
            this.btnGenerateAll = new System.Windows.Forms.Button();
            this.lblBulkDesc = new System.Windows.Forms.Label();
            this.lblBulkAmount = new System.Windows.Forms.Label();
            this.txtBulkAmount = new System.Windows.Forms.TextBox();
            this.txtBulkDesc = new System.Windows.Forms.TextBox();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.btnDeleteBill = new System.Windows.Forms.Button();
            this.lblBillsTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.Location = new System.Drawing.Point(12, -1);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(107, 19);
            this.lblFormTitle.TabIndex = 16;
            this.lblFormTitle.Text = "Add Single Bill";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(22, 35);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 13);
            this.lblUnit.TabIndex = 17;
            this.lblUnit.Text = "Unit:";
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(68, 32);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(156, 21);
            this.cmbUnit.TabIndex = 13;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(22, 68);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(41, 13);
            this.lblOwner.TabIndex = 20;
            this.lblOwner.Text = "Owner:";
            // 
            // txtOwner
            // 
            this.txtOwner.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOwner.Location = new System.Drawing.Point(68, 65);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(156, 20);
            this.txtOwner.TabIndex = 21;
            this.txtOwner.TabStop = false;
            // 
            // lblBuilding
            // 
            this.lblBuilding.AutoSize = true;
            this.lblBuilding.Location = new System.Drawing.Point(22, 111);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(47, 13);
            this.lblBuilding.TabIndex = 23;
            this.lblBuilding.Text = "Building:";
            // 
            // txtBuilding
            // 
            this.txtBuilding.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuilding.Location = new System.Drawing.Point(68, 108);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.ReadOnly = true;
            this.txtBuilding.Size = new System.Drawing.Size(156, 20);
            this.txtBuilding.TabIndex = 25;
            this.txtBuilding.TabStop = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(22, 152);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(55, 13);
            this.lblAmount.TabIndex = 26;
            this.lblAmount.Text = "Amount $:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(83, 149);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 14;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(16, 208);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(40, 13);
            this.lblMonth.TabIndex = 27;
            this.lblMonth.Text = "Month:";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12});
            this.cmbMonth.Location = new System.Drawing.Point(63, 205);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(52, 21);
            this.cmbMonth.TabIndex = 15;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(151, 189);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 28;
            this.lblYear.Text = "Year:";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(144, 205);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(60, 21);
            this.cmbYear.TabIndex = 18;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 255);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(32, 13);
            this.lblDescription.TabIndex = 29;
            this.lblDescription.Text = "Desc";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(68, 240);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(156, 56);
            this.txtDescription.TabIndex = 19;
            // 
            // btnSaveSingle
            // 
            this.btnSaveSingle.Location = new System.Drawing.Point(63, 302);
            this.btnSaveSingle.Name = "btnSaveSingle";
            this.btnSaveSingle.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSingle.TabIndex = 22;
            this.btnSaveSingle.Text = "Save Bill";
            this.btnSaveSingle.UseVisualStyleBackColor = true;
            this.btnSaveSingle.Click += new System.EventHandler(this.btnSaveSingle_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(144, 302);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 23);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Location = new System.Drawing.Point(16, 338);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(189, 13);
            this.lblOr.TabIndex = 33;
            this.lblOr.Text = "── OR ──────────────────";
            // 
            // lblBulkTitle
            // 
            this.lblBulkTitle.AutoSize = true;
            this.lblBulkTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBulkTitle.Location = new System.Drawing.Point(16, 363);
            this.lblBulkTitle.Name = "lblBulkTitle";
            this.lblBulkTitle.Size = new System.Drawing.Size(138, 15);
            this.lblBulkTitle.TabIndex = 34;
            this.lblBulkTitle.Text = "Generate for ALL Units:";
            // 
            // lblBulkMonth
            // 
            this.lblBulkMonth.AutoSize = true;
            this.lblBulkMonth.Location = new System.Drawing.Point(23, 386);
            this.lblBulkMonth.Name = "lblBulkMonth";
            this.lblBulkMonth.Size = new System.Drawing.Size(40, 13);
            this.lblBulkMonth.TabIndex = 35;
            this.lblBulkMonth.Text = "Month:";
            // 
            // cmbBulkMonth
            // 
            this.cmbBulkMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBulkMonth.FormattingEnabled = true;
            this.cmbBulkMonth.Items.AddRange(new object[] {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12});
            this.cmbBulkMonth.Location = new System.Drawing.Point(69, 383);
            this.cmbBulkMonth.Name = "cmbBulkMonth";
            this.cmbBulkMonth.Size = new System.Drawing.Size(52, 21);
            this.cmbBulkMonth.TabIndex = 30;
            // 
            // lblBulkYear
            // 
            this.lblBulkYear.AutoSize = true;
            this.lblBulkYear.Location = new System.Drawing.Point(129, 386);
            this.lblBulkYear.Name = "lblBulkYear";
            this.lblBulkYear.Size = new System.Drawing.Size(32, 13);
            this.lblBulkYear.TabIndex = 36;
            this.lblBulkYear.Text = "Year:";
            // 
            // cmbBulkYear
            // 
            this.cmbBulkYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBulkYear.FormattingEnabled = true;
            this.cmbBulkYear.Location = new System.Drawing.Point(167, 383);
            this.cmbBulkYear.Name = "cmbBulkYear";
            this.cmbBulkYear.Size = new System.Drawing.Size(57, 21);
            this.cmbBulkYear.TabIndex = 31;
            // 
            // btnGenerateAll
            // 
            this.btnGenerateAll.Location = new System.Drawing.Point(68, 506);
            this.btnGenerateAll.Name = "btnGenerateAll";
            this.btnGenerateAll.Size = new System.Drawing.Size(156, 28);
            this.btnGenerateAll.TabIndex = 32;
            this.btnGenerateAll.Text = "Generate Bills for All Units";
            this.btnGenerateAll.UseVisualStyleBackColor = true;
            this.btnGenerateAll.Click += new System.EventHandler(this.btnGenerateAll_Click);
            // 
            // lblBulkDesc
            // 
            this.lblBulkDesc.AutoSize = true;
            this.lblBulkDesc.Location = new System.Drawing.Point(22, 462);
            this.lblBulkDesc.Name = "lblBulkDesc";
            this.lblBulkDesc.Size = new System.Drawing.Size(30, 13);
            this.lblBulkDesc.TabIndex = 37;
            this.lblBulkDesc.Text = "desc";
            // 
            // lblBulkAmount
            // 
            this.lblBulkAmount.AutoSize = true;
            this.lblBulkAmount.Location = new System.Drawing.Point(22, 420);
            this.lblBulkAmount.Name = "lblBulkAmount";
            this.lblBulkAmount.Size = new System.Drawing.Size(42, 13);
            this.lblBulkAmount.TabIndex = 38;
            this.lblBulkAmount.Text = "amount";
            // 
            // txtBulkAmount
            // 
            this.txtBulkAmount.Location = new System.Drawing.Point(69, 417);
            this.txtBulkAmount.Name = "txtBulkAmount";
            this.txtBulkAmount.Size = new System.Drawing.Size(100, 20);
            this.txtBulkAmount.TabIndex = 39;
            // 
            // txtBulkDesc
            // 
            this.txtBulkDesc.Location = new System.Drawing.Point(68, 443);
            this.txtBulkDesc.Multiline = true;
            this.txtBulkDesc.Name = "txtBulkDesc";
            this.txtBulkDesc.Size = new System.Drawing.Size(156, 57);
            this.txtBulkDesc.TabIndex = 40;
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Location = new System.Drawing.Point(266, 35);
            this.dgvBills.MultiSelect = false;
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.Size = new System.Drawing.Size(646, 371);
            this.dgvBills.TabIndex = 41;
            // 
            // btnDeleteBill
            // 
            this.btnDeleteBill.Location = new System.Drawing.Point(266, 412);
            this.btnDeleteBill.Name = "btnDeleteBill";
            this.btnDeleteBill.Size = new System.Drawing.Size(112, 23);
            this.btnDeleteBill.TabIndex = 42;
            this.btnDeleteBill.Text = "Delete Selected";
            this.btnDeleteBill.UseVisualStyleBackColor = true;
            this.btnDeleteBill.Click += new System.EventHandler(this.btnDeleteBill_Click);
            // 
            // lblBillsTitle
            // 
            this.lblBillsTitle.AutoSize = true;
            this.lblBillsTitle.Location = new System.Drawing.Point(263, 9);
            this.lblBillsTitle.Name = "lblBillsTitle";
            this.lblBillsTitle.Size = new System.Drawing.Size(93, 13);
            this.lblBillsTitle.TabIndex = 43;
            this.lblBillsTitle.Text = "Maintenance Bills:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(400, 412);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 546);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.btnDeleteBill);
            this.Controls.Add(this.lblBillsTitle);
            this.Controls.Add(this.txtBulkDesc);
            this.Controls.Add(this.txtBulkAmount);
            this.Controls.Add(this.lblBulkAmount);
            this.Controls.Add(this.lblBulkDesc);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.lblBulkTitle);
            this.Controls.Add(this.lblBulkMonth);
            this.Controls.Add(this.cmbBulkMonth);
            this.Controls.Add(this.lblBulkYear);
            this.Controls.Add(this.cmbBulkYear);
            this.Controls.Add(this.btnGenerateAll);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.lblBuilding);
            this.Controls.Add(this.txtBuilding);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSaveSingle);
            this.Controls.Add(this.btnClear);
            this.Name = "MaintenanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaintenanceForm";
            this.Load += new System.EventHandler(this.MaintenanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSaveSingle;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Label lblBulkTitle;
        private System.Windows.Forms.Label lblBulkMonth;
        private System.Windows.Forms.ComboBox cmbBulkMonth;
        private System.Windows.Forms.Label lblBulkYear;
        private System.Windows.Forms.ComboBox cmbBulkYear;
        private System.Windows.Forms.Button btnGenerateAll;
        private System.Windows.Forms.Label lblBulkDesc;
        private System.Windows.Forms.Label lblBulkAmount;
        private System.Windows.Forms.TextBox txtBulkAmount;
        private System.Windows.Forms.TextBox txtBulkDesc;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.Button btnDeleteBill;
        private System.Windows.Forms.Label lblBillsTitle;
        private System.Windows.Forms.Button btnClose;
    }
}
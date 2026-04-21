namespace ServiceSystem.Forms
{
    partial class MonthlyServiceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.btnDeleteBill = new System.Windows.Forms.Button();
            this.lblBillsTitle = new System.Windows.Forms.Label();
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
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSaveSingle = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblOr = new System.Windows.Forms.Label();
            this.lblBulkTitle = new System.Windows.Forms.Label();
            this.lblBulkMonth = new System.Windows.Forms.Label();
            this.cmbBulkMonth = new System.Windows.Forms.ComboBox();
            this.lblBulkYear = new System.Windows.Forms.Label();
            this.cmbBulkYear = new System.Windows.Forms.ComboBox();
            this.btnGenerateAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Location = new System.Drawing.Point(220, 35);
            this.dgvBills.MultiSelect = false;
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.Size = new System.Drawing.Size(712, 371);
            this.dgvBills.TabIndex = 0;
            // 
            // btnDeleteBill
            // 
            this.btnDeleteBill.Location = new System.Drawing.Point(220, 412);
            this.btnDeleteBill.Name = "btnDeleteBill";
            this.btnDeleteBill.Size = new System.Drawing.Size(112, 23);
            this.btnDeleteBill.TabIndex = 1;
            this.btnDeleteBill.Text = "Delete Selected";
            this.btnDeleteBill.UseVisualStyleBackColor = true;
            this.btnDeleteBill.Click += new System.EventHandler(this.btnDeleteBill_Click);
            // 
            // lblBillsTitle
            // 
            this.lblBillsTitle.AutoSize = true;
            this.lblBillsTitle.Location = new System.Drawing.Point(217, 9);
            this.lblBillsTitle.Name = "lblBillsTitle";
            this.lblBillsTitle.Size = new System.Drawing.Size(78, 13);
            this.lblBillsTitle.TabIndex = 2;
            this.lblBillsTitle.Text = "Bills Recorded:";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.Location = new System.Drawing.Point(55, 13);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(107, 19);
            this.lblFormTitle.TabIndex = 3;
            this.lblFormTitle.Text = "Add Single Bill";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(6, 49);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 13);
            this.lblUnit.TabIndex = 4;
            this.lblUnit.Text = "Unit:";
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(55, 46);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(150, 21);
            this.cmbUnit.TabIndex = 1;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(6, 82);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(41, 13);
            this.lblOwner.TabIndex = 5;
            this.lblOwner.Text = "Owner:";
            // 
            // txtOwner
            // 
            this.txtOwner.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOwner.Location = new System.Drawing.Point(55, 79);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(150, 20);
            this.txtOwner.TabIndex = 6;
            this.txtOwner.TabStop = false;
            // 
            // lblBuilding
            // 
            this.lblBuilding.AutoSize = true;
            this.lblBuilding.Location = new System.Drawing.Point(6, 125);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(47, 13);
            this.lblBuilding.TabIndex = 7;
            this.lblBuilding.Text = "Building:";
            // 
            // txtBuilding
            // 
            this.txtBuilding.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuilding.Location = new System.Drawing.Point(55, 122);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.ReadOnly = true;
            this.txtBuilding.Size = new System.Drawing.Size(150, 20);
            this.txtBuilding.TabIndex = 8;
            this.txtBuilding.TabStop = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(12, 166);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(55, 13);
            this.lblAmount.TabIndex = 9;
            this.lblAmount.Text = "Amount $:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(73, 163);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 2;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(6, 222);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(40, 13);
            this.lblMonth.TabIndex = 10;
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
            this.cmbMonth.Location = new System.Drawing.Point(53, 219);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(52, 21);
            this.cmbMonth.TabIndex = 3;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(112, 222);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 11;
            this.lblYear.Text = "Year:";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(145, 219);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(60, 21);
            this.cmbYear.TabIndex = 4;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 269);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 12;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(53, 266);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(161, 20);
            this.txtNotes.TabIndex = 5;
            // 
            // btnSaveSingle
            // 
            this.btnSaveSingle.Location = new System.Drawing.Point(54, 300);
            this.btnSaveSingle.Name = "btnSaveSingle";
            this.btnSaveSingle.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSingle.TabIndex = 6;
            this.btnSaveSingle.Text = "Save Bill";
            this.btnSaveSingle.UseVisualStyleBackColor = true;
            this.btnSaveSingle.Click += new System.EventHandler(this.btnSaveSingle_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(139, 300);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Location = new System.Drawing.Point(12, 345);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(189, 13);
            this.lblOr.TabIndex = 13;
            this.lblOr.Text = "── OR ──────────────────";
            // 
            // lblBulkTitle
            // 
            this.lblBulkTitle.AutoSize = true;
            this.lblBulkTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBulkTitle.Location = new System.Drawing.Point(12, 370);
            this.lblBulkTitle.Name = "lblBulkTitle";
            this.lblBulkTitle.Size = new System.Drawing.Size(138, 15);
            this.lblBulkTitle.TabIndex = 14;
            this.lblBulkTitle.Text = "Generate for ALL Units:";
            // 
            // lblBulkMonth
            // 
            this.lblBulkMonth.AutoSize = true;
            this.lblBulkMonth.Location = new System.Drawing.Point(19, 393);
            this.lblBulkMonth.Name = "lblBulkMonth";
            this.lblBulkMonth.Size = new System.Drawing.Size(40, 13);
            this.lblBulkMonth.TabIndex = 15;
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
            this.cmbBulkMonth.Location = new System.Drawing.Point(65, 390);
            this.cmbBulkMonth.Name = "cmbBulkMonth";
            this.cmbBulkMonth.Size = new System.Drawing.Size(52, 21);
            this.cmbBulkMonth.TabIndex = 8;
            // 
            // lblBulkYear
            // 
            this.lblBulkYear.AutoSize = true;
            this.lblBulkYear.Location = new System.Drawing.Point(125, 393);
            this.lblBulkYear.Name = "lblBulkYear";
            this.lblBulkYear.Size = new System.Drawing.Size(32, 13);
            this.lblBulkYear.TabIndex = 16;
            this.lblBulkYear.Text = "Year:";
            // 
            // cmbBulkYear
            // 
            this.cmbBulkYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBulkYear.FormattingEnabled = true;
            this.cmbBulkYear.Location = new System.Drawing.Point(162, 390);
            this.cmbBulkYear.Name = "cmbBulkYear";
            this.cmbBulkYear.Size = new System.Drawing.Size(52, 21);
            this.cmbBulkYear.TabIndex = 9;
            // 
            // btnGenerateAll
            // 
            this.btnGenerateAll.Location = new System.Drawing.Point(54, 425);
            this.btnGenerateAll.Name = "btnGenerateAll";
            this.btnGenerateAll.Size = new System.Drawing.Size(161, 28);
            this.btnGenerateAll.TabIndex = 10;
            this.btnGenerateAll.Text = "Generate Bills for All Units";
            this.btnGenerateAll.UseVisualStyleBackColor = true;
            this.btnGenerateAll.Click += new System.EventHandler(this.btnGenerateAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(347, 412);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MonthlyServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 513);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.btnDeleteBill);
            this.Controls.Add(this.lblBillsTitle);
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
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnSaveSingle);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.lblBulkTitle);
            this.Controls.Add(this.lblBulkMonth);
            this.Controls.Add(this.cmbBulkMonth);
            this.Controls.Add(this.lblBulkYear);
            this.Controls.Add(this.cmbBulkYear);
            this.Controls.Add(this.btnGenerateAll);
            this.Name = "MonthlyServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Service Bills";
            this.Load += new System.EventHandler(this.MonthlyServiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.Button       btnDeleteBill;
        private System.Windows.Forms.Label        lblBillsTitle;
        private System.Windows.Forms.Label        lblFormTitle;
        private System.Windows.Forms.Label        lblUnit;
        private System.Windows.Forms.ComboBox     cmbUnit;
        private System.Windows.Forms.Label        lblOwner;
        private System.Windows.Forms.TextBox      txtOwner;
        private System.Windows.Forms.Label        lblBuilding;
        private System.Windows.Forms.TextBox      txtBuilding;
        private System.Windows.Forms.Label        lblAmount;
        private System.Windows.Forms.TextBox      txtAmount;
        private System.Windows.Forms.Label        lblMonth;
        private System.Windows.Forms.ComboBox     cmbMonth;
        private System.Windows.Forms.Label        lblYear;
        private System.Windows.Forms.ComboBox     cmbYear;
        private System.Windows.Forms.Label        lblNotes;
        private System.Windows.Forms.TextBox      txtNotes;
        private System.Windows.Forms.Button       btnSaveSingle;
        private System.Windows.Forms.Button       btnClear;
        private System.Windows.Forms.Label        lblOr;
        private System.Windows.Forms.Label        lblBulkTitle;
        private System.Windows.Forms.Label        lblBulkMonth;
        private System.Windows.Forms.ComboBox     cmbBulkMonth;
        private System.Windows.Forms.Label        lblBulkYear;
        private System.Windows.Forms.ComboBox     cmbBulkYear;
        private System.Windows.Forms.Button       btnGenerateAll;
        private System.Windows.Forms.Button btnClose;
    }
}

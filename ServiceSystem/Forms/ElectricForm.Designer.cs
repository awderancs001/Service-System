namespace ServiceSystem.Forms
{
    partial class ElectricForm
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
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.lblBuilding = new System.Windows.Forms.Label();
            this.txtBuilding = new System.Windows.Forms.TextBox();
            this.lblBeginReading = new System.Windows.Forms.Label();
            this.txtBeginReading = new System.Windows.Forms.TextBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSaveSingle = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtEndReading = new System.Windows.Forms.TextBox();
            this.txtPricePerUnit = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblPricePerUnit = new System.Windows.Forms.Label();
            this.lblEndReading = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.btnDeleteBill = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(3, 15);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 13);
            this.lblUnit.TabIndex = 33;
            this.lblUnit.Text = "Unit:";
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(72, 12);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(156, 21);
            this.cmbUnit.TabIndex = 30;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(3, 48);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(41, 13);
            this.lblOwner.TabIndex = 36;
            this.lblOwner.Text = "Owner:";
            // 
            // txtOwner
            // 
            this.txtOwner.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOwner.Location = new System.Drawing.Point(72, 45);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(156, 20);
            this.txtOwner.TabIndex = 37;
            this.txtOwner.TabStop = false;
            // 
            // lblBuilding
            // 
            this.lblBuilding.AutoSize = true;
            this.lblBuilding.Location = new System.Drawing.Point(3, 91);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(47, 13);
            this.lblBuilding.TabIndex = 39;
            this.lblBuilding.Text = "Building:";
            // 
            // txtBuilding
            // 
            this.txtBuilding.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuilding.Location = new System.Drawing.Point(72, 88);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.ReadOnly = true;
            this.txtBuilding.Size = new System.Drawing.Size(156, 20);
            this.txtBuilding.TabIndex = 41;
            this.txtBuilding.TabStop = false;
            // 
            // lblBeginReading
            // 
            this.lblBeginReading.AutoSize = true;
            this.lblBeginReading.Location = new System.Drawing.Point(3, 132);
            this.lblBeginReading.Name = "lblBeginReading";
            this.lblBeginReading.Size = new System.Drawing.Size(74, 13);
            this.lblBeginReading.TabIndex = 42;
            this.lblBeginReading.Text = "BeginReading";
            // 
            // txtBeginReading
            // 
            this.txtBeginReading.Location = new System.Drawing.Point(83, 129);
            this.txtBeginReading.Name = "txtBeginReading";
            this.txtBeginReading.Size = new System.Drawing.Size(100, 20);
            this.txtBeginReading.TabIndex = 31;
            this.txtBeginReading.TextChanged += new System.EventHandler(this.CalculateTotal);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(72, 290);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(40, 13);
            this.lblMonth.TabIndex = 43;
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
            this.cmbMonth.Location = new System.Drawing.Point(72, 306);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(52, 21);
            this.cmbMonth.TabIndex = 32;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(140, 290);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 44;
            this.lblYear.Text = "Year:";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(143, 306);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(60, 21);
            this.cmbYear.TabIndex = 34;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(3, 340);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 45;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(72, 340);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(156, 56);
            this.txtNotes.TabIndex = 35;
            // 
            // btnSaveSingle
            // 
            this.btnSaveSingle.Location = new System.Drawing.Point(42, 415);
            this.btnSaveSingle.Name = "btnSaveSingle";
            this.btnSaveSingle.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSingle.TabIndex = 38;
            this.btnSaveSingle.Text = "Save Bill";
            this.btnSaveSingle.UseVisualStyleBackColor = true;
            this.btnSaveSingle.Click += new System.EventHandler(this.btnSaveSingle_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(143, 415);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 23);
            this.btnClear.TabIndex = 40;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(3, 309);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 47;
            this.lblDate.Text = "Date";
            // 
            // txtEndReading
            // 
            this.txtEndReading.Location = new System.Drawing.Point(83, 173);
            this.txtEndReading.Name = "txtEndReading";
            this.txtEndReading.Size = new System.Drawing.Size(100, 20);
            this.txtEndReading.TabIndex = 48;
            this.txtEndReading.TextChanged += new System.EventHandler(this.CalculateTotal);
            // 
            // txtPricePerUnit
            // 
            this.txtPricePerUnit.Location = new System.Drawing.Point(83, 212);
            this.txtPricePerUnit.Name = "txtPricePerUnit";
            this.txtPricePerUnit.Size = new System.Drawing.Size(100, 20);
            this.txtPricePerUnit.TabIndex = 49;
            this.txtPricePerUnit.TextChanged += new System.EventHandler(this.CalculateTotal);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTotalAmount.Location = new System.Drawing.Point(83, 248);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAmount.TabIndex = 50;
            this.txtTotalAmount.TabStop = false;
            // 
            // lblPricePerUnit
            // 
            this.lblPricePerUnit.AutoSize = true;
            this.lblPricePerUnit.Location = new System.Drawing.Point(3, 219);
            this.lblPricePerUnit.Name = "lblPricePerUnit";
            this.lblPricePerUnit.Size = new System.Drawing.Size(75, 13);
            this.lblPricePerUnit.TabIndex = 51;
            this.lblPricePerUnit.Text = "PricePerUnit $";
            // 
            // lblEndReading
            // 
            this.lblEndReading.AutoSize = true;
            this.lblEndReading.Location = new System.Drawing.Point(3, 176);
            this.lblEndReading.Name = "lblEndReading";
            this.lblEndReading.Size = new System.Drawing.Size(66, 13);
            this.lblEndReading.TabIndex = 52;
            this.lblEndReading.Text = "EndReading";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(3, 255);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(76, 13);
            this.lblTotalAmount.TabIndex = 53;
            this.lblTotalAmount.Text = "TotalAmount $";
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Location = new System.Drawing.Point(269, 28);
            this.dgvBills.MultiSelect = false;
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.Size = new System.Drawing.Size(735, 381);
            this.dgvBills.TabIndex = 54;
            // 
            // btnDeleteBill
            // 
            this.btnDeleteBill.Location = new System.Drawing.Point(269, 415);
            this.btnDeleteBill.Name = "btnDeleteBill";
            this.btnDeleteBill.Size = new System.Drawing.Size(122, 23);
            this.btnDeleteBill.TabIndex = 55;
            this.btnDeleteBill.Text = "Delete Selected";
            this.btnDeleteBill.UseVisualStyleBackColor = true;
            this.btnDeleteBill.Click += new System.EventHandler(this.btnDeleteBill_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Electric Bills:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(407, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ElectricForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 458);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteBill);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblEndReading);
            this.Controls.Add(this.lblPricePerUnit);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtPricePerUnit);
            this.Controls.Add(this.txtEndReading);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.lblBuilding);
            this.Controls.Add(this.txtBuilding);
            this.Controls.Add(this.lblBeginReading);
            this.Controls.Add(this.txtBeginReading);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnSaveSingle);
            this.Controls.Add(this.btnClear);
            this.Name = "ElectricForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ElectricForm";
            this.Load += new System.EventHandler(this.ElectricForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.Label lblBeginReading;
        private System.Windows.Forms.TextBox txtBeginReading;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSaveSingle;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtEndReading;
        private System.Windows.Forms.TextBox txtPricePerUnit;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblPricePerUnit;
        private System.Windows.Forms.Label lblEndReading;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.Button btnDeleteBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}
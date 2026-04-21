namespace ServiceSystem.Forms
{
    partial class ReceiveMoneyForm
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
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.grpNewPayment = new System.Windows.Forms.GroupBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblBalanceTitle = new System.Windows.Forms.Label();
            this.lblTotalPaid = new System.Windows.Forms.Label();
            this.lblTotalPaidTitle = new System.Windows.Forms.Label();
            this.lblTotalDebt = new System.Windows.Forms.Label();
            this.lblTotalDebtTitle = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblToYearLabel = new System.Windows.Forms.Label();
            this.lblToMonthLabel = new System.Windows.Forms.Label();
            this.cmbToYear = new System.Windows.Forms.ComboBox();
            this.cmbToMonth = new System.Windows.Forms.ComboBox();
            this.lblFromYearLabel = new System.Windows.Forms.Label();
            this.lblFromMonthLabel = new System.Windows.Forms.Label();
            this.cmbForYear = new System.Windows.Forms.ComboBox();
            this.cmbForMonth = new System.Windows.Forms.ComboBox();
            this.txtBuilding = new System.Windows.Forms.TextBox();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblToMonth = new System.Windows.Forms.Label();
            this.lblFromMonth = new System.Windows.Forms.Label();
            this.lblBuilding = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpSearch.SuspendLayout();
            this.grpNewPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.lblSearch);
            this.grpSearch.Location = new System.Drawing.Point(241, 28);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(317, 58);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(244, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(61, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(7, 30);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search: ";
            // 
            // grpNewPayment
            // 
            this.grpNewPayment.Controls.Add(this.lblBalance);
            this.grpNewPayment.Controls.Add(this.lblBalanceTitle);
            this.grpNewPayment.Controls.Add(this.lblTotalPaid);
            this.grpNewPayment.Controls.Add(this.lblTotalPaidTitle);
            this.grpNewPayment.Controls.Add(this.lblTotalDebt);
            this.grpNewPayment.Controls.Add(this.lblTotalDebtTitle);
            this.grpNewPayment.Controls.Add(this.txtAmount);
            this.grpNewPayment.Controls.Add(this.lblAmount);
            this.grpNewPayment.Controls.Add(this.txtComment);
            this.grpNewPayment.Controls.Add(this.lblToYearLabel);
            this.grpNewPayment.Controls.Add(this.lblToMonthLabel);
            this.grpNewPayment.Controls.Add(this.cmbToYear);
            this.grpNewPayment.Controls.Add(this.cmbToMonth);
            this.grpNewPayment.Controls.Add(this.lblFromYearLabel);
            this.grpNewPayment.Controls.Add(this.lblFromMonthLabel);
            this.grpNewPayment.Controls.Add(this.cmbForYear);
            this.grpNewPayment.Controls.Add(this.cmbForMonth);
            this.grpNewPayment.Controls.Add(this.txtBuilding);
            this.grpNewPayment.Controls.Add(this.txtOwner);
            this.grpNewPayment.Controls.Add(this.cmbUnit);
            this.grpNewPayment.Controls.Add(this.lblComment);
            this.grpNewPayment.Controls.Add(this.lblToMonth);
            this.grpNewPayment.Controls.Add(this.lblFromMonth);
            this.grpNewPayment.Controls.Add(this.lblBuilding);
            this.grpNewPayment.Controls.Add(this.lblOwner);
            this.grpNewPayment.Controls.Add(this.lblUnit);
            this.grpNewPayment.Location = new System.Drawing.Point(22, 92);
            this.grpNewPayment.Name = "grpNewPayment";
            this.grpNewPayment.Size = new System.Drawing.Size(210, 470);
            this.grpNewPayment.TabIndex = 1;
            this.grpNewPayment.TabStop = false;
            this.grpNewPayment.Text = "New Payment";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBalance.Location = new System.Drawing.Point(95, 415);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(35, 16);
            this.lblBalance.TabIndex = 25;
            this.lblBalance.Text = "0.00";
            // 
            // lblBalanceTitle
            // 
            this.lblBalanceTitle.AutoSize = true;
            this.lblBalanceTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBalanceTitle.Location = new System.Drawing.Point(9, 415);
            this.lblBalanceTitle.Name = "lblBalanceTitle";
            this.lblBalanceTitle.Size = new System.Drawing.Size(57, 13);
            this.lblBalanceTitle.TabIndex = 24;
            this.lblBalanceTitle.Text = "Balance:";
            // 
            // lblTotalPaid
            // 
            this.lblTotalPaid.AutoSize = true;
            this.lblTotalPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalPaid.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTotalPaid.Location = new System.Drawing.Point(95, 385);
            this.lblTotalPaid.Name = "lblTotalPaid";
            this.lblTotalPaid.Size = new System.Drawing.Size(32, 13);
            this.lblTotalPaid.TabIndex = 23;
            this.lblTotalPaid.Text = "0.00";
            // 
            // lblTotalPaidTitle
            // 
            this.lblTotalPaidTitle.AutoSize = true;
            this.lblTotalPaidTitle.Location = new System.Drawing.Point(9, 385);
            this.lblTotalPaidTitle.Name = "lblTotalPaidTitle";
            this.lblTotalPaidTitle.Size = new System.Drawing.Size(58, 13);
            this.lblTotalPaidTitle.TabIndex = 22;
            this.lblTotalPaidTitle.Text = "Total Paid:";
            // 
            // lblTotalDebt
            // 
            this.lblTotalDebt.AutoSize = true;
            this.lblTotalDebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalDebt.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTotalDebt.Location = new System.Drawing.Point(95, 360);
            this.lblTotalDebt.Name = "lblTotalDebt";
            this.lblTotalDebt.Size = new System.Drawing.Size(32, 13);
            this.lblTotalDebt.TabIndex = 21;
            this.lblTotalDebt.Text = "0.00";
            // 
            // lblTotalDebtTitle
            // 
            this.lblTotalDebtTitle.AutoSize = true;
            this.lblTotalDebtTitle.Location = new System.Drawing.Point(9, 360);
            this.lblTotalDebtTitle.Name = "lblTotalDebtTitle";
            this.lblTotalDebtTitle.Size = new System.Drawing.Size(60, 13);
            this.lblTotalDebtTitle.TabIndex = 20;
            this.lblTotalDebtTitle.Text = "Total Debt:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(72, 117);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 7;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(9, 120);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(55, 13);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Amount $:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(66, 250);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(131, 64);
            this.txtComment.TabIndex = 19;
            // 
            // lblToYearLabel
            // 
            this.lblToYearLabel.AutoSize = true;
            this.lblToYearLabel.Location = new System.Drawing.Point(144, 200);
            this.lblToYearLabel.Name = "lblToYearLabel";
            this.lblToYearLabel.Size = new System.Drawing.Size(29, 13);
            this.lblToYearLabel.TabIndex = 16;
            this.lblToYearLabel.Text = "Year";
            // 
            // lblToMonthLabel
            // 
            this.lblToMonthLabel.AutoSize = true;
            this.lblToMonthLabel.Location = new System.Drawing.Point(78, 200);
            this.lblToMonthLabel.Name = "lblToMonthLabel";
            this.lblToMonthLabel.Size = new System.Drawing.Size(37, 13);
            this.lblToMonthLabel.TabIndex = 14;
            this.lblToMonthLabel.Text = "Month";
            // 
            // cmbToYear
            // 
            this.cmbToYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToYear.FormattingEnabled = true;
            this.cmbToYear.Location = new System.Drawing.Point(137, 216);
            this.cmbToYear.Name = "cmbToYear";
            this.cmbToYear.Size = new System.Drawing.Size(57, 21);
            this.cmbToYear.TabIndex = 17;
            // 
            // cmbToMonth
            // 
            this.cmbToMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToMonth.FormattingEnabled = true;
            this.cmbToMonth.Items.AddRange(new object[] {
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
            this.cmbToMonth.Location = new System.Drawing.Point(81, 216);
            this.cmbToMonth.Name = "cmbToMonth";
            this.cmbToMonth.Size = new System.Drawing.Size(47, 21);
            this.cmbToMonth.TabIndex = 15;
            // 
            // lblFromYearLabel
            // 
            this.lblFromYearLabel.AutoSize = true;
            this.lblFromYearLabel.Location = new System.Drawing.Point(144, 150);
            this.lblFromYearLabel.Name = "lblFromYearLabel";
            this.lblFromYearLabel.Size = new System.Drawing.Size(29, 13);
            this.lblFromYearLabel.TabIndex = 11;
            this.lblFromYearLabel.Text = "Year";
            // 
            // lblFromMonthLabel
            // 
            this.lblFromMonthLabel.AutoSize = true;
            this.lblFromMonthLabel.Location = new System.Drawing.Point(78, 150);
            this.lblFromMonthLabel.Name = "lblFromMonthLabel";
            this.lblFromMonthLabel.Size = new System.Drawing.Size(37, 13);
            this.lblFromMonthLabel.TabIndex = 9;
            this.lblFromMonthLabel.Text = "Month";
            // 
            // cmbForYear
            // 
            this.cmbForYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbForYear.FormattingEnabled = true;
            this.cmbForYear.Location = new System.Drawing.Point(137, 166);
            this.cmbForYear.Name = "cmbForYear";
            this.cmbForYear.Size = new System.Drawing.Size(57, 21);
            this.cmbForYear.TabIndex = 12;
            // 
            // cmbForMonth
            // 
            this.cmbForMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbForMonth.FormattingEnabled = true;
            this.cmbForMonth.Items.AddRange(new object[] {
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
            this.cmbForMonth.Location = new System.Drawing.Point(81, 166);
            this.cmbForMonth.Name = "cmbForMonth";
            this.cmbForMonth.Size = new System.Drawing.Size(47, 21);
            this.cmbForMonth.TabIndex = 10;
            // 
            // txtBuilding
            // 
            this.txtBuilding.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuilding.Location = new System.Drawing.Point(63, 87);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.ReadOnly = true;
            this.txtBuilding.Size = new System.Drawing.Size(131, 20);
            this.txtBuilding.TabIndex = 5;
            this.txtBuilding.TabStop = false;
            // 
            // txtOwner
            // 
            this.txtOwner.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOwner.Location = new System.Drawing.Point(63, 57);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(131, 20);
            this.txtOwner.TabIndex = 3;
            this.txtOwner.TabStop = false;
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(63, 27);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(131, 21);
            this.cmbUnit.TabIndex = 1;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(9, 250);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(54, 13);
            this.lblComment.TabIndex = 18;
            this.lblComment.Text = "Comment:";
            // 
            // lblToMonth
            // 
            this.lblToMonth.AutoSize = true;
            this.lblToMonth.Location = new System.Drawing.Point(9, 200);
            this.lblToMonth.Name = "lblToMonth";
            this.lblToMonth.Size = new System.Drawing.Size(77, 13);
            this.lblToMonth.TabIndex = 13;
            this.lblToMonth.Text = "To Month (opt)";
            // 
            // lblFromMonth
            // 
            this.lblFromMonth.AutoSize = true;
            this.lblFromMonth.Location = new System.Drawing.Point(9, 150);
            this.lblFromMonth.Name = "lblFromMonth";
            this.lblFromMonth.Size = new System.Drawing.Size(63, 13);
            this.lblFromMonth.TabIndex = 8;
            this.lblFromMonth.Text = "From Month";
            // 
            // lblBuilding
            // 
            this.lblBuilding.AutoSize = true;
            this.lblBuilding.Location = new System.Drawing.Point(9, 90);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(47, 13);
            this.lblBuilding.TabIndex = 4;
            this.lblBuilding.Text = "Building:";
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(9, 60);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(41, 13);
            this.lblOwner.TabIndex = 2;
            this.lblOwner.Text = "Owner:";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(9, 30);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 13);
            this.lblUnit.TabIndex = 0;
            this.lblUnit.Text = "Unit:";
            // 
            // dgvPayments
            // 
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Location = new System.Drawing.Point(241, 92);
            this.dgvPayments.MultiSelect = false;
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayments.Size = new System.Drawing.Size(758, 341);
            this.dgvPayments.TabIndex = 2;
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.Location = new System.Drawing.Point(238, 436);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(203, 13);
            this.lblHistoryTitle.TabIndex = 7;
            this.lblHistoryTitle.Text = "Unit History — select a unit to view";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(238, 452);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(761, 110);
            this.dgvHistory.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(256, 582);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(34, 582);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save Payment";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(129, 582);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 29);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Location = new System.Drawing.Point(360, 582);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(95, 29);
            this.btnPrintInvoice.TabIndex = 6;
            this.btnPrintInvoice.Text = "Print Invoice";
            this.btnPrintInvoice.UseVisualStyleBackColor = true;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(470, 582);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReceiveMoneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 644);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrintInvoice);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.lblHistoryTitle);
            this.Controls.Add(this.dgvPayments);
            this.Controls.Add(this.grpNewPayment);
            this.Controls.Add(this.grpSearch);
            this.Name = "ReceiveMoneyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receive Money";
            this.Load += new System.EventHandler(this.ReceiveMoneyForm_Load);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpNewPayment.ResumeLayout(false);
            this.grpNewPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox grpNewPayment;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblFromMonth;
        private System.Windows.Forms.Label lblFromMonthLabel;
        private System.Windows.Forms.ComboBox cmbForMonth;
        private System.Windows.Forms.Label lblFromYearLabel;
        private System.Windows.Forms.ComboBox cmbForYear;
        private System.Windows.Forms.Label lblToMonth;
        private System.Windows.Forms.Label lblToMonthLabel;
        private System.Windows.Forms.ComboBox cmbToMonth;
        private System.Windows.Forms.Label lblToYearLabel;
        private System.Windows.Forms.ComboBox cmbToYear;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblTotalDebtTitle;
        private System.Windows.Forms.Label lblTotalDebt;
        private System.Windows.Forms.Label lblTotalPaidTitle;
        private System.Windows.Forms.Label lblTotalPaid;
        private System.Windows.Forms.Label lblBalanceTitle;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Button btnClose;
    }
}

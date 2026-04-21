namespace ServiceSystem.Forms
{
    partial class ReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.lblReportType = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.btnDefaultDate = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblBillTypes = new System.Windows.Forms.Label();
            this.chkService = new System.Windows.Forms.CheckBox();
            this.chkMaintenance = new System.Windows.Forms.CheckBox();
            this.chkElectric = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblSummary = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Location = new System.Drawing.Point(20, 23);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(69, 13);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "Report Type:";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(115, 20);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(250, 21);
            this.cmbReportType.TabIndex = 1;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.btnDefaultDate);
            this.grpFilters.Controls.Add(this.cmbUnit);
            this.grpFilters.Controls.Add(this.lblUnit);
            this.grpFilters.Controls.Add(this.lblFrom);
            this.grpFilters.Controls.Add(this.dtpFrom);
            this.grpFilters.Controls.Add(this.lblTo);
            this.grpFilters.Controls.Add(this.dtpTo);
            this.grpFilters.Controls.Add(this.lblBillTypes);
            this.grpFilters.Controls.Add(this.chkService);
            this.grpFilters.Controls.Add(this.chkMaintenance);
            this.grpFilters.Controls.Add(this.chkElectric);
            this.grpFilters.Controls.Add(this.btnGenerate);
            this.grpFilters.Location = new System.Drawing.Point(20, 55);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(850, 110);
            this.grpFilters.TabIndex = 2;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filters";
            this.grpFilters.Enter += new System.EventHandler(this.grpFilters_Enter);
            // 
            // btnDefaultDate
            // 
            this.btnDefaultDate.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDefaultDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefaultDate.ForeColor = System.Drawing.Color.White;
            this.btnDefaultDate.Location = new System.Drawing.Point(714, 23);
            this.btnDefaultDate.Name = "btnDefaultDate";
            this.btnDefaultDate.Size = new System.Drawing.Size(130, 30);
            this.btnDefaultDate.TabIndex = 11;
            this.btnDefaultDate.Text = "Default Date";
            this.btnDefaultDate.UseVisualStyleBackColor = false;
            this.btnDefaultDate.Click += new System.EventHandler(this.btnDefaultDate_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(490, 28);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(200, 21);
            this.cmbUnit.TabIndex = 10;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(450, 32);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(32, 13);
            this.lblUnit.TabIndex = 9;
            this.lblUnit.Text = "Unit: ";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(20, 32);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(75, 28);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowUpDown = true;
            this.dtpFrom.Size = new System.Drawing.Size(150, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(245, 32);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(280, 28);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowUpDown = true;
            this.dtpTo.Size = new System.Drawing.Size(150, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblBillTypes
            // 
            this.lblBillTypes.AutoSize = true;
            this.lblBillTypes.Location = new System.Drawing.Point(20, 70);
            this.lblBillTypes.Name = "lblBillTypes";
            this.lblBillTypes.Size = new System.Drawing.Size(55, 13);
            this.lblBillTypes.TabIndex = 4;
            this.lblBillTypes.Text = "Bill Types:";
            // 
            // chkService
            // 
            this.chkService.AutoSize = true;
            this.chkService.Checked = true;
            this.chkService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkService.Location = new System.Drawing.Point(95, 69);
            this.chkService.Name = "chkService";
            this.chkService.Size = new System.Drawing.Size(62, 17);
            this.chkService.TabIndex = 5;
            this.chkService.Text = "Service";
            this.chkService.UseVisualStyleBackColor = true;
            // 
            // chkMaintenance
            // 
            this.chkMaintenance.AutoSize = true;
            this.chkMaintenance.Checked = true;
            this.chkMaintenance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMaintenance.Location = new System.Drawing.Point(180, 69);
            this.chkMaintenance.Name = "chkMaintenance";
            this.chkMaintenance.Size = new System.Drawing.Size(88, 17);
            this.chkMaintenance.TabIndex = 6;
            this.chkMaintenance.Text = "Maintenance";
            this.chkMaintenance.UseVisualStyleBackColor = true;
            // 
            // chkElectric
            // 
            this.chkElectric.AutoSize = true;
            this.chkElectric.Checked = true;
            this.chkElectric.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkElectric.Location = new System.Drawing.Point(285, 69);
            this.chkElectric.Name = "chkElectric";
            this.chkElectric.Size = new System.Drawing.Size(61, 17);
            this.chkElectric.TabIndex = 7;
            this.chkElectric.Text = "Electric";
            this.chkElectric.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(714, 69);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(130, 30);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(20, 180);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(850, 370);
            this.dgvReport.TabIndex = 3;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblSummary.Location = new System.Drawing.Point(20, 565);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(172, 17);
            this.lblSummary.TabIndex = 4;
            this.lblSummary.Text = "Total: $0.00   Count: 0";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(580, 560);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 30);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(675, 560);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(785, 560);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.lblReportType);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.grpFilters);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.ComboBox cmbReportType;

        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblBillTypes;
        private System.Windows.Forms.CheckBox chkService;
        private System.Windows.Forms.CheckBox chkMaintenance;
        private System.Windows.Forms.CheckBox chkElectric;
        private System.Windows.Forms.Button btnGenerate;

        private System.Windows.Forms.DataGridView dgvReport;

        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Button btnDefaultDate;
    }
}

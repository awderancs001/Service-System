namespace ServiceSystem.Forms
{
    partial class UnitsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.pnlBuildings = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lstBuildings = new System.Windows.Forms.ListBox();
            this.btnAddBuilding = new System.Windows.Forms.Button();
            this.btnDeleteBuilding = new System.Windows.Forms.Button();
            this.pnlUnits = new System.Windows.Forms.Panel();
            this.dgvUnits = new System.Windows.Forms.DataGridView();
            this.btnAddUnit = new System.Windows.Forms.Button();
            this.btnEditUnit = new System.Windows.Forms.Button();
            this.btnDeleteUnit = new System.Windows.Forms.Button();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbBuilding = new System.Windows.Forms.ComboBox();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.txtMonthlyFee = new System.Windows.Forms.TextBox();
            this.txtOwnerFullName = new System.Windows.Forms.TextBox();
            this.txtOwnerPhone = new System.Windows.Forms.TextBox();
            this.txtOwnerOtherPhone = new System.Windows.Forms.TextBox();
            this.txtOwnerNation = new System.Windows.Forms.TextBox();
            this.chkHasTenant = new System.Windows.Forms.CheckBox();
            this.txtTenantFullName = new System.Windows.Forms.TextBox();
            this.txtTenantPhone = new System.Windows.Forms.TextBox();
            this.txtTenantOtherPhone = new System.Windows.Forms.TextBox();
            this.txtTenantNation = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlBuildings.SuspendLayout();
            this.pnlUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnShowAll);
            this.panel1.Location = new System.Drawing.Point(25, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 54);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(68, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(154, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(276, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(424, 15);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 23);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // pnlBuildings
            // 
            this.pnlBuildings.Controls.Add(this.label2);
            this.pnlBuildings.Controls.Add(this.lstBuildings);
            this.pnlBuildings.Controls.Add(this.btnAddBuilding);
            this.pnlBuildings.Controls.Add(this.btnDeleteBuilding);
            this.pnlBuildings.Location = new System.Drawing.Point(25, 72);
            this.pnlBuildings.Name = "pnlBuildings";
            this.pnlBuildings.Size = new System.Drawing.Size(234, 577);
            this.pnlBuildings.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buildings";
            // 
            // lstBuildings
            // 
            this.lstBuildings.FormattingEnabled = true;
            this.lstBuildings.Location = new System.Drawing.Point(16, 28);
            this.lstBuildings.Name = "lstBuildings";
            this.lstBuildings.Size = new System.Drawing.Size(200, 290);
            this.lstBuildings.TabIndex = 0;
            this.lstBuildings.SelectedIndexChanged += new System.EventHandler(this.lstBuildings_SelectedIndexChanged);
            // 
            // btnAddBuilding
            // 
            this.btnAddBuilding.Location = new System.Drawing.Point(21, 324);
            this.btnAddBuilding.Name = "btnAddBuilding";
            this.btnAddBuilding.Size = new System.Drawing.Size(89, 23);
            this.btnAddBuilding.TabIndex = 1;
            this.btnAddBuilding.Text = "+ ADD";
            this.btnAddBuilding.UseVisualStyleBackColor = true;
            this.btnAddBuilding.Click += new System.EventHandler(this.btnAddBuilding_Click);
            // 
            // btnDeleteBuilding
            // 
            this.btnDeleteBuilding.Location = new System.Drawing.Point(127, 324);
            this.btnDeleteBuilding.Name = "btnDeleteBuilding";
            this.btnDeleteBuilding.Size = new System.Drawing.Size(89, 23);
            this.btnDeleteBuilding.TabIndex = 2;
            this.btnDeleteBuilding.Text = "Delete";
            this.btnDeleteBuilding.UseVisualStyleBackColor = true;
            this.btnDeleteBuilding.Click += new System.EventHandler(this.btnDeleteBuilding_Click);
            // 
            // pnlUnits
            // 
            this.pnlUnits.Controls.Add(this.dgvUnits);
            this.pnlUnits.Controls.Add(this.btnAddUnit);
            this.pnlUnits.Controls.Add(this.btnEditUnit);
            this.pnlUnits.Controls.Add(this.btnDeleteUnit);
            this.pnlUnits.Location = new System.Drawing.Point(265, 72);
            this.pnlUnits.Name = "pnlUnits";
            this.pnlUnits.Size = new System.Drawing.Size(695, 356);
            this.pnlUnits.TabIndex = 2;
            // 
            // dgvUnits
            // 
            this.dgvUnits.AllowUserToAddRows = false;
            this.dgvUnits.AllowUserToDeleteRows = false;
            this.dgvUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnits.Location = new System.Drawing.Point(10, 10);
            this.dgvUnits.MultiSelect = false;
            this.dgvUnits.Name = "dgvUnits";
            this.dgvUnits.ReadOnly = true;
            this.dgvUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnits.Size = new System.Drawing.Size(676, 306);
            this.dgvUnits.TabIndex = 0;
            // 
            // btnAddUnit
            // 
            this.btnAddUnit.Location = new System.Drawing.Point(10, 324);
            this.btnAddUnit.Name = "btnAddUnit";
            this.btnAddUnit.Size = new System.Drawing.Size(100, 23);
            this.btnAddUnit.TabIndex = 1;
            this.btnAddUnit.Text = "+ Add Unit";
            this.btnAddUnit.UseVisualStyleBackColor = true;
            this.btnAddUnit.Click += new System.EventHandler(this.btnAddUnit_Click);
            // 
            // btnEditUnit
            // 
            this.btnEditUnit.Location = new System.Drawing.Point(120, 324);
            this.btnEditUnit.Name = "btnEditUnit";
            this.btnEditUnit.Size = new System.Drawing.Size(100, 23);
            this.btnEditUnit.TabIndex = 2;
            this.btnEditUnit.Text = "Edit Unit";
            this.btnEditUnit.UseVisualStyleBackColor = true;
            this.btnEditUnit.Click += new System.EventHandler(this.btnEditUnit_Click);
            // 
            // btnDeleteUnit
            // 
            this.btnDeleteUnit.Location = new System.Drawing.Point(230, 324);
            this.btnDeleteUnit.Name = "btnDeleteUnit";
            this.btnDeleteUnit.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteUnit.TabIndex = 3;
            this.btnDeleteUnit.Text = "Delete Unit";
            this.btnDeleteUnit.UseVisualStyleBackColor = true;
            this.btnDeleteUnit.Click += new System.EventHandler(this.btnDeleteUnit_Click);
            // 
            // pnlDetail
            // 
            this.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetail.Controls.Add(this.label3);
            this.pnlDetail.Controls.Add(this.label4);
            this.pnlDetail.Controls.Add(this.label5);
            this.pnlDetail.Controls.Add(this.label6);
            this.pnlDetail.Controls.Add(this.label7);
            this.pnlDetail.Controls.Add(this.label9);
            this.pnlDetail.Controls.Add(this.label10);
            this.pnlDetail.Controls.Add(this.label11);
            this.pnlDetail.Controls.Add(this.label12);
            this.pnlDetail.Controls.Add(this.label13);
            this.pnlDetail.Controls.Add(this.label14);
            this.pnlDetail.Controls.Add(this.label15);
            this.pnlDetail.Controls.Add(this.label16);
            this.pnlDetail.Controls.Add(this.label17);
            this.pnlDetail.Controls.Add(this.cmbBuilding);
            this.pnlDetail.Controls.Add(this.txtUnitName);
            this.pnlDetail.Controls.Add(this.txtMonthlyFee);
            this.pnlDetail.Controls.Add(this.txtOwnerFullName);
            this.pnlDetail.Controls.Add(this.txtOwnerPhone);
            this.pnlDetail.Controls.Add(this.txtOwnerOtherPhone);
            this.pnlDetail.Controls.Add(this.txtOwnerNation);
            this.pnlDetail.Controls.Add(this.chkHasTenant);
            this.pnlDetail.Controls.Add(this.txtTenantFullName);
            this.pnlDetail.Controls.Add(this.txtTenantPhone);
            this.pnlDetail.Controls.Add(this.txtTenantOtherPhone);
            this.pnlDetail.Controls.Add(this.txtTenantNation);
            this.pnlDetail.Controls.Add(this.btnSave);
            this.pnlDetail.Controls.Add(this.btnCancel);
            this.pnlDetail.Location = new System.Drawing.Point(265, 434);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(695, 215);
            this.pnlDetail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(5, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "UNIT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(5, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "OWNER";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(5, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "TENANT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Building";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Unit Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Monthly Fee $";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(100, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Full Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(255, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Phone";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(380, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Other Phone";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(510, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Nation";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(100, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Full Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(255, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Phone";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(380, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "Other Phone";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(510, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Nation";
            // 
            // cmbBuilding
            // 
            this.cmbBuilding.FormattingEnabled = true;
            this.cmbBuilding.Location = new System.Drawing.Point(100, 25);
            this.cmbBuilding.Name = "cmbBuilding";
            this.cmbBuilding.Size = new System.Drawing.Size(110, 21);
            this.cmbBuilding.TabIndex = 0;
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(215, 25);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(110, 20);
            this.txtUnitName.TabIndex = 1;
            // 
            // txtMonthlyFee
            // 
            this.txtMonthlyFee.Location = new System.Drawing.Point(331, 26);
            this.txtMonthlyFee.Name = "txtMonthlyFee";
            this.txtMonthlyFee.Size = new System.Drawing.Size(100, 20);
            this.txtMonthlyFee.TabIndex = 3;
            // 
            // txtOwnerFullName
            // 
            this.txtOwnerFullName.Location = new System.Drawing.Point(100, 87);
            this.txtOwnerFullName.Name = "txtOwnerFullName";
            this.txtOwnerFullName.Size = new System.Drawing.Size(150, 20);
            this.txtOwnerFullName.TabIndex = 4;
            // 
            // txtOwnerPhone
            // 
            this.txtOwnerPhone.Location = new System.Drawing.Point(255, 87);
            this.txtOwnerPhone.Name = "txtOwnerPhone";
            this.txtOwnerPhone.Size = new System.Drawing.Size(120, 20);
            this.txtOwnerPhone.TabIndex = 5;
            // 
            // txtOwnerOtherPhone
            // 
            this.txtOwnerOtherPhone.Location = new System.Drawing.Point(380, 87);
            this.txtOwnerOtherPhone.Name = "txtOwnerOtherPhone";
            this.txtOwnerOtherPhone.Size = new System.Drawing.Size(120, 20);
            this.txtOwnerOtherPhone.TabIndex = 6;
            // 
            // txtOwnerNation
            // 
            this.txtOwnerNation.Location = new System.Drawing.Point(510, 87);
            this.txtOwnerNation.Name = "txtOwnerNation";
            this.txtOwnerNation.Size = new System.Drawing.Size(100, 20);
            this.txtOwnerNation.TabIndex = 7;
            // 
            // chkHasTenant
            // 
            this.chkHasTenant.AutoSize = true;
            this.chkHasTenant.Location = new System.Drawing.Point(5, 150);
            this.chkHasTenant.Name = "chkHasTenant";
            this.chkHasTenant.Size = new System.Drawing.Size(82, 17);
            this.chkHasTenant.TabIndex = 8;
            this.chkHasTenant.Text = "Has Tenant";
            this.chkHasTenant.UseVisualStyleBackColor = true;
            this.chkHasTenant.CheckedChanged += new System.EventHandler(this.chkHasTenant_CheckedChanged);
            // 
            // txtTenantFullName
            // 
            this.txtTenantFullName.Location = new System.Drawing.Point(100, 148);
            this.txtTenantFullName.Name = "txtTenantFullName";
            this.txtTenantFullName.Size = new System.Drawing.Size(150, 20);
            this.txtTenantFullName.TabIndex = 9;
            // 
            // txtTenantPhone
            // 
            this.txtTenantPhone.Location = new System.Drawing.Point(255, 148);
            this.txtTenantPhone.Name = "txtTenantPhone";
            this.txtTenantPhone.Size = new System.Drawing.Size(120, 20);
            this.txtTenantPhone.TabIndex = 10;
            // 
            // txtTenantOtherPhone
            // 
            this.txtTenantOtherPhone.Location = new System.Drawing.Point(380, 148);
            this.txtTenantOtherPhone.Name = "txtTenantOtherPhone";
            this.txtTenantOtherPhone.Size = new System.Drawing.Size(120, 20);
            this.txtTenantOtherPhone.TabIndex = 11;
            // 
            // txtTenantNation
            // 
            this.txtTenantNation.Location = new System.Drawing.Point(510, 148);
            this.txtTenantNation.Name = "txtTenantNation";
            this.txtTenantNation.Size = new System.Drawing.Size(100, 20);
            this.txtTenantNation.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(595, 182);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(510, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UnitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBuildings);
            this.Controls.Add(this.pnlUnits);
            this.Controls.Add(this.pnlDetail);
            this.Name = "UnitsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Units & Buildings";
            this.Load += new System.EventHandler(this.UnitsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBuildings.ResumeLayout(false);
            this.pnlBuildings.PerformLayout();
            this.pnlUnits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        // ── Control declarations ───────────────────────────────────
        private System.Windows.Forms.Panel      panel1;
        private System.Windows.Forms.Label      label1;
        private System.Windows.Forms.TextBox    txtSearch;
        private System.Windows.Forms.Button     btnSearch;
        private System.Windows.Forms.Button     btnShowAll;

        private System.Windows.Forms.Panel      pnlBuildings;
        private System.Windows.Forms.Label      label2;
        private System.Windows.Forms.ListBox    lstBuildings;
        private System.Windows.Forms.Button     btnAddBuilding;
        private System.Windows.Forms.Button     btnDeleteBuilding;

        private System.Windows.Forms.Panel      pnlUnits;
        private System.Windows.Forms.DataGridView dgvUnits;
        private System.Windows.Forms.Button     btnAddUnit;
        private System.Windows.Forms.Button     btnEditUnit;
        private System.Windows.Forms.Button     btnDeleteUnit;

        private System.Windows.Forms.Panel      pnlDetail;
        private System.Windows.Forms.Label      label3;
        private System.Windows.Forms.Label      label4;
        private System.Windows.Forms.Label      label5;
        private System.Windows.Forms.Label      label6;
        private System.Windows.Forms.Label      label7;
        private System.Windows.Forms.Label      label9;
        private System.Windows.Forms.Label      label10;
        private System.Windows.Forms.Label      label11;
        private System.Windows.Forms.Label      label12;
        private System.Windows.Forms.Label      label13;
        private System.Windows.Forms.Label      label14;
        private System.Windows.Forms.Label      label15;
        private System.Windows.Forms.Label      label16;
        private System.Windows.Forms.Label      label17;

        private System.Windows.Forms.ComboBox   cmbBuilding;
        private System.Windows.Forms.TextBox    txtUnitName;
        private System.Windows.Forms.TextBox    txtMonthlyFee;

        private System.Windows.Forms.TextBox    txtOwnerFullName;
        private System.Windows.Forms.TextBox    txtOwnerPhone;
        private System.Windows.Forms.TextBox    txtOwnerOtherPhone;
        private System.Windows.Forms.TextBox    txtOwnerNation;

        private System.Windows.Forms.CheckBox   chkHasTenant;
        private System.Windows.Forms.TextBox    txtTenantFullName;
        private System.Windows.Forms.TextBox    txtTenantPhone;
        private System.Windows.Forms.TextBox    txtTenantOtherPhone;
        private System.Windows.Forms.TextBox    txtTenantNation;

        private System.Windows.Forms.Button     btnSave;
        private System.Windows.Forms.Button     btnCancel;
    }
}

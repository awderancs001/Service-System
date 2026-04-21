using ServiceSystem.Data;
using System;
using ServiceSystem.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceSystem.Forms
{
    public partial class MaintenanceForm : Form
    {

        private UnitRepository unitRepo = new UnitRepository();
        private MaintenanceBillRepository billRepo = new MaintenanceBillRepository();
        int selectedUnitID = 0;

        public MaintenanceForm()
        {
            InitializeComponent();

        }

        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            FillMonthCombos();
            LoadUnits();
            LoadRecentBills(DateTime.Now.Month, DateTime.Now.Year);

        }

        private void SetupGrid()
        {
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBillID", HeaderText = "#", Width = 40 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUnit", HeaderText = "Unit", Width = 90 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOwnerName", HeaderText = "OwnerName", Width = 90 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBuilding", HeaderText = "Building", Width = 110 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMonth", HeaderText = "Month", Width = 90 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAmount", HeaderText = "Amount $", Width = 80 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDescription", HeaderText = "Description", Width = 130 });

        }

        private void FillMonthCombos()
        {
            int currentYear = DateTime.Now.Year;

            for(int y= currentYear-1; y<=currentYear; y++)
            {
                cmbBulkYear.Items.Add(y);
                cmbYear.Items.Add(y);

            }

            cmbMonth.SelectedItem = DateTime.Now.Month;
            cmbBulkMonth.SelectedItem = DateTime.Now.Month;
            cmbYear.SelectedItem = currentYear;
            cmbBulkYear.SelectedItem = currentYear;
        }

        private void LoadUnits()
        {

            cmbUnit.DisplayMember = "UnitName";
            cmbUnit.ValueMember = "UnitID";
            cmbUnit.DataSource = unitRepo.GetAll();
        }

        private void LoadRecentBills(int Month, int Year)
        {
            DateTime dt = new DateTime(Year, Month, 1);
            var list = billRepo.GetByMonth(dt);

            fillGrid(list);

        }

        private void fillGrid(List<MaintenanceBill> Mlist)
        {

            dgvBills.Rows.Clear();
            foreach (var bill in Mlist)
            {
              int row =  dgvBills.Rows.Add(
                    bill.MaintenanceID,
                    bill.UnitName,
                    bill.OwnerName,
                    bill.BuildingName,
                    bill.BillMonth.ToString("MM/yyyy"),
                    bill.Amount.ToString("F0"),
                    bill.Description
                    );

                dgvBills.Rows[row].Tag = bill.MaintenanceID;

            }
        }
        private void btnGenerateAll_Click(object sender, EventArgs e)
        {
            if (cmbBulkMonth.SelectedItem == null || cmbBulkYear.SelectedItem == null)
            {
                MessageBox.Show("Please Enter Month and Year");
                return;
            }

            int month = (int)cmbBulkMonth.SelectedItem;
            int year = (int)cmbBulkYear.SelectedItem;

            var confirm = MessageBox.Show("Generate bills for all units for month/year?", "confirm",
                MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
                return;

                                      
            if (!decimal.TryParse(txtBulkAmount.Text, out decimal amount) || amount <= 0)  // ✅
            {
                MessageBox.Show("Please enter a valid amount");
                return;
            }
            string desc = txtBulkDesc.Text;

            int created = billRepo.SaveBulk(month, year, amount, desc);
            MessageBox.Show($"{created} bills created");

            LoadRecentBills((int)cmbBulkMonth.SelectedItem, (int)cmbBulkYear.SelectedItem);

        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            if (dgvBills.CurrentRow == null)
            {
                MessageBox.Show("Please select Row ", "selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            int billID = (int)dgvBills.CurrentRow.Tag;

            string month = dgvBills.CurrentRow.Cells["colMonth"].Value.ToString();
            string name = dgvBills.CurrentRow.Cells["colUnit"].Value.ToString();

            var dialogResult = MessageBox.Show("Are you sure want to delete ? ",
                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult != DialogResult.Yes)
                return;

            billRepo.Delete(billID);
            LoadRecentBills((int)cmbMonth.SelectedItem, (int)cmbYear.SelectedItem);

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbUnit.SelectedIndex = -1;
            txtOwner.Text = string.Empty;
            txtBuilding.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtDescription.Text = string.Empty;
            selectedUnitID = 0;
        }

        private void btnSaveSingle_Click(object sender, EventArgs e)
        {
            if (selectedUnitID == 0)
            {
                MessageBox.Show("Please select a unit");
                return;
            }

            if (cmbMonth.SelectedItem == null)
            {
               MessageBox.Show("Please select month and year");
                return;
            }

            if(!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <=0)
            {
                MessageBox.Show("Amount must be a number"); 
                return; 
            }

            int year = (int)cmbYear.SelectedItem;
            int month = (int)cmbMonth.SelectedItem;
            DateTime billMonth = new DateTime(year, month, 1);

            var bill = new MaintenanceBill
            {
                UnitID = selectedUnitID,
                BillMonth = billMonth,
                Amount = amount,
                Description = txtDescription.Text.Trim()

            };

            billRepo.Save(bill);
            MessageBox.Show("Bill Saved", "Done");
            LoadRecentBills(month, year);
            btnClear_Click(null, null);
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unit = cmbUnit.SelectedItem as Unit;
            if (unit == null) return;

            selectedUnitID = unit.UnitID;
            txtOwner.Text = unit.OwnerFullName;
            txtBuilding.Text = unit.BuildingName;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

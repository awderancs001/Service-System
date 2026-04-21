using ServiceSystem.Data;
using ServiceSystem.Models;
using System;
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
    public partial class MonthlyServiceForm : Form
    {
        private UnitRepository unitRepo = new UnitRepository();
        private MonthlyServiceBillRepository billRepo = new MonthlyServiceBillRepository();
        private int selectedUnitID = 0;
        public MonthlyServiceForm()
        {
            InitializeComponent();
        }

        private void MonthlyServiceForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            FillMonthCombos();
            LoadUnits();
            LoadRecentBills(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void LoadRecentBills(int month, int year)
        {
            DateTime billMonth = new DateTime(year, month, 1);
            var list = billRepo.GetByMonth(billMonth);
            
            FillGrid(list);
        }

        private void FillGrid(List<MonthlyServiceBill> list)
        {
            dgvBills.Rows.Clear();
            foreach (var b in list)
            {
                int row = dgvBills.Rows.Add(
                    b.BillID,
                    b.UnitName,
                    b.OwnerName,
                    b.BuildingName,
                    b.BillMonth.ToString("MM/yyyy"),
                    b.Amount.ToString("F0"),
                    b.Notes
                );
                dgvBills.Rows[row].Tag = b.BillID;
            }
        }

        private void SetupGrid()
        {
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBillID", HeaderText = "#", Width = 40 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUnit", HeaderText = "Unit", Width = 90 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOwnerName", HeaderText = "OwnerName", Width = 90 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBuilding", HeaderText = "Building", Width = 110 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMonth", HeaderText = "Month", Width = 90 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAmount", HeaderText = "Amount $", Width = 80 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNotes", HeaderText = "Notes", Width = 130 });
        }

        private void FillMonthCombos()
        {
            int currentYear = DateTime.Now.Year;

            for (int y = currentYear - 1; y <= currentYear; y++)
            {
                cmbYear.Items.Add(y);
                cmbBulkYear.Items.Add(y);

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
        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUnit.SelectedItem == null) return;

            var unit = (Unit)cmbUnit.SelectedItem;
            selectedUnitID = unit.UnitID;
            txtOwner.Text = unit.OwnerFullName;
            txtBuilding.Text = unit.BuildingName;
            txtAmount.Text = unit.MonthlyServiceAmount.ToString("F0");
        }

        private void btnSaveSingle_Click(object sender, EventArgs e)
        {
            if (selectedUnitID == 0)
            {
                var dialogresult = MessageBox.Show("Please select a unit");
                return;
            }

            if (cmbMonth.SelectedItem == null)
            {
                var dialogresult = MessageBox.Show("Please select month and year");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Amount must be a number");
                return;
            }

            int year = (int)cmbYear.SelectedItem;
            int month = (int)cmbMonth.SelectedItem;
            DateTime billMonth = new DateTime(year, month, 1);

            if(billRepo.BillExists(selectedUnitID, billMonth))
            {
                MessageBox.Show("Bill already exists for this unit this month.", "Duplicate");
                return;
            }


            var bill = new MonthlyServiceBill
            {
                UnitID = selectedUnitID,
                BillMonth = billMonth,
                Amount = amount,
                Notes = txtNotes.Text.Trim()
            };
            billRepo.Save(bill);

            MessageBox.Show("Bill saved.", "Done");
            LoadRecentBills(month, year);
            btnClear_Click(null, null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbUnit.SelectedIndex = -1;
            txtOwner.Text = string.Empty;
            txtBuilding.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtNotes.Text = string.Empty;
            selectedUnitID = 0;

        }

        private void btnGenerateAll_Click(object sender, EventArgs e)
        {
            if (cmbBulkMonth.SelectedItem == null || cmbBulkYear.SelectedItem == null)
            {
                MessageBox.Show("Please select month and year.");
                return;
            }

            int month = (int)cmbBulkMonth.SelectedItem;
            int year = (int)cmbBulkYear.SelectedItem;

            var confirm = MessageBox.Show("Generate bills for all units for month/year?", "Confrim"
                , MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
                return;

            int created = billRepo.SaveBulk(month, year);
            MessageBox.Show($"{created} bills created");
            LoadRecentBills(month, year);
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            if (dgvBills.CurrentRow == null)
            {
                MessageBox.Show("Please select a unit first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cmbMonth.SelectedItem != null && cmbYear.SelectedItem != null)
                LoadRecentBills((int)cmbMonth.SelectedItem, (int)cmbYear.SelectedItem);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

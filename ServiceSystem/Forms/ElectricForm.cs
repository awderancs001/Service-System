using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ServiceSystem.Data;
using ServiceSystem.Models;

namespace ServiceSystem.Forms
{
    public partial class ElectricForm : Form
    {
        private UnitRepository unitRepo = new UnitRepository();
        private ElectricBillRepository billRepo = new ElectricBillRepository();
        private int selectedUnitID = 0;

        public ElectricForm()
        {
            InitializeComponent();
            
        }

        private void SetUpGrid()
        {
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colID", HeaderText = "#", Width = 40 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUnit", HeaderText = "Unit", Width = 80 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOwner", HeaderText = "Owner", Width = 90 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBuilding", HeaderText = "Building", Width = 90 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMonth", HeaderText = "Month", Width = 70 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBegin", HeaderText = "Begin", Width = 60 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEnd", HeaderText = "End", Width = 60 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrice", HeaderText = "Price", Width = 55 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTotal", HeaderText = "Total $", Width = 65 });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNotes", HeaderText = "Notes", Width = 100 });
        }

        private void FillMonthCombs()
        {
            int currentYear = DateTime.Now.Year;

            for(int y=currentYear-1; y<=currentYear; y++)
            {
                cmbYear.Items.Add(y);
            }

            cmbMonth.SelectedItem = DateTime.Now.Month;
            cmbYear.SelectedItem = currentYear;
        }

        private void LoadUnits()
        {
            cmbUnit.DisplayMember = "UnitName";
            cmbUnit.ValueMember = "UnitID";
            cmbUnit.DataSource = unitRepo.GetAll();
        }

        private void LoadRecentBills(int month, int year)
        {
            DateTime dt = new DateTime(year, month, 1);
            var list = billRepo.GetByMonth(dt);
            FillGrid(list);
        }

        private void FillGrid(List<ElectricBill> list)
        {
            dgvBills.Rows.Clear();
            foreach (var bill in list)
            {
                int row = dgvBills.Rows.Add(
                    bill.ElectricID,
                    bill.UnitName,
                    bill.OwnerName,
                    bill.BuildingName,
                    bill.BillMonth.ToString("MM/yyyy"),
                    bill.BeginReading.ToString("F2"),
                    bill.EndReading.ToString("F2"),
                    bill.PricePerUnit.ToString("F4"),
                    bill.TotalAmount.ToString("F2"),
                    bill.Notes
                );
                dgvBills.Rows[row].Tag = bill.ElectricID;
            }
        }
        private void ElectricForm_Load(object sender, EventArgs e)
        {
            SetUpGrid();
            FillMonthCombs();
            LoadUnits();
            LoadRecentBills(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unit = cmbUnit.SelectedItem as Unit;
            if (unit == null) return;

            selectedUnitID = unit.UnitID;
            txtOwner.Text = unit.OwnerFullName;
            txtBuilding.Text = unit.BuildingName;
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            // Try to parse all 3 fields — if any fails, clear total
            if (decimal.TryParse(txtBeginReading.Text, out decimal begin) &&
                decimal.TryParse(txtEndReading.Text, out decimal end) &&
                decimal.TryParse(txtPricePerUnit.Text, out decimal price))
            {
                decimal total = (end - begin) * price;
                txtTotalAmount.Text = total.ToString("F2");
            }
            else
            {
                txtTotalAmount.Text = "";
            }
        }

        private void btnSaveSingle_Click(object sender, EventArgs e)
        {
            if (selectedUnitID == 0)
            {
                MessageBox.Show("Please select a unit");
                return;
            }

            if (cmbMonth.SelectedItem == null || cmbYear.SelectedItem == null)
            {
                MessageBox.Show("Please select month and year");
                return;
            }

            if (!decimal.TryParse(txtBeginReading.Text, out decimal begin))
            {
                MessageBox.Show("Begin Reading must be a number");
                return;
            }

            if (!decimal.TryParse(txtEndReading.Text, out decimal end))
            {
                MessageBox.Show("End Reading must be a number");
                return;
            }

            if (!decimal.TryParse(txtPricePerUnit.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Price per unit must be a valid number");
                return;
            }

            if (end < begin)
            {
                MessageBox.Show("End Reading cannot be less than Begin Reading");
                return;
            }

            int month = (int)cmbMonth.SelectedItem;
            int year = (int)cmbYear.SelectedItem;
            DateTime billMonth = new DateTime(year, month, 1);

            // Check if bill already exists for this unit/month
            if (billRepo.IsBillExist(selectedUnitID, billMonth))
            {
                MessageBox.Show("A bill already exists for this unit and month");
                return;
            }

            var bill = new ElectricBill
            {
                UnitID = selectedUnitID,
                BillMonth = billMonth,
                BeginReading = begin,
                EndReading = end,
                PricePerUnit = price,
                Notes = txtNotes.Text.Trim()
            };

            billRepo.Save(bill);
            MessageBox.Show("Bill Saved", "Done");
            LoadRecentBills(month, year);
            btnClear_Click(null, null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbUnit.SelectedIndex = -1;
            txtOwner.Text = string.Empty;
            txtBuilding.Text = string.Empty;
            txtBeginReading.Text = string.Empty;
            txtEndReading.Text = string.Empty;
            txtPricePerUnit.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            txtNotes.Text = string.Empty;
            selectedUnitID = 0;
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            if (dgvBills.CurrentRow == null)
            {
                MessageBox.Show("Please select a row", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int electricID = (int)dgvBills.CurrentRow.Tag;

            var result = MessageBox.Show("Are you sure you want to delete?",
                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            billRepo.Delete(electricID);
            LoadRecentBills((int)cmbMonth.SelectedItem, (int)cmbYear.SelectedItem);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

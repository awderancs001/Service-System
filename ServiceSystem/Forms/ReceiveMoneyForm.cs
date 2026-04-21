using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ServiceSystem.Data;
using ServiceSystem.Models;

namespace ServiceSystem.Forms
{
    public partial class ReceiveMoneyForm : Form
    {
        private UnitRepository unitRepo = new UnitRepository();
        private PaymentRepository paymentRepo = new PaymentRepository();
        private int selectedUnitID = 0;

        public ReceiveMoneyForm()
        {
            InitializeComponent();
        }

        private void ReceiveMoneyForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            SetupHistoryGrid();
            FillMonthCombos();
            LoadUnits();
            LoadPayments(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void SetupGrid()
        {
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "colID", HeaderText = "#", Width = 40 });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUnit", HeaderText = "Unit", Width = 80 });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOwner", HeaderText = "Owner", Width = 90 });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBuilding", HeaderText = "Building", Width = 80 });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAmount", HeaderText = "Amount $", Width = 70 });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "colForMonth", HeaderText = "From", Width = 65 });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "colToMonth", HeaderText = "To", Width = 65 });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = "Date", Width = 75 });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "colComment", HeaderText = "Comment", Width = 100 });
        }

        private void SetupHistoryGrid()
        {
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHType",  HeaderText = "Type",    Width = 90  });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHMonth", HeaderText = "Month",   Width = 70  });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHDebt",  HeaderText = "Debt $",  Width = 80  });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHPaid",  HeaderText = "Paid $",  Width = 80  });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHNote",  HeaderText = "Note",    Width = 150 });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHDate",  HeaderText = "Created", Width = 80  });
        }

        private void FillMonthCombos()
        {
            // Clear first in case Designer put items in
            cmbForMonth.Items.Clear();
            cmbToMonth.Items.Clear();
            cmbForYear.Items.Clear();
            cmbToYear.Items.Clear();

            // Fill months — store as ints 1..12 so LoadPayments() can use them directly
            for (int m = 1; m <= 12; m++)
            {
                cmbForMonth.Items.Add(m);
                cmbToMonth.Items.Add(m);
            }

            // Fill years — last year, this year, next year
            int currentYear = DateTime.Now.Year;
            for (int y = currentYear - 1; y <= currentYear + 1; y++)
            {
                cmbForYear.Items.Add(y);
                cmbToYear.Items.Add(y);
            }

            // Default selections — now they actually match because items exist
            cmbForMonth.SelectedItem = DateTime.Now.Month;
            cmbForYear.SelectedItem = currentYear;
            cmbToMonth.SelectedItem = DateTime.Now.Month;
            cmbToYear.SelectedItem = currentYear;
        }

        private void LoadUnits()
        {
            cmbUnit.DisplayMember = "UnitName";
            cmbUnit.ValueMember = "UnitID";
            cmbUnit.DataSource = unitRepo.GetAll();
        }

        private void LoadPayments(int month, int year)
        {
            var list = paymentRepo.GetByMonth(month, year);
            FillGrid(list);
        }

        private void FillGrid(List<Payment> list)
        {
            dgvPayments.Rows.Clear();
            foreach (var p in list)
            {
                int row = dgvPayments.Rows.Add(
                    p.PaymentID,
                    p.UnitName,
                    p.OwnerFullName,
                    p.BuildingName,
                    p.Amount.ToString("F0"),
                    p.ForMonth.ToString("MM/yyyy"),
                    p.ToMonth.HasValue ? p.ToMonth.Value.ToString("MM/yyyy") : "-",
                    p.PaymentDate.ToString("dd/MM/yyyy"),
                    p.Comment
                );
                dgvPayments.Rows[row].Tag = p.PaymentID;
            }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unit = cmbUnit.SelectedItem as Unit;
            if (unit == null) return;

            selectedUnitID = unit.UnitID;
            txtOwner.Text = unit.OwnerFullName;
            txtBuilding.Text = unit.BuildingName;

            LoadUnitBalance(unit.UnitID);
            LoadUnitHistory(unit.UnitID, unit.UnitName);
        }

        private void LoadUnitBalance(int unitID)
        {
            var bal = unitRepo.GetBalance(unitID);

            lblTotalDebt.Text = bal.TotalCharged.ToString("F2");
            lblTotalPaid.Text = bal.TotalPaid.ToString("F2");
            lblBalance.Text   = bal.Balance.ToString("F2");

            // Red if unit still owes money, green if paid-up/overpaid
            lblBalance.ForeColor = bal.Balance > 0
                ? System.Drawing.Color.Firebrick
                : System.Drawing.Color.SeaGreen;
        }

        private void LoadUnitHistory(int unitID, string unitName)
        {
            var history = unitRepo.GetHistory(unitID);

            dgvHistory.Rows.Clear();
            foreach (var h in history)
            {
                int row = dgvHistory.Rows.Add(
                    h.Type,
                    h.Month.ToString("MM/yyyy"),
                    h.Debt > 0 ? h.Debt.ToString("F2") : "",
                    h.Paid > 0 ? h.Paid.ToString("F2") : "",
                    h.Note,
                    h.CreatedDate.ToString("dd/MM/yyyy")
                );

                // Color payments green so they stand out from bills
                if (h.Type == "Payment")
                    dgvHistory.Rows[row].DefaultCellStyle.ForeColor = System.Drawing.Color.SeaGreen;
            }

            lblHistoryTitle.Text = "Unit History — " + unitName + " (" + history.Count + " records)";
        }

        private void ClearUnitInfo()
        {
            lblTotalDebt.Text = "0.00";
            lblTotalPaid.Text = "0.00";
            lblBalance.Text   = "0.00";
            lblBalance.ForeColor = System.Drawing.SystemColors.ControlText;
            dgvHistory.Rows.Clear();
            lblHistoryTitle.Text = "Unit History — select a unit to view";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                // Empty search = show current month payments
                LoadPayments(DateTime.Now.Month, DateTime.Now.Year);
                return;
            }

            var list = paymentRepo.Search(keyword);
            FillGrid(list);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedUnitID == 0)
            {
                MessageBox.Show("Please select a unit");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount");
                return;
            }

            if (cmbForMonth.SelectedItem == null || cmbForYear.SelectedItem == null)
            {
                MessageBox.Show("Please select From Month and Year");
                return;
            }

            int forMonth = (int)cmbForMonth.SelectedItem;
            int forYear = (int)cmbForYear.SelectedItem;

            // To Month is optional
            DateTime? toMonth = null;
            if (cmbToMonth.SelectedItem != null && cmbToYear.SelectedItem != null)
            {
                int toM = (int)cmbToMonth.SelectedItem;
                int toY = (int)cmbToYear.SelectedItem;
                toMonth = new DateTime(toY, toM, 1);
            }

            var payment = new Payment
            {
                UnitID = selectedUnitID,
                Amount = amount,
                ForMonth = new DateTime(forYear, forMonth, 1),
                ToMonth = toMonth,
                PaymentDate = DateTime.Now,
                Comment = txtComment.Text.Trim()
            };

            paymentRepo.Save(payment);
            MessageBox.Show("Payment Saved!", "Done");

            // Refresh balance + history for the unit BEFORE clearing
            // (otherwise selectedUnitID resets to 0 in btnClear_Click)
            LoadUnitBalance(selectedUnitID);
            LoadUnitHistory(selectedUnitID, cmbUnit.Text);

            LoadPayments(DateTime.Now.Month, DateTime.Now.Year);
            btnClear_Click(null, null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbUnit.SelectedIndex = -1;
            txtOwner.Text = string.Empty;
            txtBuilding.Text = string.Empty;
            txtAmount.Text = string.Empty;
            cmbForMonth.SelectedItem = DateTime.Now.Month;
            cmbForYear.SelectedItem = DateTime.Now.Year;
            cmbToMonth.SelectedIndex = -1;
            cmbToYear.SelectedIndex = -1;
            txtComment.Text = string.Empty;
            txtSearch.Text = string.Empty;
            selectedUnitID = 0;
            ClearUnitInfo();
            LoadPayments(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPayments.CurrentRow == null)
            {
                MessageBox.Show("Please select a row", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int paymentID = (int)dgvPayments.CurrentRow.Tag;

            var result = MessageBox.Show("Are you sure you want to delete this payment?",
                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            paymentRepo.Delete(paymentID);
            LoadPayments(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dgvPayments.CurrentRow == null)
            {
                MessageBox.Show("Please select a payment first");
                return;
            }

            // Get payment ID from the row's Tag, then load the full Payment from DB
            int paymentID = (int)dgvPayments.CurrentRow.Tag;
            Payment p = paymentRepo.GetByID(paymentID);
            if (p == null)
            {
                MessageBox.Show("Could not load payment details.");
                return;
            }

            // Open the InvoiceForm as a modal dialog (blocks until user closes it)
            using (var frm = new InvoiceForm(p))
            {
                frm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

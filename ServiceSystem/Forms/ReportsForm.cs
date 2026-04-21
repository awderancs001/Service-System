using ServiceSystem.Data;
using ServiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
namespace ServiceSystem.Forms
{
    public partial class ReportsForm : Form
    {

        private ReportsRepository reportsRepo = new ReportsRepository();
        private UnitRepository unitRepo = new UnitRepository();
        private List<Unit> unitList;
        private System.Drawing.Printing.PrintDocument printDoc;
        private int printRowIndex;  // tracks which row we're on across pages
     

        public ReportsForm()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------
        // EVENT HANDLERS — empty stubs for now
        // We will fill these in step by step together
        // -------------------------------------------------------

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            FillComboBoxReports();
            LoadDateTimePickerReports();
            FillComboBoxUnits();
            UpdateFilterVisibility();
            btnGenerate_Click(null, null);

            // NEW: setup print document
            printDoc = new System.Drawing.Printing.PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
            printDoc.BeginPrint += PrintDoc_BeginPrint;
        }
        private void PrintDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printRowIndex = 0;  // reset counter at start of every print job
        }

        private void LoadUnitDirectory()
        {
            // 1. Get data from DB
            List<Unit> list = reportsRepo.GetUnitDirectory();

            // 2. Clear old grid content
            dgvReport.Rows.Clear();
            dgvReport.Columns.Clear();

            // 3. Add the columns we want to show (in order)
            dgvReport.Columns.Add("Building", "Building");
            dgvReport.Columns.Add("Unit", "Unit");
            dgvReport.Columns.Add("Owner", "Owner");
            dgvReport.Columns.Add("Phone", "Phone");
            dgvReport.Columns.Add("MonthlyFee", "Monthly Fee");

            // 4. Fill rows
            foreach (Unit u in list)
            {
                dgvReport.Rows.Add(
                    u.BuildingName,                              // Building
                    u.UnitName,                              // Unit
                    u.OwnerFullName,                              // Owner
                    u.OwnerPhone,                              // Phone
                    u.MonthlyServiceAmount.ToString("F2")    // Monthly Fee (formatted to 2 decimals)
                );
            }

            // 5. Update summary label (no total amount for this report, just count)
            lblSummary.Text = "Count: " + list.Count;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string selected = cmbReportType.SelectedItem.ToString();

            switch (selected)
            {
                case "Unit Directory":
                    LoadUnitDirectory();
                    break;

                case "Unit History":
                    LoadUnitHistory();
                    break;

                case "Debtors List":
                    LoadDebtorsList();
                    break;

                case "Payment History":
                    LoadPaymentHistory();
                    break;

                case "Per-Building Summary":
                    LoadBuildingSummary();
                    break;
                    //


                default:
                    dgvReport.Rows.Clear();
                    dgvReport.Columns.Clear();
                    lblSummary.Text = "Report coming soon...";
                        break;
            }
        }

        private void FillComboBoxReports()
        {
            cmbReportType.Items.AddRange(new object[] {
                "Debtors List",
                "Payment History",
                "Per-Building Summary",
                "Unit Directory",
                "Unit History"
                            });
            cmbReportType.SelectedIndex = 1;

        }

        private void FillComboBoxUnits()
        {
            unitList = unitRepo.GetAll();

            cmbUnit.Items.Clear();

            foreach (Unit u in unitList)
            {
                cmbUnit.Items.Add(u.UnitName + " (" + u.BuildingName + ")" );
            }

            if (cmbUnit.Items.Count > 0)
        cmbUnit.SelectedIndex = 0;

        }
        private void LoadDateTimePickerReports()
        {
            DateTime min, max;
            reportsRepo.GetGlobalDateRange(out min, out max);

            dtpFrom.Value = min;
            dtpTo.Value = max;
        }

        private void UpdateFilterVisibility()
        {
            string selected = cmbReportType.SelectedItem?.ToString() ?? "";

            // Flags — which filters show for this report
            bool showDates = selected != "Unit Directory";
            bool showBillType = selected != "Unit Directory" && selected != "Unit History" 
                && selected != "Payment History";
            bool showUnit = selected == "Unit History";

            // Apply visibility
            lblFrom.Visible = dtpFrom.Visible = showDates;
            lblTo.Visible = dtpTo.Visible = showDates;

            lblBillTypes.Visible = showBillType;
            chkService.Visible = showBillType;
            chkMaintenance.Visible = showBillType;
            chkElectric.Visible = showBillType;

            lblUnit.Visible = cmbUnit.Visible = showUnit;
            btnDefaultDate.Visible = showDates;
            
        }

        private void LoadUnitHistory()
        {
            // 1. Validate selection
            int idx = cmbUnit.SelectedIndex;
            if (idx < 0)
            {
                MessageBox.Show("Please select a valid unit from the list.");
                return;
            }
            Unit selectedUnit = unitList[idx];

            // 2. Get history from repo
            List<UnitHistoryItem> list = unitRepo.GetHistoryByDateRange(
            selectedUnit.UnitID, dtpFrom.Value, dtpTo.Value);

            // 3. Clear grid
            dgvReport.Rows.Clear();
            dgvReport.Columns.Clear();

            // 4. Add columns
            dgvReport.Columns.Add("Date", "Date");
            dgvReport.Columns.Add("Type", "Type");
            dgvReport.Columns.Add("Month", "Month");
            dgvReport.Columns.Add("Debt", "Debt");
            dgvReport.Columns.Add("Paid", "Paid");
            dgvReport.Columns.Add("Note", "Note");

            // 5. Track totals
            decimal totalDebt = 0;
            decimal totalPaid = 0;

            // 6. Fill rows
            foreach (UnitHistoryItem h in list)
            {
                int rowIndex = dgvReport.Rows.Add(
                    h.CreatedDate.ToString("dd/MM/yyyy"),
                    h.Type,
                    h.Month.ToString("MM/yyyy"),
                    h.Debt > 0 ? h.Debt.ToString("F2") : "",
                    h.Paid > 0 ? h.Paid.ToString("F2") : "",
                    h.Note
                );

                // Color-code: red for debt, green for payment
                if (h.Type == "Payment")
                    dgvReport.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.SeaGreen;
                else
                    dgvReport.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Firebrick;

                totalDebt += h.Debt;
                totalPaid += h.Paid;
            }

            // 7. Update summary
            decimal balance = totalDebt - totalPaid;
            lblSummary.Text = string.Format(
                "Unit: {0}   Charged: ${1:F2}   Paid: ${2:F2}   Balance: ${3:F2}",
                selectedUnit.UnitName, totalDebt, totalPaid, balance);

            lblSummary.ForeColor = (balance > 0) ? Color.Firebrick : Color.SeaGreen;
        }

        private void LoadDebtorsList()
        {
            // 1. Get data from repo (pass dates + 3 checkbox states)
            List<DebtorItem> list = reportsRepo.GetDebtorsList(
                dtpFrom.Value, dtpTo.Value,
                chkService.Checked, chkMaintenance.Checked, chkElectric.Checked);

            // 2. Clear grid
            dgvReport.Rows.Clear();
            dgvReport.Columns.Clear();

            // 3. Add columns: Building, Unit, Owner, Phone, Charged, Paid, Balance
            dgvReport.Columns.Add("Building", "Building");
            dgvReport.Columns.Add("Unit", "Unit");
            dgvReport.Columns.Add("Owner", "Owner");
            dgvReport.Columns.Add("Phone", "Phone");
            dgvReport.Columns.Add("Charged", "Charged");
            dgvReport.Columns.Add("Paid", "Paid");
            dgvReport.Columns.Add("Balance", "Balance");
          

            // 4. Track totals
            decimal totalBalance = 0;

            // 5. Fill rows
            foreach (DebtorItem d in list)
            {
                dgvReport.Rows.Add(
                    d.BuildingName,
                    d.UnitName,
                    d.OwnerFullName,
                    d.OwnerPhone,
                    d.TotalCharged.ToString("F2"),
                    d.TotalPaid.ToString("F2"),
                    d.Balance.ToString("F2")
                    // ← YOU pass the other 6 values in order
                    // format numbers with .ToString("F2")
                );
                totalBalance += d.Balance;
            }

            // 6. Update summary
            lblSummary.Text = string.Format(
                "Debtors: {0}   Total Owed: ${1:F2}",
                list.Count, totalBalance);

            lblSummary.ForeColor = totalBalance > 0 ? Color.Firebrick : Color.SeaGreen;
        }

        private void LoadPaymentHistory()
        {
            List<Payment> list = reportsRepo.GetPaymentHistory(dtpFrom.Value, dtpTo.Value);

            dgvReport.Rows.Clear();
            dgvReport.Columns.Clear();

            //Date | Unit | Building | Owner | For Months | Amount | Received By | Comment
            // Add 8 columns
            dgvReport.Columns.Add("Date", "Date");
            dgvReport.Columns.Add("Unit", "Unit");
            dgvReport.Columns.Add("Building", "Building");
            dgvReport.Columns.Add("Owner", "Owner");
            dgvReport.Columns.Add("For Months", "For Months");
            dgvReport.Columns.Add("Amount", "Amount");
            dgvReport.Columns.Add("Received By", "Received By");
            dgvReport.Columns.Add("Comment", "Comment");

            decimal totalAmount = 0;

            foreach (Payment p in list)
            {
                // Build "For Months" text — if ToMonth has value, show range, else single month
                string months = p.ToMonth.HasValue
                    ? p.ForMonth.ToString("MM/yyyy") + " – " + p.ToMonth.Value.ToString("MM/yyyy")
                    : p.ForMonth.ToString("MM/yyyy");

                dgvReport.Rows.Add(
                    p.PaymentDate.ToString("dd/MM/yyyy"),
                    p.UnitName,
                    p.BuildingName,
                    p.OwnerFullName,
                    months,
                    p.Amount.ToString("F2"),
                    p.ReceivedByName,
                    p.Comment
                    // ← YOU fill the other 7 values
                );

                totalAmount += p.Amount;
            }

            lblSummary.Text = string.Format("Payments: {0}   Total Received: ${1:F2}",
                list.Count, totalAmount);

            lblSummary.ForeColor = Color.SeaGreen;   // always green for income
        }

        private void LoadBuildingSummary()
        {
            // 1. Get data from repo (dates + 3 checkboxes, like Debtors)
            List<BuildingSummaryItem> list = 
            reportsRepo.GetBuildingSummary(dtpFrom.Value, dtpTo.Value,
            chkService.Checked, chkMaintenance.Checked, chkElectric.Checked);

            // 2. Clear grid
            dgvReport.Rows.Clear();
            dgvReport.Columns.Clear();

            // 3. Add 5 columns: Building, Units, Charged, Paid, Balance
            dgvReport.Columns.Add("Building", "Building");
            dgvReport.Columns.Add("Units", "Units");
            dgvReport.Columns.Add("Charged", "Charged");
            dgvReport.Columns.Add("Paid", "Paid");
            dgvReport.Columns.Add("Balance", "Balance");


            // 4. Track totals
            decimal totalCharged = 0;
            decimal totalPaid = 0;
            decimal totalBalance = 0;

            // 5. Fill rows (use .ToString("F2") for money)
            foreach (BuildingSummaryItem b in list)
            {
                dgvReport.Rows.Add(
                
                    b.BuildingName,
                    b.UnitCount,
                    b.TotalCharged.ToString("F2"),
                    b.TotalPaid.ToString("F2"),
                    b.Balance.ToString("F2")
                );
                totalCharged += b.TotalCharged;
                totalPaid += b.TotalPaid;
                totalBalance += b.Balance;
            }

            // 6. Update summary
            lblSummary.Text = string.Format(
                "Buildings: {0}   Charged: ${1:F2}   Paid: ${2:F2}   Balance: ${3:F2}",
                list.Count, totalCharged, totalPaid, totalBalance);

            lblSummary.ForeColor = totalBalance > 0 ? Color.Firebrick : Color.SeaGreen;
        }
        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterVisibility();
            // TODO: show/hide filters depending on which report is selected
        }

     

        private void btnPrint_Click(object sender, EventArgs e)
        {
       
            if (dgvReport.Columns.Count == 0 || dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("No data to print. Generate a report first.");
                return;
            }

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;
            printDialog.AllowSomePages = true;
            printDialog.UseEXDialog = true;


            if(printDialog.ShowDialog() != DialogResult.OK)
            return;
            
            // Show print preview dialog (user can pick printer, portrait/landscape, etc.)
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.Width = 1000;
            preview.Height = 700;
            preview.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font cellFont = new Font("Arial", 9, FontStyle.Regular);
            Font summaryFont = new Font("Arial", 10, FontStyle.Bold);

            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int rightEdge = e.MarginBounds.Right;
            int bottomEdge = e.MarginBounds.Bottom;

            int y = topMargin;

            // -----------------------------
            // 1. Title (only on first page)
            // -----------------------------
            if (printRowIndex == 0)
            {
                string title = cmbReportType.SelectedItem.ToString();
                g.DrawString(title, titleFont, Brushes.Black, leftMargin, y);
                y += 30;

                // Date printed
                string dateLine = "Printed: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                g.DrawString(dateLine, cellFont, Brushes.Gray, leftMargin, y);
                y += 25;
            }

            // -----------------------------
            // 2. Calculate column widths
            // -----------------------------
            int totalWidth = rightEdge - leftMargin;
            int colCount = dgvReport.Columns.Count;
            int colWidth = totalWidth / colCount;

            // -----------------------------
            // 3. Draw column headers
            // -----------------------------
            int x = leftMargin;
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                Rectangle rect = new Rectangle(x, y, colWidth, 25);
                g.FillRectangle(Brushes.LightGray, rect);
                g.DrawRectangle(Pens.Black, rect);
                g.DrawString(col.HeaderText, headerFont, Brushes.Black, x + 3, y + 5);
                x += colWidth;
            }
            y += 25;

            // -----------------------------
            // 4. Draw rows (until page fills)
            // -----------------------------
            int rowHeight = 20;
            while (printRowIndex < dgvReport.Rows.Count)
            {
                // If next row won't fit → tell Windows "print another page"
                if (y + rowHeight > bottomEdge - 40)  // leave space for summary
                {
                    e.HasMorePages = true;
                    return;
                }

                DataGridViewRow row = dgvReport.Rows[printRowIndex];
                x = leftMargin;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    Rectangle rect = new Rectangle(x, y, colWidth, rowHeight);
                    g.DrawRectangle(Pens.LightGray, rect);
                    string text = cell.Value == null ? "" : cell.Value.ToString();
                    g.DrawString(text, cellFont, Brushes.Black, x + 3, y + 3);
                    x += colWidth;
                }
                y += rowHeight;
                printRowIndex++;
            }

            // -----------------------------
            // 5. Summary line (last page only)
            // -----------------------------
            y += 15;
            g.DrawString(lblSummary.Text, summaryFont, Brushes.Black, leftMargin, y);

            // All done — no more pages
            e.HasMorePages = false;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            // 1. Check if there's data to export
            if (dgvReport.Columns.Count == 0 || dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("No data to export. Generate a report first.");
                return;
            }

            // 2. Open Save File dialog
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV files (*.csv)|*.csv";
            dlg.Title = "Export Report to CSV";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;  // user clicked Cancel

            // 3. Write the file
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(dlg.FileName))
                {
                    // 3a. Write header row (column names)
                    List<string> headers = new List<string>();
                    foreach (DataGridViewColumn col in dgvReport.Columns)
                        headers.Add(EscapeCsv(col.HeaderText));
                    writer.WriteLine(string.Join(",", headers));

                    // 3b. Write data rows
                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        List<string> values = new List<string>();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string value = cell.Value == null ? "" : cell.Value.ToString();
                            values.Add(EscapeCsv(value));
                        }
                        writer.WriteLine(string.Join(",", values));
                    }
                }

                MessageBox.Show("Exported successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting file: " + ex.Message);
            }
        }

        // Helper: wrap value in quotes if it contains comma, quote, or newline
        private string EscapeCsv(string value)
        {
            if (value == null) return "";

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                // Double any existing quotes, then wrap whole thing in quotes
                value = value.Replace("\"", "\"\"");
                return "\"" + value + "\"";
            }
            return value;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterVisibility();
        }

        private void btnDefaultDate_Click(object sender, EventArgs e)
        {
            DateTime min, max;
            reportsRepo.GetGlobalDateRange(out min, out max);

            dtpFrom.Value = min;
            dtpTo.Value = max;
        }

        private void grpFilters_Enter(object sender, EventArgs e)
        {

        }
    }
}

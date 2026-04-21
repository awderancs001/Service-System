using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using ServiceSystem.Data;
using ServiceSystem.Models;

namespace ServiceSystem.Forms
{
    public partial class InvoiceForm : Form
    {
        // Repositories we will need
        private InvoiceRepository  invoiceRepo  = new InvoiceRepository();
        private SettingsRepository settingsRepo = new SettingsRepository();

        // The payment this invoice is for — passed in by the caller (ReceiveMoneyForm)
        private Payment payment;

        // After saving, we store the Invoice so Print can use it
        private Invoice savedInvoice = null;

        // Constructor — receives the payment we want to print an invoice for
        public InvoiceForm(Payment p)
        {
            InitializeComponent();
            this.payment = p;

            // Set paper size to A5 for the printed invoice
            // (A5 = 148 x 210 mm, half of A4 — nice size for a receipt)
            printDocument.DefaultPageSettings.PaperSize =
                new PaperSize("A5", 583, 827); // hundredths of an inch
            // 583 × 827 (1/100 inch) = 148.1 × 210.1 mm = A5 exactly
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            // 1. Fill company info from SystemSettings
            lblCompanyName.Text    = settingsRepo.GetValue("CompanyName");
            lblCompanyPhone.Text   = "Phone: "   + settingsRepo.GetValue("CompanyPhone");
            lblCompanyAddress.Text = "Address: " + settingsRepo.GetValue("CompanyAddress");

            // 2. Check if this payment already has an invoice (no duplicates!)
            var existing = invoiceRepo.GetByPaymentID(payment.PaymentID);
            if (existing != null)
            {
                // Already invoiced — load the saved data instead of a fresh number
                savedInvoice = existing;
                lblInvoiceNumberValue.Text = existing.InvoiceNumber;
                txtContent.Text = existing.InvoiceContent;
                btnSave.Enabled = false;  // can't save again
                this.Text = "Invoice (already saved)";
            }
            else
            {
                // Fresh invoice — generate next number
                lblInvoiceNumberValue.Text = invoiceRepo.GenerateInvoiceNumber();
                txtContent.Text = BuildDefaultContent();
            }

            // 3. Fill payment info (labels are filled the same way whether new or existing)
            // We use CreatedDate (DATETIME) not PaymentDate (DATE only)
            // because PaymentDate strips the time — we want the real moment
            // "dd/MM/yyyy hh:mm tt"  →  "16/04/2026 02:24 PM"
            lblDateValue.Text     = payment.CreatedDate.ToString("dd/MM/yyyy hh:mm tt");
            lblReceiverValue.Text = payment.OwnerFullName;
            lblSignature.Text = payment.OwnerFullName;
            lblUnitValue.Text     = payment.UnitName + "  (" + payment.BuildingName + ")";

            // Multi-month? show range, else just one month
            lblMonthsValue.Text = payment.ToMonth.HasValue
                ? payment.ForMonth.ToString("MM/yyyy") + "  to  " + payment.ToMonth.Value.ToString("MM/yyyy")
                : payment.ForMonth.ToString("MM/yyyy");

            lblBillTypeValue.Text = "Mixed"; // user can upgrade UI later
            lblAmountValue.Text   = "$" + payment.Amount.ToString("F2");

            lblReceivedByValue.Text = SessionManager.CurrentUser.FullName;
        }

        // -------------------------------------------------------
        // Helper — builds default invoice content text
        // -------------------------------------------------------
        private string BuildDefaultContent()
        {
            string months = payment.ToMonth.HasValue
                ? payment.ForMonth.ToString("MM/yyyy") + " to " + payment.ToMonth.Value.ToString("MM/yyyy")
                : payment.ForMonth.ToString("MM/yyyy");

            return string.Format(
                "Received the amount of ${0} from {1} (Unit {2}) for service fees covering {3}.\r\n\r\nThank you.",
                payment.Amount.ToString("F2"),
                payment.OwnerFullName,
                payment.UnitName,
                months);
        }

        // -------------------------------------------------------
        // SAVE — create Invoice object and insert into DB
        // -------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                savedInvoice = new Invoice
                {
                    InvoiceNumber  = lblInvoiceNumberValue.Text,
                    PaymentID      = payment.PaymentID,
                    UnitID         = payment.UnitID,
                    GiverName      = lblCompanyName.Text,
                    ReceiverName   = payment.OwnerFullName,
                    DebtMonth      = payment.ForMonth,
                    DebtToMonth    = payment.ToMonth,
                    PaymentDate    = payment.PaymentDate,
                    Amount         = payment.Amount,
                    BillType       = lblBillTypeValue.Text,
                    InvoiceContent = txtContent.Text
                };

                invoiceRepo.Save(savedInvoice);
                MessageBox.Show("Invoice saved!", "Done");
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving invoice:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------------
        // PRINT — open Print Preview dialog
        // The actual drawing happens in printDocument_PrintPage below
        // -------------------------------------------------------
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (savedInvoice == null)
            {
                var result = MessageBox.Show(
                    "You should save the invoice first.\nPrint anyway as a preview?",
                    "Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }

            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        // -------------------------------------------------------
        // PRINT PAGE — fires when Windows asks us to draw the page
        // 'e.Graphics' is our canvas. We draw text/lines onto it.
        // Coordinates are in units of 1/100 inch by default.
        // -------------------------------------------------------
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font bigBold  = new Font("Arial", 16, FontStyle.Bold);
            Font bold     = new Font("Arial", 11, FontStyle.Bold);
            Font normal   = new Font("Arial", 10, FontStyle.Regular);
            Font amountFt = new Font("Arial", 14, FontStyle.Bold);

            float x = 60;   // left margin
            float y = 60;   // top margin

            // Company header — centered
            SizeF hdrSize = g.MeasureString(lblCompanyName.Text, bigBold);
            g.DrawString(lblCompanyName.Text, bigBold, Brushes.Black,
                (e.PageBounds.Width - hdrSize.Width) / 2, y);
            y += 30;

            g.DrawString(lblCompanyPhone.Text,   normal, Brushes.Black, x, y); y += 18;
            g.DrawString(lblCompanyAddress.Text, normal, Brushes.Black, x, y); y += 20;

            // Separator line
            g.DrawLine(Pens.Black, x, y, e.PageBounds.Width - x, y);
            y += 15;

            // Invoice info
            g.DrawString("Invoice #:", bold, Brushes.Black, x, y);
            g.DrawString(lblInvoiceNumberValue.Text, normal, Brushes.Black, x + 110, y);
            y += 22;

            g.DrawString("Date:", bold, Brushes.Black, x, y);
            g.DrawString(lblDateValue.Text, normal, Brushes.Black, x + 110, y);
            y += 25;

            g.DrawLine(Pens.Black, x, y, e.PageBounds.Width - x, y);
            y += 15;

            // Payer info
            g.DrawString("Received From:", bold, Brushes.Black, x, y);
            g.DrawString(lblReceiverValue.Text, normal, Brushes.Black, x + 110, y);
            y += 22;

            g.DrawString("Unit:", bold, Brushes.Black, x, y);
            g.DrawString(lblUnitValue.Text, normal, Brushes.Black, x + 110, y);
            y += 22;

            g.DrawString("For Months:", bold, Brushes.Black, x, y);
            g.DrawString(lblMonthsValue.Text, normal, Brushes.Black, x + 110, y);
            y += 22;

            g.DrawString("Bill Type:", bold, Brushes.Black, x, y);
            g.DrawString(lblBillTypeValue.Text, normal, Brushes.Black, x + 110, y);
            y += 30;

            // Amount — big and bold
            g.DrawString("AMOUNT:", amountFt, Brushes.Black, x, y);
            g.DrawString(lblAmountValue.Text, amountFt, Brushes.DarkGreen, x + 130, y);
            y += 40;

            // Separator
            g.DrawLine(Pens.Black, x, y, e.PageBounds.Width - x, y);
            y += 15;

            // Notes area — wrapped text inside a rectangle
            g.DrawString("Notes:", bold, Brushes.Black, x, y);
            y += 20;

            RectangleF notesArea = new RectangleF(x, y, e.PageBounds.Width - (2 * x), 200);
            g.DrawString(txtContent.Text, normal, Brushes.Black, notesArea);
            y += 210;

            // Signature line
            g.DrawLine(Pens.Black, x, y, e.PageBounds.Width - x, y);
            y += 10;
            g.DrawString("Received By: " + lblReceivedByValue.Text, bold, Brushes.Black, x, y);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDateValue_Click(object sender, EventArgs e)
        {

        }
    }
}

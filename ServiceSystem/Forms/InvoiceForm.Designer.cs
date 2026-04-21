namespace ServiceSystem.Forms
{
    partial class InvoiceForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.lblReceivedByValue = new System.Windows.Forms.Label();
            this.lblReceivedBy = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblAmountValue = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblMonthsValue = new System.Windows.Forms.Label();
            this.lblMonths = new System.Windows.Forms.Label();
            this.lblUnitValue = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblReceiverValue = new System.Windows.Forms.Label();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.lblSep2 = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblInvoiceNumberValue = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.lblSep1 = new System.Windows.Forms.Label();
            this.lblCompanyAddress = new System.Windows.Forms.Label();
            this.lblCompanyPhone = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.lblBillType = new System.Windows.Forms.Label();
            this.lblBillTypeValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSignature = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlInvoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.BackColor = System.Drawing.Color.White;
            this.pnlInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInvoice.Controls.Add(this.lblSignature);
            this.pnlInvoice.Controls.Add(this.label3);
            this.pnlInvoice.Controls.Add(this.label1);
            this.pnlInvoice.Controls.Add(this.lblReceivedByValue);
            this.pnlInvoice.Controls.Add(this.lblReceivedBy);
            this.pnlInvoice.Controls.Add(this.txtContent);
            this.pnlInvoice.Controls.Add(this.lblNotes);
            this.pnlInvoice.Controls.Add(this.lblAmountValue);
            this.pnlInvoice.Controls.Add(this.lblAmount);
            this.pnlInvoice.Controls.Add(this.lblBillTypeValue);
            this.pnlInvoice.Controls.Add(this.lblBillType);
            this.pnlInvoice.Controls.Add(this.lblMonthsValue);
            this.pnlInvoice.Controls.Add(this.lblMonths);
            this.pnlInvoice.Controls.Add(this.lblUnitValue);
            this.pnlInvoice.Controls.Add(this.lblUnit);
            this.pnlInvoice.Controls.Add(this.lblReceiverValue);
            this.pnlInvoice.Controls.Add(this.lblReceiver);
            this.pnlInvoice.Controls.Add(this.lblSep2);
            this.pnlInvoice.Controls.Add(this.lblDateValue);
            this.pnlInvoice.Controls.Add(this.lblDate);
            this.pnlInvoice.Controls.Add(this.lblInvoiceNumberValue);
            this.pnlInvoice.Controls.Add(this.lblInvoiceNumber);
            this.pnlInvoice.Controls.Add(this.lblSep1);
            this.pnlInvoice.Controls.Add(this.lblCompanyAddress);
            this.pnlInvoice.Controls.Add(this.lblCompanyPhone);
            this.pnlInvoice.Controls.Add(this.lblCompanyName);
            this.pnlInvoice.Location = new System.Drawing.Point(20, 20);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(500, 649);
            this.pnlInvoice.TabIndex = 0;
            // 
            // lblReceivedByValue
            // 
            this.lblReceivedByValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblReceivedByValue.Location = new System.Drawing.Point(113, 595);
            this.lblReceivedByValue.Name = "lblReceivedByValue";
            this.lblReceivedByValue.Size = new System.Drawing.Size(125, 20);
            this.lblReceivedByValue.TabIndex = 22;
            this.lblReceivedByValue.Text = "---";
            // 
            // lblReceivedBy
            // 
            this.lblReceivedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblReceivedBy.Location = new System.Drawing.Point(13, 595);
            this.lblReceivedBy.Name = "lblReceivedBy";
            this.lblReceivedBy.Size = new System.Drawing.Size(100, 20);
            this.lblReceivedBy.TabIndex = 21;
            this.lblReceivedBy.Text = "Received By:";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(15, 336);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(470, 130);
            this.txtContent.TabIndex = 20;
            // 
            // lblNotes
            // 
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblNotes.Location = new System.Drawing.Point(15, 313);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(100, 20);
            this.lblNotes.TabIndex = 19;
            this.lblNotes.Text = "Notes:";
            // 
            // lblAmountValue
            // 
            this.lblAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblAmountValue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblAmountValue.Location = new System.Drawing.Point(120, 285);
            this.lblAmountValue.Name = "lblAmountValue";
            this.lblAmountValue.Size = new System.Drawing.Size(365, 25);
            this.lblAmountValue.TabIndex = 18;
            this.lblAmountValue.Text = "$0.00";
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Location = new System.Drawing.Point(15, 285);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(100, 25);
            this.lblAmount.TabIndex = 17;
            this.lblAmount.Text = "AMOUNT:";
            // 
            // lblMonthsValue
            // 
            this.lblMonthsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMonthsValue.Location = new System.Drawing.Point(115, 225);
            this.lblMonthsValue.Name = "lblMonthsValue";
            this.lblMonthsValue.Size = new System.Drawing.Size(370, 20);
            this.lblMonthsValue.TabIndex = 14;
            this.lblMonthsValue.Text = "--/----";
            // 
            // lblMonths
            // 
            this.lblMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonths.Location = new System.Drawing.Point(15, 225);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(100, 20);
            this.lblMonths.TabIndex = 13;
            this.lblMonths.Text = "For Months:";
            // 
            // lblUnitValue
            // 
            this.lblUnitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblUnitValue.Location = new System.Drawing.Point(115, 200);
            this.lblUnitValue.Name = "lblUnitValue";
            this.lblUnitValue.Size = new System.Drawing.Size(370, 20);
            this.lblUnitValue.TabIndex = 12;
            this.lblUnitValue.Text = "---";
            // 
            // lblUnit
            // 
            this.lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblUnit.Location = new System.Drawing.Point(15, 200);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(100, 20);
            this.lblUnit.TabIndex = 11;
            this.lblUnit.Text = "Unit:";
            // 
            // lblReceiverValue
            // 
            this.lblReceiverValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblReceiverValue.Location = new System.Drawing.Point(138, 175);
            this.lblReceiverValue.Name = "lblReceiverValue";
            this.lblReceiverValue.Size = new System.Drawing.Size(309, 20);
            this.lblReceiverValue.TabIndex = 10;
            this.lblReceiverValue.Text = "---";
            // 
            // lblReceiver
            // 
            this.lblReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblReceiver.Location = new System.Drawing.Point(15, 175);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(100, 20);
            this.lblReceiver.TabIndex = 9;
            this.lblReceiver.Text = "Received From:";
            // 
            // lblSep2
            // 
            this.lblSep2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSep2.Location = new System.Drawing.Point(10, 160);
            this.lblSep2.Name = "lblSep2";
            this.lblSep2.Size = new System.Drawing.Size(478, 2);
            this.lblSep2.TabIndex = 8;
            // 
            // lblDateValue
            // 
            this.lblDateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDateValue.Location = new System.Drawing.Point(115, 135);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(370, 20);
            this.lblDateValue.TabIndex = 7;
            this.lblDateValue.Text = "--/--/----";
            this.lblDateValue.Click += new System.EventHandler(this.lblDateValue_Click);
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(15, 135);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 20);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date:";
            // 
            // lblInvoiceNumberValue
            // 
            this.lblInvoiceNumberValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblInvoiceNumberValue.Location = new System.Drawing.Point(115, 110);
            this.lblInvoiceNumberValue.Name = "lblInvoiceNumberValue";
            this.lblInvoiceNumberValue.Size = new System.Drawing.Size(370, 20);
            this.lblInvoiceNumberValue.TabIndex = 5;
            this.lblInvoiceNumberValue.Text = "INV-0000-0000";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceNumber.Location = new System.Drawing.Point(15, 110);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(100, 20);
            this.lblInvoiceNumber.TabIndex = 4;
            this.lblInvoiceNumber.Text = "Invoice #:";
            // 
            // lblSep1
            // 
            this.lblSep1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSep1.Location = new System.Drawing.Point(10, 95);
            this.lblSep1.Name = "lblSep1";
            this.lblSep1.Size = new System.Drawing.Size(478, 2);
            this.lblSep1.TabIndex = 3;
            // 
            // lblCompanyAddress
            // 
            this.lblCompanyAddress.Location = new System.Drawing.Point(10, 70);
            this.lblCompanyAddress.Name = "lblCompanyAddress";
            this.lblCompanyAddress.Size = new System.Drawing.Size(478, 18);
            this.lblCompanyAddress.TabIndex = 2;
            this.lblCompanyAddress.Text = " Chwarcha - Sulaymani";
            this.lblCompanyAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCompanyPhone
            // 
            this.lblCompanyPhone.Location = new System.Drawing.Point(10, 50);
            this.lblCompanyPhone.Name = "lblCompanyPhone";
            this.lblCompanyPhone.Size = new System.Drawing.Size(478, 18);
            this.lblCompanyPhone.TabIndex = 1;
            this.lblCompanyPhone.Text = "Phone: 07700992626";
            this.lblCompanyPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblCompanyName.Location = new System.Drawing.Point(10, 15);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(478, 30);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "New Chwarchra Resisdant";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(109, 675);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Invoice";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(209, 675);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 32);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(309, 675);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // lblBillType
            // 
            this.lblBillType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblBillType.Location = new System.Drawing.Point(15, 250);
            this.lblBillType.Name = "lblBillType";
            this.lblBillType.Size = new System.Drawing.Size(100, 20);
            this.lblBillType.TabIndex = 15;
            this.lblBillType.Text = "Bill Type:";
            this.lblBillType.Visible = false;
            // 
            // lblBillTypeValue
            // 
            this.lblBillTypeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblBillTypeValue.Location = new System.Drawing.Point(115, 250);
            this.lblBillTypeValue.Name = "lblBillTypeValue";
            this.lblBillTypeValue.Size = new System.Drawing.Size(370, 20);
            this.lblBillTypeValue.TabIndex = 16;
            this.lblBillTypeValue.Text = "Mixed";
            this.lblBillTypeValue.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Signature";
            // 
            // lblSignature
            // 
            this.lblSignature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSignature.Location = new System.Drawing.Point(357, 595);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(138, 20);
            this.lblSignature.TabIndex = 25;
            this.lblSignature.Text = "---";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(257, 595);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Received:";
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 816);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlInvoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.pnlInvoice.ResumeLayout(false);
            this.pnlInvoice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblCompanyPhone;
        private System.Windows.Forms.Label lblCompanyAddress;
        private System.Windows.Forms.Label lblSep1;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblInvoiceNumberValue;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblSep2;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.Label lblReceiverValue;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblUnitValue;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label lblMonthsValue;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAmountValue;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblReceivedBy;
        private System.Windows.Forms.Label lblReceivedByValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.Label lblBillTypeValue;
        private System.Windows.Forms.Label lblBillType;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

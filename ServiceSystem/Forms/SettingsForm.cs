using System;
using System.Windows.Forms;
using ServiceSystem.Data;

namespace ServiceSystem.Forms
{
    public partial class SettingsForm : Form
    {
        private SettingsRepository settingsRepo = new SettingsRepository();

        public SettingsForm()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------
        // LOAD — pull each setting from DB into its matching field
        // -------------------------------------------------------
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Company
            txtCompanyName.Text        = settingsRepo.GetValue("CompanyName");
            txtCompanyNameKurdish.Text = settingsRepo.GetValue("CompanyNameKurdish");
            txtCompanyPhone.Text       = settingsRepo.GetValue("CompanyPhone");
            txtCompanyAddress.Text     = settingsRepo.GetValue("CompanyAddress");

            // Invoice
            txtInvoicePrefix.Text           = settingsRepo.GetValue("InvoicePrefix");
            lblLastInvoiceNumberValue.Text  = settingsRepo.GetValue("LastInvoiceNumber");

            // Electric
            txtDefaultElectricPrice.Text = settingsRepo.GetValue("DefaultElectricPrice");

            // Backup
            txtBackupFolderPath.Text        = settingsRepo.GetValue("BackupFolderPath");
            txtAutoBackupIntervalDays.Text  = settingsRepo.GetValue("AutoBackupIntervalDays");

            // Checkbox: stored as "1" or "0" strings
            chkAutoBackupEnabled.Checked = settingsRepo.GetValue("AutoBackupEnabled") == "1";
        }

        // -------------------------------------------------------
        // SAVE — push each field back into the DB
        // Validate numeric fields before writing
        // -------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation — must be a valid decimal
            if (!decimal.TryParse(txtDefaultElectricPrice.Text, out _))
            {
                MessageBox.Show("Default Electric Price must be a number.",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation — must be a positive integer
            if (!int.TryParse(txtAutoBackupIntervalDays.Text, out int days) || days < 1)
            {
                MessageBox.Show("Backup Interval must be a whole number 1 or greater.",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation — company name can't be empty (it prints on invoices!)
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                MessageBox.Show("Company Name cannot be empty.",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Company
                settingsRepo.SetValue("CompanyName",        txtCompanyName.Text.Trim());
                settingsRepo.SetValue("CompanyNameKurdish", txtCompanyNameKurdish.Text.Trim());
                settingsRepo.SetValue("CompanyPhone",       txtCompanyPhone.Text.Trim());
                settingsRepo.SetValue("CompanyAddress",     txtCompanyAddress.Text.Trim());

                // Invoice
                settingsRepo.SetValue("InvoicePrefix", txtInvoicePrefix.Text.Trim());

                // Electric
                settingsRepo.SetValue("DefaultElectricPrice", txtDefaultElectricPrice.Text.Trim());

                // Backup
                settingsRepo.SetValue("BackupFolderPath",       txtBackupFolderPath.Text.Trim());
                settingsRepo.SetValue("AutoBackupIntervalDays", txtAutoBackupIntervalDays.Text.Trim());
                settingsRepo.SetValue("AutoBackupEnabled",      chkAutoBackupEnabled.Checked ? "1" : "0");

                MessageBox.Show("Settings saved!", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------------
        // BROWSE — opens a folder picker, puts the chosen path
        // into the Backup Folder textbox.
        // -------------------------------------------------------
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Pre-select the current folder so user doesn't start from C:\
            if (!string.IsNullOrEmpty(txtBackupFolderPath.Text))
                folderBrowser.SelectedPath = txtBackupFolderPath.Text;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                // Ensure path ends with \ so file-writing code can append filenames cleanly
                string path = folderBrowser.SelectedPath;
                if (!path.EndsWith("\\")) path += "\\";
                txtBackupFolderPath.Text = path;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

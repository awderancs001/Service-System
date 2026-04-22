using ServiceSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceSystem.Forms
{
    public partial class BackupForm : Form
    {
        private BackupRepository backupRepo = new BackupRepository();

        public BackupForm()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
             "Create a backup now?\n\nThe file will be saved to:\n" + backupRepo.GetBackupFolder(),
             "Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Show wait cursor during backup
            this.Cursor = Cursors.WaitCursor;

            try
            {
                string file = backupRepo.Backup();
                this.Cursor = Cursors.Default;

                MessageBox.Show(
                    "Backup completed successfully.\n\nSaved to:\n" + file,
                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(
                    "Backup failed:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a backup file to restore";
            ofd.InitialDirectory = backupRepo.GetBackupFolder();
            ofd.Filter = "SQL Backup files (*.bak)|*.bak|All files (*.*)|*.*";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            string backupFile = ofd.FileName;

            // SERIOUS confirmation — restore overwrites everything
            var confirm = MessageBox.Show(
                "⚠ WARNING ⚠\n\n" +
                "Restoring will REPLACE all current data with the data from the backup file.\n\n" +
                "Any data entered AFTER the backup was made will be LOST.\n\n" +
                "Are you absolutely sure you want to restore from:\n" + backupFile + "?",
                "Confirm Restore",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            // Extra safety — type YES to confirm? Skip for now, double-click prevention.

            this.Cursor = Cursors.WaitCursor;

            try
            {
                backupRepo.Restore(backupFile);
                this.Cursor = Cursors.Default;

                MessageBox.Show(
                    "Restore completed successfully.\n\n" +
                    "The application will now close. Please log in again.",
                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Force full restart — restored DB may have different users, so clear session
                Application.Exit();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(
                    "Restore failed:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string folder = backupRepo.GetBackupFolder();
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                Process.Start("explorer.exe", folder);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open folder: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

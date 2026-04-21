using ServiceSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ServiceSystem.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private UserRepository userRepo = new UserRepository();
        private int userID;

        public ChangePasswordForm(int userID, string username, string fullName)
        {
            InitializeComponent();
            this.userID = userID;
            lblUserInfo.Text = fullName + " (" + username + ")";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validation (unchanged — no DB)
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter a new password.");
                this.DialogResult = DialogResult.None;
                return;
            }
            if (txtPassword.Text.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters.");
                this.DialogResult = DialogResult.None;
                return;
            }
            if (txtPassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Passwords do not match. Please retype.");
                this.DialogResult = DialogResult.None;
                return;
            }

            // DB call
            try
            {
                userRepo.ChangePassword(userID, txtPassword.Text);
                MessageBox.Show("Password changed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not change password: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;  // keep dialog open on error
            }
        }
        }
}

using ServiceSystem.Data;
using ServiceSystem.Models;
using System;
using System.Windows.Forms;

namespace ServiceSystem.Forms
{
    public partial class LoginForm : Form
    {
        private UserRepository userRepo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check that username and password are not empty
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter username.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter password.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Try to login — returns User object if correct, null if wrong
            User user = null;
            try
            {
                user = userRepo.Login(txtUsername.Text.Trim(), txtPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not connect to the database.\n\n" +
                    "Please make sure SQL Server is running and try again.\n\n" +
                    "Details: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user == null)
            {
                MessageBox.Show("Wrong username or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Login successful — save the user in SessionManager
            SessionManager.CurrentUser = user;

            // Open main form and close login form
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

    }
}

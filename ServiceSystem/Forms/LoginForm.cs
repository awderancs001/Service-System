using ServiceSystem.Data;
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
            var user = userRepo.Login(txtUsername.Text.Trim(), txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Wrong username or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Login successful — save the user in SessionManager
            // Now every form in the system knows who is logged in
            SessionManager.CurrentUser = user;

            // Open main form and close login form
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    
    }
}

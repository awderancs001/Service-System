using ServiceSystem.Data;
using ServiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ServiceSystem.Forms
{
    public partial class UserManagementForm : Form
    {

        private UserRepository userRepo = new UserRepository();
        private List<User> userList;       // keep track of users (for row click)
        private User selectedUser = null;  // currently selected user (null = new)
        public UserManagementForm()
        {
            InitializeComponent();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            FillRoleComboBox();
            LoadUsers();
            ClearForm();
        }
        private void FillRoleComboBox()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("User");
            cmbRole.SelectedIndex = 1;  // default to "User" (safer than default Admin)
        }

        private void LoadUsers()
        {
            try
            {
                // 1. Get all users from database
                userList = userRepo.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load users: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userList = new List<User>();  // empty list so grid still works
                return;
            }

            // 2. Clear grid
            dgvUserList.Rows.Clear();
            dgvUserList.Columns.Clear();

            // 3. Add columns
            dgvUserList.Columns.Add("Username", "Username");
            dgvUserList.Columns.Add("FullName", "Full Name");
            dgvUserList.Columns.Add("Role", "Role");
            dgvUserList.Columns.Add("Status", "Status");

            // 4. Fill rows
            foreach (User u in userList)
            {
                dgvUserList.Rows.Add(
                    u.Username,
                    u.FullName,
                    u.Role,
                    u.IsActive ? "Active" : "Inactive"
                );
            }
        }

        private void ClearForm()
        {
            selectedUser = null;          // new user mode
            txtUsername.Clear();
            txtFullName.Clear();
            cmbRole.SelectedIndex = 1;    // default "User"
            chkIsActive.Checked = true;   // new users are active by default
            txtUsername.Enabled = true;   // can set username for new user

            // Show password fields (new user mode)
            lblPassword.Visible = true;
            txtPassword.Visible = true;
            lblConfirmPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtUsername.Focus();          // cursor ready to type
        }

        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Ignore header click
            if (e.RowIndex < 0) return;

            // Get the user from parallel list
            selectedUser = userList[e.RowIndex];

            // Fill the right panel fields
            txtUsername.Text = selectedUser.Username;
            txtFullName.Text = selectedUser.FullName;
            cmbRole.SelectedItem = selectedUser.Role;
            chkIsActive.Checked = selectedUser.IsActive;

            // Lock username — cannot change for existing user
            txtUsername.Enabled = false;

            // Hide password fields (edit mode — use Change PW button instead)
            lblPassword.Visible = false;
            txtPassword.Visible = false;
            lblConfirmPassword.Visible = false;
            txtConfirmPassword.Visible = false;
        }

    

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
       
            // 1. Validation (no DB, no try/catch needed)
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter a full name.");
                return;
            }
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            // 2. Decide: new or update?
            if (selectedUser == null)
            {
                // --- NEW USER ---
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please enter a password.");
                    return;
                }
                if (txtPassword.Text.Length < 4)
                {
                    MessageBox.Show("Password must be at least 4 characters.");
                    return;
                }
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match. Please retype.");
                    return;
                }

                // DB call #1 — check duplicate
                try
                {
                    if (userRepo.UsernameExists(txtUsername.Text.Trim()))
                    {
                        MessageBox.Show("This username is already taken.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not check username: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Build user object
                User newUser = new User();
                newUser.Username = txtUsername.Text.Trim();
                newUser.FullName = txtFullName.Text.Trim();
                newUser.Role = cmbRole.SelectedItem.ToString();
                newUser.IsActive = chkIsActive.Checked;

                // DB call #2 — save
                try
                {
                    userRepo.Save(newUser, txtPassword.Text);
                    MessageBox.Show("User created successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not save user: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // --- UPDATE EXISTING USER ---
                if (selectedUser.UserID == SessionManager.CurrentUser.UserID
                    && !chkIsActive.Checked)
                {
                    MessageBox.Show("You cannot deactivate your own account.");
                    return;
                }

                // Last-admin protection
                // If this user is currently an active Admin, and the change would remove them
                // from the admin pool (role change OR deactivation), make sure they're not the last one
                bool wasActiveAdmin = (selectedUser.Role == "Admin" && selectedUser.IsActive);
                bool willStillBeAdmin = (cmbRole.SelectedItem.ToString() == "Admin" && chkIsActive.Checked);

                if (wasActiveAdmin && !willStillBeAdmin)
                {
                    try
                    {
                        int adminCount = userRepo.CountActiveAdmins();
                        if (adminCount <= 1)
                        {
                            MessageBox.Show(
                                "This is the last active administrator.\n\n" +
                                "You cannot remove admin rights or deactivate this account, " +
                                "because it would lock everyone out of user management and settings.",
                                "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not verify admin count: " + ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                selectedUser.FullName = txtFullName.Text.Trim();
                selectedUser.Role = cmbRole.SelectedItem.ToString();
                selectedUser.IsActive = chkIsActive.Checked;

                // DB call — update
                try
                {
                    userRepo.Update(selectedUser);
                    MessageBox.Show("User updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not update user: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 3. Reload grid + clear form — also wrapped (DB read)
            try
            {
                LoadUsers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not refresh list: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        private void btnChangePW_Click(object sender, EventArgs e)
        {

            // Must select a user first
            if (selectedUser == null)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            // Open the dialog
            ChangePasswordForm dlg = new ChangePasswordForm(
                selectedUser.UserID,
                selectedUser.Username,
                selectedUser.FullName);

            dlg.ShowDialog();

            // Nothing more to do — password is changed inside dialog

        }
    }
}

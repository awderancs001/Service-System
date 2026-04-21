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

namespace ServiceSystem.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "👤  " + SessionManager.CurrentUser.FullName;
            lblRole.Text = SessionManager.CurrentUser.Role;
            lblDate.Text = "📅  " + DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you Sure?", "Logout", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SessionManager.CurrentUser = null;
                this.Hide();
                new LoginForm().Show();   
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUnits_Click(object sender, EventArgs e)
        {
            UnitsForm uForm = new UnitsForm();  
            uForm.ShowDialog();
        }

        private void btnMontlyService_Click(object sender, EventArgs e)
        {
            new MonthlyServiceForm().ShowDialog();
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            new MaintenanceForm().ShowDialog();
        }

        private void btnElectric_Click(object sender, EventArgs e)
        {
            new ElectricForm().ShowDialog();
        }

        private void btnRecieveMoney_Click(object sender, EventArgs e)
        {
            new ReceiveMoneyForm().ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Only Admin should edit system settings
            if (SessionManager.CurrentUser.Role != "Admin")
            {
                MessageBox.Show("Only an administrator can change system settings.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new SettingsForm().ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            new ReportsForm().ShowDialog();
        }
    }
}

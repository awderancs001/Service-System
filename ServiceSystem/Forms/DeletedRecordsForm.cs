using ServiceSystem.Data;
using System;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace ServiceSystem.Forms
{
    public partial class DeletedRecordsForm : Form
    {
        public DeletedRecordsForm()
        {
            InitializeComponent();
        }

        private void DeletedRecordsForm_Load(object sender, EventArgs e)
        {
            LoadDeleted();
        }


        private void LoadDeleted()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    string sql = @"SELECT DeleteID, TableName, RecordID, RecordDescription,
                                          DeletedByName, DeletedDate
                                   FROM DeletedRecords
                                   ORDER BY DeletedDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                }

                dgvDeleteRecords.DataSource = dt;

                // Friendly column headers
                if (dgvDeleteRecords.Columns["DeleteID"] != null)
                    dgvDeleteRecords.Columns["DeleteID"].Visible = false;
                if (dgvDeleteRecords.Columns["RecordID"] != null)
                    dgvDeleteRecords.Columns["RecordID"].Visible = false;
                if (dgvDeleteRecords.Columns["TableName"] != null)
                    dgvDeleteRecords.Columns["TableName"].HeaderText = "Type";
                if (dgvDeleteRecords.Columns["RecordDescription"] != null)
                    dgvDeleteRecords.Columns["RecordDescription"].HeaderText = "Description";
                if (dgvDeleteRecords.Columns["DeletedByName"] != null)
                    dgvDeleteRecords.Columns["DeletedByName"].HeaderText = "Deleted By";
                if (dgvDeleteRecords.Columns["DeletedDate"] != null)
                    dgvDeleteRecords.Columns["DeletedDate"].HeaderText = "Deleted Date";

                dgvDeleteRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load deleted records: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvDeleteRecords.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to restore.");
                return;
            }

            // Read the row data
            int deleteID = Convert.ToInt32(dgvDeleteRecords.CurrentRow.Cells["DeleteID"].Value);
            int recordID = Convert.ToInt32(dgvDeleteRecords.CurrentRow.Cells["RecordID"].Value);
            string table = dgvDeleteRecords.CurrentRow.Cells["TableName"].Value.ToString();
            string desc = dgvDeleteRecords.CurrentRow.Cells["RecordDescription"].Value.ToString();

            var ok = MessageBox.Show(
                "Restore this record?\n\n" + desc,
                "Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok != DialogResult.Yes) return;

            // Dispatch by table name
            // - Units use IsActive flag
            // - Bills/Payments use IsDeleted flag
            string updateSql;
            switch (table)
            {
                case "Units":
                    updateSql = "UPDATE Units SET IsActive = 1 WHERE UnitID = @ID";
                    break;
                case "MonthlyServiceBills":
                    updateSql = "UPDATE MonthlyServiceBills SET IsDeleted = 0 WHERE BillID = @ID";
                    break;
                case "MaintenanceBills":
                    updateSql = "UPDATE MaintenanceBills SET IsDeleted = 0 WHERE MaintenanceID = @ID";
                    break;
                case "ElectricBills":
                    updateSql = "UPDATE ElectricBills SET IsDeleted = 0 WHERE ElectricID = @ID";
                    break;
                case "Payments":
                    updateSql = "UPDATE Payments SET IsDeleted = 0 WHERE PaymentID = @ID";
                    break;
                default:
                    MessageBox.Show("Unknown table: " + table);
                    return;
            }

            try
            {
                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    con.Open();
                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        try
                        {
                            // 1. Restore the record
                            SqlCommand restoreCmd = new SqlCommand(updateSql, con, tx);
                            restoreCmd.Parameters.AddWithValue("@ID", recordID);
                            restoreCmd.ExecuteNonQuery();

                            // 2. Remove the audit log row
                            SqlCommand logCmd = new SqlCommand(
                                "DELETE FROM DeletedRecords WHERE DeleteID = @DeleteID", con, tx);
                            logCmd.Parameters.AddWithValue("@DeleteID", deleteID);
                            logCmd.ExecuteNonQuery();

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Record restored successfully.");
                LoadDeleted();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not restore: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDeleted();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

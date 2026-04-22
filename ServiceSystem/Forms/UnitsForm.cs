using ServiceSystem.Data;
using ServiceSystem.Models;
using System;
using System.Windows.Forms;

namespace ServiceSystem.Forms
{
    public partial class UnitsForm : Form
    {
        // --- Repositories ---
        private BuildingRepository buildingRepo = new BuildingRepository();
        private UnitRepository unitRepo = new UnitRepository();

        // --- State tracking ---
        private int selectedBuildingID = 0;  // which building is selected in lstBuildings
        private int selectedUnitID = 0;      // which unit row is selected in dgvUnits
        private bool isEditMode = false;     // true = editing existing unit, false = adding new

        public UnitsForm()
        {
            InitializeComponent();
        }

        // =====================================================================
        //  FORM LOAD
        // =====================================================================
        private void UnitsForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadBuildings();
            HideDetailPanel();
        }

        // =====================================================================
        //  SETUP GRID — column headers and widths
        // =====================================================================
        private void SetupGrid()
        {
            dgvUnits.Columns.Clear();

            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "colID",       HeaderText = "#",          Width = 40  });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUnitName",  HeaderText = "Unit Name",  Width = 100 });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOwner",     HeaderText = "Owner",      Width = 130 });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPhone",     HeaderText = "Phone",      Width = 110 });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFee",       HeaderText = "Monthly $",  Width = 80  });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTenant",    HeaderText = "Tenant",     Width = 60  });
        }

        // =====================================================================
        //  LOAD BUILDINGS into the left list
        // =====================================================================
        private void LoadBuildings()
        {
            // DisplayMember tells the ListBox which text to show for each object
            lstBuildings.DisplayMember = "BuildingName";
            lstBuildings.ValueMember   = "BuildingID";

            lstBuildings.Items.Clear();

            var list = buildingRepo.GetAll();
            foreach (var b in list)
                lstBuildings.Items.Add(b);  // we store the full Building object
        }

        // =====================================================================
        //  LOAD UNITS for the selected building
        // =====================================================================
        private void LoadUnits(int buildingID)
        {
            dgvUnits.Rows.Clear();

            var list = unitRepo.GetByBuilding(buildingID);

            foreach (var u in list)
            {
                string hasTenant = u.TenantFullName != null && u.TenantFullName.Trim() != "" ? "Yes" : "No";

                int rowIndex = dgvUnits.Rows.Add(
                    u.UnitID,
                    u.UnitName,
                    u.OwnerFullName,
                    u.OwnerPhone,
                    u.MonthlyServiceAmount.ToString("F0"),
                    hasTenant
                );

                // Store the UnitID in the row Tag so we can retrieve it on click
                dgvUnits.Rows[rowIndex].Tag = u.UnitID;
            }
        }

        // =====================================================================
        //  HIDE / SHOW DETAIL PANEL
        // =====================================================================
        private void HideDetailPanel()
        {
            pnlDetail.Visible = false;

            // Clear all fields
            cmbBuilding.SelectedIndex  = -1;
            txtUnitName.Clear();
            txtMonthlyFee.Clear();

            txtOwnerFullName.Clear();
            txtOwnerPhone.Clear();
            txtOwnerOtherPhone.Clear();
            txtOwnerNation.Clear();

            chkHasTenant.Checked = false;
            txtTenantFullName.Clear();
            txtTenantPhone.Clear();
            txtTenantOtherPhone.Clear();
            txtTenantNation.Clear();

            SetTenantFieldsEnabled(false);

            selectedUnitID = 0;
            isEditMode = false;
        }

        private void ShowDetailPanel(bool editMode)
        {
            isEditMode = editMode;
            pnlDetail.Visible = true;

            // Load buildings into the combo (always refresh)
            cmbBuilding.DisplayMember = "BuildingName";
            cmbBuilding.ValueMember   = "BuildingID";
            cmbBuilding.DataSource    = buildingRepo.GetAll();

            // Pre-select the current building
            if (selectedBuildingID > 0)
            {
                foreach (Building b in cmbBuilding.Items)
                {
                    if (b.BuildingID == selectedBuildingID)
                    {
                        cmbBuilding.SelectedItem = b;
                        break;
                    }
                }
            }
        }

        // =====================================================================
        //  TENANT FIELDS — enable or disable based on checkbox
        // =====================================================================
        private void SetTenantFieldsEnabled(bool enabled)
        {
            txtTenantFullName.Enabled   = enabled;
            txtTenantPhone.Enabled      = enabled;
            txtTenantOtherPhone.Enabled = enabled;
            txtTenantNation.Enabled     = enabled;
        }

        private void chkHasTenant_CheckedChanged(object sender, EventArgs e)
        {
            SetTenantFieldsEnabled(chkHasTenant.Checked);

            if (!chkHasTenant.Checked)
            {
                txtTenantFullName.Clear();
                txtTenantPhone.Clear();
                txtTenantOtherPhone.Clear();
                txtTenantNation.Clear();
            }
        }

        // =====================================================================
        //  BUILDING LIST — selection changed
        // =====================================================================
        private void lstBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBuildings.SelectedItem == null) return;

            var building = (Building)lstBuildings.SelectedItem;
            selectedBuildingID = building.BuildingID;

            LoadUnits(selectedBuildingID);
            HideDetailPanel();
        }

        // =====================================================================
        //  ADD BUILDING
        // =====================================================================
        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            string name = ShowInputDialog("Enter building name:", "Add Building");
            if (string.IsNullOrWhiteSpace(name)) return;

            string category = ShowCategoryDialog();
            if (category == null) return;

            if (buildingRepo.NameExists(name))
            {
                MessageBox.Show("A building with this name already exists.", "Duplicate",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var b = new Building { BuildingName = name.Trim(), BuildingCategory = category };
            buildingRepo.Save(b);
            LoadBuildings();
        }

        // Small reusable input dialog — replaces Microsoft.VisualBasic.InputBox
        private string ShowInputDialog(string prompt, string title)
        {
            Form f   = new Form { Width = 300, Height = 130, Text = title,
                                  StartPosition = FormStartPosition.CenterParent,
                                  FormBorderStyle = FormBorderStyle.FixedDialog,
                                  MaximizeBox = false, MinimizeBox = false };
            Label lbl   = new Label  { Left = 10, Top = 15, Width = 270, Text = prompt };
            TextBox txt  = new TextBox { Left = 10, Top = 35, Width = 260 };
            Button ok    = new Button { Text = "OK",     Left = 110, Top = 65, Width = 75, DialogResult = DialogResult.OK };
            Button cancel= new Button { Text = "Cancel", Left = 195, Top = 65, Width = 75, DialogResult = DialogResult.Cancel };
            f.Controls.AddRange(new Control[] { lbl, txt, ok, cancel });
            f.AcceptButton = ok;
            f.CancelButton = cancel;
            return f.ShowDialog() == DialogResult.OK ? txt.Text : "";
        }

        // Shows a small dialog with two radio buttons: House / Apartment
        // Returns "House", "Apartment", or null if cancelled
        private string ShowCategoryDialog()
        {
            Form f = new Form
            {
                Width = 260, Height = 150, Text = "Building Type",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false, MinimizeBox = false
            };

            RadioButton rbHouse     = new RadioButton { Text = "House",     Left = 30, Top = 20, Width = 180, Checked = true };
            RadioButton rbApartment = new RadioButton { Text = "Apartment", Left = 30, Top = 50, Width = 180 };
            Button ok     = new Button { Text = "OK",     Left = 60,  Top = 85, Width = 75, DialogResult = DialogResult.OK };
            Button cancel = new Button { Text = "Cancel", Left = 145, Top = 85, Width = 75, DialogResult = DialogResult.Cancel };

            f.Controls.AddRange(new Control[] { rbHouse, rbApartment, ok, cancel });
            f.AcceptButton = ok;
            f.CancelButton = cancel;

            if (f.ShowDialog() != DialogResult.OK) return null;
            return rbHouse.Checked ? "House" : "Apartment";
        }

        // =====================================================================
        //  DELETE BUILDING
        // =====================================================================
        private void btnDeleteBuilding_Click(object sender, EventArgs e)
        {
            // Admin only
            if (SessionManager.CurrentUser.Role != "Admin")
            {
                MessageBox.Show("Only an administrator can delete records.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstBuildings.SelectedItem == null)
            {
                MessageBox.Show("Please select a building first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var building = (Building)lstBuildings.SelectedItem;

            var result = MessageBox.Show(
                $"Delete building \"{building.BuildingName}\"?\n\nAll units inside it will also be deleted.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            buildingRepo.Delete(building.BuildingID);
            selectedBuildingID = 0;
            dgvUnits.Rows.Clear();
            LoadBuildings();
            HideDetailPanel();
        }

        // =====================================================================
        //  ADD UNIT
        // =====================================================================
        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            if (selectedBuildingID == 0)
            {
                MessageBox.Show("Please select a building first.", "No Building Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            HideDetailPanel();
            ShowDetailPanel(editMode: false);
        }

        // =====================================================================
        //  EDIT UNIT
        // =====================================================================
        private void btnEditUnit_Click(object sender, EventArgs e)
        {
            if (dgvUnits.CurrentRow == null)
            {
                MessageBox.Show("Please select a unit first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            selectedUnitID = (int)dgvUnits.CurrentRow.Tag;
            var unit = unitRepo.GetByID(selectedUnitID);
            if (unit == null) return;

            ShowDetailPanel(editMode: true);
            FillDetailPanel(unit);
        }

        // Fill detail panel fields from a Unit object
        private void FillDetailPanel(Unit u)
        {
            // Select building in combo
            foreach (Building b in cmbBuilding.Items)
            {
                if (b.BuildingID == u.BuildingID)
                {
                    cmbBuilding.SelectedItem = b;
                    break;
                }
            }

            txtUnitName.Text   = u.UnitName;
            txtMonthlyFee.Text = u.MonthlyServiceAmount.ToString("F0");

            txtOwnerFullName.Text   = u.OwnerFullName;
            txtOwnerPhone.Text      = u.OwnerPhone;
            txtOwnerOtherPhone.Text = u.OwnerOtherPhone;
            txtOwnerNation.Text     = u.OwnerNation;

            bool hasTenant = !string.IsNullOrWhiteSpace(u.TenantFullName);
            chkHasTenant.Checked = hasTenant;
            SetTenantFieldsEnabled(hasTenant);

            txtTenantFullName.Text   = u.TenantFullName;
            txtTenantPhone.Text      = u.TenantPhone;
            txtTenantOtherPhone.Text = u.TenantOtherPhone;
            txtTenantNation.Text     = u.TenantNation;
        }

        // =====================================================================
        //  DELETE UNIT
        // =====================================================================
        private void btnDeleteUnit_Click(object sender, EventArgs e)
        {

            // Admin only
            if (SessionManager.CurrentUser.Role != "Admin")
            {
                MessageBox.Show("Only an administrator can delete records.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvUnits.CurrentRow == null)
            {
                MessageBox.Show("Please select a unit first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int unitID = (int)dgvUnits.CurrentRow.Tag;
            string unitName = dgvUnits.CurrentRow.Cells["colUnitName"].Value?.ToString();

            var result = MessageBox.Show(
                $"Delete unit \"{unitName}\"?\n\nIt will be moved to Deleted Records.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            unitRepo.Delete(unitID, $"Deleted from UnitsForm by {SessionManager.CurrentUser.FullName}");
            LoadUnits(selectedBuildingID);
            HideDetailPanel();
        }

        // =====================================================================
        //  SAVE (Add or Edit)
        // =====================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- Validate ---
            if (cmbBuilding.SelectedItem == null)
            { MessageBox.Show("Please select a building.", "Validation"); return; }

            if (string.IsNullOrWhiteSpace(txtUnitName.Text))
            { MessageBox.Show("Unit name is required.", "Validation"); return; }

            if (string.IsNullOrWhiteSpace(txtOwnerFullName.Text))
            { MessageBox.Show("Owner full name is required.", "Validation"); return; }

            if (!decimal.TryParse(txtMonthlyFee.Text, out decimal fee))
            { MessageBox.Show("Monthly fee must be a number.", "Validation"); return; }

            var building = (Building)cmbBuilding.SelectedItem;

            // --- Build Unit object ---
            var unit = new Unit
            {
                BuildingID            = building.BuildingID,
                UnitName              = txtUnitName.Text.Trim(),
                MonthlyServiceAmount  = fee,
                OwnerFullName         = txtOwnerFullName.Text.Trim(),
                OwnerPhone            = txtOwnerPhone.Text.Trim(),
                OwnerOtherPhone       = txtOwnerOtherPhone.Text.Trim(),
                OwnerNation           = txtOwnerNation.Text.Trim(),
                HasTenant             = chkHasTenant.Checked,
                TenantFullName        = chkHasTenant.Checked ? txtTenantFullName.Text.Trim() : null,
                TenantPhone           = chkHasTenant.Checked ? txtTenantPhone.Text.Trim()     : null,
                TenantOtherPhone      = chkHasTenant.Checked ? txtTenantOtherPhone.Text.Trim(): null,
                TenantNation          = chkHasTenant.Checked ? txtTenantNation.Text.Trim()    : null,
                IsActive              = true
            };

            // --- Check duplicate name ---
            int excludeID = isEditMode ? selectedUnitID : 0;
            if (unitRepo.NameExists(unit.UnitName, unit.BuildingID, excludeID))
            {
                MessageBox.Show("A unit with this name already exists in this building.", "Duplicate",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isEditMode)
            {
                unit.UnitID = selectedUnitID;
                unitRepo.Update(unit);
            }
            else
            {
                unitRepo.Save(unit);
            }

            LoadUnits(selectedBuildingID);
            HideDetailPanel();
        }

        // =====================================================================
        //  CANCEL
        // =====================================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            HideDetailPanel();
        }

        // =====================================================================
        //  SEARCH
        // =====================================================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Type something to search.", "Search");
                return;
            }

            dgvUnits.Rows.Clear();

            var list = unitRepo.Search(keyword);
            foreach (var u in list)
            {
                string hasTenant = !string.IsNullOrWhiteSpace(u.TenantFullName) ? "Yes" : "No";

                int rowIndex = dgvUnits.Rows.Add(
                    u.UnitID,
                    u.UnitName,
                    u.OwnerFullName,
                    u.OwnerPhone,
                    u.MonthlyServiceAmount.ToString("F0"),
                    hasTenant
                );
                dgvUnits.Rows[rowIndex].Tag = u.UnitID;
            }

            // Deselect building since search is across all buildings
            lstBuildings.ClearSelected();
            selectedBuildingID = 0;
            HideDetailPanel();
        }

        // =====================================================================
        //  SHOW ALL
        // =====================================================================
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            if (selectedBuildingID > 0)
            {
                LoadUnits(selectedBuildingID);
            }
            else
            {
                dgvUnits.Rows.Clear();
                var list = unitRepo.GetAll();
                foreach (var u in list)
                {
                    string hasTenant = !string.IsNullOrWhiteSpace(u.TenantFullName) ? "Yes" : "No";
                    int rowIndex = dgvUnits.Rows.Add(
                        u.UnitID, u.UnitName,
                        u.OwnerFullName, u.OwnerPhone,
                        u.MonthlyServiceAmount.ToString("F0"), hasTenant);
                    dgvUnits.Rows[rowIndex].Tag = u.UnitID;
                }
            }
        }

        // =====================================================================
        //  PANEL PAINT (keep empty — it was auto-generated)
        // =====================================================================
        private void panel3_Paint(object sender, PaintEventArgs e) { }
    }
}

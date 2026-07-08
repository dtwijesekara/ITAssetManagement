using System;
using System.Data;
using System.Windows.Forms;
using ITAssetManagement.BusinessLogic;
using ITAssetManagement.DataAccess;

namespace ITAssetManagement.Forms
{
    public partial class AddAssetForm : Form
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public AddAssetForm()
        {
            InitializeComponent();
            this.Load += AddAssetForm_Load;
        }

        private void AddAssetForm_Load(object sender, EventArgs e)
        {
            cmbAssetType.Items.AddRange(new[] { "Laptop", "Router" });
            cmbAssetType.SelectedIndex = 0;
            LoadEmployees();
            ToggleAssetTypeOptions();
        }

        private void LoadEmployees()
        {
            try
            {
                DataTable employees = _db.GetEmployees();

                DataRow unassigned = employees.NewRow();
                unassigned["EmpID"] = DBNull.Value;
                unassigned["FullName"] = "-- Unassigned --";
                employees.Rows.InsertAt(unassigned, 0);

                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "FullName";
                cmbEmployee.ValueMember = "EmpID";
            }
            catch (DataAccessException dae)
            {
                MessageBox.Show($"Could not load employees: {dae.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbAssetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleAssetTypeOptions();
        }

        private void ToggleAssetTypeOptions()
        {
            bool isLaptop = cmbAssetType.SelectedItem?.ToString() == "Laptop";
            grpLaptopOptions.Visible = isLaptop;
            grpRouterOptions.Visible = !isLaptop;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                Asset asset = BuildAssetFromForm();
                int newId = _db.AddAsset(asset);

                MessageBox.Show($"Asset saved successfully with ID: {newId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DataAccessException dae)
            {
                lblStatus.Text = $"Save failed: {dae.Message}";
            }
            catch (ArgumentException argEx)
            {
                lblStatus.Text = $"Validation error: {argEx.Message}";
            }
        }

        private Asset BuildAssetFromForm()
        {
            string type  = cmbAssetType.SelectedItem.ToString();
            string model = txtMakeModel.Text.Trim();
            string os    = txtOSVersion.Text.Trim();
            string ip    = txtIPAddress.Text.Trim();
            string mac   = txtMACAddress.Text.Trim();

            int? empId = null;
            if (cmbEmployee.SelectedValue != null && cmbEmployee.SelectedValue != DBNull.Value)
            {
                if (int.TryParse(cmbEmployee.SelectedValue.ToString(), out int parsedId))
                    empId = parsedId;
            }

            Asset asset;

            if (type == "Laptop")
            {
                asset = new Laptop(model, os, ip, mac, chkEncrypted.Checked, chkCorpManaged.Checked);
            }
            else
            {
                asset = new Router(model, os, ip, mac, chkDefaultCreds.Checked, chkFirewall.Checked, txtFirmware.Text.Trim());
            }

            asset.AssignedTo = empId;
            return asset;
        }

        private bool ValidateInput()
        {
            lblStatus.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtMakeModel.Text))
            { lblStatus.Text = "Make/Model is required."; return false; }

            if (string.IsNullOrWhiteSpace(txtOSVersion.Text))
            { lblStatus.Text = "OS Version is required."; return false; }

            if (string.IsNullOrWhiteSpace(txtIPAddress.Text))
            { lblStatus.Text = "IP Address is required."; return false; }

            if (string.IsNullOrWhiteSpace(txtMACAddress.Text))
            { lblStatus.Text = "MAC Address is required."; return false; }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

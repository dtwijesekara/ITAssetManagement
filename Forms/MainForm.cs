using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ITAssetManagement.DataAccess;

namespace ITAssetManagement.Forms
{
    public partial class MainForm : Form
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();
        private readonly string _currentUser;
        private readonly string _currentRole;

        public MainForm(string username, string role)
        {
            InitializeComponent();
            _currentUser = username;
            _currentRole = role;
            this.Load += MainForm_Load;
            this.FormClosed += MainForm_FormClosed;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {_currentUser}  |  Role: {_currentRole}";

            bool canEdit = (_currentRole == "Admin");
            btnAddAsset.Enabled    = canEdit;
            btnDeleteAsset.Enabled = canEdit;

            ConfigureDataGridView();
            LoadAssets();
        }

        private void ConfigureDataGridView()
        {
            dgvAssets.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAssets.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgvAssets.MultiSelect           = false;
            dgvAssets.ReadOnly              = true;
            dgvAssets.AllowUserToAddRows    = false;
            dgvAssets.AllowUserToDeleteRows = false;
            dgvAssets.RowHeadersVisible     = false;
            dgvAssets.BackgroundColor       = Color.White;
            dgvAssets.GridColor             = Color.LightGray;
            dgvAssets.BorderStyle           = BorderStyle.None;
            dgvAssets.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 60);
            dgvAssets.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAssets.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAssets.ColumnHeadersHeight = 35;
            dgvAssets.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 255);
            dgvAssets.EnableHeadersVisualStyles = false;
        }

        private void LoadAssets()
        {
            try
            {
                SetStatus("Loading assets...");
                DataTable assets = _db.GetAssets();
                dgvAssets.DataSource = assets;

                HideColumnIfExists("HasEncryptedDisk");
                HideColumnIfExists("IsCorpManaged");
                HideColumnIfExists("HasDefaultCreds");
                HideColumnIfExists("HasFirewallEnabled");
                HideColumnIfExists("FirmwareVersion");

                foreach (DataGridViewRow row in dgvAssets.Rows)
                {
                    string assetType = row.Cells["AssetType"]?.Value?.ToString();
                    if (assetType == "Router")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255);
                }

                lblAssetCount.Text = $"Total Assets: {assets.Rows.Count}";
                SetStatus($"Loaded {assets.Rows.Count} asset(s) successfully.");
            }
            catch (DataAccessException dae)
            {
                SetStatus("Error loading assets.");
                MessageBox.Show(dae.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideColumnIfExists(string columnName)
        {
            if (dgvAssets.Columns.Contains(columnName))
                dgvAssets.Columns[columnName].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAssets();
        }

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            AddAssetForm addForm = new AddAssetForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
                LoadAssets();
        }

        private void btnDeleteAsset_Click(object sender, EventArgs e)
        {
            if (dgvAssets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int assetId = Convert.ToInt32(dgvAssets.SelectedRows[0].Cells["AssetID"].Value);
            string model = dgvAssets.SelectedRows[0].Cells["MakeModel"].Value?.ToString();

            var confirm = MessageBox.Show($"Delete asset '{model}' (ID: {assetId})? This cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _db.DeleteAsset(assetId);
                    SetStatus($"Asset '{model}' deleted.");
                    LoadAssets();
                }
                catch (DataAccessException dae)
                {
                    MessageBox.Show(dae.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRunAudit_Click(object sender, EventArgs e)
        {
            AuditForm auditForm = new AuditForm();
            auditForm.Show(this);
        }

        private void SetStatus(string message)
        {
            toolStripStatusLabel1.Text = $"{DateTime.Now:HH:mm:ss}  |  {message}";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is LoginForm)
                {
                    f.Show();
                    return;
                }
            }
            Application.Exit();
        }
    }
}

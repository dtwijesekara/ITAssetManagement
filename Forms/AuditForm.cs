using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ITAssetManagement.DataAccess;

namespace ITAssetManagement.Forms
{
    public partial class AuditForm : Form
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();
        private DataTable _auditResults;

        public AuditForm()
        {
            InitializeComponent();
            this.Load += AuditForm_Load;
        }

        private void AuditForm_Load(object sender, EventArgs e)
        {
            ConfigureAuditGrid();
            RunAudit();
        }

        private void ConfigureAuditGrid()
        {
            dgvAuditResults.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditResults.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditResults.MultiSelect           = false;
            dgvAuditResults.ReadOnly              = true;
            dgvAuditResults.AllowUserToAddRows    = false;
            dgvAuditResults.AllowUserToDeleteRows = false;
            dgvAuditResults.RowHeadersVisible     = false;
            dgvAuditResults.BackgroundColor       = Color.White;
            dgvAuditResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 20, 20);
            dgvAuditResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAuditResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvAuditResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAuditResults.ColumnHeadersHeight = 35;
            dgvAuditResults.EnableHeadersVisualStyles = false;
        }

        private void RunAudit()
        {
            try
            {
                progressBar1.Visible = true;
                lblSummary.Text = "Running audit...";

                _auditResults = _db.RunVulnerabilityAudit();
                dgvAuditResults.DataSource = _auditResults;

                ApplyThreatHighlighting();
                UpdateSummaryLabels();

                progressBar1.Visible = false;
            }
            catch (DataAccessException dae)
            {
                progressBar1.Visible = false;
                lblSummary.Text = "Audit failed.";
                MessageBox.Show(dae.Message, "Audit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyThreatHighlighting()
        {
            foreach (DataGridViewRow row in dgvAuditResults.Rows)
            {
                string threat = row.Cells["ThreatLevel"]?.Value?.ToString();

                switch (threat)
                {
                    case "Critical":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(220, 53, 69);
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                        break;
                    case "High":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 133, 27);
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case "Medium":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 50);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "Low":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(180, 230, 180);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void UpdateSummaryLabels()
        {
            int total = _auditResults.Rows.Count;
            int critical = 0, high = 0, medium = 0, low = 0;

            foreach (DataRow row in _auditResults.Rows)
            {
                switch (row["ThreatLevel"].ToString())
                {
                    case "Critical": critical++; break;
                    case "High":     high++;     break;
                    case "Medium":   medium++;   break;
                    case "Low":      low++;      break;
                }
            }

            lblSummary.Text = $"Audit complete — {total} vulnerable asset(s) found.";
            lblCritical.Text = $"Critical: {critical}";
            lblHigh.Text = $"High: {high}  |  Medium: {medium}  |  Low: {low}";

            if (critical > 0)
                this.Text = $"VULNERABILITY AUDIT — {critical} CRITICAL ISSUE(S) FOUND";
        }

        private void btnRunAudit_Click(object sender, EventArgs e)
        {
            RunAudit();
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            if (_auditResults == null || _auditResults.Rows.Count == 0)
            {
                MessageBox.Show("No audit data to export. Run the audit first.", "Nothing to Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Report (*.txt)|*.txt";
                sfd.FileName = $"VulnerabilityReport_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            sw.WriteLine("============================================================");
                            sw.WriteLine("  IT ASSET VULNERABILITY AUDIT REPORT");
                            sw.WriteLine($"  Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                            sw.WriteLine("============================================================");
                            sw.WriteLine();

                            foreach (DataRow row in _auditResults.Rows)
                            {
                                sw.WriteLine($"[{row["ThreatLevel"]}] {row["MakeModel"]}");
                                sw.WriteLine($"  Asset ID   : {row["AssetID"]}");
                                sw.WriteLine($"  OS Version : {row["OS_Version"]}");
                                sw.WriteLine($"  IP Address : {row["IPAddress"]}");
                                sw.WriteLine($"  Assigned To: {row["AssignedTo"]} ({row["Department"]})");
                                sw.WriteLine($"  Vuln Detail: {row["VulnerabilityDescription"]}");
                                sw.WriteLine($"  OOP Status : {row["SecurityStatus"]}");
                                sw.WriteLine(new string('-', 60));
                            }
                        }

                        MessageBox.Show($"Report exported to:\n{sfd.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException ioEx)
                    {
                        MessageBox.Show($"Export failed: {ioEx.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

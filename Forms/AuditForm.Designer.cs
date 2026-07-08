namespace ITAssetManagement.Forms
{
    partial class AuditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblCritical;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Button btnRunAudit;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.DataGridView dgvAuditResults;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel pnlTop;

        private void InitializeComponent()
        {
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblCritical = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.btnRunAudit = new System.Windows.Forms.Button();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.dgvAuditResults = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditResults)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // lblSummary
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSummary.Location = new System.Drawing.Point(15, 15);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(220, 25);
            this.lblSummary.Text = "Click 'Run Audit' to begin.";

            // lblCritical
            this.lblCritical.AutoSize = true;
            this.lblCritical.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCritical.ForeColor = System.Drawing.Color.Red;
            this.lblCritical.Location = new System.Drawing.Point(15, 45);
            this.lblCritical.Name = "lblCritical";
            this.lblCritical.Size = new System.Drawing.Size(70, 19);
            this.lblCritical.Text = "Critical: 0";

            // lblHigh
            this.lblHigh.AutoSize = true;
            this.lblHigh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHigh.ForeColor = System.Drawing.Color.FromArgb(255, 133, 27);
            this.lblHigh.Location = new System.Drawing.Point(110, 45);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(160, 19);
            this.lblHigh.Text = "High: 0  |  Medium: 0  |  Low: 0";

            // btnRunAudit
            this.btnRunAudit.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnRunAudit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunAudit.ForeColor = System.Drawing.Color.White;
            this.btnRunAudit.Location = new System.Drawing.Point(820, 12);
            this.btnRunAudit.Name = "btnRunAudit";
            this.btnRunAudit.Size = new System.Drawing.Size(150, 35);
            this.btnRunAudit.TabIndex = 4;
            this.btnRunAudit.Text = "Run Audit Now";
            this.btnRunAudit.UseVisualStyleBackColor = false;
            this.btnRunAudit.Click += new System.EventHandler(this.btnRunAudit_Click);

            // btnExportReport
            this.btnExportReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportReport.Location = new System.Drawing.Point(980, 12);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(150, 35);
            this.btnExportReport.TabIndex = 5;
            this.btnExportReport.Text = "Export Report";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);

            // progressBar1
            this.progressBar1.Location = new System.Drawing.Point(420, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(380, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.Visible = false;

            // pnlTop
            this.pnlTop.Controls.Add(this.lblSummary);
            this.pnlTop.Controls.Add(this.lblCritical);
            this.pnlTop.Controls.Add(this.lblHigh);
            this.pnlTop.Controls.Add(this.progressBar1);
            this.pnlTop.Controls.Add(this.btnRunAudit);
            this.pnlTop.Controls.Add(this.btnExportReport);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 70;
            this.pnlTop.Name = "pnlTop";

            // dgvAuditResults
            this.dgvAuditResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuditResults.Location = new System.Drawing.Point(0, 70);
            this.dgvAuditResults.Name = "dgvAuditResults";
            this.dgvAuditResults.RowTemplate.Height = 32;
            this.dgvAuditResults.Size = new System.Drawing.Size(1150, 480);
            this.dgvAuditResults.TabIndex = 6;

            // AuditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 550);
            this.Controls.Add(this.dgvAuditResults);
            this.Controls.Add(this.pnlTop);
            this.Name = "AuditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vulnerability Audit Engine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditResults)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}

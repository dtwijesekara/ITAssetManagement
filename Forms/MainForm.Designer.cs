namespace ITAssetManagement.Forms
{
    partial class MainForm
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

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblAssetCount;
        private System.Windows.Forms.Button btnAddAsset;
        private System.Windows.Forms.Button btnDeleteAsset;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRunAudit;
        private System.Windows.Forms.DataGridView dgvAssets;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel pnlTop;

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblAssetCount = new System.Windows.Forms.Label();
            this.btnAddAsset = new System.Windows.Forms.Button();
            this.btnDeleteAsset = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRunAudit = new System.Windows.Forms.Button();
            this.dgvAssets = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssets)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(15, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(160, 25);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome";

            // lblAssetCount
            this.lblAssetCount.AutoSize = true;
            this.lblAssetCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAssetCount.Location = new System.Drawing.Point(15, 45);
            this.lblAssetCount.Name = "lblAssetCount";
            this.lblAssetCount.Size = new System.Drawing.Size(110, 19);
            this.lblAssetCount.TabIndex = 1;
            this.lblAssetCount.Text = "Total Assets: 0";

            // btnAddAsset
            this.btnAddAsset.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAddAsset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAsset.ForeColor = System.Drawing.Color.White;
            this.btnAddAsset.Location = new System.Drawing.Point(650, 12);
            this.btnAddAsset.Name = "btnAddAsset";
            this.btnAddAsset.Size = new System.Drawing.Size(120, 35);
            this.btnAddAsset.TabIndex = 2;
            this.btnAddAsset.Text = "Add Asset";
            this.btnAddAsset.UseVisualStyleBackColor = false;
            this.btnAddAsset.Click += new System.EventHandler(this.btnAddAsset_Click);

            // btnDeleteAsset
            this.btnDeleteAsset.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDeleteAsset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAsset.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAsset.Location = new System.Drawing.Point(780, 12);
            this.btnDeleteAsset.Name = "btnDeleteAsset";
            this.btnDeleteAsset.Size = new System.Drawing.Size(140, 35);
            this.btnDeleteAsset.TabIndex = 3;
            this.btnDeleteAsset.Text = "Delete Selected";
            this.btnDeleteAsset.UseVisualStyleBackColor = false;
            this.btnDeleteAsset.Click += new System.EventHandler(this.btnDeleteAsset_Click);

            // btnRefresh
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(930, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 35);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnRunAudit
            this.btnRunAudit.BackColor = System.Drawing.Color.FromArgb(255, 133, 27);
            this.btnRunAudit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunAudit.ForeColor = System.Drawing.Color.White;
            this.btnRunAudit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRunAudit.Location = new System.Drawing.Point(1030, 12);
            this.btnRunAudit.Name = "btnRunAudit";
            this.btnRunAudit.Size = new System.Drawing.Size(190, 35);
            this.btnRunAudit.TabIndex = 5;
            this.btnRunAudit.Text = "Run Vulnerability Audit";
            this.btnRunAudit.UseVisualStyleBackColor = false;
            this.btnRunAudit.Click += new System.EventHandler(this.btnRunAudit_Click);

            // pnlTop
            this.pnlTop.Controls.Add(this.lblWelcome);
            this.pnlTop.Controls.Add(this.lblAssetCount);
            this.pnlTop.Controls.Add(this.btnAddAsset);
            this.pnlTop.Controls.Add(this.btnDeleteAsset);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnRunAudit);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 70;
            this.pnlTop.Name = "pnlTop";

            // dgvAssets
            this.dgvAssets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssets.Location = new System.Drawing.Point(0, 70);
            this.dgvAssets.Name = "dgvAssets";
            this.dgvAssets.RowTemplate.Height = 32;
            this.dgvAssets.Size = new System.Drawing.Size(1240, 480);
            this.dgvAssets.TabIndex = 6;

            // statusStrip1
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 550);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1240, 24);
            this.statusStrip1.TabIndex = 7;

            // toolStripStatusLabel1
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(40, 19);
            this.toolStripStatusLabel1.Text = "Ready";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 574);
            this.Controls.Add(this.dgvAssets);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IT Asset & Vulnerability Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssets)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}

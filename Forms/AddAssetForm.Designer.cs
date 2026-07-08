namespace ITAssetManagement.Forms
{
    partial class AddAssetForm
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

        private System.Windows.Forms.Label lblAssetType;
        private System.Windows.Forms.ComboBox cmbAssetType;
        private System.Windows.Forms.Label lblMakeModel;
        private System.Windows.Forms.TextBox txtMakeModel;
        private System.Windows.Forms.Label lblOSVersion;
        private System.Windows.Forms.TextBox txtOSVersion;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label lblMACAddress;
        private System.Windows.Forms.TextBox txtMACAddress;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.GroupBox grpLaptopOptions;
        private System.Windows.Forms.CheckBox chkEncrypted;
        private System.Windows.Forms.CheckBox chkCorpManaged;
        private System.Windows.Forms.GroupBox grpRouterOptions;
        private System.Windows.Forms.CheckBox chkDefaultCreds;
        private System.Windows.Forms.CheckBox chkFirewall;
        private System.Windows.Forms.Label lblFirmware;
        private System.Windows.Forms.TextBox txtFirmware;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.lblAssetType = new System.Windows.Forms.Label();
            this.cmbAssetType = new System.Windows.Forms.ComboBox();
            this.lblMakeModel = new System.Windows.Forms.Label();
            this.txtMakeModel = new System.Windows.Forms.TextBox();
            this.lblOSVersion = new System.Windows.Forms.Label();
            this.txtOSVersion = new System.Windows.Forms.TextBox();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.lblMACAddress = new System.Windows.Forms.Label();
            this.txtMACAddress = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.grpLaptopOptions = new System.Windows.Forms.GroupBox();
            this.chkEncrypted = new System.Windows.Forms.CheckBox();
            this.chkCorpManaged = new System.Windows.Forms.CheckBox();
            this.grpRouterOptions = new System.Windows.Forms.GroupBox();
            this.chkDefaultCreds = new System.Windows.Forms.CheckBox();
            this.chkFirewall = new System.Windows.Forms.CheckBox();
            this.lblFirmware = new System.Windows.Forms.Label();
            this.txtFirmware = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpLaptopOptions.SuspendLayout();
            this.grpRouterOptions.SuspendLayout();
            this.SuspendLayout();

            // lblAssetType
            this.lblAssetType.AutoSize = true;
            this.lblAssetType.Location = new System.Drawing.Point(30, 25);
            this.lblAssetType.Name = "lblAssetType";
            this.lblAssetType.Size = new System.Drawing.Size(70, 19);
            this.lblAssetType.Text = "Asset Type:";

            // cmbAssetType
            this.cmbAssetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssetType.Location = new System.Drawing.Point(180, 22);
            this.cmbAssetType.Name = "cmbAssetType";
            this.cmbAssetType.Size = new System.Drawing.Size(290, 27);
            this.cmbAssetType.SelectedIndexChanged += new System.EventHandler(this.cmbAssetType_SelectedIndexChanged);

            // lblMakeModel
            this.lblMakeModel.AutoSize = true;
            this.lblMakeModel.Location = new System.Drawing.Point(30, 65);
            this.lblMakeModel.Name = "lblMakeModel";
            this.lblMakeModel.Size = new System.Drawing.Size(80, 19);
            this.lblMakeModel.Text = "Make/Model:";

            // txtMakeModel
            this.txtMakeModel.Location = new System.Drawing.Point(180, 62);
            this.txtMakeModel.Name = "txtMakeModel";
            this.txtMakeModel.Size = new System.Drawing.Size(290, 27);

            // lblOSVersion
            this.lblOSVersion.AutoSize = true;
            this.lblOSVersion.Location = new System.Drawing.Point(30, 105);
            this.lblOSVersion.Name = "lblOSVersion";
            this.lblOSVersion.Size = new System.Drawing.Size(78, 19);
            this.lblOSVersion.Text = "OS Version:";

            // txtOSVersion
            this.txtOSVersion.Location = new System.Drawing.Point(180, 102);
            this.txtOSVersion.Name = "txtOSVersion";
            this.txtOSVersion.Size = new System.Drawing.Size(290, 27);

            // lblIPAddress
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(30, 145);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(75, 19);
            this.lblIPAddress.Text = "IP Address:";

            // txtIPAddress
            this.txtIPAddress.Location = new System.Drawing.Point(180, 142);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(290, 27);

            // lblMACAddress
            this.lblMACAddress.AutoSize = true;
            this.lblMACAddress.Location = new System.Drawing.Point(30, 185);
            this.lblMACAddress.Name = "lblMACAddress";
            this.lblMACAddress.Size = new System.Drawing.Size(82, 19);
            this.lblMACAddress.Text = "MAC Address:";

            // txtMACAddress
            this.txtMACAddress.Location = new System.Drawing.Point(180, 182);
            this.txtMACAddress.Name = "txtMACAddress";
            this.txtMACAddress.Size = new System.Drawing.Size(290, 27);

            // lblEmployee
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(30, 225);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(95, 19);
            this.lblEmployee.Text = "Assign to Employee:";

            // cmbEmployee
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Location = new System.Drawing.Point(180, 222);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(290, 27);

            // grpLaptopOptions
            this.grpLaptopOptions.Controls.Add(this.chkEncrypted);
            this.grpLaptopOptions.Controls.Add(this.chkCorpManaged);
            this.grpLaptopOptions.Location = new System.Drawing.Point(30, 265);
            this.grpLaptopOptions.Name = "grpLaptopOptions";
            this.grpLaptopOptions.Size = new System.Drawing.Size(440, 90);
            this.grpLaptopOptions.Text = "Laptop Options";

            // chkEncrypted
            this.chkEncrypted.AutoSize = true;
            this.chkEncrypted.Location = new System.Drawing.Point(20, 30);
            this.chkEncrypted.Name = "chkEncrypted";
            this.chkEncrypted.Size = new System.Drawing.Size(115, 23);
            this.chkEncrypted.Text = "Disk Encrypted";

            // chkCorpManaged
            this.chkCorpManaged.AutoSize = true;
            this.chkCorpManaged.Location = new System.Drawing.Point(20, 58);
            this.chkCorpManaged.Name = "chkCorpManaged";
            this.chkCorpManaged.Size = new System.Drawing.Size(165, 23);
            this.chkCorpManaged.Text = "Corp Managed (MDM)";

            // grpRouterOptions
            this.grpRouterOptions.Controls.Add(this.chkDefaultCreds);
            this.grpRouterOptions.Controls.Add(this.chkFirewall);
            this.grpRouterOptions.Controls.Add(this.lblFirmware);
            this.grpRouterOptions.Controls.Add(this.txtFirmware);
            this.grpRouterOptions.Location = new System.Drawing.Point(30, 265);
            this.grpRouterOptions.Name = "grpRouterOptions";
            this.grpRouterOptions.Size = new System.Drawing.Size(440, 130);
            this.grpRouterOptions.Text = "Router Options";

            // chkDefaultCreds
            this.chkDefaultCreds.AutoSize = true;
            this.chkDefaultCreds.Location = new System.Drawing.Point(20, 28);
            this.chkDefaultCreds.Name = "chkDefaultCreds";
            this.chkDefaultCreds.Size = new System.Drawing.Size(190, 23);
            this.chkDefaultCreds.Text = "Has Default Credentials";

            // chkFirewall
            this.chkFirewall.AutoSize = true;
            this.chkFirewall.Checked = true;
            this.chkFirewall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirewall.Location = new System.Drawing.Point(20, 56);
            this.chkFirewall.Name = "chkFirewall";
            this.chkFirewall.Size = new System.Drawing.Size(135, 23);
            this.chkFirewall.Text = "Firewall Enabled";

            // lblFirmware
            this.lblFirmware.AutoSize = true;
            this.lblFirmware.Location = new System.Drawing.Point(20, 92);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(105, 19);
            this.lblFirmware.Text = "Firmware Version:";

            // txtFirmware
            this.txtFirmware.Location = new System.Drawing.Point(160, 89);
            this.txtFirmware.Name = "txtFirmware";
            this.txtFirmware.Size = new System.Drawing.Size(260, 27);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(150, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 38);
            this.btnSave.Text = "Save Asset";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(320, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 38);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(30, 465);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 19);

            // AddAssetForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 510);
            this.Controls.Add(this.lblAssetType);
            this.Controls.Add(this.cmbAssetType);
            this.Controls.Add(this.lblMakeModel);
            this.Controls.Add(this.txtMakeModel);
            this.Controls.Add(this.lblOSVersion);
            this.Controls.Add(this.txtOSVersion);
            this.Controls.Add(this.lblIPAddress);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.lblMACAddress);
            this.Controls.Add(this.txtMACAddress);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.grpLaptopOptions);
            this.Controls.Add(this.grpRouterOptions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddAssetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Asset";
            this.grpLaptopOptions.ResumeLayout(false);
            this.grpLaptopOptions.PerformLayout();
            this.grpRouterOptions.ResumeLayout(false);
            this.grpRouterOptions.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}

using System;
using System.Windows.Forms;
using ITAssetManagement.BusinessLogic;
using ITAssetManagement.DataAccess;

namespace ITAssetManagement.Forms
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text = "Please enter both username and password.";
                return;
            }

            try
            {
                string hash = SecurityHelper.ComputeSha256Hash(password);
                string role = _db.AuthenticateUser(username, hash);

                if (role != null)
                {
                    MainForm mainForm = new MainForm(username, role);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    lblStatus.Text = "Invalid username or password.";
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (DataAccessException dae)
            {
                MessageBox.Show(dae.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                lblStatus.Text = string.Empty;
        }
    }
}

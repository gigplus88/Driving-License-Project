using DVLD_Business;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            string UserName = txtUserName.Text;

            if (string.IsNullOrEmpty(UserName))
            {
                e.Cancel = false;
                epLogin.SetError(txtUserName, "Required");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            string Password = txtPassword.Text;


            if (string.IsNullOrEmpty(Password))
            {
                e.Cancel = false;
                epLogin.SetError(txtUserName, "Required");
            }
            if (!int.TryParse(Password, out int Result))
            {
                e.Cancel = false;
                epLogin.SetError(txtUserName, "Please Enter a numbers");
            }
        }

        static string UserName = "", Password = "";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserName = txtUserName.Text;
            Password = txtPassword.Text;

            if (!clsUser.IsUserExist(UserName, Password))
            {
                MessageBox.Show("Invalid UserName or Password", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!clsUser.IsUserActive(UserName))
            {
                MessageBox.Show(" UserName is not Active", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SaveDataToFile(UserName, Password, "CurrentUser.txt");
                FrmMain frm = new FrmMain();

                GlobalSettings.CurrentUserInfo.UserName = UserName;
                GlobalSettings.CurrentUserInfo.Password = Password;

                frm.ShowDialog();
                CleanUserNameAndPasswordTextboxes();
            }

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        static void SaveDataToFile(string UserName, string Password, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(UserName +"," + Password);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        public bool IsCbRememberMeChecked()
        {
            return cbRememberMe.Checked;
        }
        public void CleanUserNameAndPasswordTextboxes()
        {
            if (!IsCbRememberMeChecked())
            {
                txtUserName.Clear();
                txtPassword.Clear();
            }
        }
    }
}

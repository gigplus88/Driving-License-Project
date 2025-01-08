using DVLD_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmChangePassword : Form
    {
        private int _UserID = -1;
        private string _UserName;

        private clsUser _User;
        public FrmChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }
        public FrmChangePassword(string Username)
        {
            InitializeComponent();
            this._UserName = Username;
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {

        }
        public void LoadUserInfo(int UserID)
        {
            ctrlUserCard1.LoadUserInfo(UserID);
        }
        public void LoadUserInfo(string UserName)
        {
            ctrlUserCard1.LoadUserInfo(UserName);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            _User = clsUser.Find(_UserID);

            if (_User != null)
            {
                if (txtCurrentPassword.Text != _User.Password)
                {
                    e.Cancel = true;
                    epPassword.SetError(txtCurrentPassword, "Current Password is Wrong!");
                }
                else
                {
                    e.Cancel = false;
                    epPassword.SetError(txtCurrentPassword, "");
                }
            }
            else
            {
                MessageBox.Show($"User{_UserID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User = clsUser.Find(_UserID);

            _User.Password = txtNewPassword.Text;

            clsUser.Mode = clsUser.enMode.Update;

            if (_User.Save())
            {
                MessageBox.Show($"Password saved Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

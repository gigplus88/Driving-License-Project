using DVLD.Users;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmAddEditUser : Form
    {
        static private string _UserName = "";
        static private int _PersonID = 0;
        static private int _UserID = 0;

        private clsUser _User;
        public enum enMode
        {
            Added = 0, Updated = 1
        };
        public enMode Mode;
        public FrmAddEditUser()
        {
            InitializeComponent();
        }
        public FrmAddEditUser(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsUser.IsUserExist(_PersonID))
            {
                MessageBox.Show("Selected Person already has a User , Choose another one", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                clsUser.Mode = clsUser.enMode.AddNew;
                tabControl1.SelectedTab = tabPage2;
                txtUserName.Focus();
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            string Input = txtUserName.Text;
            if (string.IsNullOrEmpty(Input))
            {
                e.Cancel = true;
                epUser.SetError(txtUserName, "Password cannot be blank");
                return;
            }
            //if (clsUser.IsUserExist(Input))
            //{
            //    e.Cancel = true;
            //    epUser.SetError(txtUserName , "User already exist");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    epUser.SetError(txtUserName, "");

            //}
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                epUser.SetError(txtPassword, "Password cannot be blank");
                return;
            }
            else
            {
                e.Cancel = false;
                epUser.SetError(txtPassword, "");

            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                epUser.SetError(txtConfirmPassword, "Password confirmation does not match password");
            }
            else
            {
                e.Cancel = false;
                epUser.SetError(txtConfirmPassword, "");
            }
        }
        private void _AddUser()
        {
            /*clsUser*/
            _User = new clsUser();
            _User.PersonID = ctrlPersonCardWithFilter1._PersonID;
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            if (chbIsActive.Checked)
            {
                _User.IsActive = 1;
            }
            else
            {
                _User.IsActive = 2;

            }
            if (_User.Save())
            {
                MessageBox.Show($"{_User.UserID} Added Successfully", "Adding User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _UserID = _User.UserID;
                lblUserID.Text = _UserID.ToString();

                FrmManageUsers frmManageUsers = new FrmManageUsers();
                frmManageUsers.RefreshData();
                Mode = enMode.Updated;
            }
            else
            {
                MessageBox.Show($"Error  to Add {_User.UserID}  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (clsUser.Mode == clsUser.enMode.AddNew)
            {
                _AddUser();
            }
            else
            {
                FillUserInfoAfterEdit(_PersonID);
            }
        }
        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        enum enMFindMode { BeforeFill, AfterFill };
        enMFindMode FindMode = enMFindMode.BeforeFill;
        private void _FillBoxes(int PersonID)
        {
            _User = clsUser.FindByPersonID(PersonID);

            if (_User == null)
            {
                return;
            }
            if (FindMode == enMFindMode.BeforeFill)
            {
                lblUserID.Text = _User.UserID.ToString();
                txtUserName.Text = _User.UserName;
                txtPassword.Text = _User.Password;
                txtConfirmPassword.Text = _User.Password;
                if (_User.IsActive == 1)
                {
                    chbIsActive.Checked = true;
                }
                else
                {
                    chbIsActive.Checked = false;
                }

                FindMode = enMFindMode.AfterFill;
            }
            else
            {
                FillUserInfoAfterEdit(PersonID);
            }
        }
        public void FillUserInfoAfterEdit(int PersonID)
        {
            /* clsUser*/
            _User = clsUser.FindByPersonID(PersonID);
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            if (chbIsActive.Checked)
            {
                _User.IsActive = 1;
            }
            else
            {
                _User.IsActive = 0;
            }

            clsUser.Mode = clsUser.enMode.Update;

            if (_User.Save())
            {
                MessageBox.Show($"{_User.PersonID} Updated Successfully", "Update User", MessageBoxButtons.OK);
                _PersonID = _User.PersonID;
            }
            else
            {
                MessageBox.Show($"Error  to Update {_User.PersonID}  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void UpdateUser(int PersonID)
        {
            lblTitle.Text =  "Update User";
            ctrlPersonCardWithFilter1.PersonSearchToEdit(PersonID);
            _FillBoxes(PersonID);
        }

        private void ctrlPersonCardWithFilter1_Load_1(object sender, EventArgs e)
        {

        }

        private void FrmAddEditUser_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

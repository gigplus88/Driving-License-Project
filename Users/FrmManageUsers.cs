using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class FrmManageUsers : Form
    {
        public FrmManageUsers()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();
            lblNumberOfUsers.Text = clsUser.CountUsers().ToString();

        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmAddEditUser frm = new FrmAddEditUser();
            frm.ShowDialog();
            RefreshData();

        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmManageUsers_Load(object sender, EventArgs e)
        {
            RefreshData();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "None")
            {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = false;
                return;
            }
            if (cbFilterBy.SelectedItem.ToString() == "Is Active")
            {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = true;
                return;
            }
            cbIsActive.Visible = false;
            txtFilterBy.Visible = true;
        }
        void SearchUserID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {

                dgvUsers.DataSource = clsUser.FindUsersByUserID(Convert.ToInt16(Input));
                lblNumberOfUsers.Text = clsUser.FindUsersByUserID(Convert.ToInt16(Input)).Count.ToString();
            }
        }
        void SearchPersonID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {

                dgvUsers.DataSource = clsUser.FindUsersByPersonID(Convert.ToInt16(Input));
                lblNumberOfUsers.Text = clsUser.FindUsersByPersonID(Convert.ToInt16(Input)).Count.ToString();
            }
        }
        void SearchUserName(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {

                dgvUsers.DataSource = clsUser.FindUsersByUserName(Input);
                lblNumberOfUsers.Text = clsUser.FindUsersByUserName(Input).Count.ToString();
            }
        }
        void SearchFullName(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {

                dgvUsers.DataSource = clsUser.FindUsersByFullName(Input);
                lblNumberOfUsers.Text = clsUser.FindUsersByFullName(Input).Count.ToString();
            }
        }
        void SearchPassword(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {

                dgvUsers.DataSource = clsUser.FindUsersByPassword(Input);
                lblNumberOfUsers.Text = clsUser.FindUsersByPassword(Input).Count.ToString();
            }
        }
        void SearchUsersActive(byte Input)
        {
            dgvUsers.DataSource = clsUser.FindUsersActive(Input);
            lblNumberOfUsers.Text = clsUser.FindUsersActive(Input).Count.ToString();
        }
        void SearchUsersNoActive(byte Input)
        {
            dgvUsers.DataSource = clsUser.FindUsersNoActive(Input);
            lblNumberOfUsers.Text = clsUser.FindUsersNoActive(Input).Count.ToString();
        }
        public void Filtering()
        {
            string Input = txtFilterBy.Text.Trim(), Input2 = cbIsActive.SelectedItem.ToString().Trim();

            switch (FilterItemBycbFilterBy)
            {
                case "User ID":
                    SearchUserID(Input);
                    break;

                case "Person ID":
                    SearchPersonID(Input);
                    break;

                case "User Name":
                    SearchUserName(Input);
                    break;

                case "Full Name":
                    SearchFullName(Input);
                    break;

                case "Password ":
                    SearchPassword(Input);
                    break;

            }

        }
        string FilterItemBycbFilterBy = "";

        public void Validation()
        {

            FilterItemBycbFilterBy = cbFilterBy.SelectedItem.ToString().Trim();
            Filtering();
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsActive.SelectedItem.ToString().Trim())
            {
                case "All":
                    RefreshData();
                    break;
                case "Yes":
                    SearchUsersActive(1);
                    break;
                case "No":
                    SearchUsersNoActive(0);
                    break;
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() != "User ID" && cbFilterBy.SelectedItem.ToString() != "Person ID")
            {
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUser.Mode = clsUser.enMode.Update;
            FrmAddEditUser frm = new FrmAddEditUser(PersonID);
            frm.UpdateUser(PersonID);
            frm.ShowDialog();
            RefreshData();
        }

        int PersonID, UserID;
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                DataGridViewRow selectedRow = dgvUsers.Rows[e.RowIndex];

                PersonID =Convert.ToInt32(selectedRow.Cells["PersonID"].Value);
                UserID =Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditUser frm = new FrmAddEditUser();
            frm.ShowDialog();
            RefreshData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserInfo frm = new FrmUserInfo(UserID);
            frm.LoadUserCard(UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frm = new FrmChangePassword(UserID);
            frm.LoadUserInfo(UserID);
            frm.ShowDialog();
            RefreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo();
            if (MessageBox.Show($"Are you want to Delete Person {PersonID}", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                clsUser.DeleteUser(UserID);
                RefreshData();
            }
        }
    }
}

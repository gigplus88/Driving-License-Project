using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmManagePeople : Form
    {
        private clsPerson _Person;
        public FrmManagePeople()
        {
            InitializeComponent();
            txtFilterBy.Visible = false;
            _RefreshData();
        }

        private void _RefreshData()
        {
            dgvPoeple.DataSource = clsPerson.GetAllPeople();
            lblNumberOfPeople.Text = clsPerson.CountPeople().ToString();

        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() != "Person ID")
            {
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        void SearchPersonID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {

                dgvPoeple.DataSource = clsPerson.FindPersonByID(Convert.ToInt32(Input));
                lblNumberOfPeople.Text = clsPerson.FindPersonByID(Convert.ToInt32(Input)).Count.ToString();
            }
        }
        void SearchNationalNo(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsPerson.FindPersonByNationalNo(Input);
                lblNumberOfPeople.Text = clsPerson.FindPersonByNationalNo(Input).Count.ToString();
            }
        }
        void SearchFirstName(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsPerson.FindPersonByFirstName(Input);
                lblNumberOfPeople.Text = clsPerson.FindPersonByFirstName(Input).Count.ToString();
            }
        }
        void SearchLastName(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsPerson.FindPersonByLastName(Input);
                lblNumberOfPeople.Text = clsPerson.FindPersonByLastName(Input).Count.ToString();
            }
        }
        void SearchSecondName(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsPerson.FindPersonBySecondName(Input);
                lblNumberOfPeople.Text = clsPerson.FindPersonBySecondName(Input).Count.ToString();
            }
        }
        void SearchThirdName(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsPerson.FindPersonByThirdName(Input);
                lblNumberOfPeople.Text = clsPerson.FindPersonByThirdName(Input).Count.ToString();
            }
        }
        void SearchNationality(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsPerson.FindPersonByNationality(Input);
                lblNumberOfPeople.Text = clsPerson.FindPersonByNationality(Input).Count.ToString();
            }
        }
        void SearchGendor(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsPerson.FindPersonByGendor((Input));
                lblNumberOfPeople.Text = clsPerson.FindPersonByGendor(Input).Count.ToString();
            }
        }
        void SearchPhone(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsPerson.FindPersonByPhone(Input);
                lblNumberOfPeople.Text = clsPerson.FindPersonByPhone(Input).Count.ToString();
            }
        }
        void SearchEmail(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsPerson.FindPersonByEmail(Input);
                lblNumberOfPeople.Text = clsPerson.FindPersonByEmail(Input).Count.ToString();
            }
        }
        public void Filtering()
        {
            string Input = txtFilterBy.Text.Trim();
            switch (FilterItem)
            {
                case "Person ID":
                    SearchPersonID(Input);
                    break;

                case "National No":
                    SearchNationalNo(Input);
                    break;

                case "FirstName":
                    SearchFirstName(Input);
                    break;

                case "Second Name":
                    SearchSecondName(Input);
                    break;

                case "Third Name":
                    SearchThirdName(Input);
                    break;

                case "Last Name":
                    SearchLastName(Input);
                    break;

                case "Nationality":
                    SearchNationality(Input);
                    break;

                case "Gendor":
                    SearchGendor(Input);
                    break;

                case "Phone":
                    SearchPhone(Input);
                    break;

                case "Email":
                    SearchEmail(Input);
                    break;


            }
        }
        string FilterItem = "";

        //public void  validPersonID(KeyPressEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtFilterBy.Text))
        //    {
        //        _RefreshData();
        //    }
        //    else
        //    {
        //        NumberValidation();
        //    }

        //    if (FilterItem == "Person ID")
        //    {
        //        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //    else
        //    {
        //        e.Handled = false;
        //    }

        //}

        public void Validation()
        {
            FilterItem = cbFilterBy.SelectedItem.ToString().Trim();
            Filtering();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "None")
            {
                txtFilterBy.Visible = false;
                return;
            }
            txtFilterBy.Visible = true;
        }



        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo();
            frm.ShowDialog();
            _RefreshData();
        }

        private void FrmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo(PersonID);
            frm.UpdatePerson(PersonID);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo();
            if (MessageBox.Show($"Are you want to Delete Person {(int)dgvPoeple.CurrentCell.Value}", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //frm.DeletePerson((int)dgvPoeple.CurrentCell.Value);
                //_RefreshData();
                clsPerson.DeletePerson(PersonID);
                _RefreshData();
            }
        }


        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmPersonDetails frm = new FrmPersonDetails(PersonID);
            frm.GetPersonInfo(PersonID);
            frm.ShowDialog();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo();
            frm.ShowDialog();
            _RefreshData();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        int PersonID;
        private void dgvPoeple_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >0)
            {
                DataGridViewRow selectedRow = dgvPoeple.Rows[e.RowIndex];

                PersonID =Convert.ToInt32(selectedRow.Cells["PersonID"].Value);
            }
        }

        private void dgvPoeple_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

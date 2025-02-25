using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class FrmListDrivers : Form
    {
        public FrmListDrivers()
        {
            InitializeComponent();
        }

        private void _RefreshData()
        {
            dgvPoeple.DataSource = clsDriver.GetAllDriversInfo();
            lblNumberOfPeople.Text = clsDriver.CountDrivers().ToString();
        }
        private void ListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        
        void SearchDriverID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsDriver.FindPersonByDriverID(Convert.ToInt32(Input));
                lblNumberOfPeople.Text = clsDriver.FindPersonByDriverID(Convert.ToInt32(Input)).Count.ToString();
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

                dgvPoeple.DataSource = clsDriver.FindPersonByPersonID(Convert.ToInt32( Input));
                lblNumberOfPeople.Text = clsDriver.FindPersonByPersonID(Convert.ToInt32(Input)).Count.ToString();
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
                dgvPoeple.DataSource = clsDriver.FindPersonByNationalNo(Input);
                lblNumberOfPeople.Text = clsDriver.FindPersonByNationalNo(Input).Count.ToString();
            }
        }
        void SearchFullName(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsDriver.FindPersonByFullName(Input);
                lblNumberOfPeople.Text = clsDriver.FindPersonByFullName(Input).Count.ToString();
            }
        }
        void SearchActiveLicenses(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                _RefreshData();
            }
            else
            {
                dgvPoeple.DataSource = clsDriver.FindPersonByIsActive(Convert.ToByte( Input));
                lblNumberOfPeople.Text = clsDriver.FindPersonByIsActive(Convert.ToByte(Input)).Count.ToString();
            }
        }
        
       

        public void Filtering()
        {
            string Input = txtFilterBy.Text.Trim();
            switch (FilterItem)
            {
                case "DriverID":
                    SearchDriverID(Input);
                    break;

                case "Person ID":
                    SearchPersonID(Input);
                    break;

                case "National No":
                    SearchNationalNo(Input);
                    break;

                case "Full Name":
                    SearchFullName(Input);
                    break;

                case "Active Licenses":
                    SearchActiveLicenses(Input);
                    break;
            }
        }
        string FilterItem = "";
        public void Validation()
        {
            FilterItem = cbFilterBy.SelectedItem.ToString().Trim();
            Filtering();
        }
        
        


        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "National No" || cbFilterBy.SelectedItem.ToString() == "Full Name")
            {
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }
    }
}

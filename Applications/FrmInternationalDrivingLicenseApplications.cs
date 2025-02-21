using DVLD.License;
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

namespace DVLD.Applications
{
    public partial class FrmInternationalDrivingLicenseApplications : Form
    {
        public FrmInternationalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        public void RefreshData()
        {
            dgvInternationalDrivingLicenseApplications.DataSource = clsInternationalLicense.GetAllIntDrivingLicenseApp();
            lblNumberOfInternationalDrivingLicenseApplications.Text = clsInternationalLicense.CountIntDrivingLicenseApp().ToString();
        }
        private void FrmInternationalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            RefreshData(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void SearchByIntLicenseID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvInternationalDrivingLicenseApplications.DataSource = clsInternationalLicense.FindByIntLicenseID(Convert.ToInt16(Input));
                dgvInternationalDrivingLicenseApplications.Text = clsInternationalLicense.FindByIntLicenseID(Convert.ToInt16(Input)).Count.ToString();
            }
        }
        void SearchByApplicationID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvInternationalDrivingLicenseApplications.DataSource = clsInternationalLicense.FindByApplicationID(Convert.ToInt16(Input));
                dgvInternationalDrivingLicenseApplications.Text = clsInternationalLicense.FindByApplicationID(Convert.ToInt16(Input)).Count.ToString();
            }
        }
        void SearchByDriverID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvInternationalDrivingLicenseApplications.DataSource = clsInternationalLicense.FindByDriverID(Convert.ToInt16(Input));
                dgvInternationalDrivingLicenseApplications.Text = clsInternationalLicense.FindByDriverID(Convert.ToInt16(Input)).Count.ToString();
            }
        }
        void SearchByLicenseID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvInternationalDrivingLicenseApplications.DataSource = clsInternationalLicense.FindByLicenseID(Convert.ToInt16(Input));
                dgvInternationalDrivingLicenseApplications.Text = clsInternationalLicense.FindByLicenseID(Convert.ToInt16(Input)).Count.ToString();
            }
        }
        void SearchByIsActive(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvInternationalDrivingLicenseApplications.DataSource = clsInternationalLicense.FindByIsActive(Convert.ToByte(Input));
                dgvInternationalDrivingLicenseApplications.Text = clsInternationalLicense.FindByIsActive(Convert.ToByte(Input)).Count.ToString();
            }
        }
        public void Filtering()
        {
            string Input = txtFilterBy.Text.Trim();
            switch (FilterItem)
            {
                case "IntLicenseID":
                    SearchByIntLicenseID(Input);
                    break;

                case "ApplicationID":
                    SearchByApplicationID(Input);
                    break;

                case "DriverID":
                    SearchByDriverID(Input);
                    break;

                case "L.LicenseID":
                    SearchByLicenseID(Input);
                    break;

                case "IsActive":
                    SearchByIsActive(Input);
                    break;
            }
        }
        string FilterItem = "";

        public void Validation()
        {
            FilterItem = cbFilterBy.SelectedItem.ToString().Trim();
            Filtering();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
        int AppID;
        private void dgvInternationalDrivingLicenseApplications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                DataGridViewRow selectedRow = dgvInternationalDrivingLicenseApplications.Rows[e.RowIndex];

                AppID =Convert.ToInt32(selectedRow.Cells["ApplicationID"].Value);
            }
        }

        private void ShowPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsApplication.GetPersonIDByAppID(AppID);
            FrmPersonDetails frm = new FrmPersonDetails(PersonID);
            frm.ShowDialog();
            frm.GetPersonInfo(PersonID);
        }

        private void ShowLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowLicenseInfo frm = new FrmShowLicenseInfo();
            frm.ShowDialog();
            frm.LoadLicenseInfoByAppID(AppID);
        }

        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseHistory frm = new FrmLicenseHistory(AppID);
            frm.ShowDialog();
        }
    }
}

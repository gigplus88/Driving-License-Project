using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Applications
{
    public partial class FrmLocalDrivingLicenseApplications : Form
    {
        public enum enApplicationTypeID
        {
            NewLocalDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplacementforALostDL = 3,
            ReplacementforADamagedDL = 4,
            ReleaseDetainedDL = 5,
            NewInternationalLicense = 6,
            ReatkeTest = 8
        }

        public enApplicationTypeID ApplicationTypeID;
        public FrmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        public void RefreshData()
        {
            dgvLocalDrivingLicenseApplications.DataSource = clsLocalDrivingLicenseApplication.GetAllLDLAs();
            lblNumberOfLocalDrivingLicenseApplications.Text = clsLocalDrivingLicenseApplication.CountLDLA().ToString();

        }
        private void FrmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        void SearchLDLAID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvLocalDrivingLicenseApplications.DataSource = clsLocalDrivingLicenseApplication.FindByLDLAID(Convert.ToInt16(Input));
                lblNumberOfLocalDrivingLicenseApplications.Text = clsLocalDrivingLicenseApplication.FindByLDLAID(Convert.ToInt16(Input)).Count.ToString();
            }
        }
        void SearchNationalNo(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvLocalDrivingLicenseApplications.DataSource = clsLocalDrivingLicenseApplication.FindByNationalNo(Input);
                lblNumberOfLocalDrivingLicenseApplications.Text = clsLocalDrivingLicenseApplication.FindByNationalNo(Input).Count.ToString();
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
                dgvLocalDrivingLicenseApplications.DataSource = clsLocalDrivingLicenseApplication.FindByFullName(Input);
                lblNumberOfLocalDrivingLicenseApplications.Text = clsLocalDrivingLicenseApplication.FindByFullName(Input).Count.ToString();
            }
        }
        void SearchStatus(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvLocalDrivingLicenseApplications.DataSource = clsLocalDrivingLicenseApplication.FindByStatus(Input);
                lblNumberOfLocalDrivingLicenseApplications.Text = clsLocalDrivingLicenseApplication.FindByStatus(Input).Count.ToString();
            }
        }
        public void Filtering()
        {
            string Input = txtFilterBy.Text.Trim();
            switch (FilterItem)
            {
                case "L.D.L App ID":
                    SearchLDLAID(Input);
                    break;

                case "National No":
                    SearchNationalNo(Input);
                    break;

                case "Full Name":
                    SearchFullName(Input);
                    break;

                case "Status":
                    SearchStatus(Input);
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
            if (cbFilterBy.SelectedItem.ToString() != "L.D.L App ID")
            {
                return;
            }
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

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            FrmNewLocalDrivingLicenseApplication frmNewLocalDrivingLicenseApplication = new FrmNewLocalDrivingLicenseApplication((byte)enApplicationTypeID.NewLocalDrivingLicense);
            frmNewLocalDrivingLicenseApplication.ShowDialog();
        }
    }
}

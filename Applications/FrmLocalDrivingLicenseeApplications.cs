using DVLD.Test_Type;
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
using static DVLD.FrmMain;

namespace DVLD.Applications
{
    public partial class FrmLocalDrivingLicenseApplications : Form
    {
      
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
            RefreshData();
        }

        int LDLAppID;

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure to  Cancel This Application", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                clsApplication.CancelApplication(LDLAppID);
                MessageBox.Show("Application Cancelled Successfully", "Cancelled", MessageBoxButtons.OK);
                RefreshData();
            }
                
        }

        private void dgvLocalDrivingLicenseApplications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >0)
            {
                DataGridViewRow selectedRow = dgvLocalDrivingLicenseApplications.Rows[e.RowIndex];

                LDLAppID =Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            }
        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CheckIfPassVisionResult()
        {
            if (clsTest.LastVisionTest(LDLAppID ,(int) FrmMain.enApplicationTypeID.NewLocalDrivingLicense))
            {
                secheduleVisionTestToolStripMenuItem.Enabled=false;
                secheduleWrittenTestToolStripMenuItem.Enabled = true;
            }
        }

        private void secheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppID = clsLocalDrivingLicenseApplication.GetAppIDByDLAppID(LDLAppID);

            FrmVisionTestAppointements frmVisionTestAppointements = new FrmVisionTestAppointements(AppID , LDLAppID);
            frmVisionTestAppointements.FillctrlDrivingLicenseApp();
            frmVisionTestAppointements.Show();
            CheckIfPassVisionResult();
            RefreshData();

        }
    }
}

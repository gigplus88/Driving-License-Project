using DVLD.License;
using DVLD.Test_Type;
using DVLD.Test_Type.Street_Test;
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
using static System.Net.Mime.MediaTypeNames;

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
            CheckTestResult();
        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void UpdateButtonsForPersonApplicant()
        {
            showApplicationDetailsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled=true;
            deleteApplicationToolStripMenuItem.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = true;
            sechduleTestsToolStripMenuItem.Enabled = true;
            
        }
        void UpdateButtonsForDriverPerson()
        {
            showApplicationDetailsToolStripMenuItem.Enabled = false;
            editApplicationToolStripMenuItem.Enabled=false;
            deleteApplicationToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            sechduleTestsToolStripMenuItem.Enabled = false;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = true;
        }
        public void CheckTestResult()
        {
            AppID = clsLocalDrivingLicenseApplication.GetAppIDByDLAppID(LDLAppID);

            if (clsLicense.IfDontHasLicense(AppID) || 
                clsLicense.IfHasLicenseActive(AppID, 0))
            {
                UpdateButtonsForPersonApplicant();
                CheckIfPassVisionResult();
                CheckIfPassWrittenResult();
                CheckIfPassStreetResult();
            }
            else if(clsLicense.IfHasLicenseActive(AppID, 1)) // 1 is Active
            {
                UpdateButtonsForDriverPerson();
            }
            else
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
            }
        }
        public void CheckIfPassVisionResult()
        {
            if (clsLocalDrivingLicenseApplication.GetLPassedTestNumber(LDLAppID) == 1) // 1 means He passed vision test
            {
                secheduleVisionTestToolStripMenuItem.Enabled=false;
                secheduleWrittenTestToolStripMenuItem.Enabled = true;
            }
        }
        public void CheckIfPassWrittenResult()
        {
            if (clsLocalDrivingLicenseApplication.GetLPassedTestNumber(LDLAppID) == 2) // 2 means He passed vision test
            {
                secheduleVisionTestToolStripMenuItem.Enabled=false;
                secheduleWrittenTestToolStripMenuItem.Enabled = false;
                secheduleStreetTestToolStripMenuItem.Enabled =true;
            }
        }
        public void CheckIfPassStreetResult()
        {
            if (clsLocalDrivingLicenseApplication.GetLPassedTestNumber(LDLAppID) == 3) // 2 means He passed vision test
            {
                sechduleTestsToolStripMenuItem.Enabled = false ;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
            }
        }
        int AppID;
        private void secheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
             AppID = clsLocalDrivingLicenseApplication.GetAppIDByDLAppID(LDLAppID);

            FrmVisionTestAppointements frmVisionTestAppointements = new FrmVisionTestAppointements(AppID , LDLAppID);
            frmVisionTestAppointements.FillctrlDrivingLicenseApp();
            frmVisionTestAppointements.Show();
            CheckIfPassVisionResult();
            RefreshData();

        }

        private void secheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
             AppID = clsLocalDrivingLicenseApplication.GetAppIDByDLAppID(LDLAppID);

            FrmWrittenTestAppointments frmWrittenTestAppointements = new FrmWrittenTestAppointments(AppID, LDLAppID);
            frmWrittenTestAppointements.FillctrlDrivingLicenseApp();
            frmWrittenTestAppointements.Show();
            CheckIfPassWrittenResult();
            RefreshData();
        }

        private void secheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
             AppID = clsLocalDrivingLicenseApplication.GetAppIDByDLAppID(LDLAppID);

            FrmStreetTestAppointments frmWrittenTestAppointements = new FrmStreetTestAppointments(AppID, LDLAppID);
            frmWrittenTestAppointements.FillctrlDrivingLicenseApp();
            frmWrittenTestAppointements.Show();
            CheckIfPassStreetResult();
            RefreshData();
        }

        void IssueButtonsAfterGetLicense()
        {
            showLicenseToolStripMenuItem.Enabled = true;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
        }
        void AddLicenseData()
        {
            clsLicense License = new clsLicense();
            License.Save();
        }
        /* void CompleteApplicationStatus()
         {
             _Application = clsApplication.Find(clsLocalDrivingLicenseApplication.GetAppIDByDLAppID(LDLAppID));
             _Application.ApplicationPersonID = _Application.ApplicationPersonID;
             _Application.ApplicationDate = _Application.ApplicationDate;
             _Application.ApplicationTypeID = _Application.ApplicationTypeID;
             _Application.ApplicationStatus = 3; // 3 is complete 
             _Application.LastStatusDate = _Application.LastStatusDate;
             _Application.PaidFees = _Application.PaidFees;
             _Application.CreatedByID = clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);

             clsApplication.Mode = clsApplication.enMode.Update;
             _Application.Save();
         }*/
        void CompleteApplication()
        {
            clsApplication.CompleteApplication(LDLAppID);
        }
        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppID = clsLocalDrivingLicenseApplication.GetAppIDByDLAppID(LDLAppID);

            if (clsLocalDrivingLicenseApplication.GetLPassedTestNumber(LDLAppID) == 3) 
            {
                FrmIssueDriverLicense frmIssueDriverLicense = new FrmIssueDriverLicense(LDLAppID ,AppID);
                frmIssueDriverLicense.ShowDialog();
                AddLicenseData();
                CompleteApplication();
                RefreshData();
                IssueButtonsAfterGetLicense();
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowLicenseInfo frmShowLicenseInfo = new FrmShowLicenseInfo(LDLAppID);
            frmShowLicenseInfo.LoadLicenseInfoByLDLApp(LDLAppID);
            frmShowLicenseInfo.ShowDialog();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppID = clsLocalDrivingLicenseApplication.GetAppIDByDLAppID(LDLAppID);
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(AppID);
            frmLicenseHistory.ShowDialog();
        }
    }
}

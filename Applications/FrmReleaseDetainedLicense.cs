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
using static Humanizer.On;
using static DVLD.FrmMain;


namespace DVLD.Applications
{
    public partial class FrmReleaseDetainedLicense : Form
    {

        private clsApplication _Application;
        private clsLicense _License;
        private clsDetainedLicense _DetainedLicense;

        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }
        public enApplicationStatus ApplicationStatus;
        public FrmReleaseDetainedLicense()
        {
            InitializeComponent();
            ctrlLicenseInfo1.SetParentForm(this);
            FrmMain.ApplicationTypeID = enApplicationTypeID.ReleaseDetainedDL;
        }
        public void GenerateButtonFilter(string Input)
        {
            ctrlLicenseInfo1.GenerateFilterClick( Input);
            ctrlLicenseInfo1.DisableGroupBoxFilter();
            ctrlLicenseInfo1.WrittetxtValueFilterBy(Input);
        }
        public void UpdateInfoAfterSearching()
        {
            int LicenseID = ctrlLicenseInfo1.LicenseID;
            float AppFees = clsApplicationType.GetApplicationFeesByApplicationTypeID(Convert.ToByte(enApplicationTypeID.ReleaseDetainedDL));
            _DetainedLicense = clsDetainedLicense.Find(clsDetainedLicense.GetDetainIDByLicenseID(LicenseID));

            if (_DetainedLicense != null)
            {
                lblDetainID.Text = _DetainedLicense.DetainID.ToString();
                lblDetainDate.Text = _DetainedLicense.DetainDate.ToString();
                lblLicenseID.Text = _DetainedLicense.LicenseID.ToString(); 
                lblCreatedBy.Text = clsUser.GetUserNameByUserID( _DetainedLicense.CreatedByUserID );
                lblFineFees.Text = _DetainedLicense.FineFees.ToString();
                lblApplicationFees.Text = AppFees.ToString();
                lblTotalFees.Text = (AppFees + _DetainedLicense.FineFees).ToString();
            }
        }
        public void UpdateLicenseID()
        {
            lblLicenseID.Text = ctrlLicenseInfo1.LicenseID.ToString();
        }
        public void DisabledReleaseButtonForApp(bool Issue)
        {
            btnRelease.Enabled = Issue;
        }
        int AppID, LicenseID, UserID;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void SavedApplicationInfo(enApplicationTypeID ApplicationTypeID)
        {
            _Application.ApplicationPersonID = clsApplication.GetPersonIDByAppID(AppID);
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID =(byte)ApplicationTypeID;
            _Application.ApplicationStatus =Convert.ToByte(enApplicationStatus.New); //New = 1 , Cancelled = 2 , Completed = =3
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees =clsApplicationType.GetApplicationFeesByApplicationTypeID(_Application.ApplicationTypeID);
            _Application.CreatedByID = UserID;

        }
        void CompleteApplicationByAppID()
        {
            clsApplication.CompleteApplicationByAppID(_Application.ApplicationID);
        }
        void ReleaseLicense(int DetainID)
        {
            //clsDetainedLicense.LicenseReleased(DetainID);
            clsDetainedLicense.Mode = clsDetainedLicense.enMode.Update;
            _DetainedLicense = clsDetainedLicense.Find(DetainID);

            _DetainedLicense.DetainID = DetainID;
            _DetainedLicense.LicenseID = _DetainedLicense.LicenseID;
            _DetainedLicense.DetainDate = clsDetainedLicense.GetDetainDate(DetainID);
            _DetainedLicense.FineFees = _DetainedLicense.FineFees;
            _DetainedLicense.CreatedByUserID = _DetainedLicense.CreatedByUserID;
            _DetainedLicense.IsReleased = 1;
            _DetainedLicense.ReleaseDate = DateTime.Now;
            _DetainedLicense.ReleasedByUserID = UserID;
            _DetainedLicense.ReleaseApplicationID =  _Application.ApplicationID;
            _DetainedLicense.Save();
        }
        void UpdatesAfterReplacement()
        {
            llblShowLicenseInfo.Enabled = true;
            ctrlLicenseInfo1.DisableGroupBoxFilter();
            btnRelease.Enabled = false;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
        }
        void SaveLDLApp()
        {
            clsLocalDrivingLicenseApplication LDLApp = new clsLocalDrivingLicenseApplication();
            LDLApp.ApplicationID = _Application.ApplicationID;
            LDLApp.LicenseClassID = clsLicense.GetLicenseClassIDByLicenseID(LicenseID);
            LDLApp.Save();
        }
        void GenerateReleaseLicense(enApplicationTypeID ApplicationTypeID)
        {
            SavedApplicationInfo(ApplicationTypeID);

            if (MessageBox.Show($"Are you sure do you want to release this Detained License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (_Application.Save())
                {
                    SaveLDLApp();
                    CompleteApplicationByAppID();
                    ReleaseLicense(_DetainedLicense.DetainID);
                    MessageBox.Show($" License Released Successfully With ID = {LicenseID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdatesAfterReplacement();

                }
            }
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            UserID = clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);
            LicenseID = ctrlLicenseInfo1.LicenseID;
            AppID = clsLicense.GetApplicationIDByLicenseID(LicenseID);

            clsApplication.Mode =clsApplication.enMode.AddNew;


            _Application = new clsApplication();
            GenerateReleaseLicense(enApplicationTypeID.ReleaseDetainedDL);
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            AppID = clsLicense.GetApplicationIDByLicenseID(LicenseID);
            FrmShowLicenseInfo frmShowLicenseInfo = new FrmShowLicenseInfo();
            frmShowLicenseInfo.LoadLicenseInfoByAppID(AppID);
            frmShowLicenseInfo.ShowDialog();
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            AppID = clsLicense.GetApplicationIDByLicenseID(ctrlLicenseInfo1.LicenseID);
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(AppID);
            frmLicenseHistory.ShowDialog();
        }
    }
}

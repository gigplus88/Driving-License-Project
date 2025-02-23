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
using static DVLD.FrmMain;
using static Humanizer.On;
using static System.Net.Mime.MediaTypeNames;


namespace DVLD.Applications
{
    public partial class FrmRenewLocalDrivingLicense : Form
    {
        private clsApplication _Application;
        private clsLicense _License;
        private clsDriver _Driver;

        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }

        public enApplicationStatus ApplicationStatus;

        public FrmRenewLocalDrivingLicense()
        {
            InitializeComponent();
            ctrlLicenseInfo1.SetParentForm(this);
            FrmMain.ApplicationTypeID = enApplicationTypeID.RenewDrivingLicense;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void UpdateLicenseID()
        {
            lblOldLicenseID.Text =  ctrlLicenseInfo1.LicenseID.ToString();
        }
        public void ExpirationDate()
        {
            lblExpirationDate.Text = clsLicense.GetExpirationDate(ctrlLicenseInfo1.LicenseID).ToString();
        }
        public void PaidFees()
        {
            lblLicenseFees.Text = clsLicense.GetPaidFees(ctrlLicenseInfo1.LicenseID).ToString();

        }
        public void AppFees()
        {
            lblApplicationFees.Text = clsApplicationType.GetApplicationFeesByApplicationTypeID((int)enApplicationTypeID.RenewDrivingLicense).ToString();

        }
        public void TotalFees()
        {
            lblTotalFees.Text = (clsLicense.GetPaidFees(ctrlLicenseInfo1.LicenseID) 
                + clsApplicationType.GetApplicationFeesByApplicationTypeID((int)enApplicationTypeID.RenewDrivingLicense)).ToString();
        }
        public void DisabledIssueButtonAndAbleShowLicenseLinkForRenewApp(bool Issue, bool LicenseLink)
        {
            btnRenew.Enabled = Issue;
            llblShowLicensesInfo.Enabled = LicenseLink;
        }
        void FillApplicationNewLicenseInfoCard()
        {
            lblAppliocationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();

            
            lblCreatedBy.Text = GlobalSettings.CurrentUserInfo.UserName;
            lblApplicationFees.Text = clsApplicationType.GetApplicationFeesByApplicationTypeID((byte)enApplicationTypeID.RenewDrivingLicense).ToString();

        }
        private void FrmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            FillApplicationNewLicenseInfoCard();
        }
        int AppID, LicenseID, UserID;

        void SaveApplicationInfo()
        {
            _Application.ApplicationPersonID = clsApplication.GetPersonIDByAppID(AppID);
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID =(byte)enApplicationTypeID.RenewDrivingLicense;
            _Application.ApplicationStatus =Convert.ToByte(enApplicationStatus.New); //New = 1 , Cancelled = 2 , Completed = =3
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees =clsApplicationType.GetApplicationFeesByApplicationTypeID(_Application.ApplicationTypeID);
            _Application.CreatedByID = UserID;

           
        }
        void SaveLDLApp()
        {
            clsLocalDrivingLicenseApplication LDLApp = new clsLocalDrivingLicenseApplication();
            LDLApp.ApplicationID = _Application.ApplicationID;
            LDLApp.LicenseClassID = clsLicense.GetLicenseClassIDByLicenseID(ctrlLicenseInfo1.LicenseID);
            LDLApp.Save();
        }
        //void MakeDriverLicense()
        //{
        //    _Driver = new clsDriver();
        //    clsDriver.Mode = clsDriver.enMode.AddNew;

        //    _Driver.PersonID = clsApplication.GetPersonIDByAppID(_Application.ApplicationID);
        //    _Driver.CreatedByUserID = UserID;
        //    _Driver.CreatedDate = DateTime.Now;
        //    _Driver.Save();
        //}
        void MakeLicenseDriver()
        {
            //MakeDriverLicense();
            clsLicense.Mode = clsLicense.enMode.AddNew;

            _License.ApplicationID = _Application.ApplicationID;
            _License.DriverID =  clsDriver.GetDriverIDByPersonID(_Application.ApplicationPersonID);
            _License.LicenseClassID = clsLocalDrivingLicenseApplication.GetLicenseClassIDByAppID(_Application.ApplicationID);
            _License.IssueDate = DateTime.Now;
            _License.ExpirationDate = _License.IssueDate.AddYears(clsLicenseClasse.GetValidityLengthByLicenseClassID(_License.LicenseClassID));

            if (txtNotes.Text == "")
            {
                _License.Notes = DBNull.Value.ToString();
            }
            else
            {
                _License.Notes = txtNotes.Text;
            }
            _License.PaidFees = clsLicenseClasse.GetPaidFeesByLicenseClassID(_License.LicenseClassID);

            _License.IsActive = Convert.ToByte(!clsDetainedLicense.IsDetainedLicense(_License.LicenseClassID));

            _License.IssueReason =Convert.ToByte(clsApplication.GetAppTypeIDByAppID(_Application.ApplicationID));

            _License.CreatedByID = UserID;

        }
        void DisactiveOldLicense()
        {
            clsLicense.DisableOldLicense(ctrlLicenseInfo1.LicenseID);
        }
        void CompleteApplicationByAppID()
        {
            clsApplication.CompleteApplicationByAppID(_Application.ApplicationID);
        }
        private void llblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppID = clsLicense.GetApplicationIDByLicenseID(ctrlLicenseInfo1.LicenseID);
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

        void UpdatesAfterRenew()
        {
            llblShowLicensesInfo.Enabled = true;
            ctrlLicenseInfo1.DisableGroupBoxFilter();
            btnRenew.Enabled = false;
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            UserID = clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);
            LicenseID = ctrlLicenseInfo1.LicenseID;
            AppID = clsLicense.GetApplicationIDByLicenseID(LicenseID);

                
            _Application = new clsApplication();
            _License = new clsLicense();

            clsApplication.Mode =clsApplication.enMode.AddNew;
            clsLicense.Mode = clsLicense.enMode.AddNew;
            SaveApplicationInfo();

            
            if (_Application.Save())
            {
                 SaveLDLApp();
                 if (MessageBox.Show($"Are you sure do you want to issue the License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                 {
                    MakeLicenseDriver();
                    clsLicense.Mode = clsLicense.enMode.AddNew;

                    if (_License.Save())
                    {
                        DisactiveOldLicense();
                        CompleteApplicationByAppID();

                        MessageBox.Show($" License Renewed Successfully With ID = {clsLicense.GetLicenseIDByApplicationID(_License.ApplicationID) }","License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdatesAfterRenew();
                    }
                 }
            }
            
            
        }
    }
}

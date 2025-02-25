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

namespace DVLD.Applications
{
    public partial class FrmReplacementForDamagedLicense : Form
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
        public FrmReplacementForDamagedLicense()
        {
            InitializeComponent();
            ctrlLicenseInfo1.SetParentForm(this);
            FrmMain.ApplicationTypeID = enApplicationTypeID.ReplacementforADamagedDL;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void UpdateLicenseID()
        {
            lblOldLicenseID.Text =  ctrlLicenseInfo1.LicenseID.ToString();
        }
        public void DisabledIssueButtonForApp(bool Issue)
        {
            btnIssueReplacement.Enabled = Issue;
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
        void SaveLDLApp()
        {
            clsLocalDrivingLicenseApplication LDLApp = new clsLocalDrivingLicenseApplication();
            LDLApp.ApplicationID = _Application.ApplicationID;
            LDLApp.LicenseClassID = clsLicense.GetLicenseClassIDByLicenseID(ctrlLicenseInfo1.LicenseID);
            LDLApp.Save();
        }
        void MakeLicenseDriver()
        {
            //MakeDriverLicense();
            clsLicense.Mode = clsLicense.enMode.AddNew;

            _License.ApplicationID = _Application.ApplicationID;
            _License.DriverID =  clsDriver.GetDriverIDByPersonID(_Application.ApplicationPersonID);
            _License.LicenseClassID = clsLocalDrivingLicenseApplication.GetLicenseClassIDByAppID(_Application.ApplicationID);
            _License.IssueDate = DateTime.Now;
            _License.ExpirationDate = _License.IssueDate.AddYears(clsLicenseClasse.GetValidityLengthByLicenseClassID(_License.LicenseClassID));

            _License.Notes = clsLicense.GetNotesByOldLicenseID(LicenseID);
            
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
        void UpdatesAfterReplacement()
        {
            llblShowNewLicensesInfo.Enabled = true;
            ctrlLicenseInfo1.DisableGroupBoxFilter();
            btnIssueReplacement.Enabled = false;
            lblLRApplicationID.Text = _Application.ApplicationID.ToString();
            lblReplacedLicenseID.Text = clsLicense.GetLicenseIDByApplicationID(_Application.ApplicationID).ToString();
        }
        int AppID, LicenseID, UserID;
        void GenerateReplacementLicense(enApplicationTypeID ApplicationTypeID)
        {
            SavedApplicationInfo(ApplicationTypeID);

            if (_Application.Save())
            {
                SaveLDLApp();
                if (MessageBox.Show($"Are you sure do you want to issue a Replacement for the License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    MakeLicenseDriver();
                    clsLicense.Mode = clsLicense.enMode.AddNew;

                    if (_License.Save())
                    {
                        DisactiveOldLicense();
                        CompleteApplicationByAppID();

                        MessageBox.Show($" License Replace Successfully With ID = {clsLicense.GetLicenseIDByApplicationID(_Application.ApplicationID)}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdatesAfterReplacement();
                    }
                }
            }
        }
        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            UserID = clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);
            LicenseID = ctrlLicenseInfo1.LicenseID;
            AppID = clsLicense.GetApplicationIDByLicenseID(LicenseID);


            _Application = new clsApplication();
            _License = new clsLicense();

            clsApplication.Mode =clsApplication.enMode.AddNew;
            clsLicense.Mode = clsLicense.enMode.AddNew;

            if (rbdamagedLicense.Checked)
            {
                GenerateReplacementLicense(enApplicationTypeID.ReplacementforADamagedDL);
            }
            else if (rbLostLicense.Checked)
            {
                GenerateReplacementLicense(enApplicationTypeID.ReplacementforALostDL);
            }
            else
            {
                MessageBox.Show("You Should click at Lost License radio button ", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppID = clsLicense.GetApplicationIDByLicenseID(ctrlLicenseInfo1.LicenseID);
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(AppID);
            frmLicenseHistory.ShowDialog();
        }

        private void llblShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppID = clsLicense.GetApplicationIDByLicenseID(clsLicense.GetLicenseIDByApplicationID(_Application.ApplicationID));
            FrmShowLicenseInfo frmShowLicenseInfo = new FrmShowLicenseInfo();
            frmShowLicenseInfo.LoadLicenseInfoByAppID(AppID);
            frmShowLicenseInfo.ShowDialog();
        }

        void GeneratePaidFeesByReplacementType()
        {
            if (rbdamagedLicense.Checked)
            {
                lblApplicationFees.Text = clsApplicationType.GetApplicationFeesByApplicationTypeID((byte)enApplicationTypeID.ReplacementforADamagedDL).ToString();
            }
            else
            {
                lblApplicationFees.Text = clsApplicationType.GetApplicationFeesByApplicationTypeID((byte)enApplicationTypeID.ReplacementforALostDL).ToString();
            }
        }

        private void rbdamagedLicense_Click(object sender, EventArgs e)
        {
            GeneratePaidFeesByReplacementType();
        }

        private void rbLostLicense_Click(object sender, EventArgs e)
        {
            GeneratePaidFeesByReplacementType();
        }

        void FillRelaceLicenseApplicationInfoCard()
        {
            lblAppliocationDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = GlobalSettings.CurrentUserInfo.UserName;
            GeneratePaidFeesByReplacementType();
        }
        private void FrmReplacementForDemagedLicense_Load(object sender, EventArgs e)
        {
            FillRelaceLicenseApplicationInfoCard();
        }
    }
}

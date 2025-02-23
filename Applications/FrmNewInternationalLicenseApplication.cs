using DVLD.Controls;
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
    public partial class FrmNewInternationalLicenseApplication : Form
    {
        private clsApplication _Application;
        private clsInternationalLicense _InternationalLicense;

        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }

        public enApplicationStatus ApplicationStatus;
        public FrmNewInternationalLicenseApplication()
        {
            InitializeComponent();
            FrmMain.ApplicationTypeID = enApplicationTypeID.NewInternationalLicense;
            ctrlLicenseInfo1.SetParentForm(this);

        }
        private ctrlLicenseInfo _ctrlLicenseInfo;

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int AppID , LicenseID , UserID;
        void SaveApplicationInfo()
        {
            _Application.ApplicationPersonID = clsApplication.GetPersonIDByAppID(AppID);
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID =(byte)enApplicationTypeID.NewInternationalLicense;
            _Application.ApplicationStatus =Convert.ToByte(enApplicationStatus.New); //New = 1 , Cancelled = 2 , Completed = =3
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees =clsApplicationType.GetApplicationFeesByApplicationTypeID(_Application.ApplicationTypeID);
            _Application.CreatedByID = UserID;
        }

        private void llblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmInternationalDriverInfo InternationalDriverInfo = new FrmInternationalDriverInfo(ctrlLicenseInfo1.LicenseID);
            InternationalDriverInfo.ShowDialog();
        }

        void SaveInternationalLicenseInfo()
        {
            _InternationalLicense.ApplicationID = AppID;
            _InternationalLicense.DriverID = clsLicense.GetDriverIDByLicenseID(LicenseID);
            _InternationalLicense.IssueUsingLocalLicenseID = LicenseID;
            _InternationalLicense.IssueDate = DateTime.Now;

            DateTime ExpirationDate = DateTime.Now.AddYears(1);

            _InternationalLicense.ExpirationDate = ExpirationDate;
            _InternationalLicense.IsActive = 1; //1 is Active , 0 is not active
            _InternationalLicense.CreatedByUserID = UserID;
        }
        public void DisabledIssueButtonAndAbleShowLicenseLink( bool Issue , bool LicenseLink)
        {
            ButtonIssue.Enabled = Issue;
            llblShowLicensesInfo.Enabled = LicenseLink;
        }
        public void UpdateLicenseID()
        {
            lblLocalLicenseID.Text =  ctrlLicenseInfo1.LicenseID.ToString();
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppID = clsLicense.GetApplicationIDByLicenseID(ctrlLicenseInfo1.LicenseID);
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(AppID);
            frmLicenseHistory.ShowDialog();
        }

        private void ctrLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
        void FillApplicationInfoCard()
        {
            lblAppliocationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();

            DateTime ExpirationDate = DateTime.Now.AddYears(1);
            lblExpirationDate.Text = ExpirationDate.ToString();

            lblCreatedBy.Text = GlobalSettings.CurrentUserInfo.UserName;
            lblFees.Text = clsApplicationType.GetApplicationFeesByApplicationTypeID((byte)enApplicationTypeID.NewInternationalLicense).ToString();

        }
        private void FrmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            FillApplicationInfoCard();
        }
        private void Issue_Click(object sender, EventArgs e)
        {
            UserID = clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);
            LicenseID = ctrlLicenseInfo1.LicenseID;
            AppID = clsLicense.GetApplicationIDByLicenseID(LicenseID);

            if (clsLicense.IfLicenseActive(ctrlLicenseInfo1.LicenseID , 1) && !clsLicense.IsExpireDate(ctrlLicenseInfo1.LicenseID))
            {
                if (!clsInternationalLicense.IfHasActiveInternationalLicense(ctrlLicenseInfo1.LicenseID))
                {
                    _Application = new clsApplication();
                    _InternationalLicense = new clsInternationalLicense();

                    clsApplication.Mode =clsApplication.enMode.AddNew;
                    clsInternationalLicense.Mode = clsInternationalLicense.enMode.AddNew;
                    SaveApplicationInfo();

                    if (MessageBox.Show($"Are you sure do you want to issue the License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information)== DialogResult.Yes)
                    {
                        if (_Application.Save())
                        {
                            SaveInternationalLicenseInfo();

                            if (_InternationalLicense.Save())
                            {
                                clsApplication.CompleteApplicationByAppID(_Application.ApplicationID);
                                
                                MessageBox.Show($"International License Issued Successfully With ID = {_InternationalLicense.InternationalLicenseID}",
                                    "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                llblShowLicensesInfo.Enabled = true;
                                ctrlLicenseInfo1.DisableGroupBoxFilter();
                            }


                        }
                    }
                }
            }


        }
    }
}

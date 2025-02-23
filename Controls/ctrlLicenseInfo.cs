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
using DVLD.Applications;

namespace DVLD.Controls
{
    public partial class ctrlLicenseInfo : UserControl
    {
        private FrmNewInternationalLicenseApplication _frmNewInternationalLicenseApplication; 
        private FrmRenewLocalDrivingLicense _frmRenewLocalDrivingLicense;
        private FrmReplacementForDamagedLicense _frmReplacementForDamagedLicense;

        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }
       
        public void SetParentForm(FrmNewInternationalLicenseApplication frm)
        {
            _frmNewInternationalLicenseApplication = frm;
        }
        public void SetParentForm(FrmRenewLocalDrivingLicense frm)
        {
            _frmRenewLocalDrivingLicense = frm;
        }
        public void SetParentForm(FrmReplacementForDamagedLicense frm)
        {
            _frmReplacementForDamagedLicense = frm;
        }
        public int LicenseID;
       void LoadLicenseInfoForIntApp()
       {
            int AppIDByLicenseID = clsLicense.GetApplicationIDByLicenseID(LicenseID);

            //lblLocalLicenseID.Text = LicenseID.ToString();
            if (!clsInternationalLicense.IfHasActiveInternationalLicense(LicenseID))
            {
                driverLicenseInfo1.LoadLicenseInfoByAppID(AppIDByLicenseID);
            }

            else
            {
                driverLicenseInfo1.LoadLicenseInfoByAppID(AppIDByLicenseID);

                if (_frmNewInternationalLicenseApplication != null)
                {
                    _frmNewInternationalLicenseApplication.UpdateLicenseID();
                    DisabledIssueButtonAndAbleShowLicenseLink();
                }

                MessageBox.Show($"Person already have an active International License with ID=" +
                    $" {clsInternationalLicense.GetIntLicenseIDIDByLicenseID(LicenseID)} ", "Not allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GetInfosAfterSearchingForRenew()
        {
            _frmRenewLocalDrivingLicense.ExpirationDate();
            _frmRenewLocalDrivingLicense.UpdateLicenseID();
            _frmRenewLocalDrivingLicense.PaidFees();
            _frmRenewLocalDrivingLicense.AppFees();
            _frmRenewLocalDrivingLicense.TotalFees();
        }
        void GetInfosAfterSearchingForReplaceDamaged()
        {
            _frmReplacementForDamagedLicense.UpdateLicenseID();
            _frmReplacementForDamagedLicense.DisabledIssueButtonForReplaceDamagedApp(true);
        }
        void DisabledIssueButtonAndAbleShowLicenseLink()
        {
            _frmNewInternationalLicenseApplication.DisabledIssueButtonAndAbleShowLicenseLink(false, true);    
        }
        void DisabledIssueButtonAndAbleShowLicenseLinkForRenewApp()
        {
            _frmRenewLocalDrivingLicense.DisabledIssueButtonAndAbleShowLicenseLinkForRenewApp(false, true);
        }
        void UpdateInfoAfterSearchingForRenew()
        {
            if (_frmRenewLocalDrivingLicense != null)
            {
                GetInfosAfterSearchingForRenew();
            }
        }
        void UpdateInfoAfterSearchingForReplaceDamaged()
        {
            if (_frmReplacementForDamagedLicense != null)
            {
                GetInfosAfterSearchingForReplaceDamaged();
            }
        }
        int AppIDByLicenseID;
        void GenerateLicenseInfoForRenew()
        {
            if (!clsLicense.IsExpireDate(LicenseID))
            {
                AppIDByLicenseID = clsLicense.GetApplicationIDByLicenseID(LicenseID);
                UpdateInfoAfterSearchingForRenew();
                DisabledIssueButtonAndAbleShowLicenseLinkForRenewApp();
                driverLicenseInfo1.LoadLicenseInfoByAppID(AppIDByLicenseID);

                MessageBox.Show($"Selected License is not expired , it will expired on :{clsLicense.GetExpirationDate(LicenseID)} ", "Not allowed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UpdateInfoAfterSearchingForRenew();
                driverLicenseInfo1.LoadLicenseInfoByAppID(AppIDByLicenseID);
            }
        }
        void LoadLicenseInfoForRenewLicenseApp()
        {
             AppIDByLicenseID = clsLicense.GetApplicationIDByLicenseID(LicenseID);

            //lblLocalLicenseID.Text = LicenseID.ToString();
            if(clsLicense.IfDontHasLicense(AppIDByLicenseID))
            {
                MessageBox.Show($"You dont have any License with ID = {LicenseID} ", "Error");
            }
            else
            {
                GenerateLicenseInfoForRenew();
            }
               
        }
        void GenerateInfoForReplaceDamagedLicense()
        {
            UpdateInfoAfterSearchingForReplaceDamaged();
            driverLicenseInfo1.LoadLicenseInfoByAppID(AppIDByLicenseID);   
        }
        void LoadLicenseInfoForReplaceForDamagedLicenseApp()
        {
            AppIDByLicenseID = clsLicense.GetApplicationIDByLicenseID(LicenseID);

            if (clsLicense.IfDontHasLicense(AppIDByLicenseID))
            {
                MessageBox.Show($"You dont have any License with ID = {LicenseID} ", "Error" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            else if ( clsLicense.IfLicenseActive(LicenseID , 0)) //dont Active = 0
            {
                MessageBox.Show($"Selected License is not Active , Choose an Active License ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GenerateInfoForReplaceDamagedLicense();
            }
        }
        private void btnFilterByLicenseID_Click(object sender, EventArgs e)
        {
            string Input = txtLicenseID.Text;

            if (Input == "")
            {
                MessageBox.Show("Your textbox is empty , Enter your LicenseID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (FrmMain.ApplicationTypeID == enApplicationTypeID.NewInternationalLicense)
            {
                LicenseID =Convert.ToInt32(Input);
                LoadLicenseInfoForIntApp();
            }
            else if (FrmMain.ApplicationTypeID == enApplicationTypeID.RenewDrivingLicense)
            {
                LicenseID =Convert.ToInt32(Input);
                LoadLicenseInfoForRenewLicenseApp();
            }
            else if (FrmMain.ApplicationTypeID == enApplicationTypeID.ReplacementforADamagedDL)
            {
                LicenseID =Convert.ToInt32(Input);
                LoadLicenseInfoForReplaceForDamagedLicenseApp();
            }
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       /* void FillApplicationInfoCard()
        {
            lblAppliocationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();

            DateTime ExpirationDate = DateTime.Now.AddYears(1);
            lblExpirationDate.Text = ExpirationDate.ToString();   

            lblCreatedBy.Text = GlobalSettings.CurrentUserInfo.UserName;
            lblFees.Text = clsApplicationType.GetApplicationFeesByApplicationTypeID((byte)enApplicationTypeID.NewInternationalLicense).ToString();

        }*/
        private void ctrLicenseInfo_Load(object sender, EventArgs e)
        {
            
        }
        
        public void DisableGroupBoxFilter()
        {
            gbFilter.Enabled = false;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void driverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }

        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }
    }
}

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


namespace DVLD.License
{
    public partial class FrmDetainLicense : Form
    {
        private clsApplication _Application;
        private clsLicense _License;
        private clsDetainedLicense _DetainLicense;

        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }

        public enApplicationStatus ApplicationStatus;
        public FrmDetainLicense()
        {
            InitializeComponent();
            ctrlLicenseInfo1.SetParentForm(this);
            
        }
        public void UpdateLicenseID()
        {
            lblLicenseID.Text =  ctrlLicenseInfo1.LicenseID.ToString();
        }
        public void DisabledDetainButton(bool Issue)
        {
            btnDetain.Enabled = Issue;
        }
        void FillDetainInfoCard()
        {
            lblDetainDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = GlobalSettings.CurrentUserInfo.UserName;
            txtFineFees.Text = "No Fees Yet";
        }
        private void FrmDetainLicense_Load(object sender, EventArgs e)
        {
            FillDetainInfoCard();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void UpdatesAfterDetain()
        {
            llblShowLicenseInfo.Enabled = true;
            ctrlLicenseInfo1.DisableGroupBoxFilter();
            btnDetain.Enabled = false;
            lblDetainID.Text = clsDetainedLicense.GetDetainIDByLicenseID(LicenseID).ToString();
        }
        int UserID, LicenseID , DetainID , AppID;

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppID = clsLicense.GetApplicationIDByLicenseID(ctrlLicenseInfo1.LicenseID);
            FrmLicenseHistory frmLicenseHistory = new FrmLicenseHistory(AppID);
            frmLicenseHistory.ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppID = clsLicense.GetApplicationIDByLicenseID(LicenseID);
            FrmShowLicenseInfo frmShowLicenseInfo = new FrmShowLicenseInfo();
            frmShowLicenseInfo.LoadLicenseInfoByAppID(AppID);
            frmShowLicenseInfo.ShowDialog();
        }

        void GenerateDetainOfLicense( )
        {
            UserID = clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);
            LicenseID = ctrlLicenseInfo1.LicenseID;

            _DetainLicense = new clsDetainedLicense();

            _DetainLicense.LicenseID = LicenseID;
            _DetainLicense.DetainDate = DateTime.Now;
            _DetainLicense.FineFees = Convert.ToInt32(txtFineFees.Text);
            _DetainLicense.CreatedByUserID = UserID;
            _DetainLicense.IsReleased = 0; // 0 is not release , 1 is released
            _DetainLicense.ReleaseDate = null ;
            _DetainLicense.ReleasedByUserID = null;
            _DetainLicense.ReleaseApplicationID = null;

            if (MessageBox.Show($"Are you sure you want to detain this License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                clsDetainedLicense.Mode = clsDetainedLicense.enMode.AddNew;
                if (_DetainLicense.Save())
                {
                    MessageBox.Show($" License Detain Successfully With ID = {clsDetainedLicense.GetDetainIDByLicenseID(LicenseID)}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdatesAfterDetain();
                }
            }
            
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            GenerateDetainOfLicense();
           
        }
    }
}

﻿using DVLD_Business;
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
        void GetInfosAfterSearching()
        {
            _frmRenewLocalDrivingLicense.ExpirationDate();
            _frmRenewLocalDrivingLicense.UpdateLicenseID();
            _frmRenewLocalDrivingLicense.PaidFees();
            _frmRenewLocalDrivingLicense.AppFees();
            _frmRenewLocalDrivingLicense.TotalFees();
        }
        void DisabledIssueButtonAndAbleShowLicenseLink()
        {
            _frmNewInternationalLicenseApplication.DisabledIssueButtonAndAbleShowLicenseLink(false, true);    
        }
        void DisabledIssueButtonAndAbleShowLicenseLinkForRenewApp()
        {
            _frmRenewLocalDrivingLicense.DisabledIssueButtonAndAbleShowLicenseLinkForRenewApp(false, true);
        }
        void UpdateInfoAfterSearching()
        {
            if (_frmRenewLocalDrivingLicense != null)
            {
                GetInfosAfterSearching();
            }
        }
        int AppIDByLicenseID;
        void GenerateLicenseInfo()
        {
            if (!clsLicense.IsExpireDate(LicenseID))
            {
                AppIDByLicenseID = clsLicense.GetApplicationIDByLicenseID(LicenseID);
                UpdateInfoAfterSearching();
                DisabledIssueButtonAndAbleShowLicenseLinkForRenewApp();
                driverLicenseInfo1.LoadLicenseInfoByAppID(AppIDByLicenseID);

                MessageBox.Show($"Selected License is not expired , it will expired on :{clsLicense.GetExpirationDate(LicenseID)} ", "Not allowed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UpdateInfoAfterSearching();
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
                GenerateLicenseInfo();
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

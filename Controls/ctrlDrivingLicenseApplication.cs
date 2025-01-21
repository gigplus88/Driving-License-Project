using DVLD.Properties;
using DVLD.Test_Type;
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

namespace DVLD.Controls
{
    public partial class ctrlDrivingLicenseApplication : UserControl
    {
        private clsApplication _Application;
        private clsLocalDrivingLicenseApplication _LDLApplication;

        private int _ApplicationID = -1;
        private int _ApplicantPersonID = -1;
        public int LDLAppID;
        public string FullName, ClassName;
        public ctrlDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

      
       



        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
      
        public void LoadDrivingLicenseAppInfo(int ApplicationID)
        {
            _Application = clsApplication.Find( ApplicationID);

            if (_Application != null)
            {
                FillLDLApplicationCard();
            }

            else
            {
                MessageBox.Show("Driving License Application not found" , "Info");
            }
        }

        void CheckStatus()
        {
            if (_Application.ApplicationStatus == 1)
            {
                lblStatus.Text ="New";
            }
            else if (_Application.ApplicationStatus == 2)
            {
                lblStatus.Text ="Cancelled";
            }
            else
            {
                lblStatus.Text ="Completed";
            }
        }
        public void FillLDLApplicationCard()
        {
            _ApplicantPersonID = _Application.ApplicationPersonID;
            _ApplicationID = _Application.ApplicationID;
            _LDLApplication = clsLocalDrivingLicenseApplication.Find(_ApplicationID);

            // For LDLApplication
            lblDLAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClassName.Text = clsLicenseClasse.GetClassNameByLicenseClassID(_LDLApplication.LicenseClassID);
            lblPassedTest.Text = clsLocalDrivingLicenseApplication.GetTestNumberByLDLAppID(_LDLApplication.LocalDrivingLicenseApplicationID).ToString() +"/3";

            // For Application Basic Info
            
            lblID.Text = _Application.ApplicationID.ToString();
            CheckStatus();
            lblFees.Text = _Application.PaidFees.ToString();
            lblAppType.Text = clsApplicationType.GetApplicationTypeNameByApplicationTypeID(_Application.ApplicationTypeID);
            lblApplicant.Text =clsPerson.GetFullNameByPersonID(_Application.ApplicationPersonID) .ToString();
            lblApplicationDate.Text =_Application.ApplicationDate.ToString();
            lblStatusDate.Text =_Application.LastStatusDate.ToString();
            lblCreatedBy.Text = GlobalSettings.CurrentUserInfo.UserName;

             LDLAppID =Convert.ToInt32(lblDLAppID.Text);

            FullName = lblApplicant.Text.Trim();
            ClassName = lblLicenseClassName.Text.Trim();


        }

        private void gpDLAI_Enter(object sender, EventArgs e)
        {

        }

        private void llblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonDetails frmPersonDetails = new FrmPersonDetails(_ApplicantPersonID);
            frmPersonDetails.GetPersonInfo(_ApplicantPersonID);
            frmPersonDetails.ShowDialog();
        }
    }
}

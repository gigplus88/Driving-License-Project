using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public string FullName, ClassName;
        public int LDLAppID;
        private int _ApplicantPersonID = -1;


        private clsApplication _Application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationBasicInfo(int ApplicationID)
        {
            _Application = clsApplication.Find(ApplicationID);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationBasicInfoCard();
        }
        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblAppType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblApplicationDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedBy.Text = "[????]";

        }
        void CheckStatus()
        {
            if (_Application.ApplicationStatus == (clsApplication.enApplicationStatus)1)
            {
                lblStatus.Text ="New";
            }
            else if (_Application.ApplicationStatus ==(clsApplication.enApplicationStatus)2)
            {
                lblStatus.Text ="Cancelled";
            }
            else
            {
                lblStatus.Text ="Completed";
            }
        }
        void _FillApplicationBasicInfoCard()
        {
            _ApplicantPersonID = _Application.ApplicantPersonID;

            lblApplicationID.Text = _Application.ApplicationID.ToString();
            CheckStatus();
            lblFees.Text = _Application.PaidFees.ToString();
            lblAppType.Text = clsApplicationType.GetApplicationTypeNameByApplicationTypeID(_Application.ApplicationTypeID);
            lblApplicant.Text =clsPerson.GetFullNameByPersonID(_Application.ApplicantPersonID).ToString();
            lblApplicationDate.Text =_Application.ApplicationDate.ToString();
            lblStatusDate.Text =_Application.LastStatusDate.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;

            FullName = lblApplicant.Text.Trim();
        }

        private void llblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonDetails frmPersonDetails = new FrmPersonDetails(_ApplicantPersonID);
            frmPersonDetails.ShowDialog();
        }

        private void gpDLAI_Enter(object sender, EventArgs e)
        {

        }
    }
}

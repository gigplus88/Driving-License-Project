using DVLD.Controls;
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

namespace DVLD.Test_Type
{
    public partial class FrmScheduleTest : Form
    {
        private int _LDLAppID;
        private int _TestAppointmentID;
        private string _FullName;
        private string _ClassName;
        public static int Trial ;
        private clsTestAppointment _TestAppointment;
        private clsTest _Test;
        public enum enTestType
        {
            Vision = 1,
            Written = 2,
            Practical = 3
        };
        public static enTestType TestType ;

        public enum enApplicationTypeID
        {
            NewLocalDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplacementforALostDL = 3,
            ReplacementforADamagedDL = 4,
            ReleaseDetainedDL = 5,
            NewInternationalLicense = 6,
            ReatkeTest = 8
        }

        public enum enTestMode 
        {
           NewTest = 1,
           RetakeTest = 2
        }

        public enTestMode TestMode;


        public FrmScheduleTest(int TestAppointmentID ,int LDLAppID, string FullName , string Classsname)
        {
            InitializeComponent();
            this._TestAppointmentID = TestAppointmentID;
            this._LDLAppID = LDLAppID;
            this._FullName = FullName;
            this._ClassName = Classsname;
        }
       
        public FrmScheduleTest()
        {
            InitializeComponent();
           
        }

        private void FrmScheduleTest_Load(object sender, EventArgs e)
        {
            FillScheduleTestCard();
        }

        public void LockOperation()
        {
            lblLockedMessage.Visible =true;
            dtpTestDate.Enabled = false;
            btnSave.Enabled = false;
        }
        public void CheckIfRetakeTest()
        {
            if (clsTest.CountTestTrial(_TestAppointmentID) >= 1)
            {
                _Test = clsTest.Find(_TestAppointmentID);
                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTest.Enabled = true;
                lblTrial.Text = clsTest.CountTestTrial(_TestAppointmentID).ToString();
                lblRetakeTestAppID.Text = _Test.TestID.ToString();
            }
        }
        public void FillScheduleTestCard()
        {
            lblLDLAppID.Text = _LDLAppID.ToString();
            lblClassName.Text = _ClassName;
            lblName.Text = _FullName;
            
            lblTrial.Text = Trial.ToString();

            DateTime Today = DateTime.Now;
            dtpTestDate.MinDate = Today.AddDays(1);
            dtpTestDate.MaxDate = Today.AddYears(1);

            lblFeesTest.Text = clsTestType.GetTestFeesByTypeID((int)enTestType.Vision).ToString();

            if (clsTest.CountTestTrial(_TestAppointmentID) == 0)
            {
                lblRetakAppFees.Text = 0.ToString();
            }
            else
            {
                lblRetakAppFees.Text = clsApplicationType.GetApplicationFeesByApplicationTypeID( Convert.ToByte( enApplicationTypeID.ReatkeTest)).ToString();
            }

            lblTotalFees.Text = (clsTestType.GetTestFeesByTypeID((int)enTestType.Vision) +
                                Convert.ToInt16(lblRetakAppFees.Text)).ToString();
            lblRetakeTestAppID.Text = "N/A";
            CheckIfRetakeTest();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddTestAppointment()
        {
            clsTestAppointment.Mode = clsTestAppointment.enMode.AddNew;

            clsTestAppointment Test = new clsTestAppointment();
            Test.TestTypeID =  (int)enTestType.Vision;
            Test.LocalDrivingLicenseApplicationID = _LDLAppID;
            Test.AppointmentDate = dtpTestDate.Value;
            Test.PaidFees = clsTestType.GetTestFeesByTypeID((int)enTestType.Vision);
            Test.CreatedByUserID =clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);
            Test.IsLocked = 0; // 0 before testing , 1 after testing

            if (Test.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Save Data Vision Test" , MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        public void UpdateTestAppointment(byte Islocked)
        {
            clsTestAppointment.Mode = clsTestAppointment.enMode.Update;

            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            _TestAppointment.TestTypeID =  (int)enTestType.Vision;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LDLAppID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = clsTestType.GetTestFeesByTypeID((int)enTestType.Vision);
            _TestAppointment.CreatedByUserID =clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);
            _TestAppointment.IsLocked = Islocked; // 0 before testing , 1 after testing

            if (_TestAppointment.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Save Data Vision Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.Mode == clsTestAppointment.enMode.AddNew)
            {
                AddTestAppointment();
            }
            else
            {
                UpdateTestAppointment(0);
            }


        }
    }
}

using DVLD.Applications;
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
using static DVLD.Test_Type.FrmScheduleTest;

namespace DVLD.Test_Type
{
    public partial class FrmTakeTest : Form
    {
        private int _LDLAppID;
        private int _TestAppointmentID;
        private string _FullName;
        private string _ClassName;
        public static int Trial = 0;
        private clsTest _Test;
        public enum enTestType
        {
            Vision = 1,
            Written = 2,
            Practical = 3
        };
        public static enTestType TestType;
        public FrmTakeTest(int TestAppointmentID, int LDLAppID, string FullName, string Classsname)
        {
            InitializeComponent();
            this._TestAppointmentID = TestAppointmentID;
            this._LDLAppID = LDLAppID;
            this._FullName = FullName;
            this._ClassName = Classsname;
        }

        private void FrmTakeTest_Load(object sender, EventArgs e)
        {
            FillTestCardBeforeTesting();
        }
        public void FillTestCardBeforeTesting()
        {
            lblLDLAppID.Text = _LDLAppID.ToString();
            lblClassName.Text = _ClassName;
            lblName.Text = _FullName;
            lblTrial.Text = clsTest.CountTestTrial(_TestAppointmentID).ToString();
            lblDate.Text = clsTestAppointment.GetTestDateByTestAppointmentID(_TestAppointmentID,(int)enTestType.Vision).ToString();
            lblFeesTest.Text = clsTestType.GetTestFeesByTypeID((int)enTestType.Vision).ToString();
            lblTestID.Text = "No taken Yet";
        }
        void CheckTestResult()
        {
            if (rbPass.Checked)
            {
                _Test.TestResult = 1;
            }
            else
            {
                _Test.TestResult = 0;
            }
        }
        public void AddTest()
        {
            _Test = new clsTest();

            _Test.TestAppointmentID = _TestAppointmentID;
            // If Pass Result=0 , if Fail Result=1
            CheckTestResult();
            _Test.Notes = txtNotes.Text;
            _Test.CreatedByUserID = clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);

            if (MessageBox.Show("Are you sure you want to save this Result? \nAfter that You cannot change the Pass/Fail Results ","Confirm" , MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                if (_Test.Save())
                {   
                    lblTestID.Text = _Test.TestID.ToString();
                   
                    lblTrial.Text =clsTest.CountTestTrial(_TestAppointmentID).ToString();

                    LockeAppointment();

                }
            }
          
        }
        void LockeAppointment()
        {
            FrmScheduleTest frmScheduleTest = new FrmScheduleTest(_TestAppointmentID, _LDLAppID, _FullName, _ClassName);
            frmScheduleTest.UpdateTestAppointment(1); // 1 is locked

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            AddTest();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

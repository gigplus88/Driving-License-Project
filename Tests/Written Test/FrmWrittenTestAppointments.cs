using DVLD.Test_Type;
using DVLD_Business;
using System;
using System.Windows.Forms;
using static DVLD.FrmMain;

namespace DVLD.Test_Type
{
    public partial class FrmWrittenTestAppointments : Form
    {
        private int _AppID;
        private int _LDLAppID;
        private int _TestAppointmentID;

        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }

        public enApplicationStatus ApplicationStatus;
        public byte ApplicationTypeID = 0;
        private clsApplication _Application;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public enum enTestType
        {
            Vision = 1,
            Written = 2,
            Practical = 3
        };
        public static enTestType TestType;

        public FrmWrittenTestAppointments(int AppID, int LDLAppID)
        {
            InitializeComponent();
            this._AppID = AppID;
            this._LDLAppID = LDLAppID;
        }
        public void RefreshData()
        {
            dgvAppointments.DataSource = clsTestAppointment.GetTestAppointementData();
            lblNumberOfAppointments.Text = clsTestAppointment.CountAppointments().ToString();

        }
        private void FrmWrittenTestAppointments_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void FillctrlDrivingLicenseApp()
        {
            ctrlDrivingLicenseApplication1.LoadDrivingLicenseAppInfo(_AppID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int TestAppointmentID;
        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                DataGridViewRow selectedRow = dgvAppointments.Rows[e.RowIndex];

                TestAppointmentID =Convert.ToInt16(selectedRow.Cells["TestAppointmentID"].Value);

            }
        }
        void SaveApplicationInfo()
        {
            _Application.ApplicationPersonID = clsApplication.GetPersonIDByAppID(_AppID);
            _Application.ApplicationTypeID =(byte)enApplicationTypeID.ReatkeTest;
            _Application.ApplicationStatus =Convert.ToByte(enApplicationStatus.New); //New = 1 , Cancelled = 2 , Completed = =3
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees =clsApplicationType.GetApplicationFeesByApplicationTypeID(_Application.ApplicationTypeID);
            _Application.CreatedByID = clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);
        }
        void SaveLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplication.ApplicationID = _AppID;
            _LocalDrivingLicenseApplication.LicenseClassID = clsLocalDrivingLicenseApplication.GetLicenseClassIDByDLAppID(_LDLAppID);
        }
        private void _AddRetakeTestApplication()
        {
            _Application = new clsApplication();
            _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();

            SaveApplicationInfo();

            // For LocalDrivingLicenseApplication

            clsApplication.Mode =clsApplication.enMode.AddNew;
            clsLocalDrivingLicenseApplication.Mode = clsLocalDrivingLicenseApplication.enMode.AddNew;

            if (_Application.Save())
            {
                SaveLocalDrivingLicenseApplicationInfo();
                if (_LocalDrivingLicenseApplication.Save())
                {
                    MessageBox.Show($"{_Application.ApplicationID} Added Successfully", "Adding Application", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show($"Error  to Add {_Application.ApplicationID}  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void _TakeScheduleTest()
        {
            FrmScheduleTest frmScheduleTest = new FrmScheduleTest(_TestAppointmentID, ctrlDrivingLicenseApplication1.LDLAppID,
                  ctrlDrivingLicenseApplication1.FullName, ctrlDrivingLicenseApplication1.ClassName);
            frmScheduleTest.FillScheduleTestCardForWritten();
            frmScheduleTest.ShowDialog();
            RefreshData();
        }
        private void btnNewScheduleTest_Click(object sender, EventArgs e)
        {
            int PersonLDLAppID = ctrlDrivingLicenseApplication1.LDLAppID;
            if (!clsTestAppointment.IsHasTestAppointment(PersonLDLAppID , (int) enTestType.Written))
            {
                _TakeScheduleTest();
                return;
            }
            if (clsTestAppointment.IsHasActiveScheduleTest(PersonLDLAppID))
            {
                MessageBox.Show("Person Already has an active Appointments for this test , You cannot add new Appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (clsTestAppointment.IsHasTestAppointment(PersonLDLAppID))
            {
                if (clsTest.CheckLastTest(PersonLDLAppID, (int)enTestType.Written) == false) // if equal 0 is fail
                {
                    _TestAppointmentID = clsTestAppointment.GetTestAppointmentIDByLDLAppID(PersonLDLAppID);
                    _AddRetakeTestApplication();
                    _TakeScheduleTest();
                    return;
                }
                else
                {
                    MessageBox.Show("This Person Already passed this test before, You can only retake failed Test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestAppointment.Mode = clsTestAppointment.enMode.Update;

            if (clsTestAppointment.IsAppointmentLocked(_LDLAppID, (int)enTestType.Written))
            {
                FrmScheduleTest frmScheduleTest1 = new FrmScheduleTest(TestAppointmentID, ctrlDrivingLicenseApplication1.LDLAppID,
                    ctrlDrivingLicenseApplication1.FullName, ctrlDrivingLicenseApplication1.ClassName);
                frmScheduleTest1.LockOperation();
                frmScheduleTest1.ShowDialog();
            }
            else
            {
                _TakeScheduleTest();
            }
        }

        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsTest.CheckLastTestByTestAppointmentID(TestAppointmentID, (int)enTestType.Written) == false)
            {
                FrmTakeTest frmTakeTest = new FrmTakeTest(TestAppointmentID, ctrlDrivingLicenseApplication1.LDLAppID,ctrlDrivingLicenseApplication1.FullName,
                                                         ctrlDrivingLicenseApplication1.ClassName , FrmTakeTest.enTestType.Written);
                frmTakeTest.ShowDialog();
                RefreshData();
            }
            else
            {
                MessageBox.Show("This Person Already passed this test before, You can only retake failed Test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}

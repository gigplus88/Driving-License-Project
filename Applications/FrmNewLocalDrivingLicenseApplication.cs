using DVLD.Users;
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
using static DVLD.ctrlPersonCardWithFilter;
using static DVLD.FrmMain;

namespace DVLD.Applications
{
    public partial class FrmNewLocalDrivingLicenseApplication : Form
    {

        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }

        public enApplicationStatus ApplicationStatus;
        public byte ApplicationTypeID ;
        private int _ApplicantPersonID = 0;
        private clsApplication _Application;
        private clsPerson _Person;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private string _ApplicationNationalNo;
        public enum enMode
        {
            Added = 0, Updated = 1
        };
        public enMode Mode;
        public FrmNewLocalDrivingLicenseApplication(byte ApplicationTypeID)
        {
            InitializeComponent();
            this.ApplicationTypeID = ApplicationTypeID;
        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

        }
        enum enMFindMode { BeforeFill, AfterFill };
        enMFindMode FindMode = enMFindMode.BeforeFill;
        private void _FillBoxes(int PersonID)
        {
            //_Application = clsApplication.FindByPersonID(PersonID);

            if (_Application == null)
            {
                return;
            }
            //if (FindMode == enMFindMode.BeforeFill)
            //{
            //    lblUserID.Text = _Application.UserID.ToString();
            //    txtUserName.Text = _Application.UserName;
            //    txtPassword.Text = _Application.Password;
            //    txtConfirmPassword.Text = _Application.Password;
            //    if (_Application.IsActive == 1)
            //    {
            //        chbIsActive.Checked = true;
            //    }
            //    else
            //    {
            //        chbIsActive.Checked = false;
            //    }

            //    FindMode = enMFindMode.AfterFill;
            //}
            else
            {
                FillUserInfoAfterEdit(PersonID);
            }
        }
        public void FillUserInfoAfterEdit(int PersonID)
        {
            ///* clsUser*/
            //_Application = clsUser.FindByPersonID(PersonID);
            //_Application.UserName = txtUserName.Text;
            //_Application.Password = txtPassword.Text;
            //if (chbIsActive.Checked)
            //{
            //    _Application.IsActive = 1;
            //}
            //else
            //{
            //    _Application.IsActive = 0;
            //}

            //clsUser.Mode = clsUser.enMode.Update;

            //if (_Application.Save())
            //{
            //    MessageBox.Show($"{_Application.PersonID} Updated Successfully", "Update User", MessageBoxButtons.OK);
            //    _PersonID = _Application.PersonID;
            //}
            //else
            //{
            //    MessageBox.Show($"Error  to Update {_Application.PersonID}  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

        }
        public void UpdateUser(int PersonID)
        {
            lblTitle.Text =  "Update User";
            ctrlPersonCardWithFilter1.PersonSearchToEdit(PersonID);
            _FillBoxes(PersonID);
        }

        //public void IsActivePerson()
        //{
        //    if (!clsApplication.IsPersonExist(_ApplicantPersonID))
        //    {
        //        clsApplication.Mode = clsApplication.enMode.AddNew;
        //        tabControl1.SelectedTab = tpApplicationInfo;
        //        cbLicenseClass.Focus();
        //        return;
        //    }
        //    if (clsApplication.IsPersonCanBeApplicantByLicenseClasse(_ApplicantPersonID , _ApplicantPersonID))
        //    {
        //        clsApplication.Mode = clsApplication.enMode.AddNew;
        //        tabControl1.SelectedTab = tpApplicationInfo;
        //        cbLicenseClass.Focus();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Selected Person already has a Active Application  , Choose another one", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        public void ToNextTabPage()
        {
            clsApplication.Mode = clsApplication.enMode.AddNew;
            tabControl1.SelectedTab = tpApplicationInfo;
            cbLicenseClass.Focus();
            FillImplicitInfo();
        }
        public void FillImplicitInfo()
        {
            ApplicationTypeID =(int)enApplicationTypeID.NewLocalDrivingLicense;

            lblApplicationDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = clsApplicationType.GetApplicationFeesByApplicationTypeID(ApplicationTypeID).ToString();
            lblCreatedBy.Text ="user4"; //GlobalSettings.CurrentUserInfo.UserName;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.SearchingMode == enSearchingMode.PersonID)
            {
                _ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
                ToNextTabPage();
                return;
            }
            else
            {
                _ApplicationNationalNo = ctrlPersonCardWithFilter1.NationalNo;
                _Person = clsPerson.Find(_ApplicationNationalNo);
                if (_Person != null)
                {
                    _ApplicantPersonID = _Person.PersonID;
                    ToNextTabPage();
                }
            }

        }
        bool IsApplicationWithLicenseClasseCanDoing()
        {
            if (!clsApplication.IsPersonHasApplicationByLicenseClasse(Convert.ToInt16(clsLicenseClasse.GetLicenseClassIDByClassName(cbLicenseClass.SelectedItem.ToString() ))) )
            {
                return true;
            }
            if (!clsApplication.IsPersonCanBeApplicantByLicenseClasse(_ApplicantPersonID, ApplicationTypeID,Convert.ToInt32(clsLicenseClasse.GetLicenseClassIDByClassName(cbLicenseClass.SelectedItem.ToString() ))) )
            {
                MessageBox.Show("Choose another License Class ,The selected Person Already have an active application for the selected class with id " +
                $"= {clsApplication.GetLastApplicationIDByPersonIDAppTypeAndLicense(_ApplicantPersonID, ApplicationTypeID ,Convert.ToInt32(clsLicenseClasse.GetLicenseClassIDByClassName(cbLicenseClass.SelectedItem.ToString()))) }",
                "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        void SaveApplicationInfo()
        {
            _Application.ApplicationPersonID = _ApplicantPersonID;
            _Application.ApplicationTypeID =ApplicationTypeID;
            _Application.ApplicationStatus =Convert.ToByte(enApplicationStatus.New); //New = 1 , Cancelled = 2 , Completed = =3
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees =clsApplicationType.GetApplicationFeesByApplicationTypeID(ApplicationTypeID);
            _Application.CreatedByID = clsUser.GetUserIDByUserName("user4"); //GlobalSettings.CurrentUserInfo.UserName

        }
        void SaveLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplication.ApplicationID = _Application.ApplicationID;

            if (cbLicenseClass.SelectedItem != null)
            {
                _LocalDrivingLicenseApplication.LicenseClassID = Convert.ToInt32(clsLicenseClasse.GetLicenseClassIDByClassName(cbLicenseClass.SelectedItem.ToString()));
            }
            else
            {
                _LocalDrivingLicenseApplication.LicenseClassID = 0;
            }
        }

        private void _AddApplicantPerson()
        {
            ApplicationTypeID =(int)enApplicationTypeID.NewLocalDrivingLicense;
            _Application = new clsApplication();
            _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();

            SaveApplicationInfo();
            if (!IsApplicationWithLicenseClasseCanDoing())
            {
                return;
            }
            // For LocalDrivingLicenseApplication

            clsApplication.Mode =clsApplication.enMode.AddNew;
            clsLocalDrivingLicenseApplication.Mode = clsLocalDrivingLicenseApplication.enMode.AddNew;

            if (_Application.Save() )
            {
                SaveLocalDrivingLicenseApplicationInfo();
                if (_LocalDrivingLicenseApplication.Save())
                {
                    MessageBox.Show($"{_Application.ApplicationID} Added Successfully", "Adding Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblDLApplicationID.Text = _Application.ApplicationID.ToString();
                }
               
                //FrmManageUsers frmManageUsers = new FrmManageUsers();
                //frmManageUsers.RefreshData();
                //Mode = enMode.Updated;
            }
            else
            {
                MessageBox.Show($"Error  to Add {_Application.ApplicationID}  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Added)
            {
                _AddApplicantPerson();

            }
        }
    }
}

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

namespace DVLD.Applications
{
    public partial class FrmNewLocalDrivingLicenseApplication : Form
    {
        private int _ApplicationTypeID = 1;
        private int _ApplicationPersonID = 0;
        private clsApplication _Application;
        private clsPerson _Person;

        private string _ApplicationNationalNo;
        public enum enMode
        {
            Added = 0, Updated = 1
        };
        public enMode Mode;
        public FrmNewLocalDrivingLicenseApplication(int ApplicationTypeID)
        {
            InitializeComponent();
            this._ApplicationTypeID = ApplicationTypeID;
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

        public void IsActivePerson()
        {
            if (!clsApplication.IsPersonExist(_ApplicationPersonID))
            {
                clsApplication.Mode = clsApplication.enMode.AddNew;
                tabControl1.SelectedTab = tpApplicationInfo;
                cbLicenseClass.Focus();
                return;
            }
            if (clsApplication.IsPersonHasApplicationActive(_ApplicationPersonID))
            {
                clsApplication.Mode = clsApplication.enMode.AddNew;
                tabControl1.SelectedTab = tpApplicationInfo;
                cbLicenseClass.Focus();
            }
            else
            {
                MessageBox.Show("Selected Person already has a Active Application  , Choose another one", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.SearchingMode == enSearchingMode.PersonID)
            {
                _ApplicationPersonID = ctrlPersonCardWithFilter1.PersonID;
                IsActivePerson();
            }
            else
            {
                _ApplicationNationalNo = ctrlPersonCardWithFilter1.NationalNo;
                _Person = clsPerson.Find(_ApplicationNationalNo);
                if (_Person != null)
                {
                    _ApplicationPersonID = _Person.PersonID;
                    IsActivePerson();
                }
            }

        }
    }
}

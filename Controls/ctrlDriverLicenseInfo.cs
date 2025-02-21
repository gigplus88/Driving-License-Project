using DVLD_Business;
using System;
using DVLD.Properties;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Humanizer;


namespace DVLD.Controls
{
    public partial class DriverLicenseInfo : UserControl
    {
        private clsLicense _License;
        private clsPerson _Person;
        private clsLocalDrivingLicenseApplication _LDLApplication;

        private int _ApplicationID = -1;
        private int _ApplicantPersonID = -1;
        public int LDLAppID;
        public string FullName, ClassName;
        public DriverLicenseInfo()
        {
            InitializeComponent();
        }

        void CheckPersonImage()
        {
            if (_Person.ImagePath != "")
            {
                if (File.Exists(_Person.ImagePath))
                {
                    pbPersonImage.Load(_Person.ImagePath);
                }
                else
                {
                    MessageBox.Show($"Sorry Could not find this image {_Person.ImagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                if (_Person.Gender == 0)
                {
                    pbPersonImage.Image = Resources.employee_17986056;
                }
                else
                {
                    pbPersonImage.Image = Resources.people_15676106;

                }
            }
        }
        void FillLicenseInfoCard()
        {
            //For Person Info

            lblName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;

            if (_Person.Gender == 0)
            {
                lblGendor.Text = "Male";
            }
            else
            {
                lblGendor.Text = "Woman";
            }
            lblDateOfBirth.Text = (_Person.DateOfBirth).ToString();
            CheckPersonImage();
            // For License Info

            lblClass.Text = clsLicenseClasse.GetClassNameByLicenseClassID( _License.LicenseClassID );
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblIssueDate.Text = _License.IssueDate.ToString();

            lblIssueRaison.Text = Convert.ToInt32(_License.IssueReason).ToOrdinalWords() + "Time";
            lblNotes.Text = _License.Notes;

            if (_License.IsActive == 1)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString();

            // For DetainedLicense

            if (clsDetainedLicense.IsDetainedLicense(_License.LicenseID ))
            {
                lblIsDetained.Text = "Yes";
            }
            else
            {
                lblIsDetained.Text = "No";
            }
        }

        private void gpApplicationBasicInfo_Enter(object sender, EventArgs e)
        {

        }
        public void LoadLicenseInfoByLDLApp(int LDLApp)
        {
            int AppIDByLDLApp = clsLocalDrivingLicenseApplication.GetAppIDByDLAppID(LDLApp);

            _Person = clsPerson.Find(clsApplication.GetPersonIDByAppID(AppIDByLDLApp));
            _License = clsLicense.Find( clsLicense.GetLicenseIDByApplicationID(AppIDByLDLApp));

            if (_License != null && _Person != null)
            {
                FillLicenseInfoCard();
            }

            else
            {
                MessageBox.Show("License Info not found", "Info");
            }
        }

        public void LoadLicenseInfoByAppID(int AppID)
        {

            _Person = clsPerson.Find(clsApplication.GetPersonIDByAppID(AppID));
            _License = clsLicense.Find(clsLicense.GetLicenseIDByApplicationID(AppID));

            if (_License != null && _Person != null)
            {
                FillLicenseInfoCard();
            }

            else
            {
                MessageBox.Show("License Info not found", "Info");
            }
        }
    }
}

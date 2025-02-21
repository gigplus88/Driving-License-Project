using DVLD_Business;
using System;
using DVLD.Properties;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DVLD.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private clsLicense _License;
        private clsPerson _Person;
        private clsInternationalLicense _InternationalLicense;
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
        void FillInternationalLicenseInfoCard()
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

            // For International License Info
            lblIntLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString();

            if (_InternationalLicense.IsActive == 1)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }

            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString();


            // For License Info
            lblLicenseID.Text = _License.LicenseID.ToString();

           


        }
        public void LoadLicenseInfoByLicenseID(int LicenseID)
        {
            
            _Person = clsPerson.Find(clsLicense.GetPersonIDByLicenseID( LicenseID));
            _InternationalLicense = clsInternationalLicense.Find(clsInternationalLicense.GetIntLicenseIDIDByLicenseID(LicenseID));
            _License = clsLicense.Find(LicenseID);

            if (_License != null && _Person != null)
            {
                FillInternationalLicenseInfoCard();
            }

            else
            {
                MessageBox.Show("License Info not found", "Info");
            }
        }

    }
}

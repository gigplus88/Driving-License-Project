using DVLD.Properties;
using DVLD_Business;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;
        private int _PersonID = -1;
        private string _NationalNo;

        public int PersonID
        {
            get { return _PersonID; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person != null)
            {
                FillPersonCard();
            }

            else
            {
                MessageBox.Show("Person not found");
            }
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person != null)
            {
                FillPersonCard();
            }

            else
            {
                MessageBox.Show("Person not found");
            }
        }

        public void FillPersonCard()
        {
            _PersonID = _Person.PersonID;
            _NationalNo = _Person.NationalNo;
            lblPersonID.Text = _PersonID.ToString();
            lblName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            if (_Person.Gender == 0)
            {
                lblGendor.Text = "Male";
                pbGendorImage.Image = Resources.employee_17986056;

            }
            else
            {
                lblGendor.Text = "Female";
                pbGendorImage.Image = Resources.people_15676106;


            }

            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblPhone.Text = _Person.Phone;

            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo(_PersonID);
            frm.UpdatePerson(_PersonID);
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }
    }
}

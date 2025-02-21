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
using static Humanizer.On;

namespace DVLD.License
{
    public partial class FrmLicenseHistory : Form
    {
        private int _AppID = -1;

        public FrmLicenseHistory(int AppID)
        {
            InitializeComponent();
            this._AppID = AppID;
        }

        public void LoadDriverLicenseInfo() 
        {
            int PersonID = clsApplication.GetPersonIDByAppID(_AppID);

            ctrlPersonCardWithFilter1.LoadAllPersonInfo(PersonID);
            dgvLicenseInfo.DataSource = clsLicense.GetLocalDriverLicensesInfo(PersonID);
            lblNumberOfLicenses.Text = clsLicense.CountDriverLicenses(PersonID).ToString();
        }
        public void LoadInternationalLicenseInfo()
        {
            int LicenseID = clsLicense.GetLicenseIDByApplicationID(_AppID);
            
            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetIntDrivingLicenseByLicenseID(LicenseID);
            lblNumberOfInternationalLicenses.Text = clsInternationalLicense.CountDriverLicenseByLicenseID(LicenseID).ToString();
        }
        private void FrmLicenseHistory_Load(object sender, EventArgs e)
        {
            LoadDriverLicenseInfo();
            LoadInternationalLicenseInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ControlBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvLicenseInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblNumberOfLicenses_Click(object sender, EventArgs e)
        {

        }
    }
}

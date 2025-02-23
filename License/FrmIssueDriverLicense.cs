using DVLD.Test_Type;
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

namespace DVLD.License
{
    public partial class FrmIssueDriverLicense : Form
    {
        private int _AppID;
        private int _LDLAppID;
        private clsDriver _Driver;
        public FrmIssueDriverLicense(int LDLAppID , int AppID)
        {
            InitializeComponent();
            this._AppID = AppID;
            this._LDLAppID = LDLAppID;
        }

        private void FillPersonDataForIssue()
        {
            ctrlDrivingLicenseApplication1.LoadDrivingLicenseAppInfo(_AppID);
        }
        private void FrmIssueDriverLicense_Load(object sender, EventArgs e)
        {
            FillPersonDataForIssue();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void TakeDriverLicense()
        {
            _Driver = new clsDriver();
            //_Driver.DriverID = _AppID;
            _Driver.PersonID = clsApplication.GetPersonIDByAppID(_AppID);
            _Driver.CreatedByUserID = clsUser.GetUserIDByUserName( GlobalSettings.CurrentUserInfo.UserName);
            _Driver.CreatedDate = DateTime.Now;
            if (_Driver.Save())
            {
                if (MessageBox.Show($"License issued successfully with License ID = {_Driver.DriverID}", "Succeded", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }

            }
        }
        void MakeLicenseInfo()
        {
            clsLicense License = new clsLicense();
            clsLicense.Mode = clsLicense.enMode.AddNew;

            License.ApplicationID = _AppID;
            License.DriverID = _Driver.DriverID;
            License.LicenseClassID = clsLocalDrivingLicenseApplication.GetLicenseClassIDByDLAppID(_LDLAppID);
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = License.IssueDate.AddYears(clsLicenseClasse.GetValidityLengthByLicenseClassID(License.LicenseClassID));

            if (txtNotes.Text == "")
            {
                License.Notes = DBNull.Value.ToString();
            }
            else
            {
                License.Notes = txtNotes.Text;
            }
            License.PaidFees = clsLicenseClasse.GetPaidFeesByLicenseClassID(License.LicenseClassID);

            License.IsActive = Convert.ToByte(!clsDetainedLicense.IsDetainedLicense(License.LicenseClassID));

            License.IssueReason =Convert.ToByte(clsApplication.GetAppTypeIDByAppID(_AppID));

            License.CreatedByID = clsUser.GetUserIDByUserName(GlobalSettings.CurrentUserInfo.UserName);

            License.Save();
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            TakeDriverLicense();
            MakeLicenseInfo();
        }
    }
}

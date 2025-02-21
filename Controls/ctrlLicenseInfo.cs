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
using static DVLD.FrmMain;
using DVLD.Applications;

namespace DVLD.Controls
{
    public partial class ctrlLicenseInfo : UserControl
    {
        private FrmNewInternationalLicenseApplication _frmNewInternationalLicenseApplication;

        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }
       
        public void SetParentForm(FrmNewInternationalLicenseApplication frm)
        {
            _frmNewInternationalLicenseApplication = frm;
        }
        public int LicenseID;
       
        private void btnFilterByLicenseID_Click(object sender, EventArgs e)
        {
            string Input = txtLicenseID.Text;

            if (Input == "")
            {
                MessageBox.Show("Your textbox is empty , Enter your LicenseID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                LicenseID =Convert.ToInt32(Input);
                int AppIDByLicenseID = clsLicense.GetApplicationIDByLicenseID(LicenseID);
                lblLocalLicenseID.Text = LicenseID.ToString();
                if (!clsInternationalLicense.IfHasActiveInternationalLicense(LicenseID))
                {
                    driverLicenseInfo1.LoadLicenseInfoByAppID(AppIDByLicenseID);
                }

                else
                {
                    driverLicenseInfo1.LoadLicenseInfoByAppID(AppIDByLicenseID);

                    if (_frmNewInternationalLicenseApplication != null)
                    {
                        _frmNewInternationalLicenseApplication.DisabledIssueButtonAndAbleShowLicenseLink(false, true);
                    }

                    MessageBox.Show($"Person already have an active International License with ID=" +
                        $" {clsInternationalLicense.GetIntLicenseIDIDByLicenseID(LicenseID)} ", "Not allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void FillApplicationInfoCard()
        {
            lblAppliocationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();

            DateTime ExpirationDate = DateTime.Now.AddYears(1);
            lblExpirationDate.Text = ExpirationDate.ToString();   

            lblCreatedBy.Text = GlobalSettings.CurrentUserInfo.UserName;
            lblFees.Text = clsApplicationType.GetApplicationFeesByApplicationTypeID((byte)enApplicationTypeID.NewInternationalLicense).ToString();

        }
        private void ctrLicenseInfo_Load(object sender, EventArgs e)
        {
            FillApplicationInfoCard();
        }
        
        public void DisableGroupBoxFilter()
        {
            gbFilter.Enabled = false;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void driverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}

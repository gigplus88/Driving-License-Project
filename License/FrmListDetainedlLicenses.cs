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
using static Humanizer.On;

namespace DVLD.License
{
    public partial class FrmListDetainedlLicenses : Form
    {
        public FrmListDetainedlLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void RefreshData()
        {
            dgvListDetainedLicenses.DataSource = clsDetainedLicense.GetDetainedLicenseList();
            lblNumberOfDetainedLicenses.Text = clsDetainedLicense.CountDetainedLicenses().ToString();
        }
        private void FrmListDetainedlLicenses_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        void EnableReleaseDetainedLicenseToolStripMenuItem(bool IsEnable)
        {
            if (clsDetainedLicense.IsDetainedLicense(LicenseID))
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = IsEnable;
            }
        }
        int LicenseID , AppID;
        private void dgvListDetainedLicenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnableReleaseDetainedLicenseToolStripMenuItem(false);

            if (e.RowIndex >=0)
            {
                DataGridViewRow selectedRow = dgvListDetainedLicenses.Rows[e.RowIndex];

                LicenseID = Convert.ToInt32( selectedRow.Cells["L.ID"].Value );
            }
            AppID = clsLicense.GetApplicationIDByLicenseID(LicenseID);
            EnableReleaseDetainedLicenseToolStripMenuItem(true);
        }

        private void ShowPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsApplication.GetPersonIDByAppID(AppID);
            FrmPersonDetails frm = new FrmPersonDetails(PersonID);
            frm.ShowDialog();
            frm.GetPersonInfo(PersonID);
        }

        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseHistory frm = new FrmLicenseHistory(AppID);
            frm.ShowDialog();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            FrmDetainLicense frm = new FrmDetainLicense();
            frm.ShowDialog();
            RefreshData();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainedLicense frm = new FrmReleaseDetainedLicense();
            frm.ShowDialog();
            RefreshData();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainedLicense frm = new FrmReleaseDetainedLicense();
            frm.GenerateButtonFilter( LicenseID.ToString());
            frm.ShowDialog();
            RefreshData();
        }
        void SearchByDetainID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvListDetainedLicenses.DataSource = clsDetainedLicense.FindByByDetainID(Convert.ToInt32(Input));
                lblNumberOfDetainedLicenses.Text = clsDetainedLicense.FindByByDetainID(Convert.ToInt32(Input)).Count.ToString();
            }
        }
        void SearchByReleasedLicense(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else 
            {
                dgvListDetainedLicenses.DataSource = clsDetainedLicense.FindByByReleasedLicense(Convert.ToByte(Input));
                lblNumberOfDetainedLicenses.Text = clsDetainedLicense.FindByByReleasedLicense(Convert.ToByte(Input)).Count.ToString();
            }
        }
        void SearchByNationalNo(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvListDetainedLicenses.DataSource = clsDetainedLicense.FindByNationalNo(Input);
                lblNumberOfDetainedLicenses.Text = clsDetainedLicense.FindByNationalNo(Input).Count.ToString();
            }
        }
        void SearchByFullName(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvListDetainedLicenses.DataSource = clsDetainedLicense.FindByFullName(Input);
                lblNumberOfDetainedLicenses.Text = clsDetainedLicense.FindByFullName(Input).Count.ToString();
            }
        }
        void SearchByReleasedAppID(string Input)
        {
            if (string.IsNullOrEmpty(Input))
            {
                RefreshData();
            }
            else
            {
                dgvListDetainedLicenses.DataSource = clsDetainedLicense.FindByReleaseAppID(Convert.ToInt32(Input));
                lblNumberOfDetainedLicenses.Text = clsDetainedLicense.FindByReleaseAppID(Convert.ToInt32(Input)).Count.ToString();
            }
        }
        public void Filtering()
        {
            string Input = txtFilterBy.Text.Trim();
            switch (FilterItem)
            {
                case "Detain ID":
                    SearchByDetainID(Input);
                    break;

                case "Is Released":
                    SearchByReleasedLicense(Input);
                    break;

                case "National No":
                    SearchByNationalNo(Input);
                    break;

                case "Full Name":
                    SearchByFullName(Input);
                    break;
                case "Released Application ID":
                    SearchByReleasedAppID(Input);
                    break;
            }
        }
        string FilterItem = "";
        public void Validation()
        {
            FilterItem = cbFilterBy.SelectedItem.ToString().Trim();
            Filtering();
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "Full Name" || cbFilterBy.SelectedItem.ToString() == "National No")
            {
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "None")
            {
                txtFilterBy.Visible = false;
                return;
            }
            txtFilterBy.Visible = true;
        }

       

        private void ShowLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowLicenseInfo frm = new FrmShowLicenseInfo();
            frm.ShowDialog();
            frm.LoadLicenseInfoByAppID(AppID);
        }
    }
}

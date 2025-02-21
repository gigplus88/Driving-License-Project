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
    public partial class FrmInternationalDriverInfo : Form
    {
        private int _LicenseID;
        public FrmInternationalDriverInfo(int LicenseID)
        {
            InitializeComponent();
            this._LicenseID = LicenseID;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInternationalDriverInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverInternationalLicenseInfo1.LoadLicenseInfoByLicenseID(_LicenseID);
        }
    }
}

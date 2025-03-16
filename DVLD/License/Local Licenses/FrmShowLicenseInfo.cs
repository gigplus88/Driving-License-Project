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
    public partial class FrmShowLicenseInfo : Form
    {
        private int _LicenseID = -1;

      
        public FrmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            this._LicenseID = LicenseID;
        }

        private void FrmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            driverLicenseInfo1.LoadInfo(_LicenseID);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

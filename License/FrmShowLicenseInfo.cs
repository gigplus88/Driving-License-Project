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
        private int _LDLAppID = -1;
        private int _AppID = -1;

        public FrmShowLicenseInfo()
        {
            InitializeComponent();
        }
        public FrmShowLicenseInfo(int LDLAppID)
        {
            InitializeComponent();
            this._LDLAppID = LDLAppID;
        }

        private void FrmShowLicenseInfo_Load(object sender, EventArgs e)
        {
        }
        public void LoadLicenseInfoByLDLApp(int LDLAppID)
        {
            driverLicenseInfo1.LoadLicenseInfoByLDLApp(LDLAppID);
        }
        public void LoadLicenseInfoByAppID(int AppID)
        {
            driverLicenseInfo1.LoadLicenseInfoByAppID(AppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

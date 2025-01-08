using DVLD.Applications;
using DVLD.Users;
using System;
using System.Windows.Forms;

namespace DVLD
{
    internal static class Program
    {
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmNewLocalDrivingLicenseApplication());
            Application.Run(new FrmMain());
            //Application.Run(new FrmLogin());
        }
    }

}

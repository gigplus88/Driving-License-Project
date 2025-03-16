using DVLD.Applications;
using DVLD.License;
using DVLD.Test_Type;
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
            //Application.Run(new FrmWrittenTestAppointments(98,59));
           // Application.Run(new FrmLicenseHistory(110));
           Application.Run(new FrmLogin());
        }
    }

}

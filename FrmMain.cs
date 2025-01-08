using DVLD.Applications;
using DVLD.Users;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmMain : Form
    {
        private string UserName;
        public FrmMain()
        {
            InitializeComponent();
        }
        public FrmMain(string UserName)
        {
            InitializeComponent();
            this.UserName = UserName;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmManagePeople frm = new FrmManagePeople();
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void accountSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        static List<string> LoadDataFromFile(string filePath)
        {
            var Users = new List<string>();

            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var parts = line.Split(',');
                    Users.Add(parts[0]);
                    Users.Add(parts[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return Users;
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin frm = new FrmLogin();
        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmManageUsers frm = new FrmManageUsers();
            frm.ShowDialog();
        }

        string CurrentUserName = "";
        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUserName = GlobalSettings.CurrentUserInfo.UserName;
            clsUser _User = clsUser.Find(CurrentUserName);

            if (_User != null)
            {
                FrmUserInfo frmUserInfo = new FrmUserInfo(CurrentUserName);
                frmUserInfo.LoadUserCard(CurrentUserName);
                frmUserInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sorry User not found", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chqngePqsszordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUserName = GlobalSettings.CurrentUserInfo.UserName;

            FrmChangePassword frm = new FrmChangePassword(CurrentUserName);
            frm.LoadUserInfo(CurrentUserName);
            frm.ShowDialog();
        }

        private void applicationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tsmManageApplicationTypes_Click(object sender, EventArgs e)
        {
            FrmManageApplicationTypes frm = new FrmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void tsmManageTestTypes_Click(object sender, EventArgs e)
        {
            FrmListTestType frm = new FrmListTestType();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplicationType localLicense = clsApplicationType.Find(1);
            FrmNewLocalDrivingLicenseApplication frm = new FrmNewLocalDrivingLicenseApplication(localLicense.ApplicationID);
            frm.ShowDialog();
        }
    }
}

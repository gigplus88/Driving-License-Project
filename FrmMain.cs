﻿using DVLD.Applications;
using DVLD.License;
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
        public enum enApplicationTypeID
        {
            NewLocalDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplacementforALostDL = 3,
            ReplacementforADamagedDL = 4,
            ReleaseDetainedDL = 5,
            NewInternationalLicense = 6,
            ReatkeTest = 8
        }

        public static enApplicationTypeID ApplicationTypeID;
        public enum enTestType
        {
            Vision = 1,
            Written = 2,
            Practical = 3
        };
        public static enTestType TestType;
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
            //clsApplicationType localLicense = clsApplicationType.Find(1);
            FrmNewLocalDrivingLicenseApplication frm = new FrmNewLocalDrivingLicenseApplication((byte)enApplicationTypeID.NewLocalDrivingLicense);
            frm.ShowDialog();
        }

        private void localDrivingApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLocalDrivingLicenseApplications frm = new FrmLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmListDrivers listDrivers = new FrmListDrivers();
            listDrivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewInternationalLicenseApplication frm = new FrmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInternationalDrivingLicenseApplications frm = new FrmInternationalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRenewLocalDrivingLicense frm = new FrmRenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void deplacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReplacementForDamagedLicense frm = new FrmReplacementForDamagedLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetainLicense frm = new FrmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainedLicense frm = new FrmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListDetainedlLicenses frm = new FrmListDetainedlLicenses();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLocalDrivingLicenseApplications frm = new FrmLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReleaseDetainedLicense frm = new FrmReleaseDetainedLicense();
            frm.ShowDialog();
        }
    }
}

﻿using DVLD_Business;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmLogin : Form
    {
        clsUser _User;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            string UserName = txtUserName.Text;

            if (string.IsNullOrEmpty(UserName))
            {
                e.Cancel = false;
                epLogin.SetError(txtUserName, "Required");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            string Password = txtPassword.Text;


            if (string.IsNullOrEmpty(Password))
            {
                e.Cancel = false;
                epLogin.SetError(txtUserName, "Required");
            }
            if (!int.TryParse(Password, out int Result))
            {
                e.Cancel = false;
                epLogin.SetError(txtUserName, "Please Enter a numbers");
            }
        }

        static string UserName = "", Password = "";

        private void btnLogin_Click(object sender, EventArgs e)
        {

            UserName = txtUserName.Text;
            Password = txtPassword.Text;

            _User = clsUser.FindByUsernameAndPassword(UserName.Trim(), Password.Trim());

            if (_User != null)
            {
                if (!_User.IsActive)
                {
                    MessageBox.Show(" UserName is not Active", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();
                    return;
                }
                else
                {
                    if (cbRememberMe.Checked)
                    {
                        //store username and password
                        clsGlobalSettings.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                    }
                    else
                    {
                        //store empty username and password
                        clsGlobalSettings.RememberUsernameAndPassword("", "");

                    }

                    clsGlobalSettings.CurrentUser = _User;

                    this.Hide(); // I hide this form
                    FrmMain frm =  new FrmMain(this);
                    frm.ShowDialog();
                }
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid UserName or Password", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void GenerateStoredData()
        {
            string UserName = "", Password = "";
            if (clsGlobalSettings.GetStoredCredential(ref UserName , ref  Password ))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;    
                cbRememberMe.Checked = true;
            }
            else
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                cbRememberMe.Checked =false;
            }
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            GenerateStoredData();
        }

        public bool IsCbRememberMeChecked()
        {
            return cbRememberMe.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CleanUserNameAndPasswordTextboxes()
        {
            if (!IsCbRememberMeChecked())
            {
                txtUserName.Clear();
                txtPassword.Clear();
            }
        }
    }
}

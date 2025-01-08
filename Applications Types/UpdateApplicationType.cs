using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmUpdateApplicationType : Form
    {
        private clsApplicationType _Application;
        private int _ApplicationTypeID = 0;
        enum enMFindMode { BeforeFill, AfterFill };
        enMFindMode FindMode = enMFindMode.BeforeFill;
        public FrmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            this._ApplicationTypeID = ApplicationTypeID;
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void FilApplicationInfoAfterEdit(int ApplicationTypeID)
        {
            //_Application = clsApplications.Find(ApplicationTypeID);
            _Application.Title =  txtTitle.Text;
            _Application.Fees = Convert.ToInt32(txtFees.Text);

            clsApplicationType.Mode = clsApplicationType.enMode.Update;

            if (_Application.Save())
            {
                MessageBox.Show($"Application {_Application.ApplicationID} Updated Successfully", "Update Application Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ApplicationTypeID = _Application.ApplicationID;
            }
            else
            {
                MessageBox.Show($"Error  to Update {_Application.ApplicationID}  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void _FillBoxes(int ApplicationTypeID)
        {
            if (FindMode == enMFindMode.BeforeFill)
            {
                _Application = clsApplicationType.Find(ApplicationTypeID);
                if (_Application == null)
                {
                    return;
                }
                lblApplicationTypeID.Text = _Application.ApplicationID.ToString();
                txtTitle.Text = _Application.Title;
                txtFees.Text =_Application.Fees.ToString();

                FindMode = enMFindMode.AfterFill;
            }
            else
            {
                FilApplicationInfoAfterEdit(ApplicationTypeID);
            }


        }
        public void UpdateApplicationTypeInfo(int ApplicationTypeID)
        {
            _FillBoxes(ApplicationTypeID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateApplicationTypeInfo(_ApplicationTypeID);
        }

        private void FrmUpdateApplicationType_Load(object sender, EventArgs e)
        {

        }
    }
}

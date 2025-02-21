using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Test
{
    public partial class FrmUpateTestType : Form
    {
        private int _TestTypeID = 0;
        private clsTestType _TestType;
        enum enMFindMode { BeforeFill, AfterFill };
        enMFindMode FindMode = enMFindMode.BeforeFill;
        public FrmUpateTestType(int TestTypeID)
        {
            InitializeComponent();
            this._TestTypeID = TestTypeID;
        }

        private void FrmUpateTestType_Load(object sender, EventArgs e)
        {

        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void FilTestTypeInfoAfterEdit(int TestTypeID)
        {
            _TestType.TestTypeTitle =  txtTitle.Text;
            _TestType.TestTypeDescription =  txtDescription.Text;
            _TestType.TestTypeFees = Convert.ToInt32(txtFees.Text);

            clsApplicationType.Mode = clsApplicationType.enMode.Update;

            if (_TestType.Save())
            {
                MessageBox.Show($"Test Type {_TestType.TestTypeID} Updated Successfully", "Update Test Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _TestTypeID = _TestType.TestTypeID;
            }
            else
            {
                MessageBox.Show($"Error  to Update  {_TestType.TestTypeID}  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void _FillBoxes(int TestTypeID)
        {
            if (FindMode == enMFindMode.BeforeFill)
            {
                _TestType = clsTestType.Find(TestTypeID);
                if (_TestType == null)
                {
                    return;
                }
                lblTestypeID.Text = _TestType.TestTypeID.ToString();
                txtTitle.Text = _TestType.TestTypeTitle;
                txtDescription.Text = _TestType.TestTypeDescription;
                txtFees.Text =_TestType.TestTypeFees.ToString();

                FindMode = enMFindMode.AfterFill;
            }
            else
            {
                FilTestTypeInfoAfterEdit(TestTypeID);
            }


        }
        public void UpdateTestTypeInfo(int TestTypeID)
        {
            _FillBoxes(TestTypeID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateTestTypeInfo(_TestTypeID);
        }
    }
}

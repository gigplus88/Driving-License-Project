using DVLD.Test;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmListTestType : Form
    {
        public FrmListTestType()
        {
            InitializeComponent();
        }
        public void RefreshData()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            lblNumberOfTestTypes.Text = clsTestType.CountAllTestTypes().ToString();

        }
        private void FrmListTestType_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestType.Mode = clsTestType.enMode.Update;
            FrmUpateTestType frm = new FrmUpateTestType(TestTypeID);
            frm.UpdateTestTypeInfo(TestTypeID);
            frm.ShowDialog();
            RefreshData();
        }
        int TestTypeID;

        private void dgvTestTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >0)
            {
                DataGridViewRow selectedRow = dgvTestTypes.Rows[e.RowIndex];

                TestTypeID =Convert.ToInt32(selectedRow.Cells["ID"].Value);
            }
        }
    }
}

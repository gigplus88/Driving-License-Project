using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class FrmManageApplicationTypes : Form
    {
        public FrmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void FrmManageApplicationType_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            dgvApplications.DataSource = clsApplicationType.GetAllApplications();
            lblNumberOfApplications.Text = clsApplicationType.CountAllApplications().ToString();

        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplicationType.Mode = clsApplicationType.enMode.Update;
            FrmUpdateApplicationType frm = new FrmUpdateApplicationType(ApplicationTypeID);
            frm.UpdateApplicationTypeInfo(ApplicationTypeID);
            frm.ShowDialog();
            RefreshData();
        }

        int ApplicationTypeID;
        private void dgvApplications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >0)
            {
                DataGridViewRow selectedRow = dgvApplications.Rows[e.RowIndex];

                ApplicationTypeID =Convert.ToInt32(selectedRow.Cells["ID"].Value);
            }
        }
    }
}

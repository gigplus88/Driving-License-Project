using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class TestUserControl : UserControl
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        private int _PersonID = 0;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public TestUserControl()
        {
            InitializeComponent();
        }

        private void TestUserControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FirstName = txtFirstName.Text, LastName = txtLastName.Text;
            _PersonID = 2;
            //FrmTestTypes frm = new FrmTestTypes(_PersonID);
            //frm.CheckedAddedPerson( PersonID);

            DataBack?.Invoke(this, _PersonID);

        }

    }
}

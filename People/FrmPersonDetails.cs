using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmPersonDetails : Form
    {
        private int _PersonID;
        private string NationalNo;
        public FrmPersonDetails()
        {
            InitializeComponent();
        }
        public FrmPersonDetails(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
        }
        public FrmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            this.NationalNo = NationalNo;
        }

        private void FrmPersonDetails_Load(object sender, EventArgs e)
        {

        }

        public void GetPersonInfo(int PersonID)
        {
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }
        public void GetPersonInfo(string NationalNo)
        {
            ctrlPersonCard1.LoadPersonInfo(NationalNo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

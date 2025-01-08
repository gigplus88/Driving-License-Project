using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmAddEditPersonInfo : Form
    {
        static private int _PersonID;
        static private string _NationalNo;

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        public FrmAddEditPersonInfo()
        {
            InitializeComponent();

        }
        public FrmAddEditPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        public FrmAddEditPersonInfo(string NationalNo)
        {
            InitializeComponent();
            _NationalNo = NationalNo;
        }

        private void AddEditPersonInfo_Load(object sender, EventArgs e)
        {

        }


        private void ctrlAddEditPerson1_Load(object sender, EventArgs e)
        {
        }

        private void ctrlAddEditPerson1_DataBack(object sender, int PersonID)
        {
            lblPersonID.Text = _PersonID.ToString();
            DataBack?.Invoke(this, _PersonID);
        }
        public void UpdatePerson(int PersonID)
        {
            lblTitle.Text =  "Update Person";
            lblPersonID.Text = PersonID.ToString();
            ctrlAddEditPerson1.UpdatePersonFromContext(PersonID);
        }
        public void DeletePerson(int PersonID)
        {
            clsPerson.DeletePerson(PersonID);
        }
        private void ctrlAddEditPerson1_Load_1(object sender, EventArgs e)
        {

        }



    }
}

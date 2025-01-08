using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        private clsPerson _Person;
        public int _PersonID ;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public string _NationalNo;
        public string NationalNo
        {
            get { return _NationalNo; }
        }

        public enum enSearchingMode { PersonID = 0, NationalNo = 1 };

        public enSearchingMode SearchingMode;
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void PersonCardWithFilter_Load(object sender, EventArgs e)
        {

        }
        public void PersonSearch()
        {
            string input = txtPersonInfo.Text.Trim();
            if (cbFindBy.SelectedItem ==  null)
            {
                MessageBox.Show("Please Choose Your Filter Item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbFindBy.SelectedItem.ToString() ==  "PersonID" && int.TryParse(input, out int Result))
            {
                if (clsPerson.IsPersonExist(Result))
                {
                    _Person = clsPerson.Find(Result);
                    _PersonID = _Person.PersonID;
                    SearchingMode = enSearchingMode.PersonID;

                }
                else
                {
                    MessageBox.Show($"This Person with PersonID {Result} not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cbFindBy.SelectedItem.ToString() ==  "National No" && !int.TryParse(input, out int Result1))
            {
                if (clsPerson.IsPersonExist(input))
                {
                    _Person = clsPerson.Find(input);
                    _NationalNo = _Person.NationalNo;
                    SearchingMode = enSearchingMode.NationalNo;
                }
                else
                {
                    MessageBox.Show($"This Person with National No {input} not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void PersonSearchToEdit(int PersonID)
        {
            cbFindBy.Enabled = false;
            txtPersonInfo.Enabled = false;
            btnSearch.Enabled = false;
            btnAddPerson.Enabled = false;

            cbFindBy.Text = "PersonID";
            txtPersonInfo.Text = PersonID.ToString();
            if (clsPerson.IsPersonExist(PersonID))
            {
                _Person = clsPerson.Find(PersonID);
                _PersonID = _Person.PersonID;
                ctrlPersonCard1.LoadPersonInfo(_PersonID);

            }

        }




        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            PersonSearch();
            if (SearchingMode == enSearchingMode.PersonID)
            {
                ctrlPersonCard1.LoadPersonInfo(_PersonID);
            }
            else if (SearchingMode == enSearchingMode.NationalNo)
            {
                ctrlPersonCard1.LoadPersonInfo(_NationalNo);

            }

            //else
            //{
            //    PersonSearchToEdit(_PersonID);
            //    ctrlPersonCard1.LoadPersonInfo(_PersonID);
            //}
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPersonInfo frmAddEditPersonInfo = new FrmAddEditPersonInfo();

            frmAddEditPersonInfo.DataBack += FrmAddEditPerson_DataBack;

            frmAddEditPersonInfo.ShowDialog();
        }

        private void FrmAddEditPerson_DataBack(object sender, int PersonID)
        {
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}

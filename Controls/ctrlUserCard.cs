using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;
        private int _UserID = -1;
        private string _UseName = "";

        public int UserID
        {
            get { return _UserID; }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.Find(UserID);

            if (_User != null)
            {
                FillUserCard();
            }

            else
            {
                MessageBox.Show("User not found");
            }
        }
        public void LoadUserInfo(string UserName)
        {
            _User = clsUser.Find(UserName);

            if (_User != null)
            {
                FillUserCard();
            }

            else
            {
                MessageBox.Show("User not found");
            }
        }

        public void FillUserCard()
        {
            _UserID = _User.UserID;
            _UseName = _User.UserName;
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            if (_User.IsActive == 1)
            {
                llblIsActive.Text = "Yes";
            }
            else
            {
                llblIsActive.Text = "No";
            }
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}

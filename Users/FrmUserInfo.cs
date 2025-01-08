using System;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class FrmUserInfo : Form
    {
        private int _UserID;
        private string _UserName;
        public FrmUserInfo(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }
        public FrmUserInfo(string UseerName)
        {
            InitializeComponent();
            this._UserName = UseerName;
        }

        private void FrmUserInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadUserCard(int UserID)
        {
            ctrlUserCard1.LoadUserInfo(UserID);
        }
        public void LoadUserCard(string UserName)
        {
            ctrlUserCard1.LoadUserInfo(UserName);
        }
    }
}

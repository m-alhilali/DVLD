using DVLD_DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrlUserInformation : UserControl
    {
        private int _UserID=-1;
        private clsUsers _UserInfo;
        public clsUsers UserInfo
        {
            get { return _UserInfo; }

        }

        public int UserID
        { 
            get
            {
                return _UserID;
            }
                 
        }
        public ctrlUserInformation()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            _UserInfo=clsUsers.Find(UserID);
            if (_UserInfo == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            lblIsActive.Text = (_UserInfo.IsActive == true) ? "Yes" : "No";
            lblUserID.Text = _UserInfo.UserID.ToString();
            lblUserName.Text = _UserInfo.UserName;
            ctrlPersonInformation1.LoadPersonInfo(_UserInfo.PersonID);

        }
        private void ctrlUserInformation_Load(object sender, EventArgs e)
        {
           
        }

        private void ResetPersonInfo()
        {
            ctrlPersonInformation1.ResetctrlPersonInfo();
            lblUserID.Text = "??????";
            lblUserName.Text = "??????";
            lblIsActive.Text = "??????";
        }
    }
}

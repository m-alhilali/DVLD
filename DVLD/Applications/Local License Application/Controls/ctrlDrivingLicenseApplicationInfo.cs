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
using DVLD.Licenses;

namespace DVLD.Controls
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        private int _LocalID;
        private clsLocalDrivingLicenseApplication LocalApplication;
        public bool LinkLableShowLicenseInfoIsEnable { set { lnkShowLicense.Enabled = value; } }

        public int LocalApplicationID
        {
            get
            {
                return _LocalID;
            }
           
        }
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void gbPersonInformation_Click(object sender, EventArgs e)
        {

        }
        public void LoadData(int LocalAppID)
        {
           
           LocalApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalAppID);
           if (LocalApplication != null)
           {
               lnkShowLicense.Enabled = true;
                _LocalID = LocalApplication.LocalDrivingLicenseApplicationID;
               lblID.Text = LocalApplication.LocalDrivingLicenseApplicationID.ToString();
               lblPassedTest.Text = "3/"+LocalApplication.GetPassedTestCount().ToString();
               lblApplied.Text = LocalApplication.LicenseClassesInfo.ClassName.ToString();
           }
           else
            {
                ResetData();
            }
          
           
        }
        public void ResetData()
        {
           
          
               lnkShowLicense.Enabled = false;
                _LocalID = -1;
               lblID.Text = "??????";
               lblPassedTest.Text = "3/0";
               lblApplied.Text = "??????";
               lnkShowLicense.Enabled = false;
          
          
           
        }

        private void gbPersonInformation_Click_1(object sender, EventArgs e)
        {

        }

        private void lnkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = LocalApplication.GetActiveLicenseID();
            if (ID == -1)
                return;
            frmDriverLicenseInfo frm = new frmDriverLicenseInfo(ID);
            frm.ShowDialog();
        }
    }
}

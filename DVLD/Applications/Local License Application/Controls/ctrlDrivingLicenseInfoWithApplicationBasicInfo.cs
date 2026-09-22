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
    public partial class ctrlDrivingLicenseInfoWithApplicationBasicInfo : UserControl
    {
        private clsLocalDrivingLicenseApplication _LocalApplication;
        private int LicenseID = -1;
        public int ApplicationID 
        {  
            get
            { return ctrlApplicationBasicInfo1.ApplicationID; }
        }
       
        public int LocalApplicationID
        {  
            get
            { return ctrlDrivingLicenseApplicationInfo2.LocalApplicationID; }
           
        }

        private void _FillData()
        {
            LicenseID = _LocalApplication.GetActiveLicenseID();
            ctrlApplicationBasicInfo1.LoadApplicationData(_LocalApplication.ApplicationID);
            ctrlDrivingLicenseApplicationInfo2.LoadData(_LocalApplication.LocalDrivingLicenseApplicationID);
            ctrlDrivingLicenseApplicationInfo2.LinkLableShowLicenseInfoIsEnable = (LicenseID!=-1);
        }
        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);
            if (_LocalApplication != null)
            {
                _FillData(); 

            }
            else
            {
                ctrlApplicationBasicInfo1.ResetData();
                ctrlDrivingLicenseApplicationInfo2.ResetData();
                MessageBox.Show("_LocalDrivungLicenseApplication Application Dosen't Exists", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingAppID)
        {
            _LocalApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingAppID);
            if (_LocalApplication != null)
            {
                _FillData();
            }
            else
            {
                ctrlApplicationBasicInfo1.ResetData();
                ctrlDrivingLicenseApplicationInfo2.ResetData();
                MessageBox.Show("_LocalDrivungLicenseApplication Application Dosen't Exists", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public ctrlDrivingLicenseInfoWithApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private void ctrlApplicationBasicInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}

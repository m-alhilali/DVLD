using DVLD.Properties;
using DVLD_DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID = -1;
        private clsInternationalLicenses _InternationalLicense;

        public int InternationalLicenseID
        {
            get
            { return _InternationalLicenseID; }

        }
        public ctrInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadImage()
        {
            if (_InternationalLicense.DriverInfo.PersonInfo.Gendor == 0)
            {
                pbPhoto.Image = Resources.manicon;
            }
            else
            {
                pbPhoto.Image = Resources.womanicon;
            }

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "") {
                if (File.Exists(ImagePath))
                {
                    pbPhoto.Load(ImagePath);
                }
                else
                {
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }




        }

        public void ResetInfo()
        {
            lblInternationalID.Text = "??????";
            lblName.Text = "??????";
            lblLicenseID.Text = "??????";
            lblNationalNo.Text = "??????";
            lblGendor.Text = "??????";
            lblDateOfBirth.Text = "??????";
            lblIssueDate.Text = "??????";
            lblExpiratinDate.Text = "??????";
            lblDriverID.Text = "??????";
            lblApplicationID.Text = "??????";
            lblIsActive.Text = "??????";
            pbPhoto.Image = Resources.manicon;
            lblIsDetained.Text = "??????";
        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID=InternationalLicenseID;
            _InternationalLicense = clsInternationalLicenses.Find(InternationalLicenseID);
            if (_InternationalLicense==null)
            {
                ResetInfo();
                return;
            }
           
           

           lblInternationalID.Text = _InternationalLicense.InternationalLicenseID.ToString();
           lblName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
           lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
           lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
           lblGendor.Text = _InternationalLicense.DriverInfo.PersonInfo.Gendor==0?"Male":"Female";
           lblDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToString("d");
           lblIssueDate.Text = _InternationalLicense.IssueDate.ToString("d");
           lblExpiratinDate.Text = _InternationalLicense.ExpirationDate.ToString("d");
           lblDriverID.Text = _InternationalLicense.DriverID.ToString();
           lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
           lblIsActive.Text = _InternationalLicense.IsActive==true?"Yes":"No";

            _LoadImage();
                   
                
            }

        }

    
}

using DVLD.Properties;
using DVLD_DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {

        public Color SetCustomBorderColor
        {
            get { return gbInformation.CustomBorderColor; }
            set
            {
                gbInformation.CustomBorderColor = value;
                gbInformation.BorderColor = value;
            }
        }
        private int _LicenseID;
        private clsLicenses _License;
        public clsLicenses SelectedLicenseInfo
        {
            get
            { return _License; }
        }
        public int LicenseID
        {
            get
            { return _LicenseID; }
        }
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadImage()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbPhoto.Image = Resources.manicon;
            else
                pbPhoto.Image = Resources.womanicon;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPhoto.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void LoadDriverLicenseInfo(int LicenseID)
        {
            _License = clsLicenses.Find(LicenseID);
            if(_License== null)
            {
                ResetInfo();
                MessageBox.Show("Could not find License ID = " + LicenseID.ToString(),
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }



            _LicenseID = LicenseID;
           lblClass.Text = _License.LicenseClassesInfo.ClassName;
           lblName.Text = _License.DriverInfo.PersonInfo.FullName;
           lblLicenseID.Text = _License.LicenseID.ToString();
           lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
           lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor==0?"Male":"Female";
           lblDateOfBirth.Text =_License.DriverInfo.PersonInfo.DateOfBirth.ToString("d");
           lblIssueDate.Text = _License.IssueDate.ToString("d");
           lblExpiratinDate.Text = _License.ExpirationDate.ToString("d");
           lblDriverID.Text = _License.DriverID.ToString();
           lblIssueReason.Text = _License.IssueReasonText;
           lblIsActive.Text = _License.IsActive?"Yes":"No";
           lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
           lblIsDetained.Text = _License.IsDetained ? "Yes" : "NO";
           _LoadImage();
           
          

        }
        public void ResetInfo()
        {
            lblClass.Text = "??????";
            lblName.Text = "??????";
            lblLicenseID.Text = "??????";
            lblNationalNo.Text = "??????";
            lblGendor.Text = "??????";
            lblDateOfBirth.Text = "??????";
            lblIssueDate.Text = "??????";
            lblExpiratinDate.Text = "??????";
            lblDriverID.Text = "??????";
            lblIssueReason.Text = "??????";
            lblIsActive.Text = "??????";
            lblNotes.Text = "??????";
            pbPhoto.Image = Resources.manicon;
            lblIsDetained.Text = "??????";
        }

    }
}
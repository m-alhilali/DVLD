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
using DVLD.People;

namespace DVLD.Controls
{
    public partial class ctrlPersonInformation : UserControl
    {
        private clsPerson _Person;
        public ctrlPersonInformation()
        {
            InitializeComponent();
        }
        private int _PersonID=-1;
        public int PersonID 
        { 
            get
            {
                return _PersonID;
            }
        }
        public clsPerson PersonInfo 
        { 
            get
            {
                return _Person;
            }
        }

        private void lnkAddOrUpdatePerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddorUpdatePerson frm = new frmAddorUpdatePerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(PersonID);
        }

        private void FillDetailInfo()
        {
            lblPersonID.Text=_Person.PersonID.ToString();
            _PersonID = _Person.PersonID;
            lblName.Text=_Person.FullName;
            lblNationalNo.Text=_Person.NationalNo;
            lblGendor.Text=(_Person.Gendor)==0?"Male":"Female";
            lblEmail.Text=_Person.Email;
            lblAddress.Text=_Person.Address;
            lblDateOfBirth.Text=_Person.DateOfBirth.ToString("d");
            lblPhone.Text=_Person.Phone;
            lblCountry.Text= _Person.CountryInfo.CountryName;
            LoadImage();

        }

        private void LoadImage()
        {
            pbPhoto.Image = ((_Person.Gendor) == 0) ? Resources.manicon : Resources.womanicon;
            if (_Person.ImagePath != "")
                if (File.Exists(_Person.ImagePath))
                    pbPhoto.ImageLocation = _Person.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + _Person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void ResetctrlPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "??????";
            lblName.Text = "??????";
            lblNationalNo.Text = "??????";
            lblGendor.Text = "??????";
            lblEmail.Text = "??????";
            lblDateOfBirth.Text = "??????";
            lblCountry.Text = "??????";
            lblAddress.Text = "??????";
            lblPhone.Text = "??????";
            lnkEditPersonInfo.Enabled=false;
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {

                ResetctrlPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                FillDetailInfo();
                lnkEditPersonInfo.Enabled = true;
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {

                ResetctrlPersonInfo();
                MessageBox.Show("No Person with National No = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                FillDetailInfo();
                lnkEditPersonInfo.Enabled = true;
        }
        private void ctrlPersonInformation_Load(object sender, EventArgs e)
        {
        }

        private void pbPhoto_Click(object sender, EventArgs e)
        {

        }

        private void gbPersonInformation_Click(object sender, EventArgs e)
        {

        }
    }
}

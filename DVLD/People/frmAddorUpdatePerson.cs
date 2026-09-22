using DVLD.GlobalClasses;
using DVLD.Properties;
using DVLD_DataBusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD.People
{
    public partial class frmAddorUpdatePerson : Form
    {
        public delegate void DataBackEventHandle(object sender, int PersonID);
        public event DataBackEventHandle DataBackEvent;

        private int _PersonID=-1;
        private clsPerson _Person;

        public enum enMode { AddNew=1,Update=2}
        private enMode Mode=enMode.AddNew;
        public enum enGendor { Male = 0, Female = 1 };

        public frmAddorUpdatePerson()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmAddorUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            Mode = enMode.Update;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void _LoadData()
        {
            _Person=clsPerson.Find(_PersonID);
            if (_Person == null) 
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblPersonID.Text = _PersonID.ToString();
            tbNationalNo.Text=_Person.NationalNo;
            if (_Person.ImagePath != "")
            {
                pbPhoto.ImageLocation = _Person.ImagePath;

            }

            dgvTime.Text = _Person.DateOfBirth.ToString("d") ;
            tbPhone.Text = _Person.Phone;
            tbAddress.Text = _Person.Address;
            tbFirstName.Text = _Person.FirstName;
            tbLastName.Text = _Person.LastName;
            tbEmail.Text = _Person.Email;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);
            if(_Person.Gendor == 0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }
            btnDeleteImage.Visible = (_Person.ImagePath != "");

        }
        private void btnSavePerson_Click(object sender, EventArgs e)
        {
            
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
                return;

            _Person.NationalNo = tbNationalNo.Text;
            
            if (pbPhoto.ImageLocation != null)
                _Person.ImagePath = pbPhoto.ImageLocation;
            else
                _Person.ImagePath = "";
            _Person.DateOfBirth = dgvTime.Value;
            _Person.Phone = tbPhone.Text;
            _Person.Address = tbAddress.Text;
            _Person.FirstName = tbFirstName.Text;
            _Person.LastName = tbLastName.Text;
            _Person.Email = tbEmail.Text;
            _Person.SecondName = tbSecondName.Text;
            _Person.ThirdName = tbThirdName.Text;
            _Person.NationalityCountryID = Convert.ToInt16(cbCountry.SelectedValue);

            if (rbMale.Checked)
                _Person.Gendor = (short)enGendor.Male;
            else
                _Person.Gendor = (short)enGendor.Female;


            if (_Person.Save())
            {
                MessageBox.Show($"People Don Successfuly", $"Add|Update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DataBackEvent?.Invoke(this, _Person.PersonID);
                lblPersonID.Text = _Person.PersonID.ToString();
                btnSave.Enabled = false;
                Mode = enMode.Update;
                lblTitle.Text = "Update Person";

            }
            else
            {
                MessageBox.Show($"Failed Save ", $"Add|Update", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(_Person.PersonID >0)
            {
                DataBackEvent?.Invoke(this, _Person.PersonID);
            }
            this.Close();
        }

        private void ChangeSizeButton(object sender, EventArgs e)
        {
            ChangeSizeControl.ChangeSizeButton(sender);
        }

        private void ResetSizeButton(object sender, EventArgs e)
        {
            ChangeSizeControl.ResetSizeButton(sender);

        }

        private void frmAddorUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (Mode ==enMode.Update)
            {
                _LoadData(); 
            }
           
        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountries.GetCountriesList();
            if(dtCountries!=null)
            {
                cbCountry.DataSource = dtCountries;
                cbCountry.DisplayMember = "CountryName";
                cbCountry.ValueMember = "CountryID";
               
            }
            
        }

        private void _ResetDefualtValues()
        {
            _FillCountriesInComoboBox();

            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            if (rbMale.Checked)
                pbPhoto.Image = Resources.manicon;
            else
                pbPhoto.Image = Resources.womanicon;

            btnDeleteImage.Visible = (pbPhoto.ImageLocation != null);
            dgvTime.MaxDate = DateTime.Now.AddYears(-18);
            dgvTime.Value = dgvTime.MaxDate;
            dgvTime.MinDate = DateTime.Now.AddYears(-100);
            cbCountry.SelectedIndex = cbCountry.FindString("Yemen");

            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbThirdName.Text = "";
            tbLastName.Text = "";
            tbNationalNo.Text = "";
            rbMale.Checked = true;
            tbPhone.Text = "";
            tbEmail.Text = "";
            tbAddress.Text = "";


        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            pbPhoto.ImageLocation = null;
            if(rbFemale.Checked)
            {
                pbPhoto.Image=Resources.womanicon;
            }
            else
            {
                pbPhoto.Image= Resources.manicon;
            }
            btnDeleteImage.Visible = false;
        }

        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbNationalNo, null);
            }

            if (tbNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExists(tbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNo, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(tbNationalNo, null);
            }
        }
        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbPhoto.ImageLocation == null)
                pbPhoto.Image = Resources.womanicon;
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbPhoto.ImageLocation == null)
                pbPhoto.Image = Resources.manicon;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Guna2TextBox Temp = ((Guna2TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }
        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (tbEmail.Text.Trim() == "")
                return;

            if (!clsValidations.ValidateEmail(tbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(tbEmail, null);
            }
            ;

        }
        private bool _HandlePersonImage()
        {
            if(_Person.ImagePath!=pbPhoto.ImageLocation)
            {
                if (_Person.ImagePath != "")
                { 
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException ix)
                    {
                        clsEventLog.RegistryErrorTo_EventViewer(ix.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }

                if (pbPhoto.ImageLocation !=null)
                {
                  string SourceImageFile = pbPhoto.ImageLocation.ToString();
                    if(clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPhoto.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }

            }
            return true;
        }
        private void lnklblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string FileImagePath= ofd.FileName;
                pbPhoto.Load(FileImagePath);
                btnDeleteImage.Visible = true;
            }
        }
    }

}

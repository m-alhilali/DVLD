using DVLD_DataBusinessLayer;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
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
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public Color SetCustomBorderColor
        {
            get { return ctrlDriverLicenseInfo1.SetCustomBorderColor; }
            set
            {
                ctrlDriverLicenseInfo1.SetCustomBorderColor = value;
                gbFilter.BorderColor = value;
                gbFilter.CustomBorderColor = value;
            }
        }

        public event Action<int> OnSelectedLicense;
        protected virtual void OnSelect(int licenseID)
        {
            Action<int> handle = OnSelectedLicense;
            if (handle != null)
            {
                handle(licenseID);
            }
        }


        private bool _FilterEnabled;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled=value;
                gbFilter.Enabled = _FilterEnabled;
            }

        }
       
        private int _LicenseID = -1;

        public int LicenseID { get { return ctrlDriverLicenseInfo1.LicenseID; } }
        public clsLicenses SelectedLicenseInfo
        { get { return ctrlDriverLicenseInfo1.SelectedLicenseInfo; } }


        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            tbSearch.Text= Convert.ToString(LicenseID);
            ctrlDriverLicenseInfo1.LoadDriverLicenseInfo(LicenseID);
            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;
            if (OnSelectedLicense != null && FilterEnabled)
                OnSelectedLicense(_LicenseID);
        }

       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbSearch.Focus();
                return;

            }
            _LicenseID = int.Parse(tbSearch.Text);
            LoadLicenseInfo(_LicenseID);

        }
        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbSearch, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(tbSearch, null);
            }
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

        }


        private void DriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
            FilterEnabled = true;
        }
        public void tbLicenseIDFocus()
        {
            tbSearch.Focus();
        }
    }
}

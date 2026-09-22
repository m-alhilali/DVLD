using DVLD.Controls;
using DVLD.Licenses;
using DVLD_DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmRenewDrivingLicense : Form
    {

        private int _NewLicenseID = 0;

        public frmRenewDrivingLicense()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if ((cp.Style & 0x00800000) == 0)
                {
                    cp.ExStyle |= 0x02000000;
                }
                return cp;
            }
        }

        private void driverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            _NewLicenseID = obj;
            lblOldLicenseID.Text = _NewLicenseID.ToString();
            lnklblLicenseHistory.Enabled = (_NewLicenseID > 0);

            if (_NewLicenseID < 0)
            {
                return;
            }

            lblLicenseFees.Text = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassesInfo.ClassFees.ToString("N2");
            lblTotalFees.Text = ((Convert.ToDecimal(lblLicenseFees.Text)) + (Convert.ToDecimal(lblApplicationFees.Text))).ToString("N2");
            lblExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClasses.Find(ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassesInfo.LicenseClassID).DefaultValidityLength).ToString("d");
            tbNotes.Text = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes.ToString();

            if (!ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + (ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToString("d"))
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            if (!ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            btnRenew.Enabled = true;
        }
        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrldriverLicenseInfoWithFilter1.tbLicenseIDFocus();
            lblApplicationDate.Text = DateTime.Now.ToString("d");
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = "??????";
            lblCreatedBy.Text = GlobleUser.CurrentUser.UserName;
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationTypeFees.ToString("N2");
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            clsLicenses NewLicense = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(tbNotes.Text.Trim(), GlobleUser.CurrentUser.UserID);
            if (NewLicense == null)
            {
                return;
            }
            lblExpirationDate.Text = NewLicense.ExpirationDate.ToString("d");
            lblILApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRenewLicenseID.Text= _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRenew.Enabled=false;
            lnklblShowNewLicenseInfo.Enabled=true;
            ctrldriverLicenseInfoWithFilter1.FilterEnabled = false;

        }
    
        private void lnklblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

           frmDriverLicenseInfo frm = new frmDriverLicenseInfo(_NewLicenseID);
           frm.ShowDialog();
        }

        private void lnklblLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frmhistory = new frmPersonLicenseHistory(ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmhistory.ShowDialog();
        }

        private void frmRenewDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrldriverLicenseInfoWithFilter1.tbLicenseIDFocus();
        }
    }
}

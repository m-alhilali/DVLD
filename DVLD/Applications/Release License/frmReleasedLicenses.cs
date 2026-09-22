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
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmReleasedLicenses : Form
    {
        private int _SelectedLicense;

        public frmReleasedLicenses()
        {
            InitializeComponent();
        }
        public frmReleasedLicenses(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicense = LicenseID;
            if (_SelectedLicense > 0)
            {
                ctrldriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicense);
                ctrldriverLicenseInfoWithFilter1.FilterEnabled = false;
            }
        }
        private void frmReleaseDetainedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrldriverLicenseInfoWithFilter1.tbLicenseIDFocus();
        }

        private void driverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            _SelectedLicense = obj;
            lblLicenseID.Text = _SelectedLicense.ToString();
            lnklblShoeLicenseHistory.Enabled = (_SelectedLicense > 0);
            if (_SelectedLicense < 0)
                return;
            if (!ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationTypeFees.ToString("N2");
            lblCreatedBy.Text = GlobleUser.CurrentUser.UserName;
            lblCreatedBy.Text = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserIDInfo.UserName ;
            lblDetainDate.Text = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToString("d");
            lblLicenseID.Text=ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            lblDetainID.Text=ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblFineFees.Text = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString("N2");
            lblTotalFees.Text= (Convert.ToDecimal(lblApplicationFees.Text)+Convert.ToDecimal(lblFineFees.Text)).ToString("N2");

           btnIssue.Enabled = true;
        }
       
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Release this license", "Release License", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;

            }
            int ApplicationID = -1;
            bool IsReleased = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseLicense(GlobleUser.CurrentUser.UserID, ref ApplicationID);
            lblRApplicationID.Text = ApplicationID.ToString();
            if(!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled=false;
            lnklblShowLicenseInfo.Enabled=true;
            ctrldriverLicenseInfoWithFilter1.FilterEnabled=false;
        }
        private void lnklblShoeLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frmhistory = new frmPersonLicenseHistory(ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmhistory.ShowDialog();
        }

        private void lnklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo frm = new frmDriverLicenseInfo(_SelectedLicense);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReleasedLicenses_Load(object sender, EventArgs e)
        {
            
        }

        private void gbPersonInformation_Click(object sender, EventArgs e)
        {

        }
    }

}

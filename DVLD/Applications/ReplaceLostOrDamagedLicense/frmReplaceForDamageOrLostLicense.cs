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
using static DVLD_DataBusinessLayer.clsLicenses;

namespace DVLD.Applications
{
    public partial class frmReplaceForDamageOrLostLicense : Form
    {
        private int _NewLicenseID;
       
        public frmReplaceForDamageOrLostLicense()
        {
            InitializeComponent();
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void driverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            lblOldLicenseID.Text = _NewLicenseID.ToString();
            int SelectedLicenseID = obj;
            lnklblShoeLicenseHistory.Enabled = (SelectedLicenseID > 0);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            if (!ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }
            btnIssue.Enabled = true;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to replace this license", "Renew License", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            clsLicenses NewLicense = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReplaceLicense(_GetIssueReason(), GlobleUser.CurrentUser.UserID);
            if(NewLicense ==null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense.LicenseID;
            lblRApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblReplaceLicenseID.Text = NewLicense.LicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled = false;
            ctrldriverLicenseInfoWithFilter1.FilterEnabled = false;
            lnklblShowLicenseInfo.Enabled = true;
            gbReplacement.Enabled = false;
            

        }

        private void frmReplaceForDamageOrLostLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("d");
            lblCreatedBy.Text = GlobleUser.CurrentUser.UserName;
            rbtnDamage.Checked = true;
        }

        private void lnklblShoeLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frmhistory = new frmPersonLicenseHistory(ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmhistory.ShowDialog();
        }

        private void lnklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo frm = new frmDriverLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }
        private int _GetApplicationTypeID()
        {
            if(rbtnLost.Checked)
            {
                return (int)clsApplications.enApplicationType.ReplaceLostDrivingLicense;
            }
            else
            {
                return (int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense;
            }
        }
        private enIssueReason _GetIssueReason()
        {
            if(rbtnLost.Checked)
            {
                return enIssueReason.LostReplacement;
            }
            else
            {
                return enIssueReason.DamagedReplacement;
            }
        }
        private void rbtnDamage_CheckedChanged(object sender, EventArgs e)
        {
           
            gbReplacement.Text = "Replacement For Damage License";
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).ApplicationTypeFees.ToString("N2");
            this.Text = gbReplacement.Text;
            lblTitle.Text = gbReplacement.Text;
        }
        private void rbtnLost_CheckedChanged(object sender, EventArgs e)
        {

            gbReplacement.Text = "Replacement For Losted License";
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).ApplicationTypeFees.ToString("N2");
            this.Text = gbReplacement.Text;
            lblTitle.Text = gbReplacement.Text;
        }

        private void frmReplaceLostOrDamagedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrldriverLicenseInfoWithFilter1.tbLicenseIDFocus();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}

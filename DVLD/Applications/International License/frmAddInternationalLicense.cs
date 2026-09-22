using DVLD.Controls;
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

namespace DVLD.Licenses
{
    public partial class frmAddInternationalLicense : Form
    {
        private int _InternationalLicenseID=-1;
        public frmAddInternationalLicense()
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

        private void driverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("d");
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("d");
            lblFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewInternationalLicense).ApplicationTypeFees.ToString("N2");
            lblCreatedBy.Text = GlobleUser.CurrentUser.UserName;
        }

        private void driverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            lblLocalLicenseID.Text=obj.ToString();
            int _LocalLicenseID = obj;
            lnklblShowLicenseHistory.Enabled = (_LocalLicenseID > 0);
            if(_LocalLicenseID<=0)
            {
                btnIssue.Enabled = false;

                return;
            }
            if(ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.ClassLicenseID!=3)
            {
                btnIssue.Enabled = false;
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int ActiveInternaionalLicenseID = clsInternationalLicenses.GetActiveInternationalLicenseIDByDriverID(ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);
            if (ActiveInternaionalLicenseID!=-1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                lnklblShowLicenseInfo.Enabled = true;
                btnIssue.Enabled = false;
                return;
            }

            lnklblShowLicenseInfo.Enabled = false;
            btnIssue.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = (ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void lnklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmDriverInternationalLicenseInfo frm=new frmDriverInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
        
        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalLicenses NewInternationalLicense = new clsInternationalLicenses();

            NewInternationalLicense.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewInternationalLicense).ApplicationTypeFees;
            NewInternationalLicense.LastStatusDate=DateTime.Now;
            NewInternationalLicense.ApplicationDate= DateTime.Now;
            NewInternationalLicense.ApplicationStatus= clsApplications.enApplicationStatus.Completed;
            NewInternationalLicense.ApplicantPersonID = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            NewInternationalLicense.CreatedByUserID = GlobleUser.CurrentUser.UserID;


            NewInternationalLicense.IssuedUsingLocalLicenseID = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            NewInternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            NewInternationalLicense.IssueDate = DateTime.Now;
            NewInternationalLicense.DriverID = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            NewInternationalLicense.IsActive = true;
            if (!NewInternationalLicense.Save())
            {

                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
           
             lblInternationalLLicenseID.Text = NewInternationalLicense.InternationalLicenseID.ToString();
             lblInternationalLicenseApplicationID.Text = NewInternationalLicense.ApplicationID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + NewInternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _InternationalLicenseID = NewInternationalLicense.InternationalLicenseID;
            lnklblShowLicenseInfo.Enabled = true;
            btnIssue.Enabled = false;
            ctrldriverLicenseInfoWithFilter1.FilterEnabled = false;
            
            
        }

        private void frmAddInternationalLicense_Activated(object sender, EventArgs e)
        {
            ctrldriverLicenseInfoWithFilter1.tbLicenseIDFocus();

            {
       }

    }
}
}

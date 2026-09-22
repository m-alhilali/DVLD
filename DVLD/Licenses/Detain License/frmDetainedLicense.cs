using DVLD.Controls;
using DVLD.GlobalClasses;
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
    public partial class frmDetainedLicense : Form
    {
        private int _DetainID;
        private int _SelectedLicenseID;

        public frmDetainedLicense()
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
      
        private void driverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            _SelectedLicenseID = obj;
            lblLicenseID.Text = _SelectedLicenseID.ToString();
            lnklblShoeLicenseHistory.Enabled = (_SelectedLicenseID > 0);

            if(_SelectedLicenseID<0)
            {
                btnIssue.Enabled = false;
                return;
            }

            if (ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            tbFineFees.Focus();
            btnIssue.Enabled = true;

        }
        private void tbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetainedLicense_Load(object sender, EventArgs e)
        {
            lblCreatedBy.Text=GlobleUser.CurrentUser.UserName;
            lblDetainDate.Text = DateTime.Now.ToString("d");
        }
        private void lnklblShoeLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frmhistory = new frmPersonLicenseHistory(ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmhistory.ShowDialog();
        }

        private void lnklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo frm = new frmDriverLicenseInfo(_DetainID);
            frm.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to Detain this license", "Renew License", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }

            _DetainID = ctrldriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToDecimal(tbFineFees.Text), GlobleUser.CurrentUser.UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show($"Detained License Successfully With ID : {_DetainID}", "Detain License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lnklblShowLicenseInfo.Enabled = true;
            ctrldriverLicenseInfoWithFilter1.FilterEnabled = false;
            btnIssue.Enabled=false;
        }
    


        private void frmDetainedLicense_Activated(object sender, EventArgs e)
        {
            ctrldriverLicenseInfoWithFilter1.tbLicenseIDFocus();

        }

        private void tbFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFineFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbFineFees, null);

            }
            ;

        }
    }
}

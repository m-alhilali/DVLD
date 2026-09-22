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
using DVLD.People;

namespace DVLD.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int _ApplicationID;
        public int ApplicationID
        {
            get 
            { 
                return _ApplicationID;
            }
        }

        private clsApplications _applications;
        public clsApplications applications
        {
            get { return _applications; }
        }

        public void LoadApplicationData(int  applicationID)
        {
            _applications = clsApplications.FindBaseApplication(applicationID);
            if (_applications == null)
            {

                ResetData();
                return;
            }
            lnkEditPersonInfo.Enabled = true;
            _ApplicationID = applicationID;
            lblID.Text = _applications.ApplicationID.ToString();
            lblStatus.Text = _applications.StatusText;
            lblType.Text = _applications.ApplicationTypeInfo.ApplicationTypeTitle;
            lblFees.Text = _applications.PaidFees.ToString("N2");
            lblApplicant.Text = _applications.PersonInfo.FullName.ToString();
            lblDate.Text = _applications.ApplicationDate.ToString("d");
            lblStatusDate.Text = _applications.LastStatusDate.ToString("d");
            lblCeateByUser.Text = _applications.UserInfo.UserName;

        }
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private void gbPersonInformation_Click(object sender, EventArgs e)
        {

        }

        private void lnkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails details=new frmPersonDetails(_applications.ApplicantPersonID);
            details.ShowDialog();
            LoadApplicationData(_applications.ApplicationID);
        }
        public void ResetData()
        {


            lblApplicant.Text = "??????";
            lblID.Text = "??????";
            lblDate.Text = "??????";
            lblFees.Text = "??????";
            lblStatus.Text = "??????";
            lblStatusDate.Text = "??????";
            lblType.Text = "??????";
            lblCeateByUser.Text = "??????";
            lnkEditPersonInfo.Enabled = false;



        }

    }
}

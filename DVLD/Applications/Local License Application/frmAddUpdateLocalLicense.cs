using DVLD.Controls;
using DVLD_DataBusinessLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmAddUpdateLocalLicenseApplication : Form
    {
        private int _PersonID;
        private int _LocalApplicationID;
        clsLocalDrivingLicenseApplication _localApplication;

        public enum enMode { Add=1, Update=2}
        private enMode _Mode= enMode.Add;
        public frmAddUpdateLocalLicenseApplication(int LocalApplicationID)
        {
            InitializeComponent();
            _LocalApplicationID = LocalApplicationID;
            _Mode = enMode.Update;


        }
        public frmAddUpdateLocalLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        private void ctrlPersonInformationWithFillter1_OnSelectedPerson(int obj)
        {
            _PersonID = obj;
            btnNext.Enabled = true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedIndex == 1)
            {
                guna2TabControl1.SelectedIndex = 0;
                btnSave.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;

            }
        }
       

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode==enMode.Update)
            {
                btnSave.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
            }

            if (ctrlPersonInformationWithFillter1.PersonID!=-1)
            {
                guna2TabControl1.SelectedIndex = 1;
                btnSave.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = false;
            }
            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonInformationWithFillter1.FilterFocus();
            }

        }

        private void _LoadData()
        {
            ctrlPersonInformationWithFillter1.FilterEnable = false;
            _localApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalApplicationID);

            if (_localApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            ctrlPersonInformationWithFillter1.LoadPersonInfo(_localApplication.ApplicationInfo.ApplicantPersonID);
            lblLocalApplicationID.Text = _localApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDate.Text = _localApplication.ApplicationInfo.ApplicationDate.ToString("d");
            cbClassName.SelectedIndex = cbClassName.FindString(clsLicenseClasses.Find(_localApplication.LicenseClassesInfo.LicenseClassID).ClassName) ;
            lblFees.Text = _localApplication.ApplicationInfo.PaidFees.ToString();
            lblCreatedBy.Text = clsUsers.Find(_localApplication.ApplicationInfo.CreatedByUserID).UserName;


        }
        private void frmAddnewLocalLicense_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dataTable = clsLicenseClasses.GetAllLicenseClasses();
            if (dataTable != null)
            {
                cbClassName.DataSource = dataTable;
                cbClassName.DisplayMember = "ClassName";
                cbClassName.ValueMember = "LicenseClassID";
                cbClassName.SelectedIndex = 2;
            }
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillLicenseClassesInComoboBox();


            if (_Mode == enMode.Add)
            {

                lblTitle.Text = "New Local Driving License Application";
                this.Text = lblTitle.Text;
                _localApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonInformationWithFillter1.FilterFocus();
                lblFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewDrivingLicense).ApplicationTypeFees.ToString("N2");
                lblDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = GlobleUser.CurrentUser.UserName;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = lblTitle.Text;
                btnSave.Enabled = true;


            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenseClassID = Convert.ToInt32(cbClassName.SelectedValue);
            int ActiveApplicationID = clsApplications.GetActiveApplicationIDForLicenseClass(_PersonID,clsApplications.enApplicationType.NewDrivingLicense,LicenseClassID);

            if (ActiveApplicationID != -1) 
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbClassName.Focus();
                return;
            }
            if (clsLicenses.IsLicenseExistByPersonID(ctrlPersonInformationWithFillter1.PersonID, LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Fill Application
            _localApplication.ApplicationInfo.ApplicantPersonID = ctrlPersonInformationWithFillter1.PersonID;
            _localApplication.ApplicationInfo.ApplicationDate = DateTime.Now;
            _localApplication.ApplicationInfo.ApplicationStatus = clsApplications.enApplicationStatus.New;
            _localApplication.ApplicationInfo.ApplicationTypeID = (int)clsApplications.enApplicationType.NewDrivingLicense;
            _localApplication.ApplicationInfo.CreatedByUserID = GlobleUser.CurrentUser.UserID;
            _localApplication.ApplicationInfo.PaidFees = Convert.ToDecimal(lblFees.Text);
            _localApplication.ApplicationInfo.LastStatusDate = DateTime.Now;

            //Fill Local Application 
            _localApplication.ClassLicenseID = LicenseClassID;
            // _localApplication.ApplicationID   -----In function(Save())it will be referenced
            if (_localApplication.Save())
            {
                lblLocalApplicationID.Text = _localApplication.ApplicationID.ToString();
                btnPrevious.Enabled = false;
                _Mode = enMode.Update;
                lblTitle.Text = "Update _LocalDrivungLicenseApplication License Applications";
                this.Text = "Update Application";
                MessageBox.Show($"Data Saved Successfully.", $"Save" ,MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show($"Erorr: Failed save.", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            
            
           
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 0;
            btnSave.Enabled = false;
            btnNext.Enabled = true;

        }

        private void cbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

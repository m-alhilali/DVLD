using DVLD.Properties;
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

namespace DVLD.Controls 
{
    public partial class ctrlSchduleTest : UserControl
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointments _TestAppointments;
        private int _TestAppointmentID = -1;
        private enum enMode { Add=0,Update=1}
        private enMode Mode = enMode.Add;
        private enum enCreationMode { FirstTimeShedule=0, RetakeTestShedule = 1}
        private enCreationMode CreationMode = enCreationMode.FirstTimeShedule;

        private clsTestTypes.enTestType _TestTypeID=clsTestTypes.enTestType.VisionTest;
        public clsTestTypes.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set { 
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        gbTestType.Text = "Vision Test";
                        pbTestPhoto.Image = Resources.testvisionicon;
                        break;
                    case clsTestTypes.enTestType.WrittenTest:
                        gbTestType.Text = "Written Test";
                        pbTestPhoto.Image = Resources.testwrittenicon;
                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        gbTestType.Text = "Street Test";
                        pbTestPhoto.Image = Resources.teststreeticon;
                        break;
                }
            }
        }
        public ctrlSchduleTest()
        {
            InitializeComponent();
        }
        private bool _HandleRetakeApplication()
        {
            if (CreationMode == enCreationMode.RetakeTestShedule && Mode==enMode.Add)
            {
                clsApplications _NewApplicationForRetakeTest;
                _NewApplicationForRetakeTest = new clsApplications();
                _NewApplicationForRetakeTest.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicationInfo.ApplicantPersonID;
                _NewApplicationForRetakeTest.ApplicationDate = DateTime.Now;
                _NewApplicationForRetakeTest.ApplicationTypeID = (int)clsApplications.enApplicationType.RetakeTest;
                _NewApplicationForRetakeTest.ApplicationStatus = clsApplications.enApplicationStatus.New;
                _NewApplicationForRetakeTest.LastStatusDate = DateTime.Now;
                _NewApplicationForRetakeTest.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).ApplicationTypeFees;
                _NewApplicationForRetakeTest.CreatedByUserID = GlobleUser.CurrentUser.UserID;
                if (!_NewApplicationForRetakeTest.Save())
                {
                    _TestAppointments.RetakeTestApplicationID = -1;
                    MessageBox.Show("Failed to create Application", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }
                _TestAppointments.RetakeTestApplicationID = _NewApplicationForRetakeTest.ApplicationID;

            }
            return true;

        }
        private bool _LoadTestAppointmentData()
        {
            _TestAppointments = clsTestAppointments.Find(_TestAppointmentID);
            if (_TestAppointments == null)
            {
                MessageBox.Show("Erorr: No Test Appointment With ID = "+_TestAppointmentID,"Erorr",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnSaveApointment.Enabled=false;
                return false;
            }
            lblFees.Text = clsTestTypes.Find((int)_TestAppointments.TestTypeID).TestTypeFees.ToString("N2");
            if (DateTime.Compare(DateTime.Now, _TestAppointments.AppointmentDate) < 0)
                dtpTime.MinDate = DateTime.Now;
            else
                dtpTime.MinDate = _TestAppointments.AppointmentDate;

            dtpTime.Value = DateTime.Now;

            if(_TestAppointments.RetakeTestApplicationID<=0)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakAppTestID.Text = "N/A";
            }
            else
            {
                lblRetakeAppFees.Text = _TestAppointments.RetakeTestAppInfo.PaidFees.ToString("N2");
                lblRetakAppTestID.Text = _TestAppointments.RetakeTestApplicationID.ToString();
                lblTitle.Text = "Shedule Retake Test";
                gbRetakeTestInfo.Enabled = true;
            }
            return true;
        }
        private bool _HandlePreviousTestAppointmentConstraint()
        {
            switch (_TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    lblSubTitle.Visible = false;
                    return true;

                case clsTestTypes.enTestType.WrittenTest:
                    if (_LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest))
                    {
                        lblSubTitle.Visible = false;
                        btnSaveApointment.Enabled = false;
                        dtpTime.Enabled = true;
                        return true;
                    }
                    else
                    {
                        lblSubTitle.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblSubTitle.Visible = true;
                        btnSaveApointment.Enabled = false;
                        dtpTime.Enabled = false;
                    }
                    return false;

                case clsTestTypes.enTestType.StreetTest:
                    if (_LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest))
                    {
                        lblSubTitle.Visible = false;
                        btnSaveApointment.Enabled = false;
                        dtpTime.Enabled = true;
                        return true;
                    }
                    else
                    {
                        lblSubTitle.Visible = true;
                        lblSubTitle.Text = "Cannot Sechule, Written Test should be passed first.";
                        btnSaveApointment.Enabled = false;
                        dtpTime.Enabled = false;
                    }
                    return false;

            }
            return true;
        }
        private bool _HandleTestAppointmentLockedConstraint()
        {
            if (_TestAppointments.IsLocked) 
            {
                lblSubTitle.Visible = true;
                lblSubTitle.Text = "Person already sat for the test, appointment locked.";
                btnSaveApointment.Enabled = false;
                dtpTime.Enabled = false;
                return false;

            }
            else
                lblSubTitle.Visible = false;

            return false;

        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (Mode==enMode.Add&&_LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestTypeID)) 
            {
                lblSubTitle.Visible = true;
                lblSubTitle.Text = "Person already sat for the test, appointment locked.";
                btnSaveApointment.Enabled = false;
                dtpTime.Enabled = false;
                return false;

            }
            return true;
        }
        public void LoadInfo(int LocalDrivingLicenseApplicatioID,int TestAppointments=-1)
        {

            if(TestAppointments==-1)
            {
                Mode = enMode.Add;
            }
            else
            {
                Mode = enMode.Update;
            }

            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicatioID;
            _TestAppointmentID= TestAppointments;

            _LocalDrivingLicenseApplication=clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if( _LocalDrivingLicenseApplication==null )
            {
                MessageBox.Show("Erorr:_LocalDrivungLicenseApplication Driving License Application is not found.","Erorr",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnSaveApointment.Enabled= false; 
                return;
            }


            bool IsAttendTestBeforeThat = _LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID);

            if( IsAttendTestBeforeThat )
            {
                CreationMode=enCreationMode.RetakeTestShedule;
            }
            else
            {
                CreationMode = enCreationMode.FirstTimeShedule;
            }
            if (CreationMode == enCreationMode.RetakeTestShedule)
            {
                lblRetakeAppFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).ApplicationTypeFees.ToString("N2");
                lblRetakAppTestID.Text = "0";
                lblTitle.Text = "Shedule Retake Test";
                lblTitle.Location = new Point(141, 264);
                gbRetakeTestInfo.Enabled = true;
            }
            else
            {
                lblTitle.Text = "Shedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakAppTestID.Text = "N/A";
                gbRetakeTestInfo.Enabled = true;

            }

            lblLocalAppID.Text=_LocalDrivingLicenseApplicationID.ToString();
            lblDriverClass.Text = _LocalDrivingLicenseApplication.LicenseClassesInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplication.ApplicationInfo.PersonInfo.FullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();


            if(Mode==enMode.Add)
            {
                dtpTime.MinDate = DateTime.Now;
                lblFees.Text = clsTestTypes.Find((int)_TestTypeID).TestTypeFees.ToString("N2");
                lblRetakAppTestID.Text = "N/A";
                _TestAppointments = new clsTestAppointments();
            }
            else
            {
                if(!_LoadTestAppointmentData())
                    return;
            }
            lblTotalFees.Text=(Convert.ToDecimal(lblFees.Text)+Convert.ToDecimal(lblRetakeAppFees.Text)).ToString("N2");

            if (!_HandleActiveTestAppointmentConstraint())
                return;
            if (!_HandleTestAppointmentLockedConstraint())
                return;
            if (!_HandlePreviousTestAppointmentConstraint())
                return;

        }
        private void btnSaveApointment_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;

            _TestAppointments.AppointmentDate = dtpTime.Value;
            _TestAppointments.TestTypeID = _TestTypeID;
            _TestAppointments.PaidFees = Convert.ToDecimal(lblFees.Text);
            _TestAppointments.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointments.CreatedByUserID = GlobleUser.CurrentUser.UserID;
            if (_TestAppointments.Save())
            {
                Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erorr: Data Is not Saved Successfully", "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ctrlSchduleTest_Load(object sender, EventArgs e)
        {

        }
    }
}

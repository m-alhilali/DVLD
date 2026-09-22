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
using static DVLD_DataBusinessLayer.clsTestTypes;

namespace DVLD.Controls
{
    public partial class ctrlSecheduledTest : UserControl
    {
        private int _TestAppointmentID=-1;
        private int _TestID=-1;
        private int _LocalDrivingLicenseApplicationID=-1;
        clsTestAppointments _TestAppointment;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsTestTypes.enTestType _TestTypeID;
        public clsTestTypes.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        gbPersonInformation.Text = "Vision Test";
                        pbImage.Image = Resources.testvisionicon;
                        break;
                    case clsTestTypes.enTestType.WrittenTest:
                        gbPersonInformation.Text = "Written Test";
                        pbImage.Image = Resources.testwrittenicon;
                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        gbPersonInformation.Text = "Street Test";
                        pbImage.Image = Resources.teststreeticon;
                        break;
                }
            }
        }
        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }
        public ctrlSecheduledTest()
        {
            InitializeComponent();
        }

        public void LoadInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;
            _TestAppointment=clsTestAppointments.Find(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }
            _TestID = _TestAppointment.TestID;
            _LocalDrivingLicenseApplicationID= _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_TestAppointment.LocalDrivingLicenseApplicationID);
            if( _LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDriverClass.Text = _LocalDrivingLicenseApplication.LicenseClassesInfo.ClassName.ToString();
            lblName.Text =_LocalDrivingLicenseApplication.ApplicationInfo.PersonInfo.FullName;
            lblDate.Text = _TestAppointment.AppointmentDate.ToString("d");
            lblFees.Text = _TestAppointment.PaidFees.ToString("N2");
            lblTrial.Text = clsLocalDrivingLicenseApplication.TotalTrialsPerTest(_TestAppointment.LocalDrivingLicenseApplicationID, (clsTestTypes.enTestType)_TestTypeID).ToString();
            lblTestID.Text=(_TestID==-1)?"Not Taken Yet":_TestAppointment.TestID.ToString();

        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }
    }
}

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

namespace DVLD.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private int _LDLAppID;
        private clsTestTypes.enTestType _TestType;
        DataTable dt;
        public frmListTestAppointments(int LDLAppID,clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _TestType = TestType;

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
        private void ctrlDrivingLicenseInfoWithApplicationBasicInfo1_Load(object sender, EventArgs e)
        {
            
        }

        private void SetTitleByTestAppointmentType()
        {
            switch(_TestType)
            {
                case clsTestTypes.enTestType.VisionTest:
                    lblTitle.Text = "Vision Test Appoiment";
                    pbTestImage.Image = Resources.testvisionicon;
                    cmsTakeTest.Image = Resources.testvisionicon;

                    break;
                case clsTestTypes.enTestType.WrittenTest:
                    lblTitle.Text = "Written Test Appoiment";
                    pbTestImage.Image = Resources.testvisionicon;
                    cmsTakeTest.Image = Resources.testvisionicon;
                    break;
                case clsTestTypes.enTestType.StreetTest:
                    lblTitle.Text = "Street Test Appoiment";
                    pbTestImage.Image = Resources.testvisionicon;
                    cmsTakeTest.Image = Resources.testvisionicon;
                    break;
            }
            this.Text=lblTitle.Text;
        }
        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseInfoWithApplicationBasicInfo1.LoadApplicationInfoByLocalDrivingAppID(_LDLAppID);
            dt = clsTestAppointments.GetApplicationTestAppointmentsPerTestType(_LDLAppID,_TestType);
            dgvAppointments.DataSource = dt;
            lblTotalRecords.Text = dgvAppointments.Rows.Count.ToString();
            if (dgvAppointments.Rows.Count>0)
            {
                dgvAppointments.Columns["TestAppointmentID"].HeaderText = "Appointment ID";
                dgvAppointments.Columns["AppointmentDate"].HeaderText = "Appointment Date";
                dgvAppointments.Columns["PaidFees"].HeaderText = "Paied Fees";
                dgvAppointments.Columns["IsLocked"].HeaderText = "Is Locked";
                
            }
            SetTitleByTestAppointmentType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GoToAddNewAppointment()
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication= clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDLAppID);
            if(localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTests LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);
            if(LastTest == null)
            {
                frmSchduleTest frmSchedule = new frmSchduleTest(_LDLAppID, _TestType);
                frmSchedule.ShowDialog();
                frmListTestAppointments_Load(null, null);
                return;
            }

            if(LastTest.TestResult==true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmSchduleTest frm = new frmSchduleTest(LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm.ShowDialog();
            frmListTestAppointments_Load(null,null);
            
        }
        private void GoToUpdateAppointment(int TestAppointment)
        {
            clsTestAppointments appointments = clsTestAppointments.Find(TestAppointment);
            if (appointments == null)
            {
                MessageBox.Show("Erorr: Test is not exists yet!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (appointments.IsLocked)
            {
                MessageBox.Show("Person already sat for the test, appointment locked.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmSchduleTest frmTest=new frmSchduleTest(appointments.LocalDrivingLicenseApplicationID, _TestType,TestAppointment);
            frmTest.ShowDialog();
            frmListTestAppointments_Load(null, null);

        }
        private void btnAddApiontment_Click(object sender, EventArgs e)
        {
            GoToAddNewAppointment();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (dgvAppointments.CurrentRow!= null)
            {
                int _TestAppointment =Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
                GoToUpdateAppointment(_TestAppointment);
            }
            else
            {
                MessageBox.Show("There is no row is selected yet!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmsTakeTest_Click(object sender, EventArgs e)
        {
            int _TestAppointment = 0;
            if (dgvAppointments.CurrentRow != null)
            {
                int.TryParse(dgvAppointments.CurrentRow.Cells[0].Value.ToString(), out _TestAppointment);
            }
            
            frmTakeTest frm = new frmTakeTest(_TestAppointment,_TestType);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
            
            
        }
    }
}

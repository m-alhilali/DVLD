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
    public partial class frmTakeTest : Form
    {
        private clsTestTypes.enTestType _TestTypeID;
        private int _appointmentID;
        private int _TestID;
        //clsTestAppointments _appointments;
        //clsLocalDrivingLicenseApplication _LocalApplication;
        clsTests _Tests;
        public frmTakeTest(int TestAppontmentID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _appointmentID= TestAppontmentID;
            _TestTypeID= TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
             )
            {
                return;
            }
            _Tests.Notes = tbNotes.Text;
                _Tests.TestResult=rbtnPass.Checked;
                _Tests.CreatedByUserID=GlobleUser.CurrentUser.UserID;
                _Tests.TestAppointmentID = _appointmentID;
                if(_Tests.Save())
                {
                    MessageBox.Show("Data Saved Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSecheduledTest1.TestTypeID=_TestTypeID;
            ctrlSecheduledTest1.LoadInfo(_appointmentID);
             if(ctrlSecheduledTest1.TestAppointmentID==-1)
                btnSaveTest.Enabled = false;
            else
                btnSaveTest.Enabled = true;

            _TestID = ctrlSecheduledTest1.TestID;
            if(_TestID!=-1)
            {
                _Tests=clsTests.Find(_TestID);
                if(_Tests.TestResult)
                    rbtnPass.Checked = true;
                else
                    rbtnFailed.Checked = true;
                lblSubTitle.Visible = true;
                tbNotes.Text = _Tests.Notes;
                rbtnFailed.Enabled= false;
                rbtnPass.Enabled= false;


            }
            else
                _Tests=new clsTests();

        }
    }
}

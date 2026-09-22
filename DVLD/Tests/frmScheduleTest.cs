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
    public partial class frmSchduleTest : Form
    {
        private int _LDLAppID = -1;
        clsTestTypes.enTestType _TestTypeID=clsTestTypes.enTestType.VisionTest;
        private int _TestAppointmentID = -1;
        public frmSchduleTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID,int TestAppointment=-1)
        {
            InitializeComponent();
            _LDLAppID= LocalDrivingLicenseApplicationID;
            _TestTypeID= TestTypeID;
            _TestAppointmentID= TestAppointment;
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

        private void frmAddSchduleTestAppintment_Load(object sender, EventArgs e)
        {
            ctrlSchduleTest1.TestTypeID= _TestTypeID;
            ctrlSchduleTest1.LoadInfo(_LDLAppID, _TestAppointmentID);

        }

        private void ctrlSchduleTest1_Load(object sender, EventArgs e)
        {

        }
    }
}


using DVLD_DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.People;


namespace DVLD.Applications
{
    public partial class frmLocalApplicationDetailes : Form
    {
        private int _LocalDLApplicationID;
        public frmLocalApplicationDetailes(int LocalDLApplicationID)
        {
            InitializeComponent();
            _LocalDLApplicationID = LocalDLApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalApplicationDetailes_Load(object sender, EventArgs e)
        {
                ctrlDrivingLicenseInfoWithApplicationBasicInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDLApplicationID);
        }

    }
}

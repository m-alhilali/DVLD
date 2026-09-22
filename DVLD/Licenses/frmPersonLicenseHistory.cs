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
    public partial class frmPersonLicenseHistory : Form
    {
        private int _PersonID;
        public frmPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        public frmPersonLicenseHistory()
        {
            InitializeComponent();
        }


        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID > 0)
            {
                ctrlDriverLicenses1.LoadIDriverLicensesByPersonID(_PersonID);
                ctrlPersonInformationWithFillter1.LoadPersonInfo(_PersonID);
                ctrlPersonInformationWithFillter1.FilterEnable = false;
            }
            else
            {
                ctrlPersonInformationWithFillter1.FilterEnable=true;
                ctrlPersonInformationWithFillter1.FilterFocus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void ctrlPersonInformationWithFillter1_OnSelectedPerson(int obj)
        {
            if (obj >= 0)
            {
                ctrlDriverLicenses1.LoadIDriverLicensesByPersonID(obj);
            }
            else
            {
                ctrlDriverLicenses1.Clear();
            }
        }
    }
}

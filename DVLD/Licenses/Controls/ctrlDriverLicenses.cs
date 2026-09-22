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

namespace DVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID;
        DataTable _dtLocalLicenses;
        DataTable _dtInternationalLicebses;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void LoadLocalLicense()
        {
            _dtLocalLicenses = clsLicenses.GetDriverLicenses(_DriverID);
            dgvLocalLicenses.DataSource = _dtLocalLicenses;
            lblTotalRecords.Text = dgvLocalLicenses.Rows.Count.ToString();
           

        }
        private void LoadInternationalLicense()
        {
            
            _dtInternationalLicebses = clsInternationalLicenses.GetDriverInternationalLicenses(_DriverID);
            dgvInternationalLicense.DataSource = _dtInternationalLicebses;
            
           lblTotalRecordInternational.Text = dgvInternationalLicense.Rows.Count.ToString();

        }
        public void LoadIDriverLicensesByPersonID(int PersonID)
        {
            clsDriver Driver=clsDriver.FindDriverInfoByPersonID(PersonID);
            if (Driver == null)
            {
                MessageBox.Show($"There is no Driver linked with person with ID = {PersonID}", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DriverID =Driver.DriverID;
            LoadLocalLicense();
            LoadInternationalLicense();
        }
        public void LoadDriverLicensesByDriverID(int DriverID)
        {
            clsDriver Driver=clsDriver.FindDriverInfoByDriverID(DriverID);
            if (Driver == null)
            {
                MessageBox.Show($"There is no Driver with ID = {DriverID}", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            _DriverID = Driver.DriverID;
            LoadLocalLicense();
            LoadInternationalLicense();
        }

        private void showDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int LicenseID = 0;
            if (dgvLocalLicenses.CurrentRow == null)
                return;
            LicenseID = Convert.ToInt32(dgvLocalLicenses.CurrentRow.Cells[0].Value);
            frmDriverLicenseInfo frm = new frmDriverLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int InterLicenseID = 0;
            if (dgvLocalLicenses.CurrentRow == null)
                return;
            InterLicenseID = Convert.ToInt32(dgvLocalLicenses.CurrentRow.Cells[0].Value);
            frmDriverInternationalLicenseInfo frm = new frmDriverInternationalLicenseInfo(InterLicenseID);
        }

        public void Clear()
        {
            _dtInternationalLicebses.Clear();
            _dtLocalLicenses.Clear();
        }
    }
}

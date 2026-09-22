using DVLD.GlobalClasses;
using DVLD.Licenses;
using DVLD.Tests;
using DVLD_DataBusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmLocalDrivingLicenseApplication : Form
    {
        private DataTable _dtLDLApp;
        public frmLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            typeof(Guna2ContextMenuStrip).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(cmsLDLApplication, true, null);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if ((cp.Style & 0x00800000) == 0)
                {
                    cp.ExStyle |= 0x02000000;
                }
                return cp;
            }
        }
        private void frmLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _dtLDLApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseList();
            dgvLDLApp.DataSource = _dtLDLApp;
            lblTotalRecords.Text = _dtLDLApp.Rows.Count.ToString();

            if (dgvLDLApp.Rows.Count>0)
            {
                dgvLDLApp.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLDLApp.Columns[5].HeaderText = "Passed Test";
            }
            cbFilter.SelectedIndex = 0;
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            ChangeSizeControl.ChangeSizeButton(sender);
        }
        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            ChangeSizeControl.ResetSizeButton(sender);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddPeople_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalLicenseApplication frmAddnewLocal = new frmAddUpdateLocalLicenseApplication();
            frmAddnewLocal.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null,null);

        }
        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLDLApp.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvPeople_SelectionChanged(object sender, EventArgs e)
        {
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalID = -1;
            if (dgvLDLApp.CurrentRow == null)
                return;

            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            LocalID = Convert.ToInt32(dgvLDLApp.CurrentRow.Cells[0].Value);
            clsLocalDrivingLicenseApplication LocalApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalID);
            if (LocalApplication != null)
            {
                if (LocalApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void GoToScheduledTestType(clsTestTypes.enTestType TestType)
        {
            int LocalID = -1;
            if (dgvLDLApp.CurrentRow == null)
                return;
            LocalID = Convert.ToInt32(dgvLDLApp.CurrentRow.Cells[0].Value);
            frmListTestAppointments frmAddnewLocal = new frmListTestAppointments(LocalID, TestType);
            frmAddnewLocal.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null, null);


        }
        private void tsmSechduleTestVision_Click(object sender, EventArgs e)
        {
            GoToScheduledTestType(clsTestTypes.enTestType.VisionTest);

        }
        private void tsmSechduleTestWritten_Click(object sender, EventArgs e)
        {
            GoToScheduledTestType(clsTestTypes.enTestType.WrittenTest);

        }
        private void tsmSechduleTestStreet_Click(object sender, EventArgs e)
        {
            GoToScheduledTestType(clsTestTypes.enTestType.StreetTest);
        }
        private void tsmIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            int LocalID = -1;
            if (dgvLDLApp.CurrentRow== null)
                return;
            LocalID = Convert.ToInt32(dgvLDLApp.CurrentRow.Cells[0].Value);
            frmIssueDrivingLicense frm = new frmIssueDrivingLicense(LocalID);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null, null);
        }
        private void tsmShowLicense_Click(object sender, EventArgs e)
        {
            int LDLAppID = 0;
            if (dgvLDLApp.CurrentRow == null)
                return;
            LDLAppID = Convert.ToInt32(dgvLDLApp.CurrentRow.Cells[0].Value);
            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID).GetActiveLicenseID();
            if (LicenseID != -1)
            {
                frmDriverLicenseInfo frm = new frmDriverLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            if (dgvLDLApp.CurrentRow== null)
                return;
            int LDLAppID = 0;
            LDLAppID = Convert.ToInt32(dgvLDLApp.CurrentRow.Cells[0].Value);
           int PersonID = clsDriver.FindDriverInfoByPersonID(clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID).ApplicationInfo.ApplicantPersonID).PersonID;
           frmPersonLicenseHistory frm = new frmPersonLicenseHistory(PersonID);
           frm.ShowDialog();

        }
        private void dgvLDLApp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void cmsLDLApplication_Opening(object sender, CancelEventArgs e)
        {
            
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLDLApp.CurrentRow.Cells[0].Value);
            clsLocalDrivingLicenseApplication LocalApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (LocalApp != null) {
                int TotalPassed = Convert.ToInt32(dgvLDLApp.CurrentRow.Cells[5].Value);


                bool LicenseExists = LocalApp.IsLicenseIssued();
                tsmIssueDrivingLicense.Enabled = (TotalPassed == 3) && !LicenseExists;

                tsmShowLicense.Enabled = LicenseExists;
                tsmSechduleTest.Enabled = (!LicenseExists);
                tsmEditApplication.Enabled = !LicenseExists&&(LocalApp.ApplicationInfo.ApplicationStatus == clsApplications.enApplicationStatus.New);
                tsmCancelApplication.Enabled = (LocalApp.ApplicationInfo.ApplicationStatus == clsApplications.enApplicationStatus.New);
                deleteToolStripMenuItem.Enabled = (LocalApp.ApplicationInfo.ApplicationStatus == clsApplications.enApplicationStatus.New);

                bool PassedVesionTest = LocalApp.DoesPassTestType(clsTestTypes.enTestType.VisionTest);
                bool PassedWrittenTest = LocalApp.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
                bool PassedStreetTest = LocalApp.DoesPassTestType(clsTestTypes.enTestType.StreetTest);

                tsmSechduleTest.Enabled = (!PassedVesionTest||!PassedStreetTest||!PassedWrittenTest)&&(LocalApp.ApplicationInfo.ApplicationStatus==clsApplications.enApplicationStatus.New);

                if (tsmSechduleTest.Enabled)
                {
                    tsmSechduleTestVision.Enabled = !PassedVesionTest;
                    tsmSechduleTestWritten.Enabled = PassedVesionTest&&!PassedWrittenTest;
                    tsmSechduleTestStreet.Enabled = PassedVesionTest && PassedWrittenTest&&!PassedStreetTest;
                }
            }
            
            
            
        }
        private void tsmEditApplication_Click(object sender, EventArgs e)
        {
            if (dgvLDLApp.CurrentRow == null)
                return;
            int LDLApplicationID = Convert.ToInt32(dgvLDLApp.CurrentRow.Cells[0].Value);
            frmAddUpdateLocalLicenseApplication frmAddnewLocal = new frmAddUpdateLocalLicenseApplication(LDLApplicationID);
            frmAddnewLocal.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null, null);
        }
        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLDLApp.CurrentRow == null)
                return;
            int LDLApplicationID = Convert.ToInt32(dgvLDLApp.CurrentRow.Cells[0].Value);
            frmLocalApplicationDetailes frm = new frmLocalApplicationDetailes(LDLApplicationID);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplication_Load(null, null);
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible = (cbFilter.Text != "None");
            if (tbSearch.Visible)
            {
                tbSearch.PlaceholderText = cbFilter.Text;
                tbSearch.Focus();
            }

        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = "";
            switch(cbFilter.Text)
            {
                case "Name":
                    ColumnName = "FullName";
                    break;
                case "National No":
                    ColumnName = "NationalNo";
                    break;
                case "L.D.L.AppID":
                    ColumnName = "LocalDrivingLicenseApplicationID";
                    break;
                case "Class Name":
                    ColumnName = "ClassName";
                    break;
                case "Status":
                    ColumnName = "Status";
                    break;
                default:
                    ColumnName = "None";
                    break;
            }
            if (cbFilter.Text == "None" || tbSearch.Text.Trim() == "")
            {
                _dtLDLApp.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvLDLApp.Rows.Count.ToString();
                return;

            }
            try
            {
                if (ColumnName == "LocalDrivingLicenseApplicationID")
                {
                    _dtLDLApp.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                        ColumnName, tbSearch.Text.Trim());

                }
                else
                    _dtLDLApp.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                        ColumnName, tbSearch.Text.Trim());
            }
            catch(Exception ex) 
            {
                _dtLDLApp.DefaultView.RowFilter = "";
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            lblTotalRecords.Text = _dtLDLApp.Rows.Count.ToString();

        }
    }
}

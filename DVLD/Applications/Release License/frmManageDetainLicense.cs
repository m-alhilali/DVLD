using DVLD.GlobalClasses;
using DVLD.Licenses;
using DVLD.People;
using DVLD_DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace DVLD.Applications
{
    public partial class frmManageDetainLicense : Form
    {
        private DataTable _dtDetain;
        public frmManageDetainLicense()
        {
            InitializeComponent();
        }

        private void releasedDetainLicensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvDetainLicense.CurrentRow == null) 
                { return; }

            int LicenseID = Convert.ToInt32(dgvDetainLicense.CurrentRow.Cells[1].Value);
            frmReleasedLicenses frmReleasedLicenses = new frmReleasedLicenses(LicenseID);
            frmReleasedLicenses.ShowDialog();
            frmManageDetainLicense_Load(null, null);

        }

        private void ShowHistoryLicense_Click(object sender, EventArgs e)
        {
            if (dgvDetainLicense.CurrentRow == null)
                return;
            int LicenseID = Convert.ToInt32(dgvDetainLicense.CurrentRow.Cells[1].Value);

            int PersonID = clsLicenses.Find((LicenseID)).DriverInfo.PersonID;
            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(PersonID);
            frm.ShowDialog();
            frmManageDetainLicense_Load(null, null);

        }

        private void ShowPersonDetails_Click(object sender, EventArgs e)
        {
            if (dgvDetainLicense.CurrentRow == null)
                return;

            int LicenseID = (int)dgvDetainLicense.CurrentRow.Cells[1].Value;
            int PersonID = clsLicenses.Find(LicenseID).DriverInfo.PersonID;
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
            frmManageDetainLicense_Load(null, null);
        }

        private void ShowDetainLicense_Click(object sender, EventArgs e)
        {
            if (dgvDetainLicense.CurrentRow == null)
                return;
            int LicenseID = (int)dgvDetainLicense.CurrentRow.Cells[1].Value;

            frmDriverLicenseInfo frm = new frmDriverLicenseInfo(LicenseID);
            frm.ShowDialog();
          
        }

        private void dgvDetainLicense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           
            releasedDetainLicensToolStripMenuItem.Enabled = !(bool)(dgvDetainLicense.CurrentRow.Cells[3].Value);
            

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleasedLicenses frmReleasedLicenses = new frmReleasedLicenses();
            frmReleasedLicenses.ShowDialog();
            frmManageDetainLicense_Load(null, null);

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainedLicense frm=new frmDetainedLicense();
            frm.ShowDialog();
            frmManageDetainLicense_Load(null, null);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible = (cbFilter.Text != "None" && cbFilter.Text != "Is Released");
            cbIsReleased.Visible = (cbFilter.Text == "Is Released");

            if (cbIsReleased.Visible)
            {
                cbIsReleased.SelectedIndex = 0;
                cbIsReleased.Focus();

            }
            else if (tbSearch.Visible)
            {
                tbSearch.PlaceholderText = cbFilter.Text;
                tbSearch.Focus();
            }

        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = "";
            switch (cbFilter.Text)
            {
                case "Detain ID":
                    ColumnName = "DetainID";
                    break;
                case "License ID":
                    ColumnName = "LicenseID";
                    break;
                case "National No":
                    ColumnName = "NationalNo";
                    break;
                case "Full Name":
                    ColumnName = "FullName";
                    break;
                case "Release Application ID":
                    ColumnName = "ReleaseApplicationID";
                    break;
                default:
                    ColumnName = "None";
                    break;
            }
            if (cbFilter.Text == "None" || tbSearch.Text.Trim() == "")
            {
                _dtDetain.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvDetainLicense.Rows.Count.ToString();
                return;

            }
            try
            {
                if (ColumnName == "DetainID" || ColumnName == "LicenseID" || ColumnName == "ReleaseApplicationID")
                {
                    _dtDetain.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, tbSearch.Text.Trim());

                }
                else
                    _dtDetain.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnName, tbSearch.Text.Trim());
            }
            catch(Exception ex) 
            {
                _dtDetain.DefaultView.RowFilter = "";
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            lblTotalRecords.Text = dgvDetainLicense.Rows.Count.ToString();

        }
        private void cbIsReleased_SelectedIndexChange(object sender, EventArgs e)

        {
            string result = cbIsReleased.Text;
            string ColumnName = "IsReleased";
            switch (cbIsReleased.Text)
            {
                case "All":
                    break;
                case "No":
                    result = "0";
                    break;
                case "Yes":
                    result = "1";
                    break;
            }
            if (result == "All")
            {
                _dtDetain.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvDetainLicense.Rows.Count.ToString();
                return;

            }
            try
            {
                _dtDetain.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, result);

            }
            catch( Exception ex )
            {
                _dtDetain.DefaultView.RowFilter = "";
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            lblTotalRecords.Text = dgvDetainLicense.Rows.Count.ToString();
        }

        private void frmManageDetainLicense_Load(object sender, EventArgs e)
        {
            _dtDetain = clsDetainedLicenses.GetAllDetainedLicenses();
            dgvDetainLicense.DataSource = _dtDetain;
            lblTotalRecords.Text = dgvDetainLicense.Rows.Count.ToString();
            if (dgvDetainLicense.Rows.Count > 0)
            {


                dgvDetainLicense.Columns["DetainID"].HeaderText = "D.ID";
                dgvDetainLicense.Columns["LicenseID"].HeaderText = "L.ID";
                dgvDetainLicense.Columns["DetainDate"].HeaderText = "D.Date";
                dgvDetainLicense.Columns["ReleaseApplicationID"].HeaderText = "R.App.ID";
                dgvDetainLicense.Columns["NationalNo"].HeaderText = "N.No";
                dgvDetainLicense.Columns["IsReleased"].HeaderText = "IsReleased";
                dgvDetainLicense.Columns["FullName"].HeaderText = "FullName";

            }
            cbFilter.SelectedIndex = 0;
        }
        private void btnAddNewInternational_MouseEnter(object sender, EventArgs e)
        {
            ChangeSizeControl.ChangeSizeButton(sender);
        }

        private void btnAddNewInternational_MouseLeave(object sender, EventArgs e)
        {
            ChangeSizeControl.ResetSizeButton(sender);
        }
    }
}

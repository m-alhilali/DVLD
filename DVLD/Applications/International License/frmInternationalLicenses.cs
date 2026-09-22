using DVLD.GlobalClasses;
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


namespace DVLD.Licenses
{
    public partial class frmInternationalLicenses : Form
    {
        private DataTable _dtInternationalList;

        public frmInternationalLicenses()
        {
            InitializeComponent();
        }

        private void frmInternationalLicenses_Load(object sender, EventArgs e)
        {
            _dtInternationalList = clsInternationalLicenses.GetAllInternationalLicenses();
            dgvInternationalApp.DataSource = _dtInternationalList;
            lblTotalRecords.Text = dgvInternationalApp.Rows.Count.ToString();
            cbFilter.SelectedIndex = 0;

        }


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible = (cbFilter.Text != "None"&&cbFilter.Text!= "Is Active");
            cbIsActive.Visible = (cbFilter.Text == "Is Active");

            if (tbSearch.Visible)
            {
                tbSearch.Text = "";
                tbSearch.Focus();

            }
            else
            {
                cbIsActive.SelectedIndex = 0;
                cbIsActive.Focus();
            }


        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = "";
            switch (cbFilter.Text)
            {
                case "Driver ID":
                    ColumnName = "DriverID";
                    break;
                case "LocalLicense ID":
                    
                    ColumnName = "IssuedUsingLocalLicenseID";
                    break;
                case "Application ID":
                    ColumnName = "ApplicationID";
                    break;
                default:
                    ColumnName = "None";
                    break;
            }
            if (cbFilter.Text == "None" || tbSearch.Text.Trim() == "")
            {
                _dtInternationalList.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvInternationalApp.Rows.Count.ToString();
                return;

            }
            try
            {
                if (ColumnName == "DriverID" || ColumnName == "IssuedUsingLocalLicenseID" || ColumnName == "ApplicationID")
                {
                    _dtInternationalList.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, tbSearch.Text.Trim());

                }
                else
                    _dtInternationalList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", ColumnName, tbSearch.Text.Trim());
            }
            catch(Exception ex)
            {
                _dtInternationalList.DefaultView.RowFilter = "";
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            lblTotalRecords.Text = dgvInternationalApp.Rows.Count.ToString();

        }
        private void cbIsActive_SelectedIndexChange(object sender, EventArgs e)

        {
            string result = cbIsActive.Text;
            string ColumnName = "IsActive";
            switch (cbIsActive.Text)
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
                _dtInternationalList.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvInternationalApp.Rows.Count.ToString();
                return;

            }
            try
            {
                _dtInternationalList.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, result);

            }
            catch( Exception ex ) 
            {
                _dtInternationalList.DefaultView.RowFilter = "";
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            lblTotalRecords.Text = dgvInternationalApp.Rows.Count.ToString();
        }

        private void PersonLicenseHistory_Click(object sender, EventArgs e)
        {
            if (dgvInternationalApp.CurrentRow == null)
                return;
            
            
            int PersonID = clsDriver.FindDriverInfoByDriverID( Convert.ToInt32(dgvInternationalApp.CurrentRow.Cells[2].Value)).PersonID;
            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(PersonID);
            frm.ShowDialog();
            frmInternationalLicenses_Load(null, null);
        }

        private void DriverLicenseInfo_Click(object sender, EventArgs e)
        {
            int InternationalID = -1;
            if (dgvInternationalApp.CurrentRow == null)
                return;
            InternationalID = Convert.ToInt32(dgvInternationalApp.CurrentRow.Cells[0].Value);
            frmDriverInternationalLicenseInfo frm = new frmDriverInternationalLicenseInfo(InternationalID);
            frm.ShowDialog();
            frmInternationalLicenses_Load(null, null);
        }

        private void PersonDetails_Click(object sender, EventArgs e)
        {
            if (dgvInternationalApp.CurrentRow == null)
                return;
            int PersonID = clsDriver.FindDriverInfoByDriverID(Convert.ToInt32(dgvInternationalApp.CurrentRow.Cells[2].Value)).PersonID;
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
            frmInternationalLicenses_Load(null, null);
        }

        private void btnAddewInternational_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicense frm = new frmAddInternationalLicense();
            frm.ShowDialog();
            frmInternationalLicenses_Load(null, null);
        }
    }
}

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
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;


namespace DVLD.Drivers
{
    public partial class frmManageDrivers : Form
    {
        DataTable _dt;
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _dt = clsDriver.GetDriversList();
            dgvDrivers.DataSource = _dt;
            lblTotalRecords.Text = dgvDrivers.Rows.Count.ToString();

        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible = cbFilter.Text!="None";

            if (tbSearch.Visible)
            {
                tbSearch.Text="";
                tbSearch.Focus();
            }
           
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string ColumnName="";
            switch (cbFilter.Text)
            {
                case "Driver ID":
                    ColumnName = "DriverID";
                    break;
                case "Person ID":
                    ColumnName = "PersonID";
                    break;
                case "National No":
                    ColumnName = "NationalNo";
                    break;
                case "Full Name":
                    ColumnName = "FullName";
                    break;
                case "Active Licenses":
                    ColumnName = "NumberOfActiveLicenses";
                    break;
                default:
                    ColumnName = "None";
                    break;
            }
            try
            {
                if(tbSearch.Text.Trim()==""||ColumnName=="None")
                {
                    _dt.DefaultView.RowFilter = "";

                }
                else if (ColumnName == "PersonID" || ColumnName == "DriverID"||ColumnName== "NumberOfActiveLicenses")
                {
                    _dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, tbSearch.Text.Trim());
                }
                else
                {
                    _dt.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", ColumnName, tbSearch.Text.Trim());
                }
                lblTotalRecords.Text =_dt.Rows.Count.ToString();
                return;

            }
            catch(Exception ex)
            {
                _dt.DefaultView.RowFilter = "";
                lblTotalRecords.Text = _dt.Rows.Count.ToString();
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);


            }
            lblTotalRecords.Text = _dt.Rows.Count.ToString();

        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonID = 0;
            if (dgvDrivers.CurrentRow == null)
                return;
            PersonID = clsDriver.FindDriverInfoByDriverID( Convert.ToInt32(dgvDrivers.CurrentRow.Cells[0].Value)).PersonID;
            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
        private void ShowPersonDetails_Click(object sender, EventArgs e)
        {
            int PersonID = 0;
            if (dgvDrivers.CurrentRow == null)
                return;
            PersonID = Convert.ToInt32(dgvDrivers.CurrentRow.Cells[1].Value);
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }
        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToAddnewInternationalDrivingScreen();
        }
        private void GoToAddnewInternationalDrivingScreen()
        {
            frmAddInternationalLicense frm = new frmAddInternationalLicense();
            frm.ShowDialog();
        }
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Driver ID" || cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

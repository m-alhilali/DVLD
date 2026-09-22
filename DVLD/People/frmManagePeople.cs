using DVLD.GlobalClasses;
using DVLD_DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;



namespace DVLD.People
{
    public partial class frmManagePeople : Form
    {
        private DataTable _dtPeople;
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(1168, 697);

        }

      
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _dtPeople=clsPerson.GetPeopleList();
            dgvPeople.DataSource = _dtPeople;
            cbFilter.SelectedIndex = 0;
            lblTotalRecords.Text = dgvPeople.Rows.Count.ToString();

            if (dgvPeople.Rows.Count > 0)
            {
                //PersonID
                dgvPeople.Columns[0].HeaderText = "P.ID";
                //NationalNo
                dgvPeople.Columns[1].HeaderText = "N.No";
                //FirstName
                dgvPeople.Columns[2].HeaderText = "F.Name";
                //SecondName
                dgvPeople.Columns[3].HeaderText = "S.Name";
                //ThirdName
                dgvPeople.Columns[4].HeaderText = "Th.Name";
                //LastName
                dgvPeople.Columns[5].HeaderText = "L.Name";
                //Gendor
                dgvPeople.Columns[6].HeaderText = "Gendor";
                //DateOfBirth
                dgvPeople.Columns[7].HeaderText = "D.Birth";
                //CountryName
                dgvPeople.Columns[8].HeaderText = "Nationality";
                //Phone
                dgvPeople.Columns[9].HeaderText = "Phone";
                //Email
                dgvPeople.Columns[10].HeaderText = "Email";
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            ChangeSizeControl.ChangeSizeButton(sender);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            ChangeSizeControl.ResetSizeButton(sender);
        }
      
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible = (cbFilter.Text != "None");
            if (tbSearch.Visible)
            {
                tbSearch.Text = "";
                tbSearch.Focus();
            }
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = "";
            switch (cbFilter.Text)
            {
                case "Person ID":
                    ColumnName = "PersonID"; break;
                case "National No":
                    ColumnName = "NationalNo"; break;
                case "First Name":
                    ColumnName = "FirstName"; break;
                case "Second Name":
                    ColumnName = "SecondName"; break;
                case "Third Name":
                    ColumnName = "ThirdName"; break;
                case "Last Name":
                    ColumnName = "LastName"; break;
                case "Nationality":
                    ColumnName = "CountryName"; break;
                case "Email":
                    ColumnName = "Email"; break;
                case "Gendor":
                    ColumnName = "Gendor"; break;
                case "Phone":
                    ColumnName = "Phone"; break;
                default:
                    ColumnName = "None"; break;
            }

            if (tbSearch.Text == "" || cbFilter.Text == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvPeople.Rows.Count.ToString();
                return;

            }
            try
            {
                if (ColumnName == "PersonID")
                {
                    _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, tbSearch.Text.Trim());

                }
                else
                    _dtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", ColumnName, tbSearch.Text.Trim()); ;
            }
            catch (Exception ex)
            {
                _dtPeople.DefaultView.RowFilter = "";
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            lblTotalRecords.Text = dgvPeople.Rows.Count.ToString();
        }

        private void tbSearch_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void btnAddPeople_Click(object sender, EventArgs e)
        {
            frmAddorUpdatePerson addorUpdate = new frmAddorUpdatePerson();
            addorUpdate.ShowDialog();
            frmManagePeople_Load(null, null);

        }

        private void EditCurrentSelectedPerson(object sender, EventArgs e)
        {
            int PersonId = 0;
            if (dgvPeople.CurrentRow == null)
                return;
            PersonId = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            frmAddorUpdatePerson frm= new frmAddorUpdatePerson(PersonId);
            frm.ShowDialog();
            frmManagePeople_Load(null, null);
        }

        private void DeletePerson(object sender, EventArgs e)
        {
            int PersonId = -1;
            if (dgvPeople.CurrentRow == null)
                return;
            PersonId = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            if (MessageBox.Show($"Are you sure you want to deleted", $"Delete", MessageBoxButtons.OKCancel,MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(PersonId))
                {
                    MessageBox.Show($"Person with {PersonId} Deleted Successfuly", $"Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    frmManagePeople_Load(null, null);
                }
                else
                {
                    MessageBox.Show($"Person with {PersonId} Failed Deleted, it has data linked with it", $"Delete", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

        }

        private void showDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonId = -1;
            if (dgvPeople.CurrentRow == null)
                return;
            PersonId = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            frmPersonDetails frmdetails = new frmPersonDetails(PersonId);
            frmdetails.ShowDialog();
            frmManagePeople_Load(null, null);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"it dosn't empleminted", $"", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

      

    }
}

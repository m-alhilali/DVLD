using DVLD.GlobalClasses;
using DVLD_DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmMangeUsers : Form
    {

        DataTable _dtUsers;
        public frmMangeUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible = (cbFilter.Text != "None"&&cbFilter.Text!="Is Active");
            cbIsActive.Visible = (cbFilter.Text == "Is Active");

            if(cbIsActive.Visible)
            {
                cbIsActive.SelectedIndex = 0;
                cbIsActive.Focus();

            }
            else if(tbSearch.Visible)
            {
                tbSearch.Text = "";
                tbSearch.Focus();
            }

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = "";
            switch(cbFilter.Text)
            {
                case "Person ID":
                    ColumnName = "PersonID";
                    break;
                case "User ID":
                    ColumnName = "UserID";
                    break;
                case "Name":
                    ColumnName = "FullName";
                    break;
                case "User Name":
                    ColumnName = "UserName";
                    break;
                default:
                    ColumnName="None";
                    break;
            }
            if(cbFilter.Text=="None"||tbSearch.Text.Trim()=="")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblTotalRecords.Text=dgvUsers.Rows.Count.ToString();
                return;

            }
            try
            {
                if (ColumnName == "PersonID" || ColumnName == "UserID")
                {
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                        ColumnName, tbSearch.Text.Trim());

                }
                else
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                        ColumnName, tbSearch.Text.Trim());
            }
            catch(Exception ex)
            {
                _dtUsers.DefaultView.RowFilter = "";
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            lblTotalRecords.Text = dgvUsers.Rows.Count.ToString();

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
                default:
                    result = "All";
                    break;
            }
            if (result == "All")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvUsers.Rows.Count.ToString();
                return;

            }
            try
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, result);
            }
            catch (Exception ex)
            {
                {
                    _dtUsers.DefaultView.RowFilter = "";
                    clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                }
                lblTotalRecords.Text = dgvUsers.Rows.Count.ToString();
            }
        }

        private void frmMangeUsers_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _dtUsers = clsUsers.GetUsersList();
            dgvUsers.DataSource = _dtUsers;
            lblTotalRecords.Text = dgvUsers.Rows.Count.ToString();
            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";

                dgvUsers.Columns[1].HeaderText = "Person ID";


                dgvUsers.Columns[2].HeaderText = "Full Name";

                dgvUsers.Columns[3].HeaderText = "User Name";


                dgvUsers.Columns[4].HeaderText = "Is Active";

            }

        }
        private void frmMangeUsers_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(1129, 770);

        }

        private void guna2PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            ChangeSizeControl.ChangeSizeButton(sender);
        }

        private void guna2PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ChangeSizeControl.ResetSizeButton(sender);
        }

        private void btnAddNewUser(object sender, EventArgs e)
        {
            frmAddUpdateNewUser frmAdd = new frmAddUpdateNewUser();
            frmAdd.ShowDialog();
            frmMangeUsers_Load(null, null);


        }

        private void editUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow!=null)
            {
                int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
                frmAddUpdateNewUser frmAdd = new frmAddUpdateNewUser(UserID);
                frmAdd.ShowDialog();
                frmMangeUsers_Load(null,null);
            }
        }

        private void ChangePassword(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow!= null)
            {
                int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
                frmChangeUserPassword frmAdd = new frmChangeUserPassword(UserID);
                frmAdd.ShowDialog();
                frmMangeUsers_Load(null, null);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("Are you sure you want to deleted", "Delete User", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)==DialogResult.OK)
               { 
                if (clsUsers.DeleteUser(UserID))
                    {
                        MessageBox.Show("User has been Deleted Successfuly!", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        frmMangeUsers_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("User is not Deleted there are data connected with him!", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
        }

        private void showDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
                frmUserDetails frmUserDetails = new frmUserDetails(UserID);
                frmUserDetails.ShowDialog();
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"it dosn't empleminted", $"", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

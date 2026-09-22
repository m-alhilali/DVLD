using DVLD_DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmManageApplicationTypes : Form
    {
        private DataTable _dtApplicationTypes;
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtApplicationTypes = clsApplicationTypes.GetApplicationTypesList();
            dgvApplicationTypes.DataSource = _dtApplicationTypes;
            lblTotalRecords.Text = _dtApplicationTypes.Rows.Count.ToString();
            if (_dtApplicationTypes.Rows.Count>0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "A.Type.TestTypeID";
                dgvApplicationTypes.Columns[0].Width = 100;
                dgvApplicationTypes.Columns[1].HeaderText = "A.Titel";
                dgvApplicationTypes.Columns[2].HeaderText = "A.Fees";
                dgvApplicationTypes.Columns[2].Width = 150;

            }
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicationTypes.CurrentRow!= null)
            {
                int UserID = Convert.ToInt32(dgvApplicationTypes.CurrentRow.Cells[0].Value);
                frmUpdateApplicationTypes frmAdd = new frmUpdateApplicationTypes(UserID);
                frmAdd.ShowDialog();
                frmManageApplicationTypes_Load(null,null);
            }
        }
    }
}

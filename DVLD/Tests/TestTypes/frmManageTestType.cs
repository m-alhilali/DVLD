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
using DVLD;

namespace DVLD.Tests
{
    public partial class frmManageTestType : Form
    {
        private DataTable dt;
        public frmManageTestType()
        {
            InitializeComponent();
        }

        private void frmTestType_Load(object sender, EventArgs e)
        {
            dt = clsTestTypes.GetTestTypesList();
            dgvTestTypes.DataSource = dt;
            lblTotalRecords.Text = dt.Rows.Count.ToString();
            if(dt.Rows.Count > 0 ) 
            {
                dgvTestTypes.Columns[0].Width = 150;
            }
            
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestTypes.CurrentRow.Cells[0].Value != null)
            {
                int TestTypeID = Convert.ToInt32(dgvTestTypes.CurrentRow.Cells[0].Value);
                frmUpdateTestType frmAdd = new frmUpdateTestType((clsTestTypes.enTestType)TestTypeID);
                frmAdd.ShowDialog();
                frmTestType_Load(null,null);
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
    }
}

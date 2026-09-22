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
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmUpdateApplicationTypes : Form
    {
        private int _TypeID;
        clsApplicationTypes type ;

        public frmUpdateApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();
            _TypeID = ApplicationTypeID;
        }
        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) )
            {
               e.Handled = true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                  "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           type.ApplicationTypeID=_TypeID;
           type.ApplicationTypeTitle=tbTitle.Text;
           type.ApplicationTypeFees=Convert.ToDecimal(tbFees.Text);
           if(type.Save())
           {
               MessageBox.Show("Updated Successfuly", "Update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           }
           else
           {
               MessageBox.Show("Updated Failed", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           
        }   

        private void frmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            type= clsApplicationTypes.Find(_TypeID);
            if(type==null)
            {
                MessageBox.Show("Application Type dosn't exists", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblID.Text = _TypeID.ToString();
            tbTitle.Text = type.ApplicationTypeTitle;
            tbFees.Text = type.ApplicationTypeFees.ToString("N2");
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            ChangeSizeControl.ChangeSizeButton(sender);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            ChangeSizeControl.ResetSizeButton(sender);
        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTitle, "Title conn't be empty");
            }
            else
            {
                errorProvider1.SetError(tbTitle, null);
            }
           

        }

        private void tbFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFees, "You have to enter ammount fees");
            }
            else
            {
                errorProvider1.SetError(tbFees, null);
            }
        }
    }
}

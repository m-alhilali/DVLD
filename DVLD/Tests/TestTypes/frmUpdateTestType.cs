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

namespace DVLD.Tests
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestTypes.enTestType _TypeID=clsTestTypes.enTestType.VisionTest;
        clsTestTypes type;
        public frmUpdateTestType(clsTestTypes.enTestType TypeID)
        {
            InitializeComponent();
            _TypeID = TypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                  "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
           type.TestTypeID = (clsTestTypes.enTestType)_TypeID;
           type.TestTypeTitle = tbTitle.Text;
           type.TestTypeDescription = tbDescription.Text;
           type.TestTypeFees = Convert.ToDecimal(tbFees.Text);
           if (type.Save())
           {
               MessageBox.Show("Updated Successfuly", "Update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           }
           else
           {
               MessageBox.Show("Updated Failed", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            type = clsTestTypes.Find((int)_TypeID);
            if (type != null)
            {
                lblID.Text = ((int)_TypeID).ToString();
                tbTitle.Text = type.TestTypeTitle;
                tbDescription.Text = type.TestTypeDescription.ToString();
                tbFees.Text = type.TestTypeFees.ToString("N2");
            }
            else
            {
                MessageBox.Show("Test Type Is not exists", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
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
            if (string.IsNullOrEmpty(tbTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTitle, "Title conn't be empty");
            }
            else
            {
                errorProvider1.SetError(tbTitle, null);
            }


        }
        private void tbDescreptions_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbDescription, "Title conn't be empty");
            }
            else
            {
                errorProvider1.SetError(tbDescription, null);
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

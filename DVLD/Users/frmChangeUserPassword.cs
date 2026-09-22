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

namespace DVLD.Users
{
    public partial class frmChangeUserPassword : Form
    {
        private int _UserID=-1;
        private clsUsers _User;
        public frmChangeUserPassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
        private void btnChange_Click(object sender, EventArgs e)
        {
           if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
           if (tbNewPassword.Text == tbCurrentPassword.Text)
           {
               MessageBox.Show("You Cann't Like Last Password");
               return;
           }
           _User.Password = tbNewPassword.Text;
           if(_User.Save())
           {
               MessageBox.Show("Password Changed Successfully!","Change Password",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                _ResetDefaultValues();
           }
           else
           {
               MessageBox.Show("Password Failed Change!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);

           }
           

        }
        private void _ResetDefaultValues()
        {
            tbCurrentPassword.Text ="";
            tbNewPassword.Text = "";
            tbConfirmNewPassword.Text = "";
            tbCurrentPassword.Focus();
        }
        private void deleteErrorprovider(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            errorProvider1.SetError(ctrl, "");
        }

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _User = clsUsers.Find(_UserID);
            if (_User==null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
           ctrlUserInformation1.LoadUserInfo(_UserID);
           
           

        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "Password cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(tbNewPassword, null);
            }

            if ((_User.Password == tbCurrentPassword.Text))
            {
                errorProvider1.SetError(tbCurrentPassword, "Current Password is Wrong!");
                e.Cancel = true;
            }
            else
            { errorProvider1.SetError(tbCurrentPassword, null); }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbNewPassword.Text != tbConfirmNewPassword.Text)
            {
                errorProvider1.SetError(tbConfirmNewPassword, "Enter the same password that you entered above.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbConfirmNewPassword, null);
            }
        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(tbNewPassword, null);
            }
        }
    }
}

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
    public partial class frmAddUpdateNewUser : Form
    {
        private int _UserID;
        clsUsers _user;
        public enum enMode { Add=1,Update}
        private enMode Mode=enMode.Add;

        public frmAddUpdateNewUser()
        {
            InitializeComponent();
            Mode = enMode.Add;
        }
        public frmAddUpdateNewUser(int userID)
        {
            InitializeComponent();
            _UserID = userID;
            Mode = enMode.Update;

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

        private void _ResetDefaultValue()
        {
            if (Mode == enMode.Add)
            {
                _user = new clsUsers();
                lblTitle.Text = "Add New User";
                this.Text = "Add User";
              
                ctrlPersonInformationWithFillter1.FilterFocus();

            }
            else 
            {

                lblTitle.Text = "Update User";
                this.Text = "Update User";
                cbxIsActive.Checked = true;
                btnSave.Enabled = true;
            }
            tbUserName.Text = "";
            tbPassword.Text = "";
            tbConfirmPassword.Text = "";
        }

        private void LoadData()
        {
            _user = clsUsers.Find(_UserID);
            ctrlPersonInformationWithFillter1.FilterEnable = false;
            if (_user == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblUserID.Text = _UserID.ToString();
            tbUserName.Text = _user.UserName;
            tbPassword.Text = _user.Password;
            tbConfirmPassword.Text = _user.Password;
            cbxIsActive.Checked = _user.IsActive;
            ctrlPersonInformationWithFillter1.LoadPersonInfo(_user.PersonID);
            btnNext.Enabled = true;
        }
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if(Mode==enMode.Update)
            {
                LoadData();
                
            }
        }
        private void ctrlPersonInformationWithFillter1_Load(object sender, EventArgs e)
        {
            
        }
        private void frmAddNewUser_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(1075, 768);

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if(Mode==enMode.Update)
            {
                guna2TabControl1.SelectedIndex = 1;
                btnSave.Enabled = true;
                btnPrevious.Enabled = true;
                return;
            }
            if (ctrlPersonInformationWithFillter1.PersonID > 0)
            {
                if (clsUsers.isUserExistForPersonID(ctrlPersonInformationWithFillter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "selected another person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonInformationWithFillter1.FilterFocus();
                }
                else
                {
                    guna2TabControl1.SelectedIndex = 1;
                    btnSave.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                }
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

          
           _user.PersonID = ctrlPersonInformationWithFillter1.PersonID;
           _user.UserName = tbUserName.Text;
           _user.Password = tbPassword.Text;
           _user.IsActive=cbxIsActive.Checked;
           if(_user.Save())
            {
                MessageBox.Show($"User Saved Successfully.", $"Add|Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblUserID.Text = _user.UserID.ToString();
                lblTitle.Text = "Update User";
                this.Text = "Update User";
                Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show($"User is not saved .", $"Add|Update", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ctrlPersonInformationWithFillter1_OnSelectedPerson(int obj)
        {
            if(obj > 0)
            {
                Mode = enMode.Add;
                _ResetDefaultValue();
                btnNext.Enabled = true ;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedIndex == 1)
            {
                guna2TabControl1.SelectedIndex = 0;
                btnSave.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;

            }
        }

        private void cbxIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbUserName, "");

        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(tbUserName, null);
            }


            if (Mode==enMode.Add)
            {
                if (clsUsers.IsUserExists(tbUserName.Text))
                {
                    errorProvider1.SetError(tbUserName, "User Name already exist by another one.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(tbUserName, null);
                }
            }
            else
            {
                if (_user.UserName != tbUserName.Text.Trim())
                {
                    if (clsUsers.IsUserExists(tbUserName.Text))
                    {
                        errorProvider1.SetError(tbUserName, "User Name already exist by another one.");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider1.SetError(tbUserName, null);
                    }
                }
            }
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbConfirmPassword, "");
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (tbConfirmPassword.Text.Trim() != tbPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, null);
            }
            ;


        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(tbPassword, null);
            }
        }

        private void frmAddUpdateNewUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonInformationWithFillter1.FilterFocus();
        }
    }
}

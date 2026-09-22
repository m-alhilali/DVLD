using DVLD_DataBusinessLayer;
using System;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD.Login
{
    public partial class frmLoging : Form
    {
        private string GetProcessorId()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
            foreach(var os in searcher.Get())
            {
                return os["ProcessorId"].ToString();
            }
            return "Unknown";
        }
        private string MashineName;
        public frmLoging()
        {
            InitializeComponent();
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

        private bool RegisterLoginInformation()
        {
            if(!clsRememberLogin.IsUserExists(GlobleUser.CurrentUser.UserID))
            {
                clsRememberLogin newlogin = new clsRememberLogin();
                newlogin.UserID = GlobleUser.CurrentUser.UserID;
                newlogin.IsRememberMe = false;
                newlogin.MashineName=MashineName;
                newlogin.Save();
                
            }
            if (chkbxRememberme.Checked)
            {
                clsRememberLogin.UpdateIsRemeberMe(GlobleUser.CurrentUser.UserID, true);
            }
            else
            {
                clsRememberLogin.UpdateIsRemeberMe(GlobleUser.CurrentUser.UserID, false);
            }
            return true;
        }

        private void LoadLoginInformation()
        {
            if(clsRememberLogin.IsRemeberMe(GlobleUser.CurrentUser.UserID))
            {
                tbPassword.Text = GlobleUser.CurrentUser.Password;
                tbUserName.Text = GlobleUser.CurrentUser.UserName;
                chkbxRememberme.Checked = true;
            }
            else
            {
                tbPassword.Text = "";
                tbUserName.Text = "";
                chkbxRememberme.Checked = false;
            }
        }
        private void LoadLoginInformationByMashineName()
        {
            if(clsRememberLogin.IsRemeberMe(MashineName))
            {
                GlobleUser.CurrentUser=clsUsers.Find(clsRememberLogin.FindByMashineName(MashineName).UserID);
                tbPassword.Text = GlobleUser.CurrentUser.Password;
                tbUserName.Text = GlobleUser.CurrentUser.UserName;
                chkbxRememberme.Checked = true;
            }
            else
            {
                tbPassword.Text = "";
                tbUserName.Text = "";
                chkbxRememberme.Checked = false;
            }
        }
        private void frmLoging_Load(object sender, EventArgs e)
        {
            MashineName = GetProcessorId();
            if (clsRememberLogin.IsUserExists(MashineName))
            {
                LoadLoginInformationByMashineName();
            }
        }

        private void btnSignin_MouseEnter(object sender, EventArgs e)
        {
            ChangeSizeControl.ChangeSizeButton(sender);
        }

        private void btnSignin_MouseLeave(object sender, EventArgs e)
        {
            ChangeSizeControl.ResetSizeButton(sender);
        }


        private void btnSignin_Click(object sender, EventArgs e)
        {
            clsUsers User=clsUsers.Find(tbUserName.Text, tbPassword.Text);
            if (User!=null)
            {
                if(!User.IsActive)
                {
                    MessageBox.Show("Your account is not Active", "Login", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tbUserName.Focus();
                    return;
                }
                GlobleUser.CurrentUser = User;
                RegisterLoginInformation();
                MainScreen mainScrean = new MainScreen(this);
                this.Hide();
                mainScrean.ShowDialog();
                LoadLoginInformation();
            }
            else
            {
                MessageBox.Show("Invalid UserName/Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            errorProvider1.SetError(ctrl, "");
        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if(!clsUsers.IsUserExists(tbUserName.Text))
            {
                errorProvider1.SetError(tbUserName, "Invalid UserName!");
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            errorProvider1.SetError(ctrl, "");
        }

        private void btnAddNewInternational_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewInternational_MouseEnter(object sender, EventArgs e)
        {
            ChangeSizeControl.ChangeSizeButton(sender);
        }

        private void btnAddNewInternational_MouseLeave(object sender, EventArgs e)
        {
            ChangeSizeControl.ResetSizeButton(sender);
        }
    }
}

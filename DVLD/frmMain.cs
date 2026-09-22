using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor;
using DVLD.People;
using DVLD.Users;
using DVLD_DataBusinessLayer;
using DVLD.Login;
using DVLD.Applications;
using DVLD.Tests;
using DVLD.Licenses;
using DVLD.Drivers;


namespace DVLD
{
    public partial class MainScreen : Form
    {
        private frmLoging _frmLogin;
        public MainScreen(frmLoging frm)
        {
            InitializeComponent();
            _frmLogin = frm;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
            lblCalender.Text = DateTime.Now.ToString("MMMM d, yyyy");
            lblUserName.Text=GlobleUser.CurrentUser.UserName;
        }

        private void GoToManagePeopleScreen(object sender, EventArgs e)
        {
            frmManagePeople frm=new frmManagePeople();
            frm.ShowDialog();
        }
        private void GoToManageUsersleScreen(object sender, EventArgs e)
        {
            frmMangeUsers frmMangeUsers = new frmMangeUsers();
            frmMangeUsers.ShowDialog();
        }
        private void GoToManageApplicationTypesScreen(object sender, EventArgs e)
        {
            frmManageApplicationTypes manageApplicationTypes = new frmManageApplicationTypes();
            manageApplicationTypes.ShowDialog();
        }
        private void GoToManageTestTypesScreen(object sender, EventArgs e)
        {
            frmManageTestType manageApplicationTypes = new frmManageTestType();
            manageApplicationTypes.ShowDialog();
        }
        private void GoToManageLocalDrivingLicenseApplicationScreen()
        {
            frmLocalDrivingLicenseApplication LDLApplication = new frmLocalDrivingLicenseApplication();
            LDLApplication.ShowDialog();
        }
        private void GoToManageAddnewLocalApplicationScreen()
        {
            frmAddUpdateLocalLicenseApplication frmAddnewLocal = new frmAddUpdateLocalLicenseApplication();
            frmAddnewLocal.ShowDialog();
        }
        private void BackToLoginScreen(object sender, EventArgs e)
        {
            this.Close();
            _frmLogin.Show();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(1676, 908);
        }

        private void guna2ShadowPanel2_MouseEnter(object sender, EventArgs e)
        {
            ChangeSizeControl.ChangeSizeButton(sender);
        }

        private void guna2ShadowPanel2_MouseLeave(object sender, EventArgs e)
        {
            ChangeSizeControl.ResetSizeButton(sender);

        }

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobleUser.CurrentUser != null)
            {
                frmUserDetails frmdetails = new frmUserDetails(GlobleUser.CurrentUser.UserID);
                frmdetails.ShowDialog();
            }
        }

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobleUser.CurrentUser != null)
            {
                frmChangeUserPassword frmdetails = new frmChangeUserPassword(GlobleUser.CurrentUser.UserID);
                frmdetails.ShowDialog();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackToLoginScreen(sender,e);
        }

        private void Click_SettingsPanel(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Point p=control.PointToScreen(new Point(0,0));
            cmsSettings.Show(p.X,p.Y-cmsSettings.PreferredSize.Height);
        }

        private void Click_ApplicationsPanel(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Point p = control.PointToScreen(new Point(0, 0));
            cmsApplications.Show(p.X, p.Y - cmsApplications.PreferredSize.Height);
        }

        private void manageApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToManageApplicationTypesScreen(sender,e);
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToManageTestTypesScreen(sender, e);
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToManageAddnewLocalApplicationScreen();

        }

        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToManageLocalDrivingLicenseApplicationScreen();
        }

        private void newDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GoManageDrivers()
        {
            frmManageDrivers drivers = new frmManageDrivers();
            drivers.ShowDialog();
        }
        private void ManageDrivers(object sender, EventArgs e)
        {
            GoManageDrivers();
        }

        private void GoToAddnewInternationalDrivingScreen()
        {
            frmAddInternationalLicense frm = new frmAddInternationalLicense();
            frm.ShowDialog();
        }
        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToAddnewInternationalDrivingScreen();
        }
        private void GoToManageInternationalDrivingScreen()
        {
            frmInternationalLicenses frm = new frmInternationalLicenses();
            frm.ShowDialog();
        }
        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToManageInternationalDrivingScreen();
           
        }
        private void GoToRenewDrivingApplicationScreen()
        {
            frmRenewDrivingLicense frmRenew = new frmRenewDrivingLicense();
            frmRenew.ShowDialog();
        }
        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToRenewDrivingApplicationScreen();
        }
        private void GoToReplaceDrivingApplicationScreen()
        {
            frmReplaceForDamageOrLostLicense frmReplace = new frmReplaceForDamageOrLostLicense();
            frmReplace.ShowDialog();
        }

        private void replacementForLostOrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToReplaceDrivingApplicationScreen();
        }
        private void GoToDetainDrivingApplicationScreen()
        {
            frmDetainedLicense frmDetain = new frmDetainedLicense();
            frmDetain.ShowDialog();
        }
        private void detainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToDetainDrivingApplicationScreen();
        }
        private void GoToReleasedDetainDrivingApplicationScreen()
        {
            frmReleasedLicenses frmReleased = new frmReleasedLicenses();
            frmReleased.ShowDialog();
        }
        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToReleasedDetainDrivingApplicationScreen();
        }
        private void GoToManageDetainDrivingApplicationScreen()
        {
            frmManageDetainLicense frmReleased = new frmManageDetainLicense();
            frmReleased.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToManageDetainDrivingApplicationScreen();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToManageLocalDrivingLicenseApplicationScreen();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddNewInternational_Click(object sender, EventArgs e)
        {
            BackToLoginScreen(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");
            lblCalender.Text = DateTime.Now.ToString("MMMM d, yyyy");
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmDriverInternationalLicenseInfo : Form
    {
        private int _InternationalLicenseID = 0;
        public frmDriverInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID= InternationalLicenseID;
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

        private void frmDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrInternationalLicenseInfo1.LoadInfo(_InternationalLicenseID);
        }
    }
}

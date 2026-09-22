using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmPersonDetails : Form
    {
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            { ctrlPersonInformation1.LoadPersonInfo(PersonID); }
        }
        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();
             ctrlPersonInformation1.LoadPersonInfo(NationalNo); 
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

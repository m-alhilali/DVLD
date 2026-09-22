using DVLD_DataBusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.People;

namespace DVLD.Controls
{
    public partial class ctrlPersonInformationWithFillter : UserControl
    { 
        public event Action<int> OnSelectedPerson;
        protected void _OnSelectedResult(int PersonID)
        {
            Action<int> handler=OnSelectedPerson;
            if(handler != null )
            {
                handler(PersonID);
            }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnable
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }

        }
        public int PersonID
        {
            get
            {
                return ctrlPersonInformation1.PersonID;
            }
            
        }

        public clsPerson PersonInfo
        {
            get
            {
                return ctrlPersonInformation1.PersonInfo;
            }
        }
        public ctrlPersonInformationWithFillter()
        {
           
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            tbSearch.Text = PersonID.ToString();
            FindNow();
        }
        private void FindNow()
        {
            switch(cbFilter.Text)
            {
                case "Person ID":
                    ctrlPersonInformation1.LoadPersonInfo(Convert.ToInt32(tbSearch.Text)); break;
                case "National No":
                    ctrlPersonInformation1.LoadPersonInfo(tbSearch.Text); break;
                default:
                    break;
            }
            if(OnSelectedPerson != null && _FilterEnabled)
            {
                _OnSelectedResult(ctrlPersonInformation1.PersonID);
            }
        }


        private void btnAddPeople_Click(object sender, EventArgs e)
        {
            frmAddorUpdatePerson frmadd = new frmAddorUpdatePerson();
            frmadd.DataBackEvent += DataBack_WithPersonID;
            frmadd.ShowDialog();
        }
        private void DataBack_WithPersonID(object sender,int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            tbSearch.Text = PersonID.ToString().Trim();
            FindNow();

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible=(cbFilter.SelectedItem.ToString() != "None")?true:false;
            btnSearch.Enabled=tbSearch.Visible;
            if(tbSearch.Visible)
            {
                tbSearch.Focus();
            }
        }

        private void ctrlPersonInformationWithFillter_Load(object sender, EventArgs e)
        {
            if (cbFilter.Items.Count > 0)
                cbFilter.SelectedIndex = 0;
            else
                cbFilter.SelectedIndex = -1;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
           
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            FindNow();

        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                btnAddPeople.PerformClick();
            }
            if(cbFilter.Text=="Person ID")
            {
               e.Handled=!char.IsDigit(e.KeyChar) &&!char.IsControl(e.KeyChar);
            }
        }
        public void FilterFocus()
        {
            tbSearch.Focus();
        }
    }
}

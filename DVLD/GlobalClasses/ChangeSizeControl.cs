using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace DVLD
{
    public static class ChangeSizeControl
    {
        public static void ChangeSizeButton(object sender)
        {
            Control control = (Control)sender;
            control.Size=new System.Drawing.Size(control.Width+2, control.Height+2);
            control.Top=control.Top-1;
            control.Left=control.Left-1;
                
        }
        public static void ResetSizeButton(object sender)
        {
            Control control = (Control)sender;
            control.Size=new System.Drawing.Size(control.Width-2, control.Height-2);
            control.Top = control.Top + 1;
            control.Left = control.Left + 1;
        }
    }
}

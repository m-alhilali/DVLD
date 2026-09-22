using DVLD_DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD
{
    public static class GlobleUser
    {
        public static clsUsers CurrentUser = clsUsers.Find(-1);
    }
}

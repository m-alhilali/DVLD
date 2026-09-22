using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_DataBusinessLayer
{
    public class clsRememberLogin
    {
        private enum enMode { Add=0, Update=1}
        public bool IsRememberMe { get; set; }
        public string MashineName { get; set; }
        public int RememberLoginID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }

        enMode Mode= enMode.Add;

        public clsRememberLogin()
        {
            this.UserID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsRememberMe = false;
            this.RememberLoginID = -1;
            this.MashineName = "";

            Mode = enMode.Add;
        }

        private clsRememberLogin(int UserID, int RememberLoginID, string MashineName,string UserName, string Password, bool IsRememberMe)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsRememberMe = IsRememberMe;
            this.RememberLoginID = RememberLoginID;
            Mode = enMode.Update;

        }

        public static clsRememberLogin FindByUserID(int UserID)
        {
            string UserName = "", Password = "", MashineName="";
            int RememberLoginID = -1;
            bool IsRememberMe = false;
            if (clsRememberLoginData.FindByUserID(UserID, ref MashineName, ref RememberLoginID, ref IsRememberMe))
            {
                UserName=clsUsers.Find(UserID).UserName;
                Password=clsUsers.Find(UserID).Password;
                return new clsRememberLogin(UserID, RememberLoginID, MashineName, UserName, Password, IsRememberMe);
            }
            return null;

        }
        public static clsRememberLogin FindByMashineName(string MashineName)
        {
            string UserName = "", Password = "";
            int RememberLoginID = -1,UserID=-1;
            bool IsRememberMe = false;
            if (clsRememberLoginData.FindByMashineName(MashineName, ref UserID, ref RememberLoginID, ref IsRememberMe))
            {
                UserName=clsUsers.Find(UserID).UserName;
                Password=clsUsers.Find(UserID).Password;
                return new clsRememberLogin(UserID, RememberLoginID, MashineName, UserName, Password, IsRememberMe);
            }
            return null;

        }

        public static bool IsUserExists(int UserID)
        {
            return clsRememberLoginData.IsUserExists(UserID);
        }
        public static bool IsUserExists(string IsUserExists)
        {
            return clsRememberLoginData.IsUserExists(IsUserExists);
        }
        private bool _AddNew()
        {
            this.RememberLoginID = clsRememberLoginData.AddNewRememberLogin(this.UserID, this.MashineName,this.IsRememberMe);
            return (this.RememberLoginID > 0);
        }
        private bool _Update()
        {
            return (clsRememberLoginData.UpdateIsRemeberMe(this.UserID, this.IsRememberMe));
        }
        public bool Save()
        {
            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNew())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;

                case enMode.Update:
                    if (_Update())
                    {
                        isSaved = true;
                    }
                    return isSaved;
            }
            return isSaved;
        }

        public static bool UpdateIsRemeberMe(int UserID, bool IsRemeberMe)
        {
            return clsRememberLoginData.UpdateIsRemeberMe(UserID, IsRemeberMe);
        }

        public static bool IsRemeberMe(int UserID)
        {
            return clsRememberLoginData.IsRemeberMe(UserID);
        }
        public static bool IsRemeberMe(string MashineName)
        {
            return clsRememberLoginData.IsRemeberMe(MashineName);
        }
    }
}

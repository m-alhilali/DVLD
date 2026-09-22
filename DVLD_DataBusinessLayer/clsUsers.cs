using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataBusinessLayer
{
    public class clsUsers
    {
        private enum enMode { Add = 1, Update = 2 };
        private enMode Mode = enMode.Add;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPerson Person;
        public clsUsers()
        {
            this.PersonID = -1;
            this.UserID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;

            Mode = enMode.Add;
        }
        private clsUsers(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.PersonID = PersonID;
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.Person = clsPerson.Find(PersonID);
            Mode = enMode.Update;

        }
        public static DataTable GetUsersList()
        {

            return clsUserData.GetUsersList();
        }
        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.PersonID > 0);
        }
        private bool _UpdateUser()
        {
            return (clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive));
        }
        public bool Save()
        {
            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewUser())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;

                case enMode.Update:
                    if (_UpdateUser())
                    {
                        isSaved = true;
                    }
                    return isSaved;
            }
            return isSaved;
        }
        public static bool IsUserExists(int UserID)
        {
            return clsUserData.IsUserExists(UserID);
        }
        public static bool IsUserExists(string UserName)
        {
            return clsUserData.IsUserExists(UserName);
        }
        public static bool IsUserExists(int UserID,string UserName)
        {
            return clsUserData.IsUserExists(UserID,UserName);
        }
        public static bool IsUserExists(string UserName,string Password)
        {
            return clsUserData.IsUserExists(UserName, Password);
        }
        public static clsUsers Find(int UserID)
        {
            string UserName = "", Password = "";
            int PersonID = -1;
            bool IsActive = false;
            if (clsUserData.FindByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;

        }
        public static clsUsers Find(string UserName, string Password)
        {

            int PersonID = -1, UserID = -1; ;
            bool IsActive = false;
            if (clsUserData.FindUserByUserNameAndPassword(UserName, Password,ref UserID, ref PersonID,  ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;

        }
        public static clsUsers Find(string UserName)
        {
            string  Password = "";
            int PersonID = -1,UserID=-1;
            bool IsActive = false;
            if (clsUserData.FindUserByUserName(UserName,ref UserID, ref PersonID,  ref Password, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;

        }
        public static bool UpdatePassword(int UserID, string Password)
        {
            return clsUserData.ChangePassword(UserID, Password);
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUserData.isUserExistForPersonID(PersonID);
        }
    }

}

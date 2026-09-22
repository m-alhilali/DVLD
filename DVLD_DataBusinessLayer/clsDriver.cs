using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_DataBusinessLayer
{
    public class clsDriver
    {

        private enum enMode { Add=1,Update=2}
        enMode Mode= enMode.Add;
        public int DriverID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;

        public clsDriver()
        {
            this.DriverID = 0;
            this.PersonID = 0;
            this.CreatedDate = DateTime.MinValue;
            this.CreatedByUserID = 0;
            Mode= enMode.Add;
        }

        private clsDriver(int PersonID,int DriverID,DateTime CreatedDate,int CreateByUserID)
        {
            
            this.DriverID = DriverID;
            this.CreatedByUserID = CreateByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonID = PersonID;
            PersonInfo = clsPerson.Find(PersonID);
        }

       
        public static DataTable GetDriversList()
        {
            return clsDriversData.GetDriversList();
        }
        public static clsDriver FindDriverInfoByPersonID(int PersonID)
        {
            int DriverID = -1,CreatedByUserID=-1;
            DateTime CreatedDate = DateTime.Now;
            if (clsDriversData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(PersonID,DriverID, CreatedDate,CreatedByUserID);
            }
            return null;
        }
        public static clsDriver FindDriverInfoByDriverID(int DriverID)
        {
            int PersonID = -1,CreatedByUserID=-1;
            DateTime CreatedDate = DateTime.Now;
            if (clsDriversData.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(PersonID,DriverID, CreatedDate,CreatedByUserID);
            }
            return null;
        }
        private bool _AddNewDriver()
        {

            this.DriverID = clsDriversData.AddNewDriver(this.PersonID, this.CreatedByUserID);
            return (this.DriverID > 0);
        }
        private bool _UpdateDriver()
        {
            return (clsDriversData.UpdateDriver(this.DriverID, this.PersonID,this.CreatedByUserID));
        }
        public bool Save()
        {
            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewDriver())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;

                case enMode.Update:
                    if (_UpdateDriver())
                    {
                        isSaved = true;
                    }
                    return isSaved;
            }
            return isSaved;
        }
        public static DataTable GetLicenses(int DriverID)
        {
            return clsLicenses.GetDriverLicenses(DriverID);
        }
        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenses.GetDriverInternationalLicenseInfo(DriverID);
        }


    }


}    

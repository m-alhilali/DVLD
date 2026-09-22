using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataBusinessLayer
{
    public class clsDetainedLicenses
    {
        private enum enMode { Add=1,Update,Release}
        enMode Mode = enMode.Add;
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public clsUsers CreatedByUserIDInfo {  get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate {  get; set; }
        public int ReleasedByUserID { get; set; }
        clsUsers ReleasedByUserInfo {  get; set; }
        public int ReleaseApplicationID {  get; set; }
        public clsDetainedLicenses()
        {
            DetainID = 0;
            LicenseID=0;
            DetainDate= DateTime.MinValue;
            FineFees= 0;
            CreatedByUserID = 0;
            IsReleased = false;
            ReleaseDate = DateTime.MinValue;
            ReleasedByUserID = 0;
            ReleaseApplicationID = 0;
            Mode= enMode.Add;
        }
        private clsDetainedLicenses (int DetainID,int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.DetainDate = DetainDate;
            this.LicenseID = LicenseID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ReleaseDate = ReleaseDate;
            this.CreatedByUserID = CreatedByUserID;
            this.ReleasedByUserID = ReleasedByUserID;
            ReleasedByUserInfo = clsUsers.Find(ReleasedByUserID);
            CreatedByUserIDInfo = clsUsers.Find(CreatedByUserID);
            this.IsReleased = IsReleased;
            this.FineFees = FineFees;
            Mode=enMode.Update;

        }

        private bool _AddNewDetain()
        {
            this.DetainID= clsDetainedLicensesData.AddNewDetainLicense(this.LicenseID,this.DetainDate,this.FineFees,this.CreatedByUserID);
            return (this.DetainID > 0);
        }
        private bool _UpdateDetain()
        {
            return clsDetainedLicensesData.UdateDetainLicense(this.LicenseID,this.LicenseID,this.DetainDate,this.FineFees,this.CreatedByUserID);
            
        }
        public bool Save()
        {
            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewDetain())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;
                case enMode.Update:
                    if (_UpdateDetain())
                    {
                        isSaved = true;
                    }
                    return isSaved;

                
            }
            return isSaved;
        }

        public static bool IsLicenseDetaind(int LicenseID)
        {
            return clsDetainedLicensesData.IsLicenseDetaind(LicenseID);
        }
        public bool ReleaseDetainLicense(int ReleasedByUserID,int ReleaseApplicationID)
        {
            return clsDetainedLicensesData.ReleaseDetainLicense(this.DetainID,ReleasedByUserID,ReleaseApplicationID);
        }
        public static DataTable GetAllDetainedLicenses()
        {

            return clsDetainedLicensesData.GetAllDetainedLicenses();
        }
        public static clsDetainedLicenses FindByDetainID(int DetainID)
        {
            int LicenseID = 0, CreatedByUserID = 0,ReleasedByUserID = 0,ReleaseApplicationID = 0;
            DateTime DetainDate = DateTime.MinValue,ReleaseDate = DateTime.MinValue;
            Decimal FineFees = 0;
            bool IsReleased = false;
            
            if(clsDetainedLicensesData.FindByDetainID(DetainID,ref LicenseID,ref DetainDate,ref FineFees,ref CreatedByUserID,ref IsReleased,ref ReleaseDate,ref ReleasedByUserID,ref ReleaseApplicationID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate,FineFees,CreatedByUserID,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID);
            }
            return null;
        }
        public static clsDetainedLicenses FindByLicenseID(int LicenseID)
        {
            int DetainID = 0, CreatedByUserID = 0,ReleasedByUserID = 0,ReleaseApplicationID = 0;
            DateTime DetainDate = DateTime.MinValue,ReleaseDate = DateTime.MinValue;
            Decimal FineFees = 0;
            bool IsReleased = false;
            
            if(clsDetainedLicensesData.FindByLicenseID(LicenseID,ref DetainID, ref DetainDate,ref FineFees,ref CreatedByUserID,ref IsReleased,ref ReleaseDate,ref ReleasedByUserID,ref ReleaseApplicationID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate,FineFees, CreatedByUserID, IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID);
            }
            return null;
        }
      
    }
}

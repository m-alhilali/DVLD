using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DVLD_DataBusinessLayer.clsLicenses;

namespace DVLD_DataBusinessLayer
{
    public class clsInternationalLicenses:clsApplications
    {
        private enum enMode { Add=1,Update=2}
        enMode Mode= enMode.Add;
        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime IssueDate { get; set; }
        public bool IsActive { get; set; }

        public clsInternationalLicenses()
        {
            this.ApplicationTypeID = (int)clsApplications.enApplicationType.NewInternationalLicense;

            this.InternationalLicenseID = 0;
            this.DriverID = 0;
            this.IssuedUsingLocalLicenseID = 0;
            this.ExpirationDate = DateTime.Now;
            this.IssueDate = DateTime.Now;
            this.IsActive = true;
            Mode = enMode.Add;
        }
        public clsInternationalLicenses(int ApplicationID, int ApplicationPersonID,DateTime ApplicationDate,DateTime LastStatusDate,enApplicationStatus ApplicationStatus,
            decimal PaidFees,int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime ExpirationDate, DateTime IssueDate, bool IsActive, int CreatedByUserID)
        {
            base.ApplicationID = ApplicationID;
            base.ApplicationStatus = ApplicationStatus;
            base.ApplicationDate = ApplicationDate;
            base.LastStatusDate = LastStatusDate;
            base.ApplicantPersonID = ApplicationPersonID;
            base.ApplicationTypeID=(int)clsApplications.enApplicationType.NewInternationalLicense;
            base.CreatedByUserID = CreatedByUserID;
            base.PaidFees= PaidFees;


            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.ExpirationDate = ExpirationDate;
            this.IssueDate = IssueDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;


            this.DriverInfo=clsDriver.FindDriverInfoByDriverID(this.DriverID);
            Mode = enMode.Update;
        }
          private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicensesData.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.ExpirationDate,this.IssueDate, this.IsActive, this.CreatedByUserID);
            return (this.InternationalLicenseID !=-1);
        }
          private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicensesData.UpdateInternationalLicense(this.InternationalLicenseID,this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.ExpirationDate,this.IssueDate, this.IsActive, this.CreatedByUserID);
        }
       
        public bool Save()
        {
            base.Mode = (clsApplications.enMode)Mode;
            if (!base.Save())
                return false;

            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewInternationalLicense())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;

                case enMode.Update:
                    if (_UpdateInternationalLicense())
                    {
                        isSaved = true;
                    }
                    return isSaved;
            }
            return isSaved;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicensesData.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }

        public static clsInternationalLicenses Find(int InternationalLicenseID)
        {
            bool IsActive = false;
            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID=-1, CreatedByUserID=-1;
            DateTime ExpirationDate = DateTime.Now, IssueDate=DateTime.Now;
            if (clsInternationalLicensesData.GetInternationalLicenseInfoByID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref ExpirationDate,ref IssueDate ,ref IsActive, ref CreatedByUserID))
            {
                clsApplications Application = clsApplications.FindBaseApplication(ApplicationID);
                return new clsInternationalLicenses(Application.ApplicationID, Application.ApplicantPersonID,Application.ApplicationDate,Application.LastStatusDate,Application.ApplicationStatus,Application.PaidFees,InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID, ExpirationDate, IssueDate, IsActive, CreatedByUserID);
            }
            return null;
        }
        public static decimal GeInternationaltApplicationFees(int ApplicationTypeID)
        {
            return clsInternationalLicensesData.GetInternationaltApplicationFees(ApplicationTypeID);
        }
        public static DataTable GetAllInternationalLicenses()
        {

            return clsInternationalLicensesData.GetAllInternationalLicenses();
        }
        public static bool IsDriverHaseLicenseFromTypeOrdinary(int LicenseID)
        {
            return clsInternationalLicensesData.IsDriverHaseLicenseFromTypeOrdinary (LicenseID);
        }
        public static DataTable GetDriverInternationalLicenseInfo(int InternationalLicenseID)
        {

            return clsInternationalLicensesData.GetDriverInternationalLicenseInfo(InternationalLicenseID);
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {

            return clsInternationalLicensesData.GetDriverInternationalLicenses(DriverID);
        }

    }
}

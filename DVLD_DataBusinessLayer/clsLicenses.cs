using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataBusinessLayer
{
    public class clsLicenses
    {
        private enum enMode { Add = 1, Update = 2 };
        private enMode Mode = enMode.Add;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public int LicenseID {  get; set; }
        public int ApplicationID {  get; set; }
        public int DriverID {  get; set; }
        public clsDriver DriverInfo;
        public int ClassLicenseID {  get; set; }
        public clsLicenseClasses LicenseClassesInfo;
        public int CreatedByUserID {  get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate {  get; set; }
        public string Notes {  get; set; }
        public decimal PaidFees {  get; set; }
        public bool IsActive {  get; set; }
        public bool IsDetained
        {  
            get { return clsDetainedLicenses.IsLicenseDetaind(this.LicenseID); }
        }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(IssueReason);
            }
        }

        public clsDetainedLicenses DetainedInfo {  get; set; }

        public clsLicenses()
        {
            LicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            ClassLicenseID = 0;
            CreatedByUserID = 0;
            IsActive = false;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Notes = string.Empty;
            IssueReason= clsLicenses.enIssueReason.FirstTime;
            PaidFees = 0;
            Mode = enMode.Add;
        }

        private clsLicenses(int licenseID, int applicationID, int driverID, int licenseClassID, int createdByUserID, DateTime issueDate, DateTime expirationDate, string notes, decimal paidFees, bool isActive, clsLicenses.enIssueReason issueReason)
        {
            this.LicenseID = licenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.ClassLicenseID = licenseClassID;
            this.CreatedByUserID = createdByUserID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.IsActive = isActive;
            this.IssueReason = issueReason;
            this.DriverInfo=clsDriver.FindDriverInfoByDriverID(driverID);
            this.LicenseClassesInfo = clsLicenseClasses.Find(ClassLicenseID);
            this.DetainedInfo = clsDetainedLicenses.FindByLicenseID(this.LicenseID);
            Mode = enMode.Update;
        }
        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicensesData.AddNewLicense(this.ApplicationID,this.DriverID,this.ClassLicenseID,this.IssueDate,this.ExpirationDate,this.Notes,this.PaidFees,this.IsActive,(byte)this.IssueReason,this.CreatedByUserID);
            return (this.LicenseID > 0);
        }
        private bool _UpdateLicense()
        {
            return (clsLicensesData.UpdateLicense(this.LicenseID,this.ApplicationID, this.DriverID, this.ClassLicenseID, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive,(byte) this.IssueReason, this.CreatedByUserID));
        }
        public bool Save()
        {
            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewLicense())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;

                case enMode.Update:
                    if (_UpdateLicense())
                    {
                        isSaved = true;
                    }
                    return isSaved;
            }
            return isSaved;
        }
        public static bool IsLicenseExistByPersonID(int PersonID,int LicenseClassID)
        {
            return( clsLicenses.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID)!=-1);
        }
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return clsLicensesData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }
        public static Boolean IsLicenseExpired(int LicenseID)
        {
            DateTime LicenseExpireDate=clsLicenses.Find(LicenseID).ExpirationDate;
            return DateTime.Compare(LicenseExpireDate,DateTime.Now) < 0;

        }
        public static bool DeactivateLicense(int LicenseID)
        {
            return clsLicensesData.DeactivateLicense(LicenseID);

        }
        public Boolean IsLicenseExpired()
        {
            return (this.ExpirationDate< DateTime.Now);

        }
        public bool DeactivateCurrentLicense()
        {
            return clsLicensesData.DeactivateLicense(this.LicenseID);

        }
       
        public static DataTable GetAllLicenses()
        {
            
            return clsLicensesData.GetAllLicenses();
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            
            return clsLicensesData.GetDriverLicenses(DriverID);
        }

        public static clsLicenses Find(int LicenseID)
        {
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            int ApplicationID = 0, DriverID=0, LicenseClassID=0, CreatedByUserID=0;
            byte IssueReason = 0;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            if (clsLicensesData.GetLicenseByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref CreatedByUserID, ref PaidFees, ref IssueReason, ref IsActive, ref Notes, ref IssueDate, ref ExpirationDate))
            {
                return new clsLicenses(LicenseID,  ApplicationID,  DriverID,  LicenseClassID,  CreatedByUserID,  IssueDate,  ExpirationDate, Notes,  PaidFees, IsActive,(clsLicenses.enIssueReason) IssueReason);
            }
            return null;

        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        public clsLicenses ReplaceLicense(clsLicenses.enIssueReason IssueReason, int CreatedByUserID)
        {
            clsApplications Application=new clsApplications();
            Application.ApplicationTypeID = ((IssueReason==clsLicenses.enIssueReason.DamagedReplacement)? (int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense: (int)clsApplications.enApplicationType.ReplaceLostDrivingLicense);
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate= DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find(Application.ApplicationTypeID).ApplicationTypeFees;
            Application.CreatedByUserID = CreatedByUserID;
            if(!Application.Save())
            {
                return null;
            }

            clsLicenses NewLicense = new clsLicenses();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.ClassLicenseID = this.ClassLicenseID;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.CreatedByUserID= CreatedByUserID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees=0;
            if(!NewLicense.Save())
            {
                return null;
            }
            DeactivateCurrentLicense();

            return NewLicense;
        }
        public bool ReleaseLicense(int ReleasedByUserID,ref int ApplicationID)
        {
            clsApplications Application=new clsApplications();
            Application.ApplicationTypeID = (int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate= DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find(Application.ApplicationTypeID).ApplicationTypeFees;
            Application.CreatedByUserID = ReleasedByUserID;
            if(!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID=Application.ApplicationID;
            return (this.DetainedInfo.ReleaseDetainLicense(ReleasedByUserID,ApplicationID));
        }
        public clsLicenses RenewLicense(string Notes, int CreatedByUserID)
        {
            clsApplications Application=new clsApplications();
            Application.ApplicationTypeID = (int)clsApplications.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.LastStatusDate= DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationTypeFees;
            Application.CreatedByUserID = CreatedByUserID;
            if(!Application.Save())
            {
                return null;
            }
            clsLicenses NewLicense = new clsLicenses();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.ClassLicenseID = this.ClassLicenseID;

            int DefaultValidityLength = this.LicenseClassesInfo.DefaultValidityLength;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.IssueDate = DateTime.Now;

            NewLicense.CreatedByUserID= CreatedByUserID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.Notes = Notes;
            NewLicense.PaidFees=this.LicenseClassesInfo.ClassFees;
            if(!NewLicense.Save())
            {
                return null;
            }
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public int Detain(decimal FineFees,int CreatedByUserID)
        {
            clsDetainedLicenses DetainLicense= new clsDetainedLicenses();
            DetainLicense.DetainDate = DateTime.Now;
            DetainLicense.FineFees = FineFees;
            DetainLicense.CreatedByUserID = CreatedByUserID;
            DetainLicense.LicenseID = this.LicenseID;
            if(!DetainLicense.Save())
            {
                return -1;
            }
            return DetainLicense.DetainID;
        }
    }
}

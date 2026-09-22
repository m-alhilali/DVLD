using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DataAccessLayer.clsApplicationsData;

namespace DVLD_DataBusinessLayer
{
    public class clsApplications
    {
        public enum enMode { Add=1,Update=2};
        public enMode Mode = enMode.Add;
        public enum enApplicationStatus { New=1,Cancelled=2,Completed=3};
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public clsApplications.enApplicationStatus ApplicationStatus { get; set; }

        public clsApplicationTypes ApplicationTypeInfo;
        public clsUsers UserInfo;
        public clsPerson PersonInfo;
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public int ApplicationTypeID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public string StatusText
        {
            get
            {

                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }

        }

        public clsApplications()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationTypeID = -1;
            this.CreatedByUserID = -1;
            this.ApplicationDate=DateTime.MinValue;
            this.LastStatusDate = DateTime.MinValue;
            this.PaidFees = 0;
            Mode = enMode.Add;
            ApplicationStatus= enApplicationStatus.New;
        }
        private clsApplications(int ApplicationID,int ApplicationPersonID,int ApplicationTypeID,int CreatedByUserID,DateTime ApplicationDate,DateTime LastStatusDate,enApplicationStatus ApplicationStatus,decimal PaidFees)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicationPersonID;
            this.PersonInfo = clsPerson.Find(ApplicationPersonID);
            this.ApplicationTypeID = ApplicationTypeID;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
            this.ApplicationStatus = ApplicationStatus;
            this.PaidFees =PaidFees;
            ApplicationTypeInfo = clsApplicationTypes.Find(ApplicationTypeID);
            UserInfo = clsUsers.Find(CreatedByUserID);
            Mode = enMode.Update;
        }
        private bool _AddnewApplication()
        {
            this.ApplicationID = clsApplicationsData.AddNewApplication(this.ApplicantPersonID, this.ApplicationTypeID, this.CreatedByUserID,(byte) this.ApplicationStatus, this.PaidFees);
            return (this.ApplicationID > 0);
        }
        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplication(this.ApplicationID,this.ApplicantPersonID, this.ApplicationTypeID ,this.CreatedByUserID,(byte)this.ApplicationStatus,this.PaidFees);
        }
        public bool Save()
        {
            
            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddnewApplication())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;

                case enMode.Update:
                    if (_UpdateApplication())
                    {
                        isSaved = true;
                    }
                    return isSaved;
            }
            return isSaved;
        }
        public bool SetComplete()
        {
            return clsApplicationsData.UpdateStatus(this.ApplicationID,(byte)enApplicationStatus.Completed);
        }
        public static bool SetComplete(int ApplicationID)
        {
            return clsApplicationsData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Completed);
        }
        public static bool Cancel(int ApplicationID)
        {
            return clsApplicationsData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Cancelled);
        }
        public bool Cancel()
        {
            return clsApplicationsData.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Cancelled);
        }
        public bool Delete()
        {
            return clsApplicationsData.DeleteApplication(this.ApplicationID);
        }
        public static bool Delete(int ApplicationID)
        {
            return clsApplicationsData.DeleteApplication(ApplicationID);
        }
        public bool DosePersonHaveActiveApplication(int ApplicationTypeID)
        {
            return (clsApplicationsData.DosePersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID));
        }
        public static bool DosePersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return (clsApplicationsData.DosePersonHaveActiveApplication(PersonID, ApplicationTypeID));
        }
        public static bool IsApplicationExists(int ApplicationID)
        {
           return (clsApplicationsData.IsApplicationExists(ApplicationID));
        }
        public static bool IsApplicationCompleted(int ApplicationID)
        {
            return ((byte)clsApplications.FindBaseApplication(ApplicationID).ApplicationStatus==3);
        }
        public static bool IsApplicationCancelled(int ApplicationID)
        {
            return ((byte)clsApplications.FindBaseApplication(ApplicationID).ApplicationStatus == 2);
        }
        public static clsApplications FindBaseApplication(int ApplicationID)
        {
            byte ApplicationStatus = 0;
            int ApplicationPersonID = 0, ApplicationTypeID = 0, CreatedByUserID = 0;
            decimal PaidFees = 0;
            DateTime ApplicationDate= DateTime.MinValue, LastStatusDate= DateTime.MinValue;
            if (clsApplicationsData.FindApplication(ApplicationID, ref ApplicationPersonID, ref ApplicationTypeID, ref CreatedByUserID, ref ApplicationStatus, ref PaidFees, ref ApplicationDate, ref LastStatusDate))
            {
                return new clsApplications(ApplicationID, ApplicationPersonID, ApplicationTypeID, CreatedByUserID, ApplicationDate, LastStatusDate, (enApplicationStatus)ApplicationStatus, PaidFees);
            }
            return null;
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplications.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            int ID = -1;
            ID=clsApplicationsData.GetActiveApplicationIDForLicenseClass(PersonID,(int) ApplicationTypeID, LicenseClassID);
            return ID;
        }
        public int GetActiveApplicationID(clsApplications.enApplicationType ApplicationTypeID)
        {
            int Application = -1;
            Application= clsApplicationsData.GetActiveApplicationID(this.ApplicantPersonID,(int) ApplicationTypeID);
            return Application;
        }
        public static int GetActiveApplicationID(int ApplicationPersonID, clsApplications.enApplicationType ApplicationTypeID)
        {
            int Application = -1;
            Application= clsApplicationsData.GetActiveApplicationID(ApplicationPersonID,(int) ApplicationTypeID);
            return Application;
        }

    }
}

using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DataAccessLayer.clsApplicationsData;
using static DVLD_DataBusinessLayer.clsApplications;

namespace DVLD_DataBusinessLayer
{
    public class clsLocalDrivingLicenseApplication
    {
        private enum enMode { Add = 1, Update }
        enMode Mode = enMode.Add;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ClassLicenseID { get; set; }
        public clsLicenseClasses LicenseClassesInfo;
        public clsApplications ApplicationInfo;
        public int ApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication()
        {
            Mode = enMode.Add;
            LocalDrivingLicenseApplicationID = 0;
            ClassLicenseID = 0;
            ApplicationID = 0;
            ApplicationInfo=new clsApplications();
        }
        private clsLocalDrivingLicenseApplication(int lDLApplicationID,int ApplicationID,int ClassLicenseId)
        {
            this.LocalDrivingLicenseApplicationID = lDLApplicationID;
            this.ApplicationID = ApplicationID;
            this.ClassLicenseID = ClassLicenseId;
            ApplicationInfo = clsApplications.FindBaseApplication(this.ApplicationID);
            LicenseClassesInfo = clsLicenseClasses.Find(this.ClassLicenseID);
            Mode = enMode.Update;
        }
        private bool _AddNewLocalApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewApplication(this.ApplicationID, this.ClassLicenseID);
            return (this.LocalDrivingLicenseApplicationID !=-1);
        }
        private bool _UpdateLocalApplication()
        {
            return (clsLocalDrivingLicenseApplicationData.UpdateLocalApplcation(this.LocalDrivingLicenseApplicationID, this.ClassLicenseID));
        }
        public bool Save()
        {
            if (!this.ApplicationInfo.Save())
                return false;
            this.ApplicationID = this.ApplicationInfo.ApplicationID;
            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewLocalApplication())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;

                case enMode.Update:
                    if (_UpdateLocalApplication())
                    {
                        isSaved = true;
                    }
                    return isSaved;
            }
            return isSaved;
        }
       
        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseID = -1, LicenseClassID = -1;
            if ((clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(ApplicationID, ref LocalDrivingLicenseID, ref LicenseClassID)))
            {
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseID, ApplicationID, LicenseClassID);
            }
            return null;
        }
        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseID)
        {
            int ApplicationID = -1, LicenseClassID = -1;
            if ((clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseID,ref ApplicationID,ref LicenseClassID)))
            {
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseID, ApplicationID, LicenseClassID);
            }
            return null;
        }
        public static bool Delete(int LocalApplicationLicenseID)
        {
            bool IsLocalApplicationDeleted=false;
            bool IsBaseApplicationDeleted=false;
            IsLocalApplicationDeleted = clsLocalDrivingLicenseApplicationData.Delete(LocalApplicationLicenseID);
            if(!IsLocalApplicationDeleted)
            {
                return false;
            }
            IsBaseApplicationDeleted = clsApplications.Delete(clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalApplicationLicenseID).ApplicationID);
            return IsBaseApplicationDeleted;
        }
        public bool Cancel()
        {
            return clsApplications.Cancel(this.ApplicationID);
        }
        public bool Delete()
        {
            bool IsLocalApplicationDeleted=false;
            bool IsBaseApplicationDeleted=false;
            IsLocalApplicationDeleted = clsLocalDrivingLicenseApplicationData.Delete(this.LocalDrivingLicenseApplicationID);
            if(!IsLocalApplicationDeleted)
            {
                return false;
            }
            IsBaseApplicationDeleted = ApplicationInfo.Delete();
            return IsBaseApplicationDeleted;
        }
        public static DataTable GetLocalDrivingLicenseList()
        {
            return clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseList();
        }
        public static DataTable GetLocalDrivingLicenseDetailsList(int LocalDLApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseDetailsList(LocalDLApplicationID);
        }
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool DoesPassTestType(clsTestTypes.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool PassedAllTests()

        {
            return clsTests.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }
        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return clsTests.PassedAllTests(LocalDrivingLicenseApplicationID);
        }

        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriver Driver = clsDriver.FindDriverInfoByPersonID(this.ApplicationInfo.ApplicantPersonID);
            if (Driver == null)
            {
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicationInfo.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }

            clsLicenses _License = new clsLicenses();
            _License.ApplicationID = this.ApplicationID;
            _License.DriverID = DriverID;
            _License.IssueDate = DateTime.Now;
            _License.ClassLicenseID = this.ClassLicenseID;
            _License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassesInfo.DefaultValidityLength);
            _License.Notes = Notes;
            _License.IsActive = true;
            _License.CreatedByUserID = CreatedByUserID;
            _License.IssueReason = clsLicenses.enIssueReason.FirstTime;
            _License.PaidFees = LicenseClassesInfo.ClassFees;
            if (_License.Save())
            {
                this.ApplicationInfo.SetComplete();
                return  _License.LicenseID;
            }
            return -1;
        }
        public bool DoesPassPreviousTest(clsTestTypes.enTestType CurrentTestType)
        {
            switch (CurrentTestType)
            {
                case clsTestTypes.enTestType.VisionTest:
                    return true;
                case clsTestTypes.enTestType.WrittenTest:
                    return this.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
                case clsTestTypes.enTestType.StreetTest:
                    return this.DoesPassTestType(clsTestTypes.enTestType.StreetTest);
                default:
                    return false;
            }
        }
        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public int TotalTrialsPerTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)

        {

            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool IsThereAnActiveScheduledTest(clsTestTypes.enTestType TestTypeID)

        {

            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTests.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
        public byte GetPassedTestCount()
        {
            return clsTests.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }
        public static int GetFailedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTests.GetFailedTestCount(LocalDrivingLicenseApplicationID);
        }
        public int GetFailedTestCount()
        {
            return clsTests.GetFailedTestCount(this.LocalDrivingLicenseApplicationID);
        }
        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return clsLicenses.GetActiveLicenseIDByPersonID(this.ApplicationInfo.ApplicantPersonID, this.ClassLicenseID);
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public clsTests GetLastTestPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTests.FindLastTestPerPersonAndLicenseClass(this.ApplicationInfo.ApplicantPersonID, this.ClassLicenseID, TestTypeID);
        }
    }

}

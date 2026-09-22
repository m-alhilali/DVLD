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
    public class clsTests
    {
        public enum enMode { Add=0,Update=1};
        private enMode Mode=enMode.Add;
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointments TestAppointmentInfo { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsTests()
        {
            TestID = 0;
            TestAppointmentID = 0;
            TestResult=false;
            Notes= string.Empty;
            CreatedByUserID = 0;
            Mode = enMode.Add;
        }
        public clsTests(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            TestAppointmentInfo = clsTestAppointments.Find(TestAppointmentID);
            this.TestResult= TestResult;
            this.Notes= Notes;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }
        private bool _AddNewTest()
        {

            this.TestID = clsTestsData.AddNewTest(this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);


            return (this.TestID != -1);
        }
        private bool _UpdateTest()
        {

            return clsTestsData.UpdateTest(this.TestID, this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewTest())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTest();

            }

            return false;
        }
        public static DataTable GetAllTests()
        {
            return clsTestsData.GetAllTests();

        }
        public static clsTests Find(int TestID)
        {
            int TestAppointmentID = 1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = ""; 
            if(clsTestsData.GetTestInfoByID(TestID,ref TestAppointmentID,ref TestResult,ref Notes,ref CreatedByUserID))
            {
                return new clsTests(TestID, TestAppointmentID,TestResult,Notes,CreatedByUserID);
            }
            return null;
        }
        public static clsTests FindLastTestPerPersonAndLicenseClass(int PersonID, int LicenseClassID, clsTestTypes.enTestType TestTypeID)
        {
            int TestID = -1, TestAppointmentID = 1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = ""; 
            if(clsTestsData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID, LicenseClassID, (int)TestTypeID,ref TestID,ref TestAppointmentID,ref TestResult,ref Notes,ref CreatedByUserID))
            {
                return new clsTests(TestID, TestAppointmentID,TestResult,Notes,CreatedByUserID);
            }
            return null;
        }
        public static int GetFailedTestCount(int LocalApplicationID)
        {
            return clsTestsData.GetFailedTestCount(LocalApplicationID);
        }
        public static byte GetPassedTestCount(int LocalApplicationID)
        {
            return clsTestsData.GetPassedTestCount(LocalApplicationID);
        }
        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }

    }
}

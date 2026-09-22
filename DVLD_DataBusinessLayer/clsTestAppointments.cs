using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataBusinessLayer
{
    public class clsTestAppointments
    {
        private enum enMode { Add = 1, Update = 2 };
        private enMode Mode = enMode.Add;
        public int TestAppointmentID {  get; set; }
        public clsTestTypes.enTestType TestTypeID {  get; set; }
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int CreatedByUserID {  get; set; }
        public int RetakeTestApplicationID {  get; set; }

        public clsApplications RetakeTestAppInfo;
        public DateTime AppointmentDate {  get; set; }
        public decimal PaidFees {  get; set; }
        public bool IsLocked {  get; set; }
        public int TestID 
        {
            get { return _GetTestID(); }

        }

        public clsTestAppointments()
        { 
            Mode = enMode.Add;
            TestAppointmentID = -1;
            TestTypeID = clsTestTypes.enTestType.VisionTest;
            LocalDrivingLicenseApplicationID = -1;
            CreatedByUserID = -1;
            RetakeTestApplicationID = -1;
            AppointmentDate = DateTime.MinValue;
            PaidFees = 0;
            IsLocked = false;
        }
        public clsTestAppointments(int TestAppointmentID,clsTestTypes.enTestType TestTypeID,int LocalDrivingLicenseApplicationID,int CreatedByUserID,int RetakeTestApplicationID,DateTime AppointmentDate,decimal PaidFees,bool IsLocked)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.RetakeTestApplicationID= RetakeTestApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.PaidFees = PaidFees;
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            RetakeTestAppInfo= clsApplications.FindBaseApplication(RetakeTestApplicationID);
            Mode = enMode.Update;
        }
        private bool _AddNewTestAppointment()
        {

            this.TestAppointmentID = clsTestAppointmentsData.AddNewTestApointment((int)this.TestTypeID,this.LocalDrivingLicenseApplicationID,this.CreatedByUserID,this.RetakeTestApplicationID,this.PaidFees,this.AppointmentDate,this.IsLocked);
            return (this.TestAppointmentID > 0);
        }
        private bool _UpdateTestAppointment()
        {
            return (clsTestAppointmentsData.UpdateTestAppointment(this.TestAppointmentID,(int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.CreatedByUserID, this.RetakeTestApplicationID, this.PaidFees, this.AppointmentDate, this.IsLocked));
        }
        public bool Save()
        {
            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewTestAppointment())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;

                case enMode.Update:
                    if (_UpdateTestAppointment())
                    {
                        isSaved = true;
                    }
                    return isSaved;
            }
            return isSaved;
        }
        public static clsTestAppointments Find(int TestAppointmentID)
        {
            int TestTypeID = 0, LocalDrivingLicenseApplicationID = 0, CreatedByUserID = 0, RetakeTestApplicationID = 0;
            decimal PaidFees =0;
            DateTime AppointmentDate= DateTime.MinValue;
            bool IsLocked=false;
            if (clsTestAppointmentsData.FindTestAppointmentByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref CreatedByUserID, ref RetakeTestApplicationID, ref PaidFees, ref AppointmentDate, ref IsLocked))
            {
                return new clsTestAppointments(TestAppointmentID, (clsTestTypes.enTestType)TestTypeID,  LocalDrivingLicenseApplicationID,  CreatedByUserID,  RetakeTestApplicationID, AppointmentDate, PaidFees ,  IsLocked);
            }
            return null;
        }
        public static clsTestAppointments GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now; decimal PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (clsTestAppointmentsData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

                return new clsTestAppointments(TestAppointmentID, (clsTestTypes.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,CreatedByUserID, RetakeTestApplicationID,
             AppointmentDate, PaidFees, IsLocked);
            else
                return null;

        }
        private int _GetTestID()
        {
            return clsTestAppointmentsData.GetTestID(TestAppointmentID);
        }
        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentsData.GetAllTestAppointments();

        }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType)
        {
            return clsTestAppointmentsData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID,(int) TestType);

        }
        public  DataTable GetApplicationTestAppointmentsPerTestType(clsTestTypes.enTestType TestType)
        {
            return clsTestAppointments.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID,TestType);

        }

    }

}

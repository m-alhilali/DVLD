using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataBusinessLayer
{
    public class clsTestTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public clsTestTypes.enTestType TestTypeID { set; get; }

        public string TestTypeDescription {  get; set; }
        public string TestTypeTitle {  get; set; }
        public decimal TestTypeFees {  get; set; }
        private clsTestTypes(int testTypeID, string testTypeDescription, string testTypeTitle, decimal testTypeFees)
        {
            this.TestTypeID = (enTestType)testTypeID;
            this.TestTypeDescription = testTypeDescription;
            this.TestTypeTitle = testTypeTitle;
            this.TestTypeFees = testTypeFees;
            Mode= enMode.Update;
        }
        public clsTestTypes()
        {
            this.TestTypeID = enTestType.VisionTest;
            this.TestTypeTitle = string.Empty;
            this.TestTypeDescription = string.Empty;
            this.TestTypeFees = 0;
            Mode = enMode.AddNew;
        }
        public static clsTestTypes Find(int TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = ""; decimal TestTypeFees = 0;
            if(clsTestTypesData.Find(TestTypeID,ref TestTypeTitle,ref TestTypeDescription,ref TestTypeFees))
            {
                return new clsTestTypes(TestTypeID,TestTypeTitle,TestTypeDescription,TestTypeFees);
            }
            return null;
        }
        public static DataTable GetTestTypesList()
        {
            return clsTestTypesData.GetTestTypesList();
        }
        public bool _UpdateTestType()
        {
            return (clsTestTypesData.UpdateTestTypes((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees));
        }

        private bool _AddNewTestType()
        {
            this.TestTypeID = (clsTestTypes.enTestType)clsTestTypesData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
            return (this.TestTypeTitle != "");
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }


    }
}

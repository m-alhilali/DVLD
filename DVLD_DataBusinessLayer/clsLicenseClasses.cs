using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataBusinessLayer
{
    public class clsLicenseClasses
    {
        private enum enMode { Add = 1, Update = 2 }
        enMode Mode = enMode.Add;
        public string ClassName { get; set; }
        public int LicenseClassID { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        public clsLicenseClasses()
        {
            LicenseClassID = -1;
            ClassDescription = "";
            MinimumAllowedAge = 18;
            DefaultValidityLength = 10;
            ClassFees = 0;
            ClassDescription = "";
            Mode = enMode.Add;
        }
        private clsLicenseClasses(string className, int licenseClassID, string classDescription, byte minimumAllowedAge, byte defaultValidityLength, decimal classFees)
        {
            ClassName = className;
            LicenseClassID = licenseClassID;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
            Mode = enMode.Update;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }
        public static clsLicenseClasses Find(int LicenseClassID)
        {
            string ClassName = "", ClassDescription = "";
            byte MinimumAllowedAge = 18, DefaultValidityLength = 10;
            decimal ClassFees = 0;
            if (clsLicenseClassesData.FindByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClasses(ClassName, LicenseClassID, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            return null;
        }
        public static clsLicenseClasses Find(string ClassName)
        {
            string  ClassDescription = "";
            int LicenseClassID = -1;
            byte MinimumAllowedAge = 18, DefaultValidityLength = 10;
            decimal ClassFees = 0;
            if (clsLicenseClassesData.FindByClassName(ClassName, ref LicenseClassID, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClasses(ClassName, LicenseClassID, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            return null;
        }
        private bool _AddNewLicenseClass()
        {

            this.LicenseClassID = clsLicenseClassesData.AddNewLicenseClass(this.ClassName,this.ClassDescription,this.MinimumAllowedAge,this.DefaultValidityLength,this.ClassFees);
            return (this.LicenseClassID > 0);
        }
        private bool _UpdateLicenseClass()
        {
            return (clsLicenseClassesData.UpdateLicenseClass(this.LicenseClassID,this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees));
        }
        public bool Save()
        {
            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewLicenseClass())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;

                case enMode.Update:
                    if (_UpdateLicenseClass())
                    {
                        isSaved = true;
                    }
                    return isSaved;
            }
            return isSaved;
        }
        public static byte GetExpirationDate(int LicenseClassID)
        {
            return (clsLicenseClasses.Find(LicenseClassID)).DefaultValidityLength;
        }

    }

}

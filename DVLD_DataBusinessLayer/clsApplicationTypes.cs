using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataBusinessLayer
{
    public class clsApplicationTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFees { get; set; }

        public clsApplicationTypes()
        {
            this.ApplicationTypeID = 0;
            this.ApplicationTypeTitle = string.Empty;
            this.ApplicationTypeFees = 0;
            Mode= enMode.AddNew;
        }
        private clsApplicationTypes(int ID, string Title, decimal Fees)
        {
            this.ApplicationTypeID = ID;
            this.ApplicationTypeTitle = Title;
            this.ApplicationTypeFees = Fees;
            Mode=enMode.Update;
        }
        public static DataTable GetApplicationTypesList()
        {
            return clsApplicationTypesData.GetApplicationTypesList();
        }
        public bool _UpdateApplicationType()
        {
            return (clsApplicationTypesData.UpdateApplicationTypes(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationTypeFees));
        }
        public static clsApplicationTypes Find(int ApplicationTypeID)
        {
            string Title = "";
            decimal Fees = 0;
            if (clsApplicationTypesData.Find(ApplicationTypeID, ref Title, ref Fees))
            {
                return new clsApplicationTypes(ApplicationTypeID, Title, Fees);
            }
            return null;
        }

        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ApplicationTypeID = clsApplicationTypesData.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationTypeFees);
            return (this.ApplicationTypeID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }



    }
}

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
    public class clsPerson
    {
        private enum enMode { Add = 1, Update = 2 };
        private enMode Mode = enMode.Add;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get { return(FirstName + " " + SecondName + " " + ThirdName + " " + LastName); }
            
        }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public short NationalityCountryID { get; set; }
        private string _ImagePath { get; set; }
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsCountries CountryInfo;

        public clsPerson()
        {
            this.PersonID = 0;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.DateOfBirth = DateTime.MinValue;
            this.Gendor = -1;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.NationalityCountryID = 0;
            this.ImagePath = string.Empty;
            Mode = enMode.Add;
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, short Gendor, string Address, string Phone, string Email, short NationalCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalCountryID;
            this.ImagePath = ImagePath;
            CountryInfo = clsCountries.Find(NationalCountryID);
            Mode = enMode.Update;

        }
        public static bool DeletePerson(int PersonID)
        {
            return (clsPersonData.DeletePerson(PersonID));
        }
        private bool _AddNewPeople()
        {

            this.PersonID = clsPersonData.AddNewPeople(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            return (this.PersonID > 0);
        }
        private bool _UpdatePeople()
        {
            return (clsPersonData.UpdatePeople(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath));
        }
        public bool Save()
        {
            bool isSaved = false;
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewPeople())
                    {
                        isSaved = true;
                        Mode = enMode.Update;
                    }
                    return isSaved;

                case enMode.Update:
                    if (_UpdatePeople())
                    {
                        isSaved = true;
                    }
                    return isSaved;
            }
            return isSaved;
        }
        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            short Gendor = -1, NationalCountryID = 0;
            DateTime DateOfBirth = DateTime.MinValue, CreatedDate = DateTime.MinValue;
            if (clsPersonData.FindID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalCountryID, ImagePath);
            }
            return null;

        }
        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            short Gendor = -1, NationalCountryID = 0;
            int PersonID = 0;
            DateTime DateOfBirth = DateTime.MinValue, CreatedDate = DateTime.MinValue;
            if (clsPersonData.FindByNationalNo(NationalNo,ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalCountryID, ImagePath);
            }
            return null;

        }
        public static bool IsPersonExists(string NationalNo)
        {
            return clsPersonData.IsPersonExists(NationalNo);
        }
        public static bool IsPersonExists(int PersonID)
        {
            return clsPersonData.IsPersonExists(PersonID);
        }
        public static bool IsEmailExistsBefore(string Email)
        {
            return clsPersonData.IsEmailExistsBefore(Email);
        }
        public static DataTable GetPeopleList()
        {
            return clsPersonData.GetPeopleList();
        }


    }

}

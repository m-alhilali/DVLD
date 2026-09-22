using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataBusinessLayer
{
    public class clsCountries
    {
        public int CountryID {  get; set; }
        public string CountryName {  get; set; }
        private clsCountries(int CountryID,string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public clsCountries()
        {
            this.CountryID = 0;
            this.CountryName = "";
        }

        public static DataTable GetCountriesList()
        {
           return clsCountriesData.GetCountriesList();
        }
      
        public static clsCountries Find(string CountryName)
        {
            int CountryID = 0;
            if(clsCountriesData.FindCountry(CountryName, ref CountryID))
            {
                return new clsCountries(CountryID, CountryName);
            }
            return null;

        }
        public static clsCountries Find(int CountryID)
        {
            string CountryName = "";
            if(clsCountriesData.FindCountry(CountryID, ref CountryName))
            {
                return new clsCountries(CountryID, CountryName);
            }
            return null;

        }

    }
}

using DVLD.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DataAccessLayer.clsApplicationsData;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public class clsLicensesData
    {

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

            finally
            {
                connection.Close();
            }


            return LicenseID;
        }
        public static DataTable GetAllLicenses()
        {
            DataTable dtlist = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * from Licenses";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtlist.Load(reader);
                }
                else
                {
                    dtlist = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return dtlist;
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            DataTable dtlist = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select Licenses.LicenseID,ApplicationID,LicenseClasses.ClassName,IssueDate,ExpirationDate,IsActive
                             From Licenses join LicenseClasses on Licenses.LicenseClass= LicenseClasses.LicenseClassID
                             where DriverID=@DriverID
                             order by IsActive Desc, ExpirationDate Desc";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtlist.Load(reader);
                }
                else
                {
                    dtlist = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return dtlist;
        }
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID,DateTime IssueDate,DateTime ExpirationDate,string Notes,decimal PaidFees, bool IsActive,byte IssueReason,int CreatedByUserID)
        {
            int NewLicenseID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Insert Into Licenses
                             Values(@ApplicationID,@DriverID,@LicenseClassID,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID)
                              Select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicationID", ApplicationID);
            command.Parameters.AddWithValue(@"DriverID", DriverID);
            command.Parameters.AddWithValue(@"LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue(@"IssueDate", DateTime.Now);
            command.Parameters.AddWithValue(@"ExpirationDate", ExpirationDate);
            if (!string.IsNullOrWhiteSpace(Notes))
                command.Parameters.AddWithValue(@"Notes", Notes);
            else
                command.Parameters.AddWithValue(@"Notes", DBNull.Value);
            command.Parameters.AddWithValue(@"PaidFees", PaidFees);
            command.Parameters.AddWithValue(@"IsActive", IsActive);
            command.Parameters.AddWithValue(@"IssueReason", IssueReason);
            command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewLicenseID = insertedID;
                }

            }
            catch (Exception ex)
            {
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return NewLicenseID;
        }
        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            bool isUpdate = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Update Licenses
                             Set ApplicationID=@ApplicationID,DriverID=@DriverID,LicenseClassID=@LicenseClassID,IssueDate=@IssueDate,ExpirationDate=@ExpirationDate,Notes=@Notes,PaidFees=PaidFees,IsActive=@IsActive,IssueReason=@IssueReason,CreatedByUserID=@CreatedByUserID
                             Where LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicationID", ApplicationID);
            command.Parameters.AddWithValue(@"DriverID", DriverID);
            command.Parameters.AddWithValue(@"LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue(@"IssueDate", IssueDate);
            command.Parameters.AddWithValue(@"ExpirationDate", ExpirationDate);
            if (!string.IsNullOrWhiteSpace(Notes))
                command.Parameters.AddWithValue(@"Notes", Notes);
            else
                command.Parameters.AddWithValue(@"Notes", DBNull.Value);

            command.Parameters.AddWithValue(@"PaidFees", PaidFees);
            command.Parameters.AddWithValue(@"IsActive", IsActive);
            command.Parameters.AddWithValue(@"IssueReason", IssueReason);
            command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    isUpdate = true;
                }

            }
            catch (Exception ex)
            {
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return isUpdate;
        }
        public static bool DeactivateLicense(int LicenseID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);

            string query = @"UPDATE Licenses
                           SET 
                              IsActive = 0
                             
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool GetLicenseByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref int CreatedByUserID, ref decimal PaidFees, ref byte IssueReason, ref bool IsActive, ref string Notes, ref DateTime IssueDate, ref DateTime ExpirationDate)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"SELECT * FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClass"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                    IssueReason = Convert.ToByte(reader["IssueReason"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);

                    if (reader["Notes"] != DBNull.Value)
                        Notes = Convert.ToString(reader["Notes"]);
                    else
                        Notes = "";

                    IsFind = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
    

    }
}

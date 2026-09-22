using DVLD.GlobalClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DataAccessLayer.clsApplicationsData;

namespace DVLD_DataAccessLayer
{
    public class clsApplicationsData
    {

        public static bool FindApplication(int ApplicationID,ref int ApplicationPersonID,ref int ApplicationTypeID,ref int CreatedByUserID,ref byte ApplicationStatus,ref decimal PaidFees,ref DateTime ApplicationDate,ref DateTime LastStatusDate)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From Applications
                             Where Applications.ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ApplicationPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                    ApplicationTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]);
                    PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                    ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                    LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
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
        public static bool DosePersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) > -1);
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            int result = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Delete Applications
                              Where ApplicationID=@ApplicationID)";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return (result > 0);
        }
        public static bool UpdateStatus(int ApplicationID, byte ApplicationStatus)
        {
            int NewPersonID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Update Applications
                             Set ApplicationStatus=@ApplicationStatus,
                                 LastStatusDate=@LastStatusDate
                            Where ApplicationID=@ApplicationID
                             ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicationID", ApplicationID);
            command.Parameters.AddWithValue(@"ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue(@"LastStatusDate", DateTime.Now);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result>0)
                {
                    NewPersonID = result;
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
            return (NewPersonID>0);
        }
        public static bool UpdateApplication(int ApplicationID,int ApplicationPersonID, int ApplicationTypeID, int CreatedByUserID, byte ApplicationStatus, decimal PaidFees)
        {
            int NewPersonID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Update Applications
                             Set ApplicantPersonID=@ApplicantPersonID,ApplicationTypeID=@ApplicationTypeID,ApplicationStatus=@ApplicationStatus,LastStatusDate=@LastStatusDate,PaidFees=@PaidFees ,CreatedByUserID=@CreatedByUserID
                              Where ApplicationID=@ApplicationID
                             ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicationID", ApplicationID);
            command.Parameters.AddWithValue(@"ApplicantPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue(@"ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue(@"ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue(@"LastStatusDate", DateTime.Now);
            command.Parameters.AddWithValue(@"PaidFees", PaidFees);
            command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result>0)
                {
                    NewPersonID = result;
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
            return (NewPersonID>0);
        }
        public static int AddNewApplication(int ApplicationPersonID, int ApplicationTypeID, int CreatedByUserID, byte ApplicationStatus, decimal PaidFees)
        {
            int NewApplicationID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Insert Into Applications
                             Values(@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees ,@CreatedByUserID)
                              Select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicantPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue(@"ApplicationDate", DateTime.Now);
            command.Parameters.AddWithValue(@"ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue(@"ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue(@"LastStatusDate", DateTime.Now);
            command.Parameters.AddWithValue(@"PaidFees", PaidFees);
            command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewApplicationID = insertedID;
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
            return NewApplicationID;
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID,int LicenseClassID)
        {
            int ActiveApplicationID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select ActiveApplicationID=Applications.ApplicationID From Applications
                             join LocalDrivingLicenseApplications On Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID
                              Where Applications.ApplicantPersonID=@PersonID and Applications.ApplicationTypeID=@ApplicationTypeID
                              and  LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID and ApplicationStatus=1";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"PersonID", PersonID);
            command.Parameters.AddWithValue(@"LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue(@"ApplicationTypeID", ApplicationTypeID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    ActiveApplicationID = Convert.ToInt32(result);
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
            return (ActiveApplicationID);
        }
        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select ActiveApplicationID=ApplicationID From Applications 
                              Where ApplicantPersonID=@PersonID and ApplicationTypeID=@ApplicationTypeID and  ApplicationStatus=1";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"PersonID", PersonID);
            command.Parameters.AddWithValue(@"ApplicationTypeID", ApplicationTypeID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    ActiveApplicationID = Convert.ToInt32(result);
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
            return (ActiveApplicationID);
        }
        public static bool IsApplicationExists(int ApplicationID)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select Found=1 From Applications 
                              Where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isFind = Convert.ToInt32(result);
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
            return (isFind>0);
        }


    }
}

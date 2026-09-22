using DVLD.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsInternationalLicensesData
    {

      
        public static bool GetInternationalLicenseInfoByID(int InternationalLicenseID,ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime ExpirationDate, ref DateTime IssueDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * from InternationalLicenses
                         WHERE InternationalLicenseID=@InternationalLicenseID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"InternationalLicenseID", InternationalLicenseID);

            try
            {
                 connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);

                    IsFind = true;
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
            return IsFind;
        }
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,DateTime ExpirationDate,DateTime IssueDate,  bool IsActive,int CreatedByUserID)
        {
            int NewInternationalID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @" Update InternationalLicenses 
                               set IsActive=0
                               where DriverID=@DriverID;

                             INSERT INTO InternationalLicenses
                               (
                                ApplicationID,
                                DriverID,
                                IssuedUsingLocalLicenseID,
                                IssueDate,
                                ExpirationDate,
                                IsActive,
                                CreatedByUserID)
                         VALUES
                               (@ApplicationID,
                                @DriverID,
                                @IssuedUsingLocalLicenseID,
                                @IssueDate,
                                @ExpirationDate,
                                @IsActive,
                                @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicationID", ApplicationID);
            command.Parameters.AddWithValue(@"DriverID", DriverID);
            command.Parameters.AddWithValue(@"IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue(@"ExpirationDate", DateTime.Now.AddYears(1));
            command.Parameters.AddWithValue(@"IssueDate", DateTime.Now);
            command.Parameters.AddWithValue(@"IsActive", IsActive);
            command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewInternationalID = insertedID;
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
            return NewInternationalID;
        }
        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime ExpirationDate, DateTime IssueDate, bool IsActive, int CreatedByUserID)
        {
            bool isUpdate = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"UPDATE InternationalLicenses
                           SET 
                              ApplicationID=@ApplicationID,
                              DriverID = @DriverID,
                              IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              IsActive = @IsActive,
                              CreatedByUserID = @CreatedByUserID
                         WHERE InternationalLicenseID=@InternationalLicenseID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue(@"ApplicationID", ApplicationID);
            command.Parameters.AddWithValue(@"DriverID", DriverID);
            command.Parameters.AddWithValue(@"IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue(@"ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue(@"IssueDate", IssueDate);
            command.Parameters.AddWithValue(@"IsActive", IsActive);
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

        public static bool IsDriverHaseLicenseFromTypeOrdinary(int LicenseID)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @" Select FindByID = 1 From Licenses
                              where LicenseID = @LicenseID and LicenseClass = 3";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"LicenseID", LicenseID);
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
            return (isFind > 0);
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"SELECT Top 1 InternationalLicenseID
                            FROM InternationalLicenses 
                            where DriverID=@DriverID and GetDate() between IssueDate and ExpirationDate 
                            order by ExpirationDate Desc";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"DriverID", DriverID);
            try
            {
                connection.Open();
                object resultquery = command.ExecuteScalar();
                if (resultquery != null && int.TryParse(Convert.ToString(resultquery),out int SelectedResult))
                {
                    InternationalLicenseID = SelectedResult;
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
            return (InternationalLicenseID);
        }
        public static decimal GetInternationaltApplicationFees(int ApplicationTypeID)
        {
            decimal result = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select ApplicationTypes.ApplicationFees from ApplicationTypes
                             Where ApplicationTypeID =@ApplicationTypeID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicationTypeID", ApplicationTypeID);
            try
            {
                connection.Open();
                object resultquery = command.ExecuteScalar();
                if (resultquery != null)
                {
                    result = Convert.ToDecimal(resultquery);
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
            return (result);
        }
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dtlist = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"SELECT    InternationalLicenseID, ApplicationID,DriverID,
		                IssuedUsingLocalLicenseID , IssueDate, 
                        ExpirationDate, IsActive
		    from InternationalLicenses 
                order by IsActive, ExpirationDate desc";
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
        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            DataTable dtlist = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @" SELECT    InternationalLicenseID, ApplicationID,
		                IssuedUsingLocalLicenseID , IssueDate, 
                        ExpirationDate, IsActive
		    from InternationalLicenses where DriverID=@DriverID
                order by ExpirationDate desc";
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
        public static DataTable GetDriverInternationalLicenseInfo(int InternationalLicenseID)
        {
            DataTable dtlist = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From InternationalLicensesCardInfo_View 
                             where InternationalLicenseID=@InternationalLicenseID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"InternationalLicenseID", InternationalLicenseID);
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


    }

}

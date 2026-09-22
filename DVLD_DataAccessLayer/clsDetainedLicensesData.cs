using DVLD.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDetainedLicensesData
    {
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dtlist = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From DetainedLicenses_View order by IsReleased ,DetainID";
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
        public static bool ReleaseDetainLicense(int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int IsRealsed = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Update DetainedLicenses
                             Set IsReleased=1,ReleaseDate=@ReleaseDate,ReleasedByUserID=@ReleasedByUserID,ReleaseApplicationID=@ReleaseApplicationID
                              Where DetainID=@DetainID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"DetainID", DetainID);
            command.Parameters.AddWithValue(@"ReleaseDate", DateTime.Now);
            command.Parameters.AddWithValue(@"ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue(@"ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >0)
                {
                    IsRealsed = Convert.ToInt32(result);
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
            return (IsRealsed>0);
        }
        public static bool UdateDetainLicense(int DetainID,int LicenseID, DateTime DetainDate,decimal FineFees, int CreatedByUserID)
        {
            bool IsUpdate = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"UPDATE DetainedLicenses
                              SET LicenseID = @LicenseID, 
                              DetainDate = @DetainDate, 
                              FineFees = @FineFees,
                              CreatedByUserID = @CreatedByUserID,   
                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DetainedLicenseID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >0 )
                {
                    IsUpdate = true;
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
            return IsUpdate;
        }
        public static int AddNewDetainLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID)
        {
            int NewDetainID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Insert Into DetainedLicenses
                             (LicenseID,
                               DetainDate,
                               FineFees,
                               CreatedByUserID,
                               IsReleased
                               )
                            VALUES
                               (@LicenseID,
                               @DetainDate, 
                               @FineFees, 
                               @CreatedByUserID,
                               0)
                              Select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewDetainID = insertedID;
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
            return NewDetainID;
        }
        public static bool IsLicenseDetaind(int LicenseID)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select IsDetained=1 From DetainedLicenses 
                              Where LicenseID=@LicenseID and IsReleased=0";
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
        public static bool FindByDetainID(int DetainID,ref int LicenseID,ref DateTime DetainDate,ref decimal FineFees,ref int CreatedByUserID,ref bool IsReleased,ref DateTime ReleaseDate,ref int ReleasedByUserID,ref int ReleaseApplicationID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select top 1 * From DetainedLicenses
                             Where DetainID=@DetainID
                              order by DetainID desc";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"DetainID", DetainID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                    FineFees = Convert.ToDecimal(reader["FineFees"]);
                    IsReleased = Convert.ToBoolean(reader["IsReleased"]);

                    if (reader["ReleasedByUserID"] != DBNull.Value)
                        ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);
                    else
                        ReleasedByUserID = -1;

                    if (reader["ReleaseApplicationID"] != DBNull.Value)
                        ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                    else
                        ReleaseApplicationID = -1;

                    if (reader["ReleaseDate"] != DBNull.Value)
                        ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                    else
                        ReleaseDate = DateTime.MinValue;

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
        public static bool FindByLicenseID(int LicenseID,ref int DetainID,ref DateTime DetainDate,ref decimal FineFees,ref int CreatedByUserID,ref bool IsReleased,ref DateTime ReleaseDate,ref int ReleasedByUserID,ref int ReleaseApplicationID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select top 1 * From DetainedLicenses
                             Where LicenseID=@LicenseID
                              order by DetainID desc";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    DetainID = Convert.ToInt32(reader["DetainID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                    FineFees = Convert.ToDecimal(reader["FineFees"]);
                    IsReleased = Convert.ToBoolean(reader["IsReleased"]);

                    if (reader["ReleasedByUserID"] != DBNull.Value)
                        ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);
                    else
                        ReleasedByUserID = -1;

                    if (reader["ReleaseApplicationID"] != DBNull.Value)
                        ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                    else
                        ReleaseApplicationID = -1;

                    if (reader["ReleaseDate"] != DBNull.Value)
                        ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                    else
                        ReleaseDate = DateTime.MinValue;

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

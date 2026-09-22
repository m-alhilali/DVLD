using DVLD.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DataAccessLayer.clsApplicationsData;

namespace DVLD_DataAccessLayer
{
    public class clsTestAppointmentsData
    {
        public static bool GetLastTestAppointment(
           int LocalDrivingLicenseApplicationID, int TestTypeID,
          ref int TestAppointmentID, ref DateTime AppointmentDate,
          ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);

            string query = @"SELECT       top 1 *
                FROM            TestAppointments
                WHERE        (TestTypeID = @TestTypeID) 
                AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                order by TestAppointmentID Desc";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];


                }
                else
                {
                    isFound = false;
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

            return isFound;
        }
        public static bool UpdateTestAppointment(int TestAppointmentID,int TestTypeID, int LocalDrivingLicenseApplicationID, int CreatedByUserID, int RetakeTestApplicationID, decimal PaidFees, DateTime AppointmentDate, bool IsLocked)
        {
            bool isUpdate = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Update TestAppointments
                             Set TestTypeID=@TestTypeID,LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID,
                             CreatedByUserID=@CreatedByUserID,PaidFees=@PaidFees,AppointmentDate=@AppointmentDate,IsLocked=@IsLocked,
                             RetakeTestApplicationID=@RetakeTestApplicationID
                             Where TestAppointmentID=@TestAppointmentID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue(@"TestTypeID", TestTypeID);
            command.Parameters.AddWithValue(@"LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue(@"PaidFees", PaidFees);
            command.Parameters.AddWithValue(@"AppointmentDate", AppointmentDate);
            if (RetakeTestApplicationID > 0)
            {
                command.Parameters.AddWithValue(@"RetakeTestApplicationID", RetakeTestApplicationID);
            }
            else
            {
                command.Parameters.AddWithValue(@"RetakeTestApplicationID", DBNull.Value);
            }
            command.Parameters.AddWithValue(@"IsLocked", IsLocked);

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
        public static int AddNewTestApointment(int TestTypeID, int LocalDrivingLicenseApplicationID, int CreatedByUserID, int RetakeTestApplicationID, decimal PaidFees, DateTime AppointmentDate, bool IsLocked)
        {
            int NewTestAppointmentID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Insert Into TestAppointments
                             Values(@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@IsLocked ,@RetakeTestApplicationID)
                              Select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"TestTypeID", TestTypeID);
            command.Parameters.AddWithValue(@"LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue(@"PaidFees", PaidFees);
            command.Parameters.AddWithValue(@"AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue(@"IsLocked", IsLocked);//Optional in database it's result false(0)
            if (RetakeTestApplicationID > 0)
            {
                command.Parameters.AddWithValue(@"RetakeTestApplicationID", RetakeTestApplicationID);
            }
            else
            {
                command.Parameters.AddWithValue(@"RetakeTestApplicationID", DBNull.Value);
            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewTestAppointmentID = insertedID;
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
            return NewTestAppointmentID;
        }

        public static bool FindTestAppointmentByID(int TestAppointmentID,ref int TestTypeID,ref int LocalDrivingLicenseApplicationID,ref int CreatedByUserID,ref int RetakeTestApplicationID,ref decimal PaidFees,ref DateTime AppointmentDate,ref bool IsLocked)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From TestAppointments
                             Where TestAppointmentID=@TestAppointmentID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                    LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    IsLocked = Convert.ToBoolean(reader["IsLocked"]);

                    if (reader["RetakeTestApplicationID"] != DBNull.Value)
                        RetakeTestApplicationID = Convert.ToInt32(reader["RetakeTestApplicationID"]);
                    else
                        RetakeTestApplicationID = -1;

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
        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);

            string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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


            return TestID;

        }

        public static DataTable GetAllTestAppointments()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);

            string query = @"select * from TestAppointments_View
                                  order by AppointmentDate Desc";


            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
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

            return dt;

        }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);

            string query = @"SELECT TestAppointmentID, AppointmentDate,PaidFees, IsLocked
                        FROM TestAppointments
                        WHERE  
                        (TestTypeID = @TestTypeID) 
                        AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                        order by TestAppointmentID desc;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
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

            return dt;

        }


    }

}

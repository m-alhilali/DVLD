using DVLD.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static DVLD.GlobalClasses.clsEventLog;

namespace DVLD_DataAccessLayer
{

    public class clsDriversData
    {

        public static DataTable GetDriversList()
        {
            DataTable dtlist = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From Drivers_View order by FullName";
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
            catch(Exception ex) 
            {
                clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return dtlist;
        }
        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From Drivers 
                             Where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
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
        public static bool GetDriverInfoByDriverID( int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From Drivers 
                             Where DriverID=@DriverID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
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
        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {
            int NewDriverID=0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Update Drivers
                            Set PersonID=@PersonID,CreatedByUserID=@CreatedByUserID
                             Where DriverID=@DriverID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"DriverID", DriverID);
            command.Parameters.AddWithValue(@"PersonID", PersonID);
            command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result>0)
                {
                    NewDriverID=(result);
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
            return NewDriverID>0;
        }
        public static int AddNewDriver(int PersonID,int CreatedByUserID)
        {
            int NewDriverID=-1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Insert Into Drivers
                             Values(@PersonID,@CreatedByUserID,@CreatedDate)
                             Select SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"PersonID", PersonID);
            command.Parameters.AddWithValue(@"CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue(@"CreatedDate", DateTime.Now);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null&&int.TryParse(result.ToString(),out int insertedID))
                {
                    NewDriverID= insertedID;
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
            return NewDriverID;
        }


    }

}

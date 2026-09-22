using DVLD.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsRememberLoginData
    {
        public static bool IsUserExists(string MashineName)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select Finde=1 From RememberLogin 
                              Where MashineName=@MashineName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"MashineName", MashineName);
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
        public static bool IsUserExists(int UserID)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select Finde=1 From RememberLogin 
                              Where UserID=@UserID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"UserID", UserID);
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

        public static int AddNewRememberLogin(int UserID,string MashineName, bool IsRemeberMe)
        {

            int NewPersonID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Insert Into RememberLogin
                             Values(@UserID,@MashineName,@IsRemeberMe)
                              Select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"UserID", UserID);
            command.Parameters.AddWithValue(@"IsRemeberMe", IsRemeberMe);
            command.Parameters.AddWithValue(@"MashineName", MashineName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    NewPersonID = Convert.ToInt32(result);
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
            return NewPersonID;
        }

        public static bool UpdateIsRemeberMe(int UserID, bool IsRemeberMe)
        {
            bool isUpdate = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Update RememberLogin
                             Set IsRemeberMe=@IsRemeberMe
                             Where UserID=@UserID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"UserID", UserID);
            command.Parameters.AddWithValue(@"IsRemeberMe", IsRemeberMe);
           

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

        public static bool IsRemeberMe(string MashineName)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select IsRemeberMe From RememberLogin 
                              Where MashineName=@MashineName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"MashineName", MashineName);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isFind = Convert.ToBoolean(result);
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
            return (isFind);
        }
        public static bool IsRemeberMe(int UserID)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select IsRemeberMe From RememberLogin 
                              Where UserID=@UserID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"UserID", UserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isFind = Convert.ToBoolean(result);
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
            return (isFind);
        }

        public static bool FindByUserID(int UserID, ref string MashineName, ref int RememberLoginID, ref bool IsRemeberMe)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From RememberLogin
                             Where RememberLogin.UserID=@UserID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"UserID", UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    RememberLoginID = Convert.ToInt32(reader["RememberLoginID"]);
                    IsRemeberMe = Convert.ToBoolean(reader["IsRemeberMe"]);
                    MashineName = Convert.ToString(reader["MashineName"]);

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
        public static bool FindByMashineName(string MashineName,ref int UserID, ref int RememberLoginID, ref bool IsRemeberMe)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From RememberLogin
                             Where RememberLogin.MashineName=@MashineName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"MashineName", MashineName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    RememberLoginID = Convert.ToInt32(reader["RememberLoginID"]);
                    UserID = Convert.ToInt32(reader["UserID"]);
                    IsRemeberMe = Convert.ToBoolean(reader["IsRemeberMe"]);
                    MashineName = Convert.ToString(reader["MashineName"]);

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

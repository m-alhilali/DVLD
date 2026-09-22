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
    public class clsApplicationTypesData
    {
        public static DataTable GetApplicationTypesList()
        {
            DataTable dtlist = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From ApplicationTypes";
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
        public static int AddNewApplicationType(string Title, decimal Fees)
        {
            int NewApplicationTypeID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);

            string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            Values (@Title,@Fees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewApplicationTypeID = insertedID;
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


            return NewApplicationTypeID;

        }

        public static bool UpdateApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            bool isUpdate = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Update ApplicationTypes
                             Set ApplicationTypeTitle=@ApplicationTypeTitle,ApplicationFees=@ApplicationFees
                             Where NewApplicationTypeID=@NewApplicationTypeID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue(@"NewApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue(@"ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue(@"ApplicationFees", ApplicationFees);
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

        public static bool Find(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationTypeFees)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From ApplicationTypes
                             Where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ApplicationTypeID", ApplicationTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ApplicationTypeFees = Convert.ToDecimal(reader["ApplicationFees"]);
                    ApplicationTypeTitle = Convert.ToString(reader["ApplicationTypeTitle"]);
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

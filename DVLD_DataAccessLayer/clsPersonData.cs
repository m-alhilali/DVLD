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
    public class clsPersonData
    {
        public static bool FindID(int PersonID, ref string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
             ref short Gendor, ref string Address, ref string Phone, ref string Email, ref short NationalCountryID,
             ref string ImagePath)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From People
                             Where People.PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    NationalNo = Convert.ToString(reader["NationalNo"]);
                    FirstName = Convert.ToString(reader["FirstName"]);
                    SecondName = Convert.ToString(reader["SecondName"]);
                    LastName = Convert.ToString(reader["LastName"]);
                    Phone = Convert.ToString(reader["Phone"]);
                    Address = Convert.ToString(reader["Address"]);
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    NationalCountryID = Convert.ToInt16(reader["NationalityCountryID"]);
                    Gendor = Convert.ToInt16(reader["Gendor"]);

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = Convert.ToString(reader["ThirdName"]);
                    else
                        ThirdName = "";

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = Convert.ToString(reader["ImagePath"]);
                    else
                        ImagePath = "";

                    if (reader["Email"] != DBNull.Value)
                        Email = Convert.ToString(reader["Email"]);
                    else
                        Email = "";

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

        public static bool FindByNationalNo(string NationalNo, ref int PersonID, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref short Gendor, ref string Address, ref string Phone, ref string Email, ref short NationalCountryID, ref string ImagePath)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From People
                             Where People.NationalNo=@NationalNo";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    FirstName = Convert.ToString(reader["FirstName"]);
                    SecondName = Convert.ToString(reader["SecondName"]);
                    LastName = Convert.ToString(reader["LastName"]);
                    Phone = Convert.ToString(reader["Phone"]);
                    Address = Convert.ToString(reader["Address"]);
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    NationalCountryID = Convert.ToInt16(reader["NationalityCountryID"]);
                    Gendor = Convert.ToInt16(reader["Gendor"]);

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = Convert.ToString(reader["ThirdName"]);
                    else
                        ThirdName = "";

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = Convert.ToString(reader["ImagePath"]);
                    else
                        ImagePath = "";

                    if (reader["Email"] != DBNull.Value)
                        Email = Convert.ToString(reader["Email"]);
                    else
                        Email = "";

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

        public static bool UpdatePeople(int PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,short Gendor,
            string Address, string Phone, string Email, short NationalCountryID, string ImagePath)
        {
            bool isUpdate = false;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Update People
                             Set NationalNo=@NationalNo,FirstName=@FirstName,SecondName=@SecondName,ThirdName=@ThirdName,LastName=@LastName,DateOfBirth=@DateOfBirth ,
                             Gendor=@Gendor,Address=@Address,Phone=@Phone,Email=@Email,NationalityCountryID=@NationalityCountryID,ImagePath=@ImagePath
                             Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"PersonID", PersonID);
            command.Parameters.AddWithValue(@"NationalNo", NationalNo);
            command.Parameters.AddWithValue(@"FirstName", FirstName);
            command.Parameters.AddWithValue(@"SecondName", SecondName);
            command.Parameters.AddWithValue(@"LastName", LastName);
            command.Parameters.AddWithValue(@"Gendor", Gendor);
            command.Parameters.AddWithValue(@"DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue(@"Address", Address);
            command.Parameters.AddWithValue(@"Phone", Phone);
            command.Parameters.AddWithValue(@"NationalityCountryID", NationalCountryID);
            if (Email != "" || Email != null)
            {
                command.Parameters.AddWithValue(@"Email", Email);
            }
            else
            {
                command.Parameters.AddWithValue(@"Email", DBNull.Value);
            }

            if (ThirdName != "" || ThirdName != null)
            { command.Parameters.AddWithValue(@"ThirdName", ThirdName); }
            else
            { command.Parameters.AddWithValue(@"ThirdName", DBNull.Value); }

            if (ImagePath != "" || ImagePath != null)
            { command.Parameters.AddWithValue(@"ImagePath", ImagePath); }
            else
            { command.Parameters.AddWithValue(@"ImagePath", DBNull.Value); }

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

        public static int AddNewPeople(string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, short Gendor, string Address,
            string Phone, string Email, short NationalCountryID, string ImagePath)
        {
            int NewPersonID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Insert Into People
                             Values(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth ,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath)
                              Select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"NationalNo", NationalNo);
            command.Parameters.AddWithValue(@"FirstName", FirstName);
            command.Parameters.AddWithValue(@"SecondName", SecondName);
            command.Parameters.AddWithValue(@"LastName", LastName);
            command.Parameters.AddWithValue(@"Gendor", Gendor);
            command.Parameters.AddWithValue(@"DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue(@"Address", Address);
            command.Parameters.AddWithValue(@"Phone", Phone);
            command.Parameters.AddWithValue(@"NationalityCountryID", NationalCountryID);
            if (Email != "" || Email != null)
            {
                command.Parameters.AddWithValue(@"Email", Email);
            }
            else
            {
                command.Parameters.AddWithValue(@"Email", DBNull.Value);
            }

            if (ThirdName != "" || ThirdName != null)
            { command.Parameters.AddWithValue(@"ThirdName", ThirdName); }
            else
            { command.Parameters.AddWithValue(@"ThirdName", DBNull.Value); }

            if (ImagePath != "" || ImagePath != null)
            { command.Parameters.AddWithValue(@"ImagePath", ImagePath); }
            else
            { command.Parameters.AddWithValue(@"ImagePath", DBNull.Value); }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewPersonID = insertedID;
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

        public static DataTable GetPeopleList()
        {
            DataTable dtlist = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select * From People_View ";
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

        public static bool IsPersonExists(int PersonID)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select Finde=1 From People 
                              Where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"PersonID", PersonID);
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
        public static bool IsPersonExists(string NationalNo)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select Finde=1 From People 
                              Where NationalNo=@NationalNo";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"NationalNo", NationalNo);
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


        public static bool IsPersonHasUser(string NationalNo)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select FindByID=1 From People Join Users On Users.PersonID=People.PersonID
                             Where People.NationalNo=@NationalNo";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"NationalNo", NationalNo);
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
        public static bool DeletePerson(int PersonID)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Delete People 
                              Where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"PersonID", PersonID);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >0)
                {
                    isFind = (result);
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

        public static bool IsEmailExistsBefore(string Email)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select Finde=1 From People 
                              Where Email=@Email";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"Email", Email);
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
        public static bool IsNationalNoExistsBefore(string NationalNo)
        {
            int isFind = 0;
            SqlConnection connection = new SqlConnection(DataAccessSitting.DataSitting);
            string Query = @"Select Finde=1 From People 
                              Where NationalNo=@NationalNo";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"NationalNo", NationalNo);
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
    }

}

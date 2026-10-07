using DataAccessLayer.DataAccess.DatabaseConfig;
using DataAccessLayer.DataAccess.DatabaseConfig.DataConnections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ContactDB
    {
        public static int AddNew(DTOs.ContactDTO contact)
        {
            int NewContactId = -1;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = Contact_Queries.AddNewContact.ToString();
                        cmd.Connection = connection;

                        SqlParameter
                            FirstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50),
                            LastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar, 50),
                            EmailParameter = new SqlParameter("@Email", SqlDbType.NVarChar, 100),
                            PhoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 20),
                            AddressParameter = new SqlParameter("@Address", SqlDbType.NVarChar, 200),
                            CountryIDParameter = new SqlParameter("@CountryID", SqlDbType.Int),
                            ImageIDParameter = new SqlParameter("@ImageID", SqlDbType.Int),
                            DateOfBirthParameter = new SqlParameter("@DateOfBirth", SqlDbType.DateTime);

                        if (!string.IsNullOrEmpty(contact.FirstName))
                            FirstNameParameter.Value = contact.FirstName;
                        else
                            FirstNameParameter.Value = DBNull.Value;

                        if (!string.IsNullOrEmpty(contact.LastName))
                            LastNameParameter.Value = contact.LastName;
                        else
                            LastNameParameter.Value = DBNull.Value;

                        if (!string.IsNullOrEmpty(contact.Email))
                            EmailParameter.Value = contact.Email;
                        else
                            EmailParameter.Value = DBNull.Value;

                        if (!string.IsNullOrEmpty(contact.Phone))
                            PhoneParameter.Value = contact.Phone;
                        else
                            PhoneParameter.Value = DBNull.Value;

                        if (!string.IsNullOrEmpty(contact.Address))
                            AddressParameter.Value = contact.Address;
                        else
                            AddressParameter.Value = DBNull.Value;

                        if (contact.DateOfBirth == null)
                            DateOfBirthParameter.Value = DBNull.Value;
                        else
                            DateOfBirthParameter.Value = contact.DateOfBirth;

                        if (contact.ImageID > 0)
                            ImageIDParameter.Value = contact.ImageID;
                        else 
                            ImageIDParameter.Value = DBNull.Value;

                        if (contact.CountryID > 0)
                            CountryIDParameter.Value = contact.CountryID;
                        else CountryIDParameter.Value = DBNull.Value;

                        cmd.Parameters.Add(FirstNameParameter);
                        cmd.Parameters.Add(LastNameParameter);
                        cmd.Parameters.Add(EmailParameter);
                        cmd.Parameters.Add(PhoneParameter);
                        cmd.Parameters.Add(AddressParameter);
                        cmd.Parameters.Add(CountryIDParameter);
                        cmd.Parameters.Add(DateOfBirthParameter);
                        cmd.Parameters.Add(ImageIDParameter);

                        object result = cmd.ExecuteScalar();

                        if (result != null) NewContactId = (int)result;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NewContactId;
        }

        public static bool Delete(int id)
        {
            bool DeletedRecord = false;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection())
                {
                    connection.ConnectionString = ContactsDB_Connection.ContactsDBConnectionString;
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = Contact_Queries.DeleteContact;
                        cmd.Connection = connection;

                        SqlParameter
                            IDParameter = new SqlParameter("@ID", SqlDbType.Int);
                        IDParameter.Value = id;

                        cmd.Parameters.Add(IDParameter);

                        DeletedRecord = cmd.ExecuteNonQuery() > 0;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DeletedRecord;
        }

        public static IEnumerable<DTOs.ContactDTO> GetAll()
        {
            List<DTOs.ContactDTO> allContacts = new List<DTOs.ContactDTO>();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                using (SqlCommand cmd =
                    new SqlCommand(Contact_Queries.GetAll, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTOs.ContactDTO contact = new DTOs.ContactDTO
                            {
                                ID = (int)reader["ContactID"],
                                FirstName = (reader["FirstName"] != DBNull.Value) ? (string)reader["FirstName"] : string.Empty,
                                LastName = (reader["LastName"] != DBNull.Value) ? (string)reader["LastName"] : string.Empty,
                                Email = (reader["Email"] != DBNull.Value) ? (string)reader["Email"] : string.Empty,
                                Phone = (reader["Phone"] != DBNull.Value) ? (string)reader["Phone"] : string.Empty,
                                Address = (reader["Address"] != DBNull.Value) ? (string)reader["Address"] : string.Empty
                            };

                            if (reader["CountryID"] != DBNull.Value) contact.CountryID = (int)reader["CountryID"];
                            if (reader["Date Of Birth"] != DBNull.Value) contact.DateOfBirth = (DateTime)reader["Date Of Birth"];
                            if (reader["ImageID"] != DBNull.Value) contact.ImageID = (int)reader["ImageID"];

                            allContacts.Add(contact);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return allContacts;
        }

        public static DTOs.ContactDTO GetById(int id)
        {

            DTOs.ContactDTO dtoContact = null;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                using (SqlCommand cmd =
                    new SqlCommand(Contact_Queries.GetContactByID, connection))
                {
                    connection.Open();

                    SqlParameter IDParameter = new SqlParameter("@ContactID", SqlDbType.Int);
                    IDParameter.Value = id;

                    cmd.Parameters.Add(IDParameter);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            dtoContact = new DTOs.ContactDTO
                            {
                                ID = (int)reader["ContactID"],
                                FirstName = (reader["FirstName"] != DBNull.Value) ? (string)reader["FirstName"] : string.Empty,
                                LastName = (reader["LastName"] != DBNull.Value) ? (string)reader["LastName"] : string.Empty,
                                Email = (reader["Email"] != DBNull.Value) ? (string)reader["Email"] : string.Empty,
                                Phone = (reader["Phone"] != DBNull.Value) ? (string)reader["Phone"] : string.Empty,
                                Address = (reader["Address"] != DBNull.Value) ? (string)reader["Address"] : string.Empty,
                                
                            };

                            if (reader["Date Of Birth"] != DBNull.Value)
                                dtoContact.DateOfBirth = (DateTime)reader["Date Of Birth"];
                            else dtoContact.DateOfBirth = null;

                            if (reader["CountryID"] != DBNull.Value) 
                                dtoContact.CountryID = (int)reader["CountryID"];
                            else 
                                dtoContact = null;

                            if (reader["ImageID"] != DBNull.Value)
                                dtoContact.ImageID = (int)reader["ImageID"];

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dtoContact;
        }

        public static bool Update(DTOs.ContactDTO contact)
        {

            int RowsEffected = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd =
                       new SqlCommand(Contact_Queries.Update, connection))
                    {

                        SqlParameter
                            contactIDParameter = new SqlParameter("@ContactID", SqlDbType.Int),
                            FirstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50),
                            LastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar, 50),
                            EmailParameter = new SqlParameter("@Email", SqlDbType.NVarChar, 100),
                            PhoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 20),
                            AddressParameter = new SqlParameter("@Address", SqlDbType.NVarChar, 200),
                            CountryIDParameter = new SqlParameter("@CountryID", SqlDbType.Int),
                            ImageIDParameter = new SqlParameter("@ImageID", SqlDbType.Int),
                            DateOfBirthParameter = new SqlParameter("@DateOfBirth", SqlDbType.DateTime);

                        contactIDParameter.Value = contact.ID;

                        if (!string.IsNullOrEmpty(contact.FirstName))
                            FirstNameParameter.Value = contact.FirstName;
                        else
                            FirstNameParameter.Value = DBNull.Value;

                        if (!string.IsNullOrEmpty(contact.LastName))
                            LastNameParameter.Value = contact.LastName;
                        else
                            LastNameParameter.Value = DBNull.Value;

                        if (!string.IsNullOrEmpty(contact.Email))
                            EmailParameter.Value = contact.Email;
                        else
                            EmailParameter.Value = DBNull.Value;

                        if (!string.IsNullOrEmpty(contact.Phone))
                            PhoneParameter.Value = contact.Phone;
                        else
                            PhoneParameter.Value = DBNull.Value;

                        if (!string.IsNullOrEmpty(contact.Address))
                            AddressParameter.Value = contact.Address;
                        else
                            AddressParameter.Value = DBNull.Value;

                        if (contact.DateOfBirth == null)
                            DateOfBirthParameter.Value = DBNull.Value;
                        else
                            DateOfBirthParameter.Value = contact.DateOfBirth;

                        if (contact.ImageID > 0)
                            ImageIDParameter.Value = contact.ImageID;
                        else
                            ImageIDParameter.Value = DBNull.Value;

                        if (contact.CountryID > 0)
                            CountryIDParameter.Value = contact.CountryID;
                        else CountryIDParameter.Value = DBNull.Value;



                        cmd.Parameters.Add(contactIDParameter);
                        cmd.Parameters.Add(FirstNameParameter);
                        cmd.Parameters.Add(LastNameParameter);
                        cmd.Parameters.Add(EmailParameter);
                        cmd.Parameters.Add(PhoneParameter);
                        cmd.Parameters.Add(AddressParameter);
                        cmd.Parameters.Add(CountryIDParameter);
                        cmd.Parameters.Add(DateOfBirthParameter);
                        cmd.Parameters.Add(ImageIDParameter);

                        RowsEffected = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RowsEffected > 0;

        }

        public static bool IsContactExist(int ContactID)
        {

            bool Found = false;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd =
                       new SqlCommand(Contact_Queries.IsContactExisit, connection))
                    {

                        SqlParameter
                            ContactIDParameter = new SqlParameter("@ContactID", SqlDbType.Int);

                        ContactIDParameter.Value = ContactID;

                        cmd.Parameters.Add(ContactIDParameter);

                        Found = cmd.ExecuteScalar() != null;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Found;

        }

    }

}

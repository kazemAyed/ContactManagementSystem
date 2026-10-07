using DataAccessLayer.DataAccess.DatabaseConfig;
using DataAccessLayer.DataAccess.DatabaseConfig.DataConnections;
using DataAccessLayer.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CountryDB
    {
        public static int AddNew(DTOs.CountryDTO Country)
        {
            int NewCountryID = -1;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = Country_Queries.AddNew.ToString();
                        cmd.Connection = connection;

                        SqlParameter
                            CountryNameParameter = new SqlParameter("@CountryName", SqlDbType.NVarChar, 100),
                            CountryCodeParameter = new SqlParameter("@Code", SqlDbType.NVarChar, 3),
                            CountryPhoneCodeParameter = new SqlParameter("@PhoneCode", SqlDbType.NVarChar, 3);

                        CountryNameParameter.Value = Country.CountryName;
                        CountryCodeParameter.Value = Country.Code;
                        CountryPhoneCodeParameter.Value = Country.PhoneCode;

                        cmd.Parameters.Add(CountryNameParameter);
                        cmd.Parameters.Add(CountryCodeParameter);
                        cmd.Parameters.Add(CountryPhoneCodeParameter);

                        object result = cmd.ExecuteScalar();

                        if (result != null) NewCountryID = (int)result;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NewCountryID;
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

                        cmd.CommandText = Country_Queries.Delete;
                        cmd.Connection = connection;

                        SqlParameter
                            IDParameter = new SqlParameter("@CountryID", SqlDbType.Int);
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

        public static DataTable GetAll()
        {
            DataTable AllCountry = null;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                using (SqlCommand cmd =
                    new SqlCommand(Country_Queries.GetAll, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            AllCountry = new DataTable();
                            AllCountry.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return AllCountry;
        }

        public static DTOs.CountryDTO GetById(int id)
        {

            DTOs.CountryDTO country = null;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                using (SqlCommand cmd =
                    new SqlCommand(Country_Queries.GetByID, connection))
                {
                    connection.Open();

                    SqlParameter IDParameter = new SqlParameter("@CountryID", SqlDbType.Int);
                    IDParameter.Value = id;

                    cmd.Parameters.Add(IDParameter);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            country = new DTOs.CountryDTO
                            {
                                CountryID = (int)reader["CountryID"],
                                CountryName = (reader["CountryName"] != DBNull.Value) ? (string)reader["CountryName"] : string.Empty,
                                Code = (reader["Code"] != DBNull.Value) ? (string)reader["Code"] : string.Empty,
                                PhoneCode = (reader["PhoneCode"] != DBNull.Value) ? (string)reader["PhoneCode"] : string.Empty,
                            };

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return country;
        }

        public static DTOs.CountryDTO GetByName(string CountryName)
        {

            DTOs.CountryDTO country = null;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                using (SqlCommand cmd =
                    new SqlCommand(Contact_Queries.GetContactByName, connection))
                {
                    connection.Open();

                    SqlParameter CountryNameParameter = new SqlParameter("@CountryName", SqlDbType.NVarChar,100);
                    CountryNameParameter.Value = CountryName;

                    cmd.Parameters.Add(CountryNameParameter);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            country = new DTOs.CountryDTO
                            {
                                CountryID = (int)reader["CountryID"],
                                CountryName = (reader["CountryName"] != DBNull.Value) ? (string)reader["CountryName"] : string.Empty,
                                Code = (reader["Code"] != DBNull.Value) ? (string)reader["Code"] : string.Empty,
                                PhoneCode = (reader["PhoneCode"] != DBNull.Value) ? (string)reader["PhoneCode"] : string.Empty,
                            };

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return country;
        }

        public static bool Update(DTOs.CountryDTO Country)
        {

            int RowsEffected = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(Country_Queries.Update, connection)) 
                    {

                        SqlParameter
                            CountryIDParameter = new SqlParameter("@CountryID", SqlDbType.Int),
                            CountryNameParameter = new SqlParameter("@CountryName", SqlDbType.NVarChar, 100),
                            CountryCodeParameter = new SqlParameter("@Code", SqlDbType.NVarChar, 3),
                            CountryPhoneCodeParameter = new SqlParameter("@PhoneCode", SqlDbType.NVarChar, 3);

                        CountryIDParameter.Value = Country.CountryID;
                        CountryNameParameter.Value = Country.CountryName;
                        CountryCodeParameter.Value = Country.Code;
                        CountryPhoneCodeParameter.Value = Country.PhoneCode;

                        cmd.Parameters.Add(CountryIDParameter);
                        cmd.Parameters.Add(CountryNameParameter);
                        cmd.Parameters.Add(CountryCodeParameter);
                        cmd.Parameters.Add(CountryPhoneCodeParameter);

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

        public static bool IsContactExist(int CountryID)
        {

            bool Found = false;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd =
                       new SqlCommand(Country_Queries.IsContactExisit, connection))
                    {

                        SqlParameter
                            CountryIDParameter = new SqlParameter("@CountryID", SqlDbType.Int);

                        CountryIDParameter.Value = CountryID;

                        cmd.Parameters.Add(CountryIDParameter);

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

        public static bool IsContactExist(string CountryName)
        {

            bool Found = false;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd =
                       new SqlCommand(Country_Queries.IsContactExisit_name, connection))
                    {

                        SqlParameter
                            CountryNameParameter = new SqlParameter("@CountryName", SqlDbType.Int);

                        CountryNameParameter.Value = CountryName;

                        cmd.Parameters.Add(CountryNameParameter);

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

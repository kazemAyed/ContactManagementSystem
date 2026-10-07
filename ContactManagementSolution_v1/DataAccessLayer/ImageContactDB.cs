using DataAccessLayer.DataAccess.DatabaseConfig;
using DataAccessLayer.DataAccess.DatabaseConfig.DataConnections;
using DataAccessLayer.DatabaseConfig;
using DataAccessLayer.DatabaseConfig.DataConnections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ImageContactDB
    {
        public static int AddNew(DTOs.ImageContactDTO Entity)
        {
            int NewImageID = -1;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = ContactImage_Queries.AddNew.ToString();
                        cmd.Connection = connection;

                        SqlParameter
                            ImageNameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 100),
                            ImageDataParameter = new SqlParameter("@ImageData", SqlDbType.VarBinary, -1),
                            ImageContentTypeParameter = new SqlParameter("@ImageContentType", SqlDbType.NVarChar, 100);

                        ImageNameParameter.Value = Entity.Name;
                        ImageDataParameter.Value = Entity.ImageData;
                        ImageContentTypeParameter.Value = Entity.ImageContentType;

                        cmd.Parameters.Add(ImageNameParameter);
                        cmd.Parameters.Add(ImageDataParameter);
                        cmd.Parameters.Add(ImageContentTypeParameter);

                        object result = cmd.ExecuteScalar();

                        if (result != null) NewImageID = (int)result;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NewImageID;
        }

        public static bool Delete(int id)
        {
            bool DeletedRecord = false;

            try
            {
                using (SqlConnection connection = new SqlConnection()) 
                {
                    connection.ConnectionString = ContactsDB_Connection.ContactsDBConnectionString;
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = ContactImage_Queries.Delete;
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

        public static DataTable GetAll()
        {
            DataTable ContactImages = null;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                using (SqlCommand cmd =
                    new SqlCommand(ContactImage_Queries.GetAll, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            ContactImages = new DataTable();
                            ContactImages.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ContactImages;
        }

        public static DTOs.ImageContactDTO GetById(int id)
        {

            DTOs.ImageContactDTO contactImage = null;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                using (SqlCommand cmd =
                    new SqlCommand(ContactImage_Queries.GetByID, connection))
                {
                    connection.Open();

                    SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);
                    IDParameter.Value = id;

                    cmd.Parameters.Add(IDParameter);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            contactImage = new DTOs.ImageContactDTO()
                            {
                                Id = (int)reader["ID"],
                                Name = (reader["Name"] != DBNull.Value) ? (string)reader["Name"] : string.Empty,
                                ImageData = (reader["ImageData"] != DBNull.Value) ? (byte[])reader["ImageData"] : null,
                                ImageContentType = (reader["ImageContentType"] != DBNull.Value) ? (string)reader["ImageContentType"] : string.Empty,
                            };

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return contactImage;
        }

        public static bool Update(DTOs.ImageContactDTO Entity)
        {
            
            int RowsEffected = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(ContactImage_Queries.Update, connection))
                    {

                        SqlParameter
                             ImageIDParameter = new SqlParameter("@ID", SqlDbType.Int),
                             ImageNameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 100),
                             ImageDataParameter = new SqlParameter("@ImageData", SqlDbType.VarBinary, -1),
                             ImageContentTypeParameter = new SqlParameter("@ImageContentType", SqlDbType.NVarChar, 100);

                        ImageIDParameter.Value = Entity.Id;
                        ImageNameParameter.Value = Entity.Name;
                        ImageDataParameter.Value = Entity.ImageData;
                        ImageContentTypeParameter.Value = Entity.ImageContentType;

                        cmd.Parameters.Add(ImageIDParameter);
                        cmd.Parameters.Add(ImageNameParameter);
                        cmd.Parameters.Add(ImageDataParameter);
                        cmd.Parameters.Add(ImageContentTypeParameter);

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

        public static bool IsExist(int ID)
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
                          IDParameter = new SqlParameter("@ID", SqlDbType.Int);
                        IDParameter.Value = ID;

                        cmd.Parameters.Add(IDParameter);

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

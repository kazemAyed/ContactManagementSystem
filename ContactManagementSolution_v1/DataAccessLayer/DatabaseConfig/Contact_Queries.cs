using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.DatabaseConfig
{
    public static class Contact_Queries
    {
        public const string GetAll =
            @"
                SELECT *
                FROM Contacts;
            ";

        public const string GetContactByID =
            @"
                SELECT *
                FROM Contacts
                WHERE ContactID = @ContactID;
            ";

        public const string GetContactByName =
            @"
                select*
                from Countries
                where Countries.CountryName = @CountryName;
            ";

        public const string IsContactExisit =
            @"
                SELECT 1 AS [FOUND]
                FROM Contacts
                WHERE Contacts.ContactID = @ContactID;
            ";

        public const string GetAll_withCountryName =
            @"
                SELECT 
                	CO.ContactID,
                	CO.FirstName,
                	CO.LastName,
                	CO.Email,
                	CO.Phone,
                	CO.Address,
                	CT.CountryName
                FROM Contacts AS CO INNER JOIN Countries AS CT ON CO.CountryID = CT.CountryID;
            ";

        public const string GetAll_withCountryName_likeParam =
            @"
                SELECT 
                	CO.ContactID,
                	CO.FirstName,
                	CO.LastName,
                	CO.Email,
                	CO.Phone,
                	CO.Address,
                	CT.CountryName
                FROM Contacts AS CO INNER JOIN Countries AS CT ON CO.CountryID = CT.CountryID
                WHERE CO.FirstName LIKE @LPAR + '%' ;
            ";

        public const string GetFirstNameByID =
            @"
                SELECT CO.FirstName
                FROM Contacts AS CO 
                WHERE CO.ContactID = @ContactID
            ";


        public const string AddNewContact =
            @"

                INSERT INTO [dbo].[Contacts]
                           ([FirstName]
                           ,[LastName]
                           ,[Email]
                           ,[Phone]
                           ,[Address]
                           ,[CountryID]
                           ,[ImageID]
                           ,[Date Of Birth])
                     VALUES
                           (@FirstName
                           ,@LastName
                           ,@Email
                           ,@Phone
                           ,@Address
                           ,@CountryID
                           ,@ImageID
                           ,@DateOfBirth);
                
                SELECT CAST(SCOPE_IDENTITY() AS INT) AS ContactID;

            ";

        public const string DeleteContact =
            @"
                DELETE 
                FROM [dbo].[Contacts]
                WHERE Contacts.ContactID = @ID;
            ";

        public static string DeleteContactWithINOperater =
            $@"
                DELETE 
                FROM [dbo].[Contacts]
                WHERE Contacts.ContactID IN(@INOperater);
            ";

        public static string Update =
            @"
                UPDATE [dbo].[Contacts]
                  SET [FirstName]  = @FirstName
                     ,[LastName]   = @LastName
                     ,[Email]      = @Email
                     ,[Phone]      = @Phone
                     ,[Address]    = @Address
                     ,[CountryID]  = @CountryID
                     ,[ImageID]    = @ImageID
                     ,[Date Of Birth] = @DateOfBirth
                WHERE[Contacts].ContactID = @ContactID
            ";

    }
}

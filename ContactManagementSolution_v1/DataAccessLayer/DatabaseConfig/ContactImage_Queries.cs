using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DatabaseConfig.DataConnections
{
    public class ContactImage_Queries
    {
        public const string AddNew =
            @"

                INSERT INTO [dbo].[ContactsImage]
                           ([Name]
                           ,[ImageData]
                           ,[ImageContentType])
                     VALUES
                           (@Name
                           ,@ImageData
                           ,@ImageContentType);
                
                SELECT CAST(SCOPE_IDENTITY() AS INT) AS ContactImage;

            ";

        public const string Delete =
            @"
                DELETE FROM [dbo].[ContactsImage]
                WHERE [dbo].[ContactsImage].ID = @ID;
            ";


        public const string GetAll =
            @"
                SELECT *
                FROM ContactsImage;
            ";

        public const string GetByID =
            @"
                SELECT *
                FROM ContactsImage
                WHERE ContactsImage.ID = @ID;
            ";

        public const string Update =
            @"
                UPDATE [dbo].[ContactsImage]
                   SET [Name] = @Name
                      ,[ImageData] = @ImageData
                      ,[ImageContentType] = @ImageContentType
                 WHERE [dbo].[ContactsImage].ID = @ID;
            ";


        public const string IsExisit =
            @"
                SELECT 1 AS [FOUND]
                FROM Countries
                WHERE [dbo].[ContactsImage].ID = @ID;
            ";

    }
}

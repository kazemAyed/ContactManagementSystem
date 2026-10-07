using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DatabaseConfig
{
    
    public class Country_Queries
    {

        public const string AddNew =
            @"

                INSERT INTO [dbo].[Countries]
                           ([CountryName]
                           ,[Code]
                           ,[PhoneCode])
                     VALUES
                           (@CountryName
                           ,@Code
                           ,@PhoneCode);
                
                SELECT CAST(SCOPE_IDENTITY() AS INT) AS CountryID;

            ";

        public const string Delete =
            @"
                DELETE FROM [dbo].[Countries]
                WHERE [dbo].[Countries].CountryID = @CountryID;
            ";


        public const string GetAll =
            @"
                SELECT *
                FROM Countries 
            ";

        public const string GetByID =
            @"
                SELECT *
                FROM Countries 
                WHERE Countries.CountryID = @CountryID
            ";

        public const string Update =
            @"
                UPDATE [dbo].[Countries]
                    SET  [CountryName] = @CountryName
                        ,[Code] = @Code
                        ,[PhoneCode] = @PhoneCode
                WHERE Countries.CountryID = @CountryID;
            ";


        public const string IsContactExisit =
            @"
                SELECT 1 AS [FOUND]
                FROM Countries
                WHERE Countries.CountryID = @CountryID;
            ";

        public const string IsContactExisit_name =
            @"
                SELECT 1 AS [FOUND]
                FROM Countries
                WHERE Countries.CountryName = @CountryName;
            ";
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.DatabaseConfig.DataConnections
{
    public static class ContactsDB_Connection
    {
        public const string ContactsDBConnectionString =
            @"
                 Server=.;
                 Database=ContactsDB;
                 Trusted_Connection=True;
                 TrustServerCertificate=True;
            ";
    }
}

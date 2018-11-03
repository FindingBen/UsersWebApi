using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebApi.Controllers
{
    public class ConnectionString
    {
        public static readonly string connectionString =
            "Server=tcp:findingben.database.windows.net,1433;Initial Catalog=benbase;Persist Security Info=False;User ID=(ur id);Password=(ur pass);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}

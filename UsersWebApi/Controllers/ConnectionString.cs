using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersWebApi.Controllers
{
    public class ConnectionString
    {
        //Remember to delete this con string and use your own ;) 
        //I forgot how to ignore it from github :D 
        public static readonly string connectionString =
            "Server=tcp:findingben.database.windows.net,1433;Initial Catalog=benbase;Persist Security Info=False;User ID=(ur id);Password=(ur pass);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}

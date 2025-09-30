using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DL_PasswordManagementSystem
{
    internal static class clsDBSettings
    {
       public static string ConnectionString = "Server=.; Database=PasswordsDB; User Id=sa; Password=77MoNdEr200!;";

       public static string masterConnectionString = "Server=.;Database=master;User Id=sa;Password=77MoNdEr200!;";

    }
}

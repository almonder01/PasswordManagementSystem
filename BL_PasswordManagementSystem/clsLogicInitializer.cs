using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DL_PasswordManagementSystem;
namespace BL_PasswordManagementSystem
{
    static public class clsLogicInitializer
    {
        static public bool Initializer()
        {
            return clsDBInitializer.Initializer();
        }
    }
}

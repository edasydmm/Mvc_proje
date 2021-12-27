using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.Models
{
    public static class RoleModels
    {
        public static string Admin = "Admin";
        public static string User = "User";
        public static string Passive = "Passive";

        public static ICollection<string> Roles => new List<string>() { Admin, User, Passive };
    }
}

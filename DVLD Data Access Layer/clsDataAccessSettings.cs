using System;
using System.Configuration;

namespace DVLD_Data_Access_Layer
{
    static class clsDataAccessSettings
    {
        public static string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Learning.Config
{
    public class EConnection
    {
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["ecs"].ConnectionString;
        }
    }
}
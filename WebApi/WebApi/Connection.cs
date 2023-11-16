using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApi
{
    public static class Connection
    {
        static SqlConnection sc;
        public static SqlConnection GetConnect()
        {
            if (sc == null)
            {
                sc = new SqlConnection();
                sc.ConnectionString = "Data Source=(local); Initial Catalog=EmployeeDB; Integrated Security=true";
                sc.Open();
            }
            return sc;
        }
    }
}
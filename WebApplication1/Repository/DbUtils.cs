using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Repository
{
    public static class DbUtils
    {
        public static SqlConnection GetConnection() {
            string connectionString = "Data Source=ServerName;Initial Catalog=DataBaseName;User id=UserName;Password=Secret;";

            return new SqlConnection(connectionString);
        }

        public static string GetString(SqlDataReader reader, int index) {
            return reader[index] is DBNull ? string.Empty : reader.GetString(index);
        }

        public static Decimal GetDecimal(SqlDataReader reader, int index)
        {
            return reader[index] is DBNull ? Decimal.Zero : reader.GetDecimal(index);
        }
    }
}
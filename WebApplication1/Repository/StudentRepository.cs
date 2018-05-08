using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class StudentRepository
    {
        public SearchStudentResponse GetStudent(string sfzh, string xm)
        {
            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT sfzh, xm, xh, pycc  from db.student "
                    + "WHERE sfzh = @sfzh "
                    + "ORDER BY xm DESC;";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = DbUtils.GetConnection())
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@sfzh", sfzh);
                command.Parameters.AddWithValue("@xm", xm);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                SearchStudentResponse student = null;
                if (reader.Read())
                {
                    student = new SearchStudentResponse();
                    student.Sfzh = DbUtils.GetString(reader, 0);
                    student.Xm = DbUtils.GetString(reader, 1);
                    student.Xh = DbUtils.GetString(reader, 2);
                    student.Pycc = DbUtils.GetString(reader, 3);
                }
                reader.Close();

                return student;
            }
        }
    }
}
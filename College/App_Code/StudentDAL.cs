using System.Configuration;
using System.Data.SqlClient;

namespace College.App_Code
{
    public class StudentDAL
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString;

        public StudentDS GetStudents()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string sql = @"SELECT  
                        Id,
                        FirstName,
                        LastName,
                        Gender,
                        Country,
                        City
                    FROM 
                        Student";
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, con))
                {
                    StudentDS studentDS = new StudentDS();
                    sqlDataAdapter.Fill(studentDS, "Student");
                    return studentDS;
                }
            }
        }
    }
}
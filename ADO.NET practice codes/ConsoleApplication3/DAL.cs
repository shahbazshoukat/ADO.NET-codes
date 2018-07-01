using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class DAL
    {
        public DataTable GetAllStudents()
        {
            
            String connString = @"Data Source=.\SQLEXPRESS; Database=testing; User Id=sa; Password=password;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = "select * from Students";
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                /*List<StudentDTO> stuList = new List<StudentDTO>();
                while (reader.Read() == true)
                {

                    StudentDTO stu = new StudentDTO();
                    stu.StudentId = reader.GetInt32(0);
                    stu.Name = reader.GetString(1);
                    stu.DOB = reader.GetDateTime(2);
                    stuList.Add(stu);
                }
                return stuList;*/
                return dt;
            }
            
        }
        public void Save(StudentDTO stu)
        {
            String connString = @"Data Source=.\SQLEXPRESS; Database=testing; User Id=sa; Password=password;";
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = String.Format(@"INSERT INTO dbo.Students(Name, DOB) VALUES('{0}','{1}')", stu.Name, stu.DOB);
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                int recAff = command.ExecuteNonQuery();
                Console.WriteLine("Record Affected: {0}", recAff);
            }
            Console.ReadKey();
        }

        public int Save2(StudentDTO dto)
        {
            String connString = @"Data Source=.\SQLEXPRESS; Database=testing; User Id=sa; Password=password;";

            using(SqlConnection conn=new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = String.Format(@"INSERT INTO dbo.Students(Name,DOB) VALUES(@StuName, @DOB)");
                sqlQuery = sqlQuery + "; select scope_identity()";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter param = new SqlParameter();
                param.ParameterName = "StuName";
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                param.Value = dto.Name;

                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "DOB";
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                param.Value = dto.DOB;

                command.Parameters.Add(param);

                int studentID =Convert.ToInt32(command.ExecuteScalar());
                return studentID;
            }
        }

        public void Update(StudentDTO stu)
        {
            String connString = @"Data Source=.\SQLEXPRESS; Database=testing; User Id=sa; Password=password;";

            using(SqlConnection conn=new SqlConnection(connString))
            {
                conn.Open();
                String query = String.Format(@"UPDATE dbo.Students SET Name='{0}', DOB='{1}' WHERE StudentId={2}",stu.Name,stu.DOB,stu.StudentId);
                SqlCommand command = new SqlCommand(query, conn);
                int recAff = command.ExecuteNonQuery();
                Console.WriteLine("Record Affected: {0}", recAff);
            }
            Console.ReadKey();
        }
        public void delete(int id)
        {
            String connString = @"Data Source=.\SQLEXPRESS; Database=testing; User Id=sa; Password=password;";
            using(SqlConnection conn=new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = String.Format(@"DELETE FROM dbo.Students WHERE StudentId={0}",id);
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                int recAff = command.ExecuteNonQuery();
                Console.WriteLine("Records Affected: {0}", recAff);

            }
            Console.ReadKey();
        }
    }
}

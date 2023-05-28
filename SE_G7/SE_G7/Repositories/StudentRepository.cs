using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using SE_G7.Models;

namespace SE_G7.Repositories
{
    public class StudentRepository
    {
        

        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string sql = "SELECT * FROM InfoStudent";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Student student = CreateObject(reader);
                students.Add(student);
            }
            reader.Close();
            DB.CloseConnection();
            return students;
        }

        private static Student CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string name = reader["Name"].ToString();
            string surname = reader["Surname"].ToString();
            string email = reader["Email"].ToString();
            string phone = reader["Phone"].ToString();
            string home_university = reader["Home_university"].ToString();
            string faculty_address = reader["Faculty_address"].ToString();
            string field_of_study = reader["Field_of_study"].ToString();
            
            var student = new Student
            {
                Id = id,
                Name =name,
                Surname = surname,
                Email = email,
                Phone = phone,
                Home_university = home_university,
                Faculty_address = faculty_address,
                Field_of_study = field_of_study

            };
            return student;
        }
    }
}

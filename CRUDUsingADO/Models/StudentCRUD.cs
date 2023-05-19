///using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class StudentCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public StudentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }
        // list
        public List<Student> GetStudent()
        {
            List<Student> list = new List<Student>();
            string qry = "select * from Student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.RollNo = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Email = dr["email"].ToString();
                    student.Percentage = Convert.ToDecimal(dr["percentage"]);

                    list.Add(student);
                }
            }
            con.Close();
            return list;
        }
        // display single value against rollno
        public Student GetStudentByRollNo(int rollno)
        {
            Student student = new Student();
            string qry = "select * from Student where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { 
                    student.RollNo = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Email = dr["email"].ToString();
                    student.Percentage = Convert.ToDecimal(dr["percentage"]);

                }
            }
            con.Close();
            return student;
        }
        // add
        public int AddStudent(Student student)
        {
            int result = 0;
            string qry = "insert into Student values(@name,@branch,@email,@percentage)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@branch", student.Branch);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // edit
        public int EditStudent(Student student)
        {
            int result = 0;
            string qry = "update Student set name=@name,branch=@branch,email=@email,percentage=@percentage where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@branch", student.Branch);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            cmd.Parameters.AddWithValue("@rollno", student.RollNo);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // delete
        public int DeleteStudent(int rollno)
        {
            int result = 0;
            string qry = "delete from Student where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}

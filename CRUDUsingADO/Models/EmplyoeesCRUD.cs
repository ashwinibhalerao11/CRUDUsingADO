using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class EmplyoeesCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public EmplyoeesCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }
        // list
        public List<Employees> GetEmployees()
        {
            List<Employees> list = new List<Employees>();
            string qry = "select * from Employees";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employees employee = new Employees();
                    employee.Id = Convert.ToInt32(dr["id"]);
                    employee.Name = dr["name"].ToString();
                    employee.City = dr["city"].ToString();
                    employee.Salary = Convert.ToInt32(dr["salary"]);

                    list.Add(employee);
                }
            }
            con.Close();
            return list;
        }
        // display single value against id
        public Employees GetEmployeeById(int id)
        {
            Employees employee = new Employees();
            string qry = "select * from Employees where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    employee.Id = Convert.ToInt32(dr["id"]);
                    employee.Name = dr["name"].ToString();
                    employee.City = dr["city"].ToString();
                    employee.Salary = Convert.ToInt32(dr["salary"]);
                    
                }
            }
            con.Close();
            return employee;
        }
        // add
        public int AddEmployee(Employees employee)
        {
            int result = 0;
            string qry = "insert into Employees values(@name,@city,@salary)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@city", employee.City);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // edit
        public int EditEmployee(Employees employee)
        {
            int result = 0;
            string qry = "update Employees set name=@name,city=@city,salary=@salary where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@city", employee.City);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);
            cmd.Parameters.AddWithValue("@id", employee.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // delete
        public int DeleteEmployee(int id)
        {
            int result = 0;
            string qry = "delete from Employees where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}

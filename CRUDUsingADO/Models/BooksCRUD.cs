using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class BooksCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;  
        public BooksCRUD(IConfiguration configuration) 
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        } 
        //List
        public List<Books>GetBooks() 
        {
            List<Books> list = new List<Books>();
            string qry = "select * from Books";
            cmd=new SqlCommand(qry,con);
            con.Open();
            dr= cmd.ExecuteReader();    
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Books book = new Books();
                    book.Id = Convert.ToInt32(dr["id"]);
                    book.Name = dr["name"].ToString();
                    book.AuthName = dr["authname"].ToString();
                    book.Price = Convert.ToInt32(dr["price"]);

                    list.Add(book);
                }
            }
            con.Close();
            return list;
        }
        public Books GetBookById(int id) 
        {
            Books book = new Books();
            string qry = "select * from Books where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    book.Id = Convert.ToInt32(dr["id"]);
                    book.Name = dr["name"].ToString();
                    book.AuthName = dr["authname"].ToString();
                    book.Price = Convert.ToInt32(dr["price"]);
                }
            }
            con.Close();
            return book;
        }
        //Add
        public int AddBook(Books book) 
        {
            int result = 0;
            string qry = "insert into Books values(@name,@authname,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@authname", book.AuthName);
            cmd.Parameters.AddWithValue("@price", book.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //Edit
        public int EditBook(Books book) 
        {
            int result = 0;
            string qry = "update Books set name=@name,authname=@authname,price=@price where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@authname", book.AuthName);
            cmd.Parameters.AddWithValue("@price", book.Price);
            cmd.Parameters.AddWithValue("@id", book.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //Delete
        public int DeleteBook(int id) 
        {

            int result = 0;
            string qry = "delete from Books where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}

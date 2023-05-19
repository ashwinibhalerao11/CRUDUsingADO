using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class ProductsCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;

       public ProductsCRUD(IConfiguration configuration)
       {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
       }
        // list
        public List<Products> GetProducts()
        {
            List<Products> list = new List<Products>();
            string qry = "select * from Products";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Products product = new Products();
                    product.Id = Convert.ToInt32(dr["id"]);
                    product.Name = dr["name"].ToString();
                    product.Company = dr["company"].ToString();
                    product.Price = Convert.ToInt32(dr["price"]);

                    list.Add(product);
                }
            }
            con.Close();
            return list;
        }
        // display single value against id
        public Products GetProductById(int id)
        {
            Products product = new Products();
            string qry = "select * from Products where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    product.Id = Convert.ToInt32(dr["id"]);
                    product.Name = dr["name"].ToString();
                    product.Company = dr["company"].ToString();
                    product.Price = Convert.ToInt32(dr["price"]);
                }
            }
            con.Close();
            return product;
        }
        // add
        public int AddProduct(Products product)
        {
            int result = 0;
            string qry = "insert into Products values(@name,@company,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@company", product.Company);
            cmd.Parameters.AddWithValue("@price", product.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // edit
        public int EditProduct(Products product)
        {
            int result = 0;
            string qry = "update Products set name=@name,company=@company,price=@price where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@company", product.Company);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@id", product.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // delete
        public int DeleteProduct(int id)
        {
            int result = 0;
            string qry = "delete from Products where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}

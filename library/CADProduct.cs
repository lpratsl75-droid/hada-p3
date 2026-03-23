using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADProduct
    {
        private string conex = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";


        public CADProduct()
        {
            

            SqlConnection conexion = new SqlConnection(conex);


        }


        public bool Create(ENProduct en)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(conex);
                conexion.Open();

                SqlCommand com = new SqlCommand("SELECT INTO Products(name code amount price category creationDate) VALUES(@name @code @amount @price @category @creationDate)");

                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@code", en.v);
                com.Parameters.AddWithValue("@ampount", en.ampount);
                com.Parameters.AddWithValue("@price", en.price);
                com.Parameters.AddWithValue("@category", en.category);
                com.Parameters.AddWithValue("@creationDate", en.creationDate);

                conexion.Close();
                    
                return true;
            }
            catch(Exception e)
            {
                
                return false;
            }
        }

        public bool Update(ENProduct en)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(conex);
                conexion.Open();

                SqlCommand com = new SqlCommand("UPDATE Products SET (name=@name, code=@code, amount=@amount, price=@price, category=@category, creationDate=@creationDate)");

                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@code", en.v);
                com.Parameters.AddWithValue("@ampount", en.ampount);
                com.Parameters.AddWithValue("@price", en.price);
                com.Parameters.AddWithValue("@category", en.category);
                com.Parameters.AddWithValue("@creationDate", en.creationDate);

                conexion.Close();

                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}

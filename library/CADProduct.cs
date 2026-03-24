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

                SqlCommand com = new SqlCommand("INSERT INTO Products(name, code, amount, price, category, creationDate, id) VALUES(@name, @code, @amount, @price, @category, @creationDate, @id)" , conexion);

                com.Parameters.AddWithValue("@name", en.name);
                com.Parameters.AddWithValue("@code", en.code);
                com.Parameters.AddWithValue("@amount", en.amount);
                com.Parameters.AddWithValue("@price", en.price);
                com.Parameters.AddWithValue("@category", en.category);
                com.Parameters.AddWithValue("@creationDate", en.creationDate);
                com.Parameters.AddWithValue("@id", en.id);

                return com.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool Update(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(conex);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("UPDATE Products SET name=@name, code=@code, amount=@amount, price=@price, category=@category, creationDate=@creationDate WHERE id=@id" , conexion);

                com.Parameters.AddWithValue("@name", en.name);
                com.Parameters.AddWithValue("@code", en.code);
                com.Parameters.AddWithValue("@amount", en.amount);
                com.Parameters.AddWithValue("@price", en.price);
                com.Parameters.AddWithValue("@category", en.category);
                com.Parameters.AddWithValue("@creationDate", en.creationDate);
                com.Parameters.AddWithValue("@id", en.id);



                return com.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool Delete(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(conex);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("DELETE FROM Products WHERE id=@id", conexion);

                com.Parameters.AddWithValue("@id", en.id);



                return com.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
        public bool Read(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(conex);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("Select * FROM Products WHERE id=@id", conexion);

                com.Parameters.AddWithValue("@id", en.id);

                SqlDataReader dat = com.ExecuteReader();

                if (dat.Read())
                {
                    en.name = dat["name"].ToString();
                    en.code = int.Parse(dat["code"].ToString());
                    en.amount = dat["amount"].ToString();
                    en.price = float.Parse(dat["price"].ToString());
                    en.category = dat["category"].ToString();
                    en.creationDate = DateTime.Parse(dat["creationDate"].ToString());

                    dat.Close();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
        public bool ReadFirst(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(conex);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("Select * FROM Products", conexion);

                SqlDataReader dat = com.ExecuteReader();

                if (dat.Read())
                {
                    en.name = dat["name"].ToString();
                    en.code = int.Parse(dat["code"].ToString());
                    en.amount = dat["amount"].ToString();
                    en.price = float.Parse(dat["price"].ToString());
                    en.category = dat["category"].ToString();
                    en.creationDate = DateTime.Parse(dat["creationDate"].ToString());
                    en.id = int.Parse(dat["id"].ToString());

                    dat.Close();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool ReadNext(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(conex);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("Select * FROM Products WHERE id>@id ORDER BY id ASC", conexion);
                com.Parameters.AddWithValue("@id", en.id);

                SqlDataReader dat = com.ExecuteReader();

                if (dat.Read())
                {
                    en.name = dat["name"].ToString();
                    en.code = int.Parse(dat["code"].ToString());
                    en.amount = dat["amount"].ToString();
                    en.price = float.Parse(dat["price"].ToString());
                    en.category = dat["category"].ToString();
                    en.creationDate = DateTime.Parse(dat["creationDate"].ToString());
                    en.id = int.Parse(dat["id"].ToString());

                    dat.Close();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
        public bool ReadPrev(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(conex);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("Select * FROM Products WHERE id<@id ORDER BY id DESC", conexion);
                com.Parameters.AddWithValue("@id", en.id);

                SqlDataReader dat = com.ExecuteReader();

                if (dat.Read())
                {
                    en.name = dat["name"].ToString();
                    en.code = int.Parse(dat["code"].ToString());
                    en.amount = dat["amount"].ToString();
                    en.price = float.Parse(dat["price"].ToString());
                    en.category = dat["category"].ToString();
                    en.creationDate = DateTime.Parse(dat["creationDate"].ToString());
                    en.id = int.Parse(dat["id"].ToString());

                    dat.Close();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}

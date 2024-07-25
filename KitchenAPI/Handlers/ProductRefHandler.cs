using ClassLibrary.Objects;
using KitchenIO.Objects;
using Microsoft.Data.SqlClient;

namespace KitchenAPI.Handlers
{
    public class ProductRefHandler
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KitchenDB;Integrated Security=True";

        public async Task<string> Create(ProductRef newProduct)
        {
            //try creating the connection string, gives back error message as String if it fails
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.ToString();
            }

            //If connection string was created successfully, Insert the Location object into the database
            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("INSERT_Products", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newProduct.Id);
                cmd.Parameters.AddWithValue("Name", newProduct.Name);
                cmd.Parameters.AddWithValue("Barcode", newProduct.Barcode);
                cmd.Parameters.AddWithValue("Price", newProduct.Price);
                cmd.Parameters.AddWithValue("Type", newProduct.Type);
                cmd.Parameters.AddWithValue("@meassurement", newProduct.meassurement);
                int result = cmd.ExecuteNonQuery();

                await conn.CloseAsync();

                return "succuess";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return ex.ToString();
            }
        }
        public async Task<List<ProductRef>> GetAll()
        {
            List<ProductRef> ProductList = new List<ProductRef>();

            //try creating the connection string, gives back empty list if fails
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return ProductList;
            }


            //read all locations in database
            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("GETALL_Products", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rd = cmd.ExecuteReader();

                while (await rd.ReadAsync())
                {
                    ProductRef newPr = new ProductRef();

                    newPr.Id = rd.GetGuid(0);
                    newPr.Name = rd.GetString(1);
                    newPr.Barcode = rd.GetString(2);
                    newPr.Price = rd.GetDouble(3);
                    newPr.Type = rd.GetString(4);
                    newPr.meassurement = rd.GetString(5);

                    ProductList.Add(newPr);
                }

                await conn.CloseAsync();

                return ProductList;
            }
            catch (Exception ex)
            {
                //give back list that we have so far in case of an error
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return ProductList;
            }
        }
        public async Task<ProductRef> GetByBarcode(string barcode)
        {
            ProductRef newPr = new ProductRef();
            //try creating the connection string, gives back empty list if fails
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return newPr;
            }


            //read all locations in database
            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("GETByBarcode_Products", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Barcode", barcode);

                SqlDataReader rd = cmd.ExecuteReader();

                while (await rd.ReadAsync())
                {

                    newPr.Id = rd.GetGuid(0);
                    newPr.Name = rd.GetString(1);
                    newPr.Barcode = rd.GetString(2);
                    newPr.Price = rd.GetDouble(3);
                    newPr.Type = rd.GetString(4);
                    newPr.meassurement = rd.GetString(5);
                }

                await conn.CloseAsync();

                return newPr;
            }
            catch (Exception ex)
            {
                //give back list that we have so far in case of an error
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return newPr;
            }
        }
        public async Task<string> Update(ProductRef newProduct)
        {
            //try creating the connection string, gives back error message as String if it fails
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.ToString();
            }

            //If connection string was created successfully, Insert the Location object into the database
            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("UPDATE_Products", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newProduct.Id);
                cmd.Parameters.AddWithValue("Name", newProduct.Name);
                cmd.Parameters.AddWithValue("Barcode", newProduct.Barcode);
                cmd.Parameters.AddWithValue("Price", newProduct.Price);
                cmd.Parameters.AddWithValue("Type", newProduct.Type);
                cmd.Parameters.AddWithValue("@meassurement", newProduct.meassurement);
                int result = cmd.ExecuteNonQuery();

                await conn.CloseAsync();

                return "succuess";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return ex.ToString();
            }
        }
        public async Task<string> Delete(ProductRef newProduct)
        {
            //try creating the connection string, gives back error message as String if it fails
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.ToString();
            }

            //If connection string was created successfully, Insert the Location object into the database
            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("DELETEE_Products", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newProduct.Id);
                int result = cmd.ExecuteNonQuery();

                await conn.CloseAsync();

                return "succuess";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return ex.ToString();
            }
        }
    }
}

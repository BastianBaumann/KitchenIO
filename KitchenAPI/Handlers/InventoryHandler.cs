using ClassLibrary.Objects;
using KitchenIO.Objects;
using Microsoft.Data.SqlClient;

namespace KitchenAPI.Handlers
{
    public class InventoryHandler
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KitchenDB;Integrated Security=True";

        public async Task<string> Create(Product newProduct)
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

                SqlCommand cmd = new SqlCommand("INSERT_Inventory", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newProduct.Id);
                cmd.Parameters.AddWithValue("ProductId", newProduct.ProductId);
                cmd.Parameters.AddWithValue("Amount", newProduct.Amount);
                cmd.Parameters.AddWithValue("EP", newProduct.EP);
                cmd.Parameters.AddWithValue("Owner", newProduct.Owner);
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
        public async Task<List<Product>> GetAll()
        {
            List<Product> ProductList = new List<Product>();

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

                SqlCommand cmd = new SqlCommand("GETALL_Inventory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rd = cmd.ExecuteReader();

                while (await rd.ReadAsync())
                {
                    Product newPr = new Product();

                    newPr.Id = rd.GetGuid(0);
                    newPr.ProductId = rd.GetGuid(1);
                    newPr.Amount = rd.GetDouble(2);
                    newPr.EP = rd.GetDateTime(3);
                    newPr.Owner = rd.GetGuid(4);

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
        public async Task<string> Update(Product newProduct)
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

                SqlCommand cmd = new SqlCommand("UPDATE_Inventory", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newProduct.Id);
                cmd.Parameters.AddWithValue("Amount", newProduct.Amount);
                cmd.Parameters.AddWithValue("EP", newProduct.EP);
                cmd.Parameters.AddWithValue("Owner", newProduct.Owner);

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
        public async Task<string> Delete(Guid newProduct)
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

                SqlCommand cmd = new SqlCommand("DELETE_Inventory", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newProduct);
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

        public async Task<List<Product>> GetByOwner(Guid Owner)
        {
            List<Product> products = new List<Product>();

            //try creating the connection string, gives back empty list if fails
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return products;
            }


            //read all locations in database
            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("GETAllByOwner_Inventory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Owner", Owner);

                SqlDataReader rd = cmd.ExecuteReader();

                while (await rd.ReadAsync())
                {
                    Product newPr = new Product();

                    newPr.Id = rd.GetGuid(0);
                    newPr.ProductId = rd.GetGuid(1);
                    newPr.Amount = rd.GetDouble(2);
                    newPr.EP = rd.GetDateTime(3);
                    newPr.Owner = rd.GetGuid(4);

                    products.Add(newPr);

                }

                await conn.CloseAsync();

                return products;
            }
            catch (Exception ex)
            {
                //give back list that we have so far in case of an error
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return products;
            }
        }
    }
}

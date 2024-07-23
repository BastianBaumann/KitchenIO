using ClassLibrary.Objects;
using KitchenIO.Objects;
using Microsoft.Data.SqlClient;

namespace KitchenAPI.Handlers
{
    public class KitchenHandler
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KitchenDB;Integrated Security=True";
        public async Task<string> Create(Kitchen newKitchen)
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

            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("INSERT_Kitchen", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newKitchen.Id);
                cmd.Parameters.AddWithValue("Name", newKitchen.Name);
                cmd.Parameters.AddWithValue("Barcode",  newKitchen.Description);

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
        public async Task<string> Update(Kitchen newKitchen)
        {
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

                SqlCommand cmd = new SqlCommand("UPDATE_Kitchen", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newKitchen.Id);
                cmd.Parameters.AddWithValue("Name", newKitchen.Name);
                cmd.Parameters.AddWithValue("Barcode", newKitchen.Description);
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
        public async Task<string> Delete(Kitchen newKitchen)
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

                SqlCommand cmd = new SqlCommand("DELETEE_Kitchen", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newKitchen.Id);
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

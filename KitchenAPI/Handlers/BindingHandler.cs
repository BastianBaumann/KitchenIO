using ClassLibrary.Objects;
using Microsoft.Data.SqlClient;

namespace KitchenAPI.Handlers
{
    public class BindingHandler
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KitchenDB;Integrated Security=True";
        public async Task<string> BindKitchen(Binding newBind)
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

                SqlCommand cmd = new SqlCommand("BIND_Kitchen", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newBind.UserId);
                cmd.Parameters.AddWithValue("Name", newBind.KitchenId);

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
        public async Task<string> DeleteBindingByUser(Guid UserID)
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

                SqlCommand cmd = new SqlCommand("DELETEByUser_Bind", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UserId", UserID);
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
        public async Task<string> DeleteBindingByKitchen(Guid KitchenID)
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

                SqlCommand cmd = new SqlCommand("DELETEByUser_Bind", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("KitchenId", KitchenID);
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

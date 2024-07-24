using ClassLibrary.Objects;
using KitchenIO.Objects;
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

                cmd.Parameters.AddWithValue("UserId", newBind.UserId);
                cmd.Parameters.AddWithValue("KitchenId", newBind.KitchenId);

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
        public async Task<List<Binding>> GetByUser(Guid UserId)
        {
            List<Binding> bindingList = new List<Binding>();
            //try creating the connection string, gives back empty list if fails
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return bindingList;
            }


            //read all locations in database
            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("GETByUsers_Binding", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UserId", UserId);

                SqlDataReader rd = cmd.ExecuteReader();

                while (await rd.ReadAsync())
                {
                    Binding newBinding = new Binding();
                    newBinding.Id = rd.GetGuid(0);
                    newBinding.UserId = rd.GetGuid(1);
                    newBinding.KitchenId = rd.GetGuid(2);

                    bindingList.Add(newBinding);
                }
                    await conn.CloseAsync();

                    return bindingList;
                
            }
            catch (Exception ex)
            {
                //give back list that we have so far in case of an error
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return bindingList;
            }
        }
        public async Task<List<User>> GetByKitchen(Guid KitchenId)
        {
            List<Binding> bindList = new List<Binding>();
            List<User> userList = new List<User>();

            //try creating the connection string, gives back empty list if fails
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return userList;
            }


            //read all locations in database
            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("GETByKitchen_Binding", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("KitchenId", KitchenId);

                SqlDataReader rd = cmd.ExecuteReader();

                while (await rd.ReadAsync())
                {
                    Binding newBind = new Binding();
                    newBind.Id = rd.GetGuid(0);
                    newBind.UserId = rd.GetGuid(1);
                    newBind.KitchenId = rd.GetGuid(2);

                    bindList.Add(newBind);
                }
                await conn.CloseAsync();

            }
            catch (Exception ex)
            {
                //give back list that we have so far in case of an error
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return userList;
            }

            foreach(Binding bind in bindList)
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("GETById_Users", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UserId", bind.UserId);

                SqlDataReader rd = cmd.ExecuteReader();

                while (await rd.ReadAsync())
                {
                    User newUser = new User();
                    newUser.Id = rd.GetGuid(0);
                    newUser.Name = rd.GetString(1);
                    newUser.Allergies = rd.GetString(3);

                    userList.Add(newUser);
                }
                await conn.CloseAsync();
            }
            return userList;
        }
    }
}

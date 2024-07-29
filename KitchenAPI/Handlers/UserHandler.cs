using ClassLibrary.Objects;
using KitchenIO.Objects;
using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;

namespace KitchenAPI.Handlers
{
    public class UserHandler
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KitchenDB;Integrated Security=True";
        public async Task<string> Create(User newUser)
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

            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("INSERT_Users", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newUser.Id);
                cmd.Parameters.AddWithValue("Name", newUser.Name);
                cmd.Parameters.AddWithValue("Password", newUser.Password);
                cmd.Parameters.AddWithValue("Allergies", newUser.Allergies);

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
        public async Task<string> Update(User newUser)
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

            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("UPDATE_User", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", newUser.Id);
                cmd.Parameters.AddWithValue("Name", newUser.Name);
                cmd.Parameters.AddWithValue("Password", newUser.Password);
                cmd.Parameters.AddWithValue("Allergies", newUser.Allergies);
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
        public async Task<string> Delete(Guid UserId)
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

            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("DELETEE_User", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", UserId);
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
        public async Task<Guid> Login(string Name, string Password)
        {
            Guid FoundGuid = Guid.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("LOGIN_User", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        using (SqlDataReader rd = await cmd.ExecuteReaderAsync())
                        {
                            if (await rd.ReadAsync()) 
                            {
                                if (!rd.IsDBNull(0))
                                {
                                    FoundGuid = rd.GetGuid(0);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return FoundGuid;
        }
        public async Task<User> GetByName(string username)
        {
            User foundUser = new User();


            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return foundUser;
            }


            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("GETByName_Users", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Name", username);

                SqlDataReader rd = cmd.ExecuteReader();

                while (await rd.ReadAsync())
                {

                    foundUser.Id = rd.GetGuid(0);
                    foundUser.Name = rd.GetString(1);
                    foundUser.Allergies = rd.GetString(3);

                }

                await conn.CloseAsync();

                return foundUser;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return foundUser;
            }
        }
    }
}

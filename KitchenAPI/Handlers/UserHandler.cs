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

            //If connection string was created successfully, Insert the Location object into the database
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
            Guid FoundGuid = Guid.Empty; // Standardwert für eine nicht gefundene GUID

            // Erstelle die Verbindung
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    // Erstelle den SQL-Befehl und weise die Stored Procedure zu
                    using (SqlCommand cmd = new SqlCommand("LOGIN_User", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Füge Parameter hinzu
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        // Führe den Befehl aus
                        using (SqlDataReader rd = await cmd.ExecuteReaderAsync())
                        {
                            if (await rd.ReadAsync()) // Überprüfen, ob es eine Zeile gibt
                            {
                                // Lese die GUID, wenn sie vorhanden ist
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
                    // Fehlerprotokollierung
                    Console.WriteLine(ex);
                }
            }

            return FoundGuid;
        }

    }
}

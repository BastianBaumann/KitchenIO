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
                cmd.Parameters.AddWithValue("Description",  newKitchen.Description);

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
        public async Task<Kitchen> getKitchenById(Guid KitchenId)
        {
            Kitchen newKitchen = new Kitchen();

            //try creating the connection string, gives back empty list if fails
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return newKitchen;
            }


            //read all locations in database
            try
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("GETById_Kitchen", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("KitchenId", KitchenId);

                SqlDataReader rd = cmd.ExecuteReader();

                while (await rd.ReadAsync())
                {
                    newKitchen.Id = rd.GetGuid(0);
                    newKitchen.Name = rd.GetString(1);
                    newKitchen.Description = rd.GetString(2);
                }
                //KitchenList.Add(newKitchen);

                await conn.CloseAsync();

                return newKitchen;
            }
            catch (Exception ex)
            {
                //give back list that we have so far in case of an error
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return newKitchen;
            }
        }
        public async Task<List<Binding>> getKitchenBindingByUser(Guid UserId)
        {
            List<Binding> KitchenList = new List<Binding>();

            //try creating the connection string, gives back empty list if fails
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return KitchenList;
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

                    KitchenList.Add(newBinding);
                }

                await conn.CloseAsync();

                return KitchenList;
            }
            catch (Exception ex)
            {
                //give back list that we have so far in case of an error
                Console.WriteLine(ex);
                await conn.CloseAsync();
                return KitchenList;
            }
        }

    }
}

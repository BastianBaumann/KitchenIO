using ClassLibrary.Objects;
using KitchenIO.Objects;
using Microsoft.Data.SqlClient;
using System.Xml.Serialization;

namespace KitchenAPI.Handlers
{
    public class ValidationHandler
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KitchenDB;Integrated Security=True";

        public async Task<List<Product>> GetBadFood(Guid Owner)
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

                    if(newPr.EP < DateTime.Today || newPr.EP == DateTime.Today)
                    {
                        products.Add(newPr);
                    }

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

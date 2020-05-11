using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using VirtualStore.Entities;
using VirtualStore.Interfaces;

namespace VirtualStore.Repositories
{
    public class DigitalStoreRepository : IDigitalStoreRepository
    {
        public async Task<List<Product>> Search(string category)
        {
            List<Product> product = new List<Product>();

            using (SqlConnection sqlConnection = new SqlConnection(Constantes.SQLSERVER))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand("dbo.teste", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@category", category));
                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            product.Add(new Product(
                                reader.GetInt32("id"),
                                reader.GetString("name"),

                                new Category(
                                reader.GetString("category")),

                                new Manufacturer(
                                reader.GetString("manufacturer"),
                                reader.GetDateTime("manufacturingDate")),
                                reader.GetDecimal("price"),
                                reader.GetString("description")));

                        }
                    }
                }
            }
            return (product);
        }
    }
}

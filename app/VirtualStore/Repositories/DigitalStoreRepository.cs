using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using VirtualStore.Entities;
using VirtualStore.Interfaces.Repositories;

namespace VirtualStore.Repositories
{
    public class DigitalStoreRepository : IDigitalStoreRepository
    {
        public async Task<List<Product>> Search(string parameter)
        {
            List<Product> product = new List<Product>();

            using (SqlConnection sqlConnection = new SqlConnection(Constantes.SQLSERVER))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand("dbo.search", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@parameter", parameter));
                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            product.Add(new Product(
                                reader.GetInt64("id"),
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
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return (product);
        }

        public async Task<bool> Insert(string name, string category, string manufacturer, DateTime manufacturingDate, decimal price, string description)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Constantes.SQLSERVER))
                {
                    await sqlConnection.OpenAsync();

                    using (SqlCommand sqlCommand = new SqlCommand("dbo.Insert", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@name", name));
                        sqlCommand.Parameters.Add(new SqlParameter("@category", category));
                        sqlCommand.Parameters.Add(new SqlParameter("@manufacturer", manufacturer));
                        sqlCommand.Parameters.Add(new SqlParameter("@manufacturingDate", manufacturingDate));
                        sqlCommand.Parameters.Add(new SqlParameter("@price", price));
                        sqlCommand.Parameters.Add(new SqlParameter("@description", description));

                        sqlCommand.ExecuteNonQuery();
                    }
                    if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                        sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using XShopAPI.Factory;
using XShopData.Models;

namespace XShopAPI.Services
{
    public class ProductService : IProductService
    {
        private string connectionString;

        public ProductService(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<ProductDetail>> GetProductByCategoryId(int categoryId)
        {
            List<ProductDetail> list = new List<ProductDetail>();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string sql = "product.getProducts";
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection ))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@categoryId", categoryId);
                    using (SqlDataReader reader =  await command.ExecuteReaderAsync())
                    {
                        if(reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                ProductDetail product = new ProductDetail()
                                {
                                    Id = int.Parse(reader[0].ToString()),
                                    Name = reader[1].ToString(),
                                    Sku = reader[2].ToString(),
                                    Description = reader[3].ToString(),
                                    Price = decimal.Parse(reader[4].ToString()),
                                    CategoryId = int.Parse(reader[5].ToString()),
                                };
                                list.Add(product);
                            }
                        }
                        
                    }
                }
            }
            return list;
        }
        

        public async Task InitilProductSetUp()
        {
            // this is just demo purpose when we add Number of items to product,
            // it will handle the range automaticaly using factory
            for(var i=10000; i< 60000; i++)
            {
                int maxItemNumber = await this.GetMaxItemNumber();
                var productFactory = new ProductFactory( "test" + i.ToString(), "test" + i.ToString(), 0,  maxItemNumber);
                await this.AddFeaturedProduct(productFactory.Create());
            }
           
        }

        private  async Task AddFeaturedProduct(ProductDetail detail)
        {
            
           using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string sql = "product.setProducts";
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", detail.Name);
                    command.Parameters.AddWithValue("@description", detail.Description);
                    command.Parameters.AddWithValue("@price", detail.Price);
                    command.Parameters.AddWithValue("@categoryId", detail.CategoryId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        private async Task<int> GetMaxItemNumber()
        {
            string queryString = "select count(id) as num from [product].[productDetail]";
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var x = reader[0].ToString();
                            if (x == "")
                                return 0;
                            else
                                return int.Parse(x);
                            
                        }
                    }
                }
            }
            return 0;
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using XShopData.Models;

namespace XShopAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private string connectionString;

        public CategoryService(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<CategoryDetail>> GetAllCategory()
        {
            List<CategoryDetail> list = new List<CategoryDetail>();
            string queryString = "select detail.id, detail.name from category.categoryDetail as detail";
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            CategoryDetail cat = new CategoryDetail() { Id = int.Parse(reader[0].ToString()), Name = reader[1].ToString() };
                            list.Add(cat);
                        }
                    }
                }
            }
            return list;
        }
    }
}

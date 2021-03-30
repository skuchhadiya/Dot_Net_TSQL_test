using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using XShopData.Models;

namespace TestXShopAPI
{
    public class TestHelper
    {
        private IConfiguration config;
        private string connectionString;

        public TestHelper()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("testAppsettings.json", optional: true)
               .Build();
            this.config = configuration;
            this.connectionString = this.config.GetConnectionString("DefaultConnection");
        }
        public IConfiguration GetConfiguration()
        {

            return this.config;
        }
        public string GetConnectionString()
        {

            return this.connectionString;
        }
        public void ResetProductData()
        {
            this.config = this.GetConfiguration();
            string queryString = "delete from product.productDetail";
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ReSetCategoryData()
        {
            string queryString = "delete from category.categoryDetail";
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SetCategoryData()
        {
            List<CategoryDetail> list = new List<CategoryDetail>() {
                new CategoryDetail() {  Id=1, Name= "Home"},
                new CategoryDetail() {  Id=2, Name= "Garden"},
                new CategoryDetail() {  Id=3, Name= "Electronics"},
                new CategoryDetail() {  Id=4, Name= "Fitness"},
                new CategoryDetail() {  Id=5, Name= "Toys"},
            };
            list.ForEach(x => {
                string queryString = "Insert into category.categoryDetail (id, name) values(" + x.Id + ",'" + x.Name + "')";
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

            });
        }
    }
}

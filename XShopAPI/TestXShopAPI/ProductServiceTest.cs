using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XShopAPI.Services;
using XShopData.Models;

namespace TestXShopAPI
{
    [TestClass]
    public class ProductServiceTest
    {
        private IConfiguration config;
        private IProductService service;
        private string connectionString;
        private TestHelper help;
        public ProductServiceTest()
        {
            help = new TestHelper();
            this.config = help.GetConfiguration();
            this.service = new ProductService(this.config);
            this.connectionString = this.help.GetConnectionString();
        }
        [TestMethod]
        public async Task ShouldNotReturnAnyDataFromProduct()
        {
            this.help.ReSetCategoryData();
            this.ClearDataState();
            this.help.SetCategoryData();
            await this.service.InitilProductSetUp();
            var data = this.service.GetProductByCategoryId(1);
            Assert.AreEqual(10000, data.Result.Count);
            this.ClearDataState();
        }
        
        private void ClearDataState()
        {
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
    }
}

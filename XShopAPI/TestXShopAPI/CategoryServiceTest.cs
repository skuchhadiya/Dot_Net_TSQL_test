using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using XShopAPI.Services;
using XShopData.Models;

namespace TestXShopAPI
{
    [TestClass]
    public class CategoryServiceTest
    {
        private IConfiguration config;
        private ICategoryService service;
        private string connectionString;
        private TestHelper help;
        public CategoryServiceTest()
        {
            help = new TestHelper();
            this.config = help.GetConfiguration();
            this.service = new CategoryService(this.config);
            this.connectionString = this.help.GetConnectionString();
        }
        [TestMethod]
        public async Task ShouldNotReturnAnyData()
        {
            var data = await this.service.GetAllCategory();
            Assert.AreEqual(0, data.Count);
        }
        [TestMethod]
        public async Task ShouldGetData()
        {
            this.help.ReSetCategoryData();
            this.help.SetCategoryData();
            var data = await this.service.GetAllCategory();
            Assert.AreEqual(5, data.Count);
            this.help.ReSetCategoryData();
        }
        
    }
}

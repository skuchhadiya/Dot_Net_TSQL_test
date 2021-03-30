using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XShopAPI.Services;

namespace XShopAPI.Controllers
{
    [ApiController, Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }
        [HttpGet("{categoryId}")]
        public async Task<ActionResult> Get(int categoryId)
        {
            try
            {
                var data = await this.service.GetProductByCategoryId(categoryId);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception)
            {
                throw new Exception("Unable to get Product details, Please try again");
            }
        }
        [HttpGet("InitialiseReleaseData")]
        public async Task<ActionResult> GetInitialiseReleaseData()
        {
            try
            {
                await this.service.InitilProductSetUp();
                return Ok();
            }
            catch (Exception)
            {
                throw new Exception("Unable to set release products data, Please try again");
            }
        }
    }
}

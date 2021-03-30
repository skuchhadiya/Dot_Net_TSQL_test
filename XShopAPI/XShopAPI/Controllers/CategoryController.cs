using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XShopAPI.Services;

namespace XShopAPI.Controllers
{
    [ApiController, Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await this.service.GetAllCategory();
                if(data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch(Exception)
            {
               throw new Exception("Unable to get Category, Please try again");
            }
            
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using XShopData.Models;

namespace XShopAPI.Services
{
    public interface IProductService
    {
        Task<List<ProductDetail>> GetProductByCategoryId(int categoryId);
        Task InitilProductSetUp();

    }
}
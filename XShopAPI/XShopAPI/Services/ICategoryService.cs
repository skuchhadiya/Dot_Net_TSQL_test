using System.Collections.Generic;
using System.Threading.Tasks;
using XShopData.Models;

namespace XShopAPI.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDetail>> GetAllCategory();
    }
}
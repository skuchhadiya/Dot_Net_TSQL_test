using System.Threading.Tasks;
using XShopAPI.Enums;
using XShopData.Models;

namespace XShopAPI.Factory
{
    public class ProductFactory
    {
        private readonly string name;
        private readonly string description;
        private readonly decimal price;
        private int maxProductNumber;

        public ProductFactory(string name, string description, decimal price, int maxProductNumber)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.maxProductNumber = maxProductNumber;
        }
        public ProductDetail Create()
        {
           
            ProductDetail productDetail = new ProductDetail();
            productDetail.Name = this.name;
            productDetail.Description = this.description;
            productDetail.Price = this.price;
            productDetail.CategoryId = (int) this.GetCategory();
            return productDetail;
            

        }
        private Category GetCategory()
        {
            // To Crete a batch fro specific category 
            this.maxProductNumber = this.maxProductNumber + 10000;
            if (this.maxProductNumber > 9999 && this.maxProductNumber <= 19999)
                return Category.Home;
            if (this.maxProductNumber > 19999 && this.maxProductNumber <= 29999)
                return Category.Garden;
            else if (this.maxProductNumber > 29999 && this.maxProductNumber <= 39999)
                return Category.Electronics;
            else if (this.maxProductNumber > 39999 && this.maxProductNumber <= 49999)
                return Category.Fitness;
            else
                return Category.Toys;

        }
    }
}

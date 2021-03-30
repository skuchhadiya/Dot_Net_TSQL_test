using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using XShopData.Models;

namespace ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("MMTShop");
            var categoryData = await getData<List<CategoryDetail>>("https://localhost:44399/category");
            Console.WriteLine("ID,  Name:");
            categoryData.ForEach(x =>
            {
                // Console.WriteLine("ID :" + x.Id.ToString() + ", Name:" + x.Name);
                Console.WriteLine( x.Id.ToString() + " , " + x.Name);
            });
            Console.Write("\nPlease enter catogory Id to get product list : ");
            string key = Console.ReadLine();
            
            var productData = await getData<List<ProductDetail>>("https://localhost:44399/product/" + key[0]);
            Console.WriteLine("Product List");
            productData.ForEach(x =>
            {
                Console.WriteLine(" Name : " + x.Name + ", price: " + x.Price + "GBP");
            });

        }
        private static async Task<T> getData<T>(string url)
        {
            using (var client = new HttpClient()) //WebClient  
            {
                var result = await  client.GetStringAsync(url); //URI  
                var obj = JsonConvert.DeserializeObject<T>(result);
                return obj;
            }
        }
    }
}

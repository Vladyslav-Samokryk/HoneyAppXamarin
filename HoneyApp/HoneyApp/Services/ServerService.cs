using HoneyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HoneyApp.Services
{
    public interface IServerService
    {
        Task<Product> GetProduct();
        Task<IEnumerable<Product>> GetProducts();
        Task<byte[]> GetPhoto(int id);
        Task<int> NewOrder(Bill bill);
        Task<IEnumerable<Product>> GetBasketProducts(IEnumerable<BasketWare> wares);
        Task<Dictionary<int,Bill>> GetBills();
    }
    public class ServerService : IServerService
    {
        
        private const string URL = "http://192.168.1.249:5000/";
      
       
        private readonly ICommunicationService http;
        public ServerService()
        {
            http = new CommunicationService();
        }
        public async Task<IEnumerable<Product>> GetBasketProducts(IEnumerable<BasketWare> wares)
        {
            string json = JsonConvert.SerializeObject(wares.Select(x => x.Id));
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");            

            var result = await http.PostAsObjectAsync<IEnumerable<Product>>(URL+"WeatherForecast/orderWares", content);

            return result;
        }
        public async Task<Product> GetProduct()
        {
          return await  http.GetAsObjectAsync<Product>(URL+"WeatherForecast/GetRecomendWare");
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await http.GetAsObjectAsync<IEnumerable<Product>>(URL+"WeatherForecast/GetWares");
        }

        public async Task<Dictionary<int, Bill>> GetBills()
        {
            return await http.GetAsObjectAsync<Dictionary<int, Bill>>(URL + "WeatherForecast/GetBills");
        }
        public async Task<IEnumerable<Product>> GetProductsByIds(IEnumerable<int> id)
        {
            return await http.GetAsObjectAsync<IEnumerable<Product>>(URL+"WeatherForecast/GetWares");
        }

        public async Task<byte[]> GetPhoto(int id)
        {
            return await http.GetAsObjectAsync<byte[]>(URL+ $"WeatherForecast/image?id={id}");
        }

        public async Task<int> NewOrder(Bill bill)
        {
            string json = JsonConvert.SerializeObject(bill);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var result = await http.PostAsObjectAsync<int>(URL + "WeatherForecast/newOrder", content);

            return result;
           
        }
    }
}

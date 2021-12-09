using HoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyApp.Services
{
    public class MockDataStore : IDataStore<Product>
    {
        readonly List<Product> products;

        public MockDataStore()
        {
            
        }

        public async Task<bool> AddItemAsync(Product item)
        {
           
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Product item)
        {
            
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
          
            return await Task.FromResult(true);
        }

        public async Task<Product> GetItemAsync(int id)
        {
            return await App.ServerService.GetProduct();
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(bool forceRefresh = false)
        {
            return await  App.ServerService.GetProducts();
        }
        public async Task<IEnumerable<Product>> GetBasketItemsAsync(IEnumerable<BasketWare> wares)
        {
            return await App.ServerService.GetBasketProducts(wares);
        }
    }
}
using HoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HoneyApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<T>> GetBasketItemsAsync(IEnumerable<BasketWare> wares);

    }
}

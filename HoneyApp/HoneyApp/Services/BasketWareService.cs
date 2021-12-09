using HoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoneyApp.Services
{
    public class BasketWareService : IBasketService
    {
        public string Title => "Мій кошик";
        private List<BasketWare> _wares = new List<BasketWare>();
       
        public void AddWare(int id)
        {
            _wares.Add(new BasketWare() { Id = id });
        }
        
        public IEnumerable<BasketWare> GetWares()
        {
            return _wares;
        }

        public void IncriceCount(int id, int up)
        {
            _wares.First(x => x.Id == id).Count += up;
        }

        public bool IsInBasket(int id)
        {
           return _wares.Select(x => x.Id).Contains(id);
        }

        public void SetWares(IEnumerable<BasketWare> wares)
        {
            _wares.Clear();

            foreach (var ware in wares)            
                _wares.Add(ware);            
        }

        public void ClearBasket()
        {
            _wares.Clear();
        }
    }
}

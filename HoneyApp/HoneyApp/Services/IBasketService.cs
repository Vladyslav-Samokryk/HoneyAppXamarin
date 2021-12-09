using HoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyApp.Services
{
    public interface IBasketService
    {
        IEnumerable<BasketWare> GetWares();

        void SetWares(IEnumerable<BasketWare> wares);

        void ClearBasket();

        void AddWare(int id);

        bool IsInBasket(int id);

        void IncriceCount(int id, int up);
    }
}
